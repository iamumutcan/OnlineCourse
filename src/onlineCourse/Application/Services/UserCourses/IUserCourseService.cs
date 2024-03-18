using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;
using System.Linq.Expressions;

namespace Application.Services.UserCourses;

public interface IUserCourseService
{
    Task<UserCourse?> GetAsync(
        Expression<Func<UserCourse, bool>> predicate,
        Func<IQueryable<UserCourse>, IIncludableQueryable<UserCourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserCourse>?> GetListAsync(
        Expression<Func<UserCourse, bool>>? predicate = null,
        Func<IQueryable<UserCourse>, IOrderedQueryable<UserCourse>>? orderBy = null,
        Func<IQueryable<UserCourse>, IIncludableQueryable<UserCourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserCourse> AddAsync(UserCourse userCourse);
    Task<UserCourse> UpdateAsync(UserCourse userCourse);
    Task<UserCourse> DeleteAsync(UserCourse userCourse, bool permanent = false);
}
