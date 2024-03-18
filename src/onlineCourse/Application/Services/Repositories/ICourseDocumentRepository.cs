using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICourseDocumentRepository : IAsyncRepository<CourseDocument, Guid>, IRepository<CourseDocument, Guid>
{
}