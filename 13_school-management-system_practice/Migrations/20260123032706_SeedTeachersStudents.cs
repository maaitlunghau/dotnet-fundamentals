using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _13_school_management_system_practice.Migrations
{
    /// <inheritdoc />
    public partial class SeedTeachersStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Department", "Email", "TeacherName" },
                values: new object[,]
                {
                    { 1, "Công nghệ thông tin", "nguyenvana@school.com", "Nguyễn Văn A" },
                    { 2, "Toán học", "tranthib@school.com", "Trần Thị B" },
                    { 3, "Vật lý", "levanc@school.com", "Lê Văn C" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DateOfBirth", "StudentName", "TeacherId" },
                values: new object[,]
                {
                    { 1, "123 Nguyễn Trãi, Quận 5, TP.HCM", new DateTime(2002, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Minh Hoàng", 1 },
                    { 2, "45 Lê Lợi, Quận 1, TP.HCM", new DateTime(2003, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị Lan", 1 },
                    { 3, "78 Hai Bà Trưng, Hà Nội", new DateTime(2001, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Quốc Khánh", 1 },
                    { 4, "12 Trường Chinh, Đà Nẵng", new DateTime(2002, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Thị Hồng", 2 },
                    { 5, "90 Nguyễn Huệ, Huế", new DateTime(2003, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Võ Minh Tuấn", 2 },
                    { 6, "66 Lý Thường Kiệt, TP.HCM", new DateTime(2001, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phan Thanh Tùng", 2 },
                    { 7, "34 Pasteur, TP.HCM", new DateTime(2002, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đặng Ngọc Mai", 3 },
                    { 8, "101 Cách Mạng Tháng 8, Cần Thơ", new DateTime(2003, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bùi Quốc Dũng", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
