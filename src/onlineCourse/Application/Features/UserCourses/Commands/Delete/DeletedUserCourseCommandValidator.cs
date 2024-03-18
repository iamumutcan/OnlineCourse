using FluentValidation;

namespace Application.Features.UserCourses.Commands.Delete;

public class DeleteUserCourseCommandValidator : AbstractValidator<DeleteUserCourseCommand>
{
    public DeleteUserCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}