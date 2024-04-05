using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Courses.Commands.Create;

public class CreatedCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int SortNumber { get; set; }
    public CourseStatus Status { get; set; }
    public Guid CategoryId { get; set; }
}