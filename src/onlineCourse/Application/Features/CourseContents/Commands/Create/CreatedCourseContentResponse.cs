using NArchitecture.Core.Application.Responses;

namespace Application.Features.CourseContents.Commands.Create;

public class CreatedCourseContentResponse : IResponse
{
    public Guid Id { get; set; }
    public string Summary { get; set; }
    public Guid CourseId { get; set; }
}