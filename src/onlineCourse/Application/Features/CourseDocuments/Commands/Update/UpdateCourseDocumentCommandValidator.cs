using FluentValidation;

namespace Application.Features.CourseDocuments.Commands.Update;

public class UpdateCourseDocumentCommandValidator : AbstractValidator<UpdateCourseDocumentCommand>
{
    public UpdateCourseDocumentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FileName).NotEmpty();
        RuleFor(c => c.FileExtension).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.FileSize).NotEmpty();
        RuleFor(c => c.CourseContentId).NotEmpty();
    }
}