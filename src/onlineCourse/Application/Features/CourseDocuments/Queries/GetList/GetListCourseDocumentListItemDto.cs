using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.CourseDocuments.Queries.GetList;

public class GetListCourseDocumentListItemDto : IDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public ContentType Type { get; set; }
    public int Duration { get; set; }
    public double FileSize { get; set; }
    public Guid CourseContentId { get; set; }
}