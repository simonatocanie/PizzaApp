﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Bauturi" },
                    { 3, "Cafea" },
                    { 4, "Sosuri" }
                });

            migrationBuilder.InsertData(
                table: "Doughs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Traditional" },
                    { 2, "Subtire" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Measure", "Name" },
                values: new object[,]
                {
                    { 1, 25, "Mica" },
                    { 2, 30, "Medie" },
                    { 3, 35, "Mare" },
                    { 4, 0, "Party" }
                });

            migrationBuilder.InsertData(
                table: "CategoryDough",
                columns: new[] { "CategoryId", "DoughId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CategoryDough",
                keyColumns: new[] { "CategoryId", "DoughId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryDough",
                keyColumns: new[] { "CategoryId", "DoughId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
