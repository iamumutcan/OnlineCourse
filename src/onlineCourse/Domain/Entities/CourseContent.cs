using NArchitecture.Core.Persistence.Repositories;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class CourseContent : Entity<Guid>
{
    public string Summary { get; set; }
    public Guid CourseId { get; set; }
    [JsonIgnore]
    public virtual Course Course { get; set; }
    public virtual ICollection<CourseDocument> CourseDocuments { get; set; }
}
