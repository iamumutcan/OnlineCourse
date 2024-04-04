using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class UserCourse : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public Boolean Confirmation {  get; set; }
    public virtual ICollection<Course> Courses { get; set; }
    public virtual ICollection<User> Users { get; set; }

}