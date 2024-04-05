using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserCourses.Commands.Create;

public class CreatedUserCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public Boolean Confirmation { get; set; }
}