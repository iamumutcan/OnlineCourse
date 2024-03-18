using FluentValidation;

namespace Application.Features.UserCourses.Commands.Update;

public class UpdateUserCourseCommandValidator : AbstractValidator<UpdateUserCourseCommand>
{
    public UpdateUserCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
    }
}