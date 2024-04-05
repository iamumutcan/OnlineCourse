using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CourseContents.Queries.GetList;

public class GetListCourseContentListItemDto : IDto
{
    public Guid Id { get; set; }
    public int SortNumber { get; set; }
    public string Summary { get; set; }
    public Guid CourseId { get; set; }
}