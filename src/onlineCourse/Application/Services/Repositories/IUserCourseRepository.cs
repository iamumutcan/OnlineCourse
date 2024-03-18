using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserCourseRepository : IAsyncRepository<UserCourse, Guid>, IRepository<UserCourse, Guid>
{
}