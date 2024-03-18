using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICourseContentRepository : IAsyncRepository<CourseContent, Guid>, IRepository<CourseContent, Guid>
{
}