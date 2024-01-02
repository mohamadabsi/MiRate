using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Common.Infrastructure.Data.Migrations
{
    public partial class AddAuditLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.CreateTable(
                name: "Audit",
                schema: "common",
                columns: table => new 
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CrudOperation = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    TableName = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    KeyValues = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit",
                schema: "common");
        }
    }
}
