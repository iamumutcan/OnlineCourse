using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserCourseRepository : EfRepositoryBase<UserCourse, Guid, BaseDbContext>, IUserCourseRepository
{
    public UserCourseRepository(BaseDbContext context) : base(context)
    {
    }
}