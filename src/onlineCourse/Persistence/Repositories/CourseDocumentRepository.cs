using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseDocumentRepository : EfRepositoryBase<CourseDocument, Guid, BaseDbContext>, ICourseDocumentRepository
{
    public CourseDocumentRepository(BaseDbContext context) : base(context)
    {
    }
}