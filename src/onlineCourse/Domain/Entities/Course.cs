using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System.Text.Json.Serialization;

namespace Domain.Entities;
public class Course : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int SortNumber { get; set; }
    public CourseStatus Status { get; set; }
    public Guid CategoryId { get; set; }

    [JsonIgnore]
    public virtual Category Category { get; set; }
    public virtual ICollection<CourseContent> CourseContents { get; set; }

}
