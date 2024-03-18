using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Courses.Constants;
using Application.Features.CourseContents.Constants;
using Application.Features.CourseDocuments.Constants;
using Application.Features.UserCourses.Constants;





namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Courses
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CoursesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CoursesOperationClaims.Read },
                new() { Id = ++lastId, Name = CoursesOperationClaims.Write },
                new() { Id = ++lastId, Name = CoursesOperationClaims.Create },
                new() { Id = ++lastId, Name = CoursesOperationClaims.Update },
                new() { Id = ++lastId, Name = CoursesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CourseContents
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CourseContentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CourseContentsOperationClaims.Read },
                new() { Id = ++lastId, Name = CourseContentsOperationClaims.Write },
                new() { Id = ++lastId, Name = CourseContentsOperationClaims.Create },
                new() { Id = ++lastId, Name = CourseContentsOperationClaims.Update },
                new() { Id = ++lastId, Name = CourseContentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CourseDocuments
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CourseDocumentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CourseDocumentsOperationClaims.Read },
                new() { Id = ++lastId, Name = CourseDocumentsOperationClaims.Write },
                new() { Id = ++lastId, Name = CourseDocumentsOperationClaims.Create },
                new() { Id = ++lastId, Name = CourseDocumentsOperationClaims.Update },
                new() { Id = ++lastId, Name = CourseDocumentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UserCourses
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserCoursesOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserCoursesOperationClaims.Read },
                new() { Id = ++lastId, Name = UserCoursesOperationClaims.Write },
                new() { Id = ++lastId, Name = UserCoursesOperationClaims.Create },
                new() { Id = ++lastId, Name = UserCoursesOperationClaims.Update },
                new() { Id = ++lastId, Name = UserCoursesOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
