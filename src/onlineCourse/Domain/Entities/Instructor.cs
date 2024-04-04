using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Instructor:Entity<Guid>
{
    public string Bio { get; set; }
    public InstructorStatus InstructorStatus { get; set; }
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Course> Courses { get; set; }

}
