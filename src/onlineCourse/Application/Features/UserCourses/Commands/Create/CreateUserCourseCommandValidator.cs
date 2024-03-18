using FluentValidation;

namespace Application.Features.UserCourses.Commands.Create;

public class CreateUserCourseCommandValidator : AbstractValidator<CreateUserCourseCommand>
{
    public CreateUserCourseCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
    }
}