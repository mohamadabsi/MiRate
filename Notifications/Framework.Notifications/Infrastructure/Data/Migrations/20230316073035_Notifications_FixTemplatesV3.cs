using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixTemplatesV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1602,
                column: "HTML",
                value: "Dear {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to Manassa Tech platform to study the request added to your assignment box via the following link: {InternalUrl}");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1901,
                column: "HTML",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to Manassa Tech platform to amend the notes received from the reviewers on your registration at CITC via the following link: {ExternalUrl}</p>\r\n</h3>");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1602,
                column: "HTML",
                value: "Dear {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to Manassa Tech platform to study the request to register a company added to your assignment box via the following link: {InternalUrl}");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1901,
                column: "HTML",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to Manassa Tech platform to amend the notes received from the reviewers on your registration at CITC via the following link: {InternalUrl}</p>\r\n</h3>");
        }
    }
}
