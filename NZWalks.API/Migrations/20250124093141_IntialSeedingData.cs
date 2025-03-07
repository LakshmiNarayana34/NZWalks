using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class IntialSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d5d0f328-88f6-48f9-77ea-08dd1f4abb45"), "Easy" },
                    { new Guid("d5d0f328-88f6-48f9-77ea-08dd1f4abb47"), "Medium" },
                    { new Guid("d5d0f328-88f6-48f9-77ea-08dd1f4abb48"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImgUrl" },
                values: new object[,]
                {
                    { new Guid("d5d0f328-88f6-48f9-77ea-08dd1f4abb51"), "Dnk", "Nilotpal", null },
                    { new Guid("d5d0f328-88f6-48f9-77ea-08dd1f4abb54"), "Ilr", "prasant", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d5d0f328-88f6-48f9-77ea-08dd1f4abb45"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d5d0f328-88f6-48f9-77ea-08dd1f4abb47"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d5d0f328-88f6-48f9-77ea-08dd1f4abb48"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d5d0f328-88f6-48f9-77ea-08dd1f4abb51"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d5d0f328-88f6-48f9-77ea-08dd1f4abb54"));
        }
    }
}
