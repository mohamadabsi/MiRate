using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixTemplatesCST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1901,
                column: "HTML",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to Manassa Tech platform to amend the notes received from the reviewers on your registration at CST via the following link: {ExternalUrl}</p>\r\n</h3>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1902,
                column: "HTML",
                value: "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nKindly log in to Manassa Tech platform to amend the notes received from the reviewers on your {RequestType} at CST via the following link: {ExternalUrl}");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2001,
                column: "HTML",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">We regret to inform you that your {RequestType} request with CST is rejected , You can review your request via the following link: {ExternalUrl}</p>\r\n</h3>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2002,
                column: "HTML",
                value: "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nWe regret to inform you that your {RequestType} request with CST is rejected for these reasons: {Reason} , You can review your request via the following link: {ExternalUrl}");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2051,
                column: "HTML",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">We are pleased to inform you that your {RequestType} request with CST is approved  , You can review your request via the following link: {ExternalUrl}</p>\r\n</h3>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2052,
                column: "HTML",
                value: "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nWe are please to inform you that your {RequestType} request with CST is approved , You can review your request via the following link: {ExternalUrl}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1901,
                column: "HTML",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to Manassa Tech platform to amend the notes received from the reviewers on your registration at CITC via the following link: {ExternalUrl}</p>\r\n</h3>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1902,
                column: "HTML",
                value: "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nKindly log in to Manassa Tech platform to amend the notes received from the reviewers on your {RequestType} at CITC via the following link: {ExternalUrl}");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2001,
                column: "HTML",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">We regret to inform you that your {RequestType} request with CITC is rejected , You can review your request via the following link: {ExternalUrl}</p>\r\n</h3>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2002,
                column: "HTML",
                value: "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nWe regret to inform you that your {RequestType} request with CITC is rejected for these reasons: {Reason} , You can review your request via the following link: {ExternalUrl}");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2051,
                column: "HTML",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">We are pleased to inform you that your {RequestType} request with CITC is approved  , You can review your request via the following link: {ExternalUrl}</p>\r\n</h3>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2052,
                column: "HTML",
                value: "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nWe are please to inform you that your {RequestType} request with CITC is approved , You can review your request via the following link: {ExternalUrl}");
        }
    }
}
