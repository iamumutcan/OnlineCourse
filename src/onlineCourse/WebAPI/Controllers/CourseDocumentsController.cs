using Application.Features.CourseDocuments.Commands.Create;
using Application.Features.CourseDocuments.Commands.Delete;
using Application.Features.CourseDocuments.Commands.Update;
using Application.Features.CourseDocuments.Queries.GetById;
using Application.Features.CourseDocuments.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseDocumentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCourseDocumentCommand createCourseDocumentCommand)
    {
        CreatedCourseDocumentResponse response = await Mediator.Send(createCourseDocumentCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCourseDocumentCommand updateCourseDocumentCommand)
    {
        UpdatedCourseDocumentResponse response = await Mediator.Send(updateCourseDocumentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCourseDocumentResponse response = await Mediator.Send(new DeleteCourseDocumentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCourseDocumentResponse response = await Mediator.Send(new GetByIdCourseDocumentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseDocumentQuery getListCourseDocumentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCourseDocumentListItemDto> response = await Mediator.Send(getListCourseDocumentQuery);
        return Ok(response);
    }
}