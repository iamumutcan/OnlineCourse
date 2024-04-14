using Application.Features.CourseDocuments.Commands.Create;
using Application.Features.CourseDocuments.Commands.Delete;
using Application.Features.CourseDocuments.Commands.Update;
using Application.Features.CourseDocuments.Queries.GetById;
using Application.Features.CourseDocuments.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Adapters.FileService;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseDocumentsController : BaseController
{
    [HttpPost("UploadFile")]
    public IActionResult UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File is null or empty");
        }

        var uploadHandler = new UploadHandler();
        var result = uploadHandler.Upload(file);

        if (!string.IsNullOrEmpty(result.Error))
        {
            return BadRequest(result.Error);
        }

        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<CreatedCourseDocumentResponse>> Add([FromBody] CreateCourseDocumentCommand command)
    {
        CreatedCourseDocumentResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCourseDocumentResponse>> Update([FromBody] UpdateCourseDocumentCommand command)
    {
        UpdatedCourseDocumentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCourseDocumentResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCourseDocumentCommand command = new() { Id = id };

        DeletedCourseDocumentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCourseDocumentResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCourseDocumentQuery query = new() { Id = id };

        GetByIdCourseDocumentResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListCourseDocumentQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseDocumentQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCourseDocumentListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}