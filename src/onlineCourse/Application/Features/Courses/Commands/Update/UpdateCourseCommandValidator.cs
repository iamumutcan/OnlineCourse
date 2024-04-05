using FluentValidation;

namespace Application.Features.Courses.Commands.Update;

public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
{
    public UpdateCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.SortNumber).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}