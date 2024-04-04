using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseContent> CourseContents { get; set; }
    public DbSet<CourseDocument> CourseDocuments { get; set; }
    public DbSet<UserCourse> UserCourses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Instructor> Instructors { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Course>().Property(c => c.SortNumber).HasDefaultValue(10);
        modelBuilder.Entity<CourseContent>().Property(c => c.SortNumber).HasDefaultValue(10);
        modelBuilder.Entity<Course>().Property(c => c.Status).HasDefaultValue(CourseStatus.WaitingForApproval);
        modelBuilder.Entity<Instructor>().Property(c => c.InstructorStatus).HasDefaultValue(InstructorStatus.WaitingForApproval);
        modelBuilder.Entity<UserCourse>().Property(c => c.Confirmation).HasDefaultValue(UserCourseStatus.WaitingForApproval);

    }


}
