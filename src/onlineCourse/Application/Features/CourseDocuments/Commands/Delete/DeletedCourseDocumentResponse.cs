using NArchitecture.Core.Application.Responses;

namespace Application.Features.CourseDocuments.Commands.Delete;

public class DeletedCourseDocumentResponse : IResponse
{
    public Guid Id { get; set; }
}