using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Instructors.Queries.GetById;

public class GetByIdInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Bio { get; set; }
    public InstructorStatus InstructorStatus { get; set; }
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
}