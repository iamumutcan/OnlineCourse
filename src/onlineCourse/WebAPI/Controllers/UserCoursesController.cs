using Application.Features.UserCourses.Commands.Create;
using Application.Features.UserCourses.Commands.Delete;
using Application.Features.UserCourses.Commands.Update;
using Application.Features.UserCourses.Queries.GetById;
using Application.Features.UserCourses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserCoursesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserCourseResponse>> Add([FromBody] CreateUserCourseCommand command)
    {
        CreatedUserCourseResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserCourseResponse>> Update([FromBody] UpdateUserCourseCommand command)
    {
        UpdatedUserCourseResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserCourseResponse>> Delete([FromRoute] Guid id)
    {
        DeleteUserCourseCommand command = new() { Id = id };

        DeletedUserCourseResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserCourseResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdUserCourseQuery query = new() { Id = id };

        GetByIdUserCourseResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListUserCourseQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserCourseQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserCourseListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}