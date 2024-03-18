using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserCourses.Commands.Delete;

public class DeletedUserCourseResponse : IResponse
{
    public Guid Id { get; set; }
}