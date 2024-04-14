using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
{
    public void Configure(EntityTypeBuilder<UserCourse> builder)
    {
        builder.ToTable("UserCourses").HasKey(uc => uc.Id);

        builder.Property(uc => uc.Id).HasColumnName("Id").IsRequired();
        builder.Property(uc => uc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uc => uc.CourseId).HasColumnName("CourseId").IsRequired();
        builder.Property(uc => uc.Confirmation).HasColumnName("Confirmation").IsRequired();
        builder.Property(uc => uc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uc => uc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uc => uc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(uc => !uc.DeletedDate.HasValue);
    }
}