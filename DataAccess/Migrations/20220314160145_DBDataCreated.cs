using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class DBDataCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "PhotoUrl", "Title" },
                values: new object[] { 1, "Lorem", "test1.jpg", "Kaska" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "PhotoUrl", "Title" },
                values: new object[] { 2, "Lorem Tshirt", "test2.jpg", "Tshirt" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsFeature", "Name", "PhotoUrl", "Price" },
                values: new object[] { 1, 1, "Lorem", null, false, "Product 1", "test1.jpg", 2500m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "IsFeature", "Name", "PhotoUrl", "Price" },
                values: new object[] { 2, 2, "Lorem", null, false, "Product 2", "test2.jpg", 2300m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
