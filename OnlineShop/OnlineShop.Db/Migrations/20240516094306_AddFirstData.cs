using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("0c92b62e-7341-4009-ad46-3532fe447dd9"), 10m, "Desc1", "/images/image1.png", "Name1" },
                    { new Guid("28bac00b-9622-4767-a0ad-bb4debabe078"), 30m, "Desc3", "/images/image3.png", "Name3" },
                    { new Guid("385f579b-9c8d-47bb-9a80-41579937ac0c"), 20m, "Desc2", "/images/image2.png", "Name2" },
                    { new Guid("6e088c5a-1b7e-4363-8e4f-578b8c51eba8"), 40m, "Desc4", "/images/image4.jpg", "Name4" },
                    { new Guid("763c6078-7659-4fa9-ab4f-aa162bd4ff3e"), 50m, "Desc5", "/images/image5.png", "Name5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c92b62e-7341-4009-ad46-3532fe447dd9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("28bac00b-9622-4767-a0ad-bb4debabe078"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("385f579b-9c8d-47bb-9a80-41579937ac0c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6e088c5a-1b7e-4363-8e4f-578b8c51eba8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("763c6078-7659-4fa9-ab4f-aa162bd4ff3e"));
        }
    }
}
