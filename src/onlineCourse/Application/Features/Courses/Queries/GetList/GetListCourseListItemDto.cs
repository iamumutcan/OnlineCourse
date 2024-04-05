using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.Courses.Queries.GetList;

public class GetListCourseListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int SortNumber { get; set; }
    public CourseStatus Status { get; set; }
    public Guid CategoryId { get; set; }
}