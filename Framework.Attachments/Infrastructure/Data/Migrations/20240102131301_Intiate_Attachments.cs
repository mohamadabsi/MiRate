using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Framework.Attachments.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Intiate_Attachments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Attachment",
                table: "AttachmentType",
                keyColumn: "Id",
                keyValue: 100,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Attachment",
                table: "AttachmentType",
                keyColumn: "Id",
                keyValue: 200,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Attachment",
                table: "AttachmentType",
                keyColumn: "Id",
                keyValue: 300,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Attachment",
                table: "AttachmentType",
                keyColumn: "Id",
                keyValue: 400,
                column: "Description",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Attachment",
                table: "AttachmentType",
                keyColumn: "Id",
                keyValue: 100,
                column: "Description",
                value: "the allowed extensions are (jpg,png,jpeg,gif,pdf,doc,docx,xls,xlsx,ppm,ppt,pptx,txt) with maximum 5 MB");

            migrationBuilder.UpdateData(
                schema: "Attachment",
                table: "AttachmentType",
                keyColumn: "Id",
                keyValue: 200,
                column: "Description",
                value: "the allowed extensions are (jpg,png,jpeg) with maximum 5 MB");

            migrationBuilder.UpdateData(
                schema: "Attachment",
                table: "AttachmentType",
                keyColumn: "Id",
                keyValue: 300,
                column: "Description",
                value: "the allowed extensions are (jpg,png,jpeg) with maximum 5 MB");

            migrationBuilder.UpdateData(
                schema: "Attachment",
                table: "AttachmentType",
                keyColumn: "Id",
                keyValue: 400,
                column: "Description",
                value: "the allowed extensions are (xls,xlsx) with maximum 10 MB");
        }
    }
}
