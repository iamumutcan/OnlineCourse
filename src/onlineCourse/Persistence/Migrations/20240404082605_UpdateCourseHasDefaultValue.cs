using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCourseHasDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a619554d-2e1d-4e6e-acd9-ed76d5de6a97"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2513f241-a0d8-4976-b1bc-630f0dfb90d1"));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserCourseId" },
                values: new object[] { new Guid("f057f611-2748-44ca-8e31-1b9d6a230b4b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 251, 80, 165, 133, 186, 220, 176, 118, 103, 119, 105, 205, 151, 37, 97, 24, 21, 228, 119, 112, 39, 225, 138, 112, 180, 99, 37, 188, 194, 235, 50, 69, 144, 79, 29, 175, 69, 30, 154, 111, 217, 83, 87, 250, 96, 238, 25, 127, 236, 27, 155, 178, 3, 116, 153, 124, 53, 177, 155, 20, 237, 53, 134, 31 }, new byte[] { 19, 52, 15, 220, 51, 29, 255, 245, 249, 15, 213, 132, 245, 91, 27, 107, 186, 51, 193, 90, 208, 101, 221, 146, 209, 225, 90, 13, 47, 192, 14, 0, 134, 164, 156, 95, 51, 23, 62, 183, 55, 77, 186, 31, 135, 45, 195, 254, 97, 196, 24, 79, 52, 216, 62, 41, 230, 138, 48, 170, 247, 104, 198, 2, 78, 74, 181, 3, 231, 128, 229, 132, 202, 166, 154, 115, 22, 92, 188, 222, 149, 58, 17, 89, 153, 92, 6, 202, 48, 232, 208, 54, 45, 132, 235, 144, 156, 216, 64, 34, 188, 56, 85, 183, 224, 189, 157, 140, 80, 232, 208, 23, 119, 31, 77, 30, 48, 31, 169, 244, 113, 202, 111, 215, 234, 93, 255, 5 }, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("018f8587-be95-4c2b-8ff3-da3436fd26c3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f057f611-2748-44ca-8e31-1b9d6a230b4b") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("018f8587-be95-4c2b-8ff3-da3436fd26c3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f057f611-2748-44ca-8e31-1b9d6a230b4b"));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserCourseId" },
                values: new object[] { new Guid("2513f241-a0d8-4976-b1bc-630f0dfb90d1"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 211, 151, 154, 69, 10, 210, 85, 226, 6, 196, 232, 197, 100, 31, 86, 199, 74, 33, 138, 160, 15, 1, 150, 147, 177, 47, 69, 58, 179, 54, 193, 115, 225, 168, 140, 161, 98, 48, 0, 74, 56, 79, 101, 68, 23, 14, 102, 24, 58, 197, 84, 201, 137, 130, 85, 86, 21, 52, 77, 44, 248, 99, 49, 98 }, new byte[] { 58, 80, 10, 36, 139, 120, 179, 161, 190, 5, 87, 160, 74, 116, 225, 252, 34, 104, 129, 239, 71, 0, 160, 25, 213, 20, 150, 58, 177, 38, 157, 167, 193, 99, 151, 31, 106, 220, 18, 179, 116, 209, 70, 31, 102, 7, 170, 10, 70, 180, 57, 73, 117, 184, 254, 244, 224, 79, 81, 226, 192, 32, 62, 68, 71, 105, 53, 182, 175, 230, 221, 119, 238, 223, 84, 72, 157, 123, 15, 230, 116, 251, 169, 55, 240, 43, 236, 254, 12, 50, 9, 116, 18, 28, 111, 69, 187, 235, 87, 229, 27, 20, 29, 43, 210, 247, 208, 243, 130, 184, 252, 21, 123, 74, 66, 224, 91, 74, 44, 237, 59, 149, 40, 118, 155, 134, 59, 105 }, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a619554d-2e1d-4e6e-acd9-ed76d5de6a97"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("2513f241-a0d8-4976-b1bc-630f0dfb90d1") });
        }
    }
}
