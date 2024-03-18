using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserCourses.Commands.Update;

public class UpdatedUserCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
}