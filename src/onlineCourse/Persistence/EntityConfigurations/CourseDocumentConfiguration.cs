using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseDocumentConfiguration : IEntityTypeConfiguration<CourseDocument>
{
    public void Configure(EntityTypeBuilder<CourseDocument> builder)
    {
        builder.ToTable("CourseDocuments").HasKey(cd => cd.Id);

        builder.Property(cd => cd.Id).HasColumnName("Id").IsRequired();
        builder.Property(cd => cd.FileName).HasColumnName("FileName").IsRequired();
        builder.Property(cd => cd.FileExtension).HasColumnName("FileExtension").IsRequired();
        builder.Property(cd => cd.Type).HasColumnName("Type").IsRequired();
        builder.Property(cd => cd.Duration).HasColumnName("Duration").IsRequired();
        builder.Property(cd => cd.FileSize).HasColumnName("FileSize").IsRequired();
        builder.Property(cd => cd.CourseContentId).HasColumnName("CourseContentId").IsRequired();
        builder.Property(cd => cd.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cd => cd.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cd => cd.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cd => !cd.DeletedDate.HasValue);
    }
}