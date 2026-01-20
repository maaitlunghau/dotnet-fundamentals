using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _13_school_management_system.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Department", "Email", "TeacherName" },
                values: new object[,]
                {
                    { 1, "Công nghệ thông tin", "a.nguyen@school.com", "Nguyễn Văn A" },
                    { 2, "Khoa học máy tính", "b.tran@school.com", "Trần Thị B" },
                    { 3, "Hệ thống thông tin", "c.le@school.com", "Lê Hoàng C" },
                    { 4, "Kỹ thuật phần mềm", "d.pham@school.com", "Phạm Minh D" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Address", "DateOfBirth", "StudentName", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Hà Nội", new DateTime(2002, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn E", 1 },
                    { 2, "TP. Hồ Chí Minh", new DateTime(2003, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Thị F", 1 },
                    { 3, "Đà Nẵng", new DateTime(2001, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Văn G", 2 },
                    { 4, "Cần Thơ", new DateTime(2002, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị H", 2 },
                    { 5, "Hải Phòng", new DateTime(2003, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Văn I", 3 },
                    { 6, "Huế", new DateTime(2001, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Võ Thị K", 3 },
                    { 7, "Bình Dương", new DateTime(2002, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đặng Văn L", 4 },
                    { 8, "Đồng Nai", new DateTime(2003, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Thị M", 4 },
                    { 9, "Quảng Nam", new DateTime(2002, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phan Văn N", 4 },
                    { 10, "Nghệ An", new DateTime(2001, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngô Thị O", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 4);
        }
    }
}
