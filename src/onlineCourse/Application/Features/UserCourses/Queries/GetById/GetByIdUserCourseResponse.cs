using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserCourses.Queries.GetById;

public class GetByIdUserCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
}