using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace campingBlog.Data.Migrations
{
    public partial class addedPostAndCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog", x => x.Id);
                });
        }
    }
}
