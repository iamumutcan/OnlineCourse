using FluentValidation;

namespace Application.Features.CourseDocuments.Commands.Create;

public class CreateCourseDocumentCommandValidator : AbstractValidator<CreateCourseDocumentCommand>
{
    public CreateCourseDocumentCommandValidator()
    {
        RuleFor(c => c.FileName).NotEmpty();
        RuleFor(c => c.FileExtension).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.FileSize).NotEmpty();
        RuleFor(c => c.CourseContentId).NotEmpty();
    }
}