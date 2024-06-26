using FluentValidation;

namespace Application.Features.Instructors.Commands.Update;

public class UpdateInstructorCommandValidator : AbstractValidator<UpdateInstructorCommand>
{
    public UpdateInstructorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Bio).NotEmpty();
        RuleFor(c => c.InstructorStatus).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
    }
}