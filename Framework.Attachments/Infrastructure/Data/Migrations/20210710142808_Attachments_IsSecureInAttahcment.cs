using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Attachments.Infrastructure.Data.Migrations
{
    public partial class Attachments_IsSecureInAttahcment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Attachment");

            migrationBuilder.CreateTable(
                name: "AttachmentDownload",
                schema: "Attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentDownload", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentType",
                schema: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowedFilesExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageMaxHeight = table.Column<int>(type: "int", nullable: true),
                    ImageMaxWidth = table.Column<int>(type: "int", nullable: true),
                    IsImage = table.Column<bool>(type: "bit", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    MaxSizeInMegabytes = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                schema: "Attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSecure = table.Column<bool>(type: "bit", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentTypeId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_AttachmentType_AttachmentTypeId",
                        column: x => x.AttachmentTypeId,
                        principalSchema: "Attachment",
                        principalTable: "AttachmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentContent",
                schema: "Attachment",
                columns: table => new
                {
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    OldContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentContent", x => x.AttachmentId);
                    table.ForeignKey(
                        name: "FK_AttachmentContent_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalSchema: "Attachment",
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Attachment",
                table: "AttachmentType",
                columns: new[] { "Id", "AllowedFilesExtension", "Code", "CreatedBy", "CreatedOn", "Description", "ImageMaxHeight", "ImageMaxWidth", "IsActive", "IsDeleted", "IsImage", "IsMandatory", "MaxSizeInMegabytes", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 100, "jpg,png,jpeg,gif,pdf,doc,docx,xls,xlsx,ppm,ppt,pptx,txt", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "the allowed extensions are (jpg,png,jpeg,gif,pdf,doc,docx,xls,xlsx,ppm,ppt,pptx,txt) with maximum 5 MB", null, null, true, false, false, false, 5.0, null, null },
                    { 200, "jpg,png,jpeg", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "the allowed extensions are (jpg,png,jpeg) with maximum 5 MB", null, null, true, false, false, false, 5.0, null, null },
                    { 300, "jpg,png,jpeg", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "the allowed extensions are (jpg,png,jpeg) with maximum 5 MB", null, null, true, false, false, false, 5.0, null, null },
                    { 400, "xls,xlsx", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "the allowed extensions are (xls,xlsx) with maximum 10 MB", null, null, true, false, false, false, 10.0, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_AttachmentTypeId",
                schema: "Attachment",
                table: "Attachment",
                column: "AttachmentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentContent",
                schema: "Attachment");

            migrationBuilder.DropTable(
                name: "AttachmentDownload",
                schema: "Attachment");

            migrationBuilder.DropTable(
                name: "Attachment",
                schema: "Attachment");

            migrationBuilder.DropTable(
                name: "AttachmentType",
                schema: "Attachment");
        }
    }
}
