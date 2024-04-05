using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseDocuments;

public interface ICourseDocumentService
{
    Task<CourseDocument?> GetAsync(
        Expression<Func<CourseDocument, bool>> predicate,
        Func<IQueryable<CourseDocument>, IIncludableQueryable<CourseDocument, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CourseDocument>?> GetListAsync(
        Expression<Func<CourseDocument, bool>>? predicate = null,
        Func<IQueryable<CourseDocument>, IOrderedQueryable<CourseDocument>>? orderBy = null,
        Func<IQueryable<CourseDocument>, IIncludableQueryable<CourseDocument, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CourseDocument> AddAsync(CourseDocument courseDocument);
    Task<CourseDocument> UpdateAsync(CourseDocument courseDocument);
    Task<CourseDocument> DeleteAsync(CourseDocument courseDocument, bool permanent = false);
}
