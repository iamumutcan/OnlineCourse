using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.CourseDocuments.Queries.GetById;

public class GetByIdCourseDocumentResponse : IResponse
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public ContentType Type { get; set; }
    public int Duration { get; set; }
    public double FileSize { get; set; }
    public Guid CourseContentId { get; set; }
}