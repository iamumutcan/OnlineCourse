using FluentValidation;

namespace Application.Features.CourseContents.Commands.Create;

public class CreateCourseContentCommandValidator : AbstractValidator<CreateCourseContentCommand>
{
    public CreateCourseContentCommandValidator()
    {
        RuleFor(c => c.Summary).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
    }
}