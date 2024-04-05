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
    public async Task<IActionResult> Add([FromBody] CreateUserCourseCommand createUserCourseCommand)
    {
        CreatedUserCourseResponse response = await Mediator.Send(createUserCourseCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCourseCommand updateUserCourseCommand)
    {
        UpdatedUserCourseResponse response = await Mediator.Send(updateUserCourseCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedUserCourseResponse response = await Mediator.Send(new DeleteUserCourseCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserCourseResponse response = await Mediator.Send(new GetByIdUserCourseQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserCourseQuery getListUserCourseQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserCourseListItemDto> response = await Mediator.Send(getListUserCourseQuery);
        return Ok(response);
    }
}