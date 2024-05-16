using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Commands.Delete;
using Application.Features.Courses.Commands.Update;
using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCourseResponse>> Add([FromBody] CreateCourseCommand command)
        {
        CreatedCourseResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCourseResponse>> Update([FromBody] UpdateCourseCommand command)
    {
        UpdatedCourseResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCourseResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCourseCommand command = new() { Id = id };

        DeletedCourseResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCourseResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCourseQuery query = new() { Id = id };

        GetByIdCourseResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListCourseQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCourseListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}