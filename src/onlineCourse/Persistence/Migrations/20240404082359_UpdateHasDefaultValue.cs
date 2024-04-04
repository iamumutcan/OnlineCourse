using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHasDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ad134abe-4304-4c8b-ad05-7a957cf598d0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6df97c97-a9b0-416f-8f79-079e1992f5fb"));

            migrationBuilder.AddColumn<bool>(
                name: "Confirmation",
                table: "UserCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "InstructorStatus",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SortNumber",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 10,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SortNumber",
                table: "CourseContents",
                type: "int",
                nullable: false,
                defaultValue: 10,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserCourseId" },
                values: new object[] { new Guid("2513f241-a0d8-4976-b1bc-630f0dfb90d1"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 211, 151, 154, 69, 10, 210, 85, 226, 6, 196, 232, 197, 100, 31, 86, 199, 74, 33, 138, 160, 15, 1, 150, 147, 177, 47, 69, 58, 179, 54, 193, 115, 225, 168, 140, 161, 98, 48, 0, 74, 56, 79, 101, 68, 23, 14, 102, 24, 58, 197, 84, 201, 137, 130, 85, 86, 21, 52, 77, 44, 248, 99, 49, 98 }, new byte[] { 58, 80, 10, 36, 139, 120, 179, 161, 190, 5, 87, 160, 74, 116, 225, 252, 34, 104, 129, 239, 71, 0, 160, 25, 213, 20, 150, 58, 177, 38, 157, 167, 193, 99, 151, 31, 106, 220, 18, 179, 116, 209, 70, 31, 102, 7, 170, 10, 70, 180, 57, 73, 117, 184, 254, 244, 224, 79, 81, 226, 192, 32, 62, 68, 71, 105, 53, 182, 175, 230, 221, 119, 238, 223, 84, 72, 157, 123, 15, 230, 116, 251, 169, 55, 240, 43, 236, 254, 12, 50, 9, 116, 18, 28, 111, 69, 187, 235, 87, 229, 27, 20, 29, 43, 210, 247, 208, 243, 130, 184, 252, 21, 123, 74, 66, 224, 91, 74, 44, 237, 59, 149, 40, 118, 155, 134, 59, 105 }, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a619554d-2e1d-4e6e-acd9-ed76d5de6a97"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("2513f241-a0d8-4976-b1bc-630f0dfb90d1") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a619554d-2e1d-4e6e-acd9-ed76d5de6a97"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2513f241-a0d8-4976-b1bc-630f0dfb90d1"));

            migrationBuilder.DropColumn(
                name: "Confirmation",
                table: "UserCourses");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorStatus",
                table: "Instructors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SortNumber",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 10);

            migrationBuilder.AlterColumn<int>(
                name: "SortNumber",
                table: "CourseContents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 10);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserCourseId" },
                values: new object[] { new Guid("6df97c97-a9b0-416f-8f79-079e1992f5fb"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 214, 89, 90, 36, 35, 142, 170, 137, 68, 193, 240, 71, 45, 192, 54, 22, 150, 22, 19, 167, 48, 2, 251, 113, 226, 10, 100, 8, 74, 155, 158, 152, 104, 102, 98, 50, 190, 22, 22, 105, 203, 243, 16, 111, 208, 143, 87, 114, 234, 242, 185, 177, 248, 35, 254, 73, 129, 102, 70, 101, 91, 123, 190, 134 }, new byte[] { 169, 17, 42, 79, 137, 103, 250, 180, 181, 163, 98, 219, 105, 57, 1, 37, 239, 40, 134, 93, 199, 57, 76, 13, 82, 115, 53, 187, 206, 49, 45, 176, 180, 40, 91, 9, 8, 58, 135, 213, 245, 182, 233, 18, 152, 253, 127, 53, 210, 198, 254, 84, 176, 216, 217, 171, 172, 75, 172, 195, 27, 136, 189, 25, 23, 213, 69, 41, 18, 132, 172, 147, 225, 62, 87, 120, 186, 173, 76, 150, 237, 246, 163, 9, 82, 207, 249, 194, 157, 7, 221, 252, 196, 76, 20, 17, 194, 89, 29, 171, 58, 27, 210, 28, 205, 23, 237, 148, 83, 118, 210, 130, 226, 193, 149, 161, 47, 140, 186, 23, 48, 117, 145, 180, 56, 67, 251, 82 }, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("ad134abe-4304-4c8b-ad05-7a957cf598d0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6df97c97-a9b0-416f-8f79-079e1992f5fb") });
        }
    }
}
