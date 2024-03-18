using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserCourses.Queries.GetList;

public class GetListUserCourseListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
}