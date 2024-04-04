using FluentValidation;

namespace Application.Features.Instructors.Commands.Create;

public class CreateInstructorCommandValidator : AbstractValidator<CreateInstructorCommand>
{
    public CreateInstructorCommandValidator()
    {
        RuleFor(c => c.Bio).NotEmpty();
        RuleFor(c => c.InstructorStatus).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
    }
}