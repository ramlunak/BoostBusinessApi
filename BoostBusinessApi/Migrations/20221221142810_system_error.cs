using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoostBusinessApi.Migrations
{
    /// <inheritdoc />
    public partial class systemerror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemErrors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method = table.Column<string>(type: "varchar(20)", nullable: true),
                    Path = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Message = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Exception = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Payload = table.Column<string>(type: "varchar(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemErrors", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemErrors");
        }
    }
}
