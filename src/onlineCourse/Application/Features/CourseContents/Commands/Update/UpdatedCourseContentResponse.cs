using NArchitecture.Core.Application.Responses;

namespace Application.Features.CourseContents.Commands.Update;

public class UpdatedCourseContentResponse : IResponse
{
    public Guid Id { get; set; }
    public int SortNumber { get; set; }
    public string Summary { get; set; }
    public Guid CourseId { get; set; }
}