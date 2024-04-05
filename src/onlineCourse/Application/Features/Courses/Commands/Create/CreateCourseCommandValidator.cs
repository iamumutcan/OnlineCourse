using FluentValidation;

namespace Application.Features.Courses.Commands.Create;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.SortNumber).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}