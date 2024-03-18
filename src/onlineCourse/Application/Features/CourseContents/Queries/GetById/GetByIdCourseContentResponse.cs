using NArchitecture.Core.Application.Responses;

namespace Application.Features.CourseContents.Queries.GetById;

public class GetByIdCourseContentResponse : IResponse
{
    public Guid Id { get; set; }
    public string Summary { get; set; }
    public Guid CourseId { get; set; }
}