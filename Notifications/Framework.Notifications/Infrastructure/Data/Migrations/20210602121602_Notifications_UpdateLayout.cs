using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_UpdateLayout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                schema: "Notifications",
                table: "NotificationSetting");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"rtl\"><head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <title>CITC</title>\r\n</head>\r\n<body dir=\"ltr\" style=\"padding:0px\">\r\n    <img src=\"{RootUrl}/wwwroot/CITC/images/email_header.jpg\" width=\"598\" class=\"email_header\" style=\"border:1px solid #ddd\">\r\n    <table width=\"600\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n        <tbody><tr>\r\n            <td class=\"email_conts\" style=\"padding:10px 20px;  font:11px Segoe UI,tahoma;  line-height:20px;  color:#404040;  text-align:right;  border:1px solid #eee;  border-top:none\">\r\n                <div dir=\"ltr\">\r\n				{body}\r\n</div>\r\n<div dir=\"rtl\">\r\n{bodyAr}\r\n</div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"email_footer\" width=\"600\" style=\"padding:10px 0;  background-color:#030062;  color:#fff;  font:11px Segoe UI,tahoma;  text-align:center\">\r\n                For your suggestions and comments, send us an e-mail: <a href=\"{ContactUsEmail}\" style=\"color:#fff;  font:11px Segoe UI,tahoma\">{ContactUsEmail}</a>\r\n            </td>\r\n        </tr>\r\n    </tbody></table>\r\n\r\n</body></html>", "<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"rtl\"><head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <title>CITC</title>\r\n</head>\r\n<body dir=\"ltr\" style=\"padding:0px\">\r\n    <img src=\"{RootUrl}/wwwroot/CITC/images/email_header.jpg\" width=\"598\" class=\"email_header\" style=\"border:1px solid #ddd\">\r\n    <table width=\"600\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n        <tbody><tr>\r\n            <td class=\"email_conts\" style=\"padding:10px 20px;  font:11px Segoe UI,tahoma;  line-height:20px;  color:#404040;  text-align:right;  border:1px solid #eee;  border-top:none\">\r\n                <div dir=\"ltr\">\r\n				{body}\r\n</div>\r\n<div dir=\"rtl\">\r\n{bodyAr}\r\n</div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"email_footer\" width=\"600\" style=\"padding:10px 0;  background-color:#030062;  color:#fff;  font:11px Segoe UI,tahoma;  text-align:center\">\r\n                For your suggestions and comments, send us an e-mail: <a href=\"{ContactUsEmail}\" style=\"color:#fff;  font:11px Segoe UI,tahoma\">{ContactUsEmail}</a>\r\n            </td>\r\n        </tr>\r\n    </tbody></table>\r\n\r\n</body></html>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                schema: "Notifications",
                table: "NotificationSetting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 10,
                column: "Value",
                value: "FALSE");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 20,
                column: "Value",
                value: "FALSE");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 30,
                column: "Value",
                value: "Tasjeel Tech");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 40,
                column: "Value",
                value: "exch-array.citc.gov.sa");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 50,
                column: "Value",
                value: "Tasjeeltech@citc.gov.sa");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 60,
                column: "Value",
                value: "AzswQ@123753@zizadqhhdone");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 70,
                column: "Value",
                value: "TRUE");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 80,
                column: "Value",
                value: "587");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 90,
                column: "Value",
                value: "FALSE");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 100,
                column: "Value",
                value: "Tasjeeltech@citc.gov.sa");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 110,
                column: "Value",
                value: "Tasjeel Tech");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 120,
                column: "Value",
                value: "Tasjeeltech@citc.gov.sa");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 130,
                column: "Value",
                value: "Tasjeel Tech");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: 140,
                column: "Value",
                value: "http://localhost:44309/");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"rtl\"><head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <title>CITC</title>\r\n</head>\r\n<body dir=\"ltr\" style=\"padding:0px\">\r\n    <img src=\"{RootUrl}\\wwwroot\\CITC\\images\\email_header.jpg\" width=\"598\" class=\"email_header\" style=\"border:1px solid #ddd\">\r\n    <table width=\"600\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n        <tbody><tr>\r\n            <td class=\"email_conts\" style=\"padding:10px 20px;  font:11px Segoe UI,tahoma;  line-height:20px;  color:#404040;  text-align:right;  border:1px solid #eee;  border-top:none\">\r\n                <div dir=\"ltr\">\r\n				{body}\r\n</div>\r\n<div dir=\"rtl\">\r\n{bodyAr}\r\n</div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"email_footer\" width=\"600\" style=\"padding:10px 0;  background-color:#030062;  color:#fff;  font:11px Segoe UI,tahoma;  text-align:center\">\r\n                For your suggestions and comments, send us an e-mail: <a href=\"{ContactUsEmail}\" style=\"color:#fff;  font:11px Segoe UI,tahoma\">{ContactUsEmail}</a>\r\n            </td>\r\n        </tr>\r\n    </tbody></table>\r\n\r\n</body></html>", "<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"rtl\"><head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <title>CITC</title>\r\n</head>\r\n<body dir=\"ltr\" style=\"padding:0px\">\r\n    <img src=\"{RootUrl}\\wwwroot\\CITC\\images\\email_header.jpg\" width=\"598\" class=\"email_header\" style=\"border:1px solid #ddd\">\r\n    <table width=\"600\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n        <tbody><tr>\r\n            <td class=\"email_conts\" style=\"padding:10px 20px;  font:11px Segoe UI,tahoma;  line-height:20px;  color:#404040;  text-align:right;  border:1px solid #eee;  border-top:none\">\r\n                <div dir=\"ltr\">\r\n				{body}\r\n</div>\r\n<div dir=\"rtl\">\r\n{bodyAr}\r\n</div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"email_footer\" width=\"600\" style=\"padding:10px 0;  background-color:#030062;  color:#fff;  font:11px Segoe UI,tahoma;  text-align:center\">\r\n                For your suggestions and comments, send us an e-mail: <a href=\"{ContactUsEmail}\" style=\"color:#fff;  font:11px Segoe UI,tahoma\">{ContactUsEmail}</a>\r\n            </td>\r\n        </tr>\r\n    </tbody></table>\r\n\r\n</body></html>" });
        }
    }
}
