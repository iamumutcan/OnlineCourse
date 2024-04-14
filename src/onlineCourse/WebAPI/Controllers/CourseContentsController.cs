using Application.Features.CourseContents.Commands.Create;
using Application.Features.CourseContents.Commands.Delete;
using Application.Features.CourseContents.Commands.Update;
using Application.Features.CourseContents.Queries.GetById;
using Application.Features.CourseContents.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseContentsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCourseContentResponse>> Add([FromBody] CreateCourseContentCommand command)
    {
        CreatedCourseContentResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCourseContentResponse>> Update([FromBody] UpdateCourseContentCommand command)
    {
        UpdatedCourseContentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCourseContentResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCourseContentCommand command = new() { Id = id };

        DeletedCourseContentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCourseContentResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCourseContentQuery query = new() { Id = id };

        GetByIdCourseContentResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListCourseContentQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseContentQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCourseContentListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}