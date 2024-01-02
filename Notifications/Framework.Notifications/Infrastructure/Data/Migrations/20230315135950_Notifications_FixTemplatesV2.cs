using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixTemplatesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"rtl\"><head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <title style=\"dispaly:none\">CST</title>\r\n</head>\r\n<body dir=\"ltr\" style=\"padding:0px\">\r\n  <div style=\"background-color: #040063;text-align:center;width:100%;\">\r\n<img src=\"{RootUrl}/CITC/images/Logo.png\" min-width=\"30%\" class=\"email_header\" style=\"border:1px solid #ddd;max-width:30%\">\r\n</div>\r\n    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n        <tbody><tr>\r\n            <td class=\"email_conts\" style=\"padding:10px 20px;  font:11px Segoe UI,tahoma;  line-height:20px;  color:#404040;  text-align:right;  border:1px solid #eee;  border-top:none\">\r\n                <div dir=\"ltr\">\r\n				{body}\r\n</div>\r\n<div dir=\"rtl\">\r\n{bodyAr}\r\n</div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"email_footer\" width=\"600\" style=\"padding:10px 0;  background-color:#030062;  color:#fff;  font:11px Segoe UI,tahoma;  text-align:center\">\r\n                For your suggestions and comments, send us an e-mail: <a href=\"{ContactUsEmail}\" style=\"color:#fff;  font:11px Segoe UI,tahoma\">{ContactUsEmail}</a>\r\n            </td>\r\n        </tr>\r\n    </tbody></table>\r\n\r\n</body></html>", "<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"rtl\"><head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <title>CST</title>\r\n</head>\r\n<body dir=\"ltr\" style=\"padding:0px\">\r\n<img src=\"{RootUrl}/CITC/images/Logo.png\" min-width=\"30%\" class=\"email_header\" style=\"border:1px solid #ddd;max-width:30%\">\r\n    <table width=\"600\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n        <tbody><tr>\r\n            <td class=\"email_conts\" style=\"padding:10px 20px;  font:11px Segoe UI,tahoma;  line-height:20px;  color:#404040;  text-align:right;  border:1px solid #eee;  border-top:none\">\r\n                <div dir=\"ltr\">\r\n				{body}\r\n</div>\r\n<div dir=\"rtl\">\r\n{bodyAr}\r\n</div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"email_footer\" width=\"600\" style=\"padding:10px 0;  background-color:#030062;  color:#fff;  font:11px Segoe UI,tahoma;  text-align:center\">\r\n                For your suggestions and comments, send us an e-mail: <a href=\"{ContactUsEmail}\" style=\"color:#fff;  font:11px Segoe UI,tahoma\">{ContactUsEmail}</a>\r\n            </td>\r\n        </tr>\r\n    </tbody></table>\r\n\r\n</body></html>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2001,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">We regret to inform you that your {RequestType} request with CITC is rejected , You can review your request via the following link: {ExternalUrl}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأسف لإبلاغكم برفض طلب {RequestTypeAr} في منصة تك بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{ExternalUrl}.</p> \r\n\r\n\r\n            </h3>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"rtl\"><head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <title style=\"dispaly:none\">CST</title>\r\n</head>\r\n<body dir=\"ltr\" style=\"padding:0px\">\r\n  <div style=\"background-color: #040063;text-align:center;width:100%;\">\r\n<img src=\"{RootUrl}/CITC/images/Logo.png\" min-width=\"100%\" class=\"email_header\" style=\"border:1px solid #ddd;max-width:100%\">\r\n</div>\r\n    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n        <tbody><tr>\r\n            <td class=\"email_conts\" style=\"padding:10px 20px;  font:11px Segoe UI,tahoma;  line-height:20px;  color:#404040;  text-align:right;  border:1px solid #eee;  border-top:none\">\r\n                <div dir=\"ltr\">\r\n				{body}\r\n</div>\r\n<div dir=\"rtl\">\r\n{bodyAr}\r\n</div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"email_footer\" width=\"600\" style=\"padding:10px 0;  background-color:#030062;  color:#fff;  font:11px Segoe UI,tahoma;  text-align:center\">\r\n                For your suggestions and comments, send us an e-mail: <a href=\"{ContactUsEmail}\" style=\"color:#fff;  font:11px Segoe UI,tahoma\">{ContactUsEmail}</a>\r\n            </td>\r\n        </tr>\r\n    </tbody></table>\r\n\r\n</body></html>", "<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"rtl\"><head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <title>CST</title>\r\n</head>\r\n<body dir=\"ltr\" style=\"padding:0px\">\r\n    <img src=\"{RootUrl}/wwwroot/CITC/images/Logo.png\" width=\"598\" class=\"email_header\" style=\"border:1px solid #ddd\">\r\n    <table width=\"600\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n        <tbody><tr>\r\n            <td class=\"email_conts\" style=\"padding:10px 20px;  font:11px Segoe UI,tahoma;  line-height:20px;  color:#404040;  text-align:right;  border:1px solid #eee;  border-top:none\">\r\n                <div dir=\"ltr\">\r\n				{body}\r\n</div>\r\n<div dir=\"rtl\">\r\n{bodyAr}\r\n</div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"email_footer\" width=\"600\" style=\"padding:10px 0;  background-color:#030062;  color:#fff;  font:11px Segoe UI,tahoma;  text-align:center\">\r\n                For your suggestions and comments, send us an e-mail: <a href=\"{ContactUsEmail}\" style=\"color:#fff;  font:11px Segoe UI,tahoma\">{ContactUsEmail}</a>\r\n            </td>\r\n        </tr>\r\n    </tbody></table>\r\n\r\n</body></html>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2001,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">We regret to inform you that your {RequestType} request with CITC is rejected for these reasons: {Reason} , You can review your request via the following link: {ExternalUrl}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأسف لإبلاغكم برفض طلب {RequestTypeAr} في منصة تك بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{ExternalUrl}.</p> \r\n    <p>&nbsp;</p> \r\n    <p>الأسباب :&nbsp; {Reason}</p> \r\n\r\n            </h3>" });
        }
    }
}
