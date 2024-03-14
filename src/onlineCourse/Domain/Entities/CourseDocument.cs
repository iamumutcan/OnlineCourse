using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class CourseDocument : Entity<Guid>
{
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public  ContentType Type { get; set; }
    public int Duration { get; set; }
    public double FileSize { get; set; }
    public Guid CourseContentId { get; set; }
    [JsonIgnore]
    public virtual CourseContent CourseContent { get; set; }

}
