using FluentValidation;

namespace Application.Features.CourseDocuments.Commands.Delete;

public class DeleteCourseDocumentCommandValidator : AbstractValidator<DeleteCourseDocumentCommand>
{
    public DeleteCourseDocumentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}