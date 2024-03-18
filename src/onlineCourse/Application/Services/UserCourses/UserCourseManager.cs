using Application.Features.UserCourses.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;
using System.Linq.Expressions;

namespace Application.Services.UserCourses;

public class UserCourseManager : IUserCourseService
{
    private readonly IUserCourseRepository _userCourseRepository;
    private readonly UserCourseBusinessRules _userCourseBusinessRules;

    public UserCourseManager(IUserCourseRepository userCourseRepository, UserCourseBusinessRules userCourseBusinessRules)
    {
        _userCourseRepository = userCourseRepository;
        _userCourseBusinessRules = userCourseBusinessRules;
    }

    public async Task<UserCourse?> GetAsync(
        Expression<Func<UserCourse, bool>> predicate,
        Func<IQueryable<UserCourse>, IIncludableQueryable<UserCourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserCourse? userCourse = await _userCourseRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userCourse;
    }

    public async Task<IPaginate<UserCourse>?> GetListAsync(
        Expression<Func<UserCourse, bool>>? predicate = null,
        Func<IQueryable<UserCourse>, IOrderedQueryable<UserCourse>>? orderBy = null,
        Func<IQueryable<UserCourse>, IIncludableQueryable<UserCourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserCourse> userCourseList = await _userCourseRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userCourseList;
    }

    public async Task<UserCourse> AddAsync(UserCourse userCourse)
    {
        UserCourse addedUserCourse = await _userCourseRepository.AddAsync(userCourse);

        return addedUserCourse;
    }

    public async Task<UserCourse> UpdateAsync(UserCourse userCourse)
    {
        UserCourse updatedUserCourse = await _userCourseRepository.UpdateAsync(userCourse);

        return updatedUserCourse;
    }

    public async Task<UserCourse> DeleteAsync(UserCourse userCourse, bool permanent = false)
    {
        UserCourse deletedUserCourse = await _userCourseRepository.DeleteAsync(userCourse);

        return deletedUserCourse;
    }
}
