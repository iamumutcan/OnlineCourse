using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.Instructors.Queries.GetList;

public class GetListInstructorListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Bio { get; set; }
    public InstructorStatus InstructorStatus { get; set; }
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
}