using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixNotificationTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 101,
                column: "HTML",
                value: "<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"rtl\"><head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <title style=\"dispaly:none\">CITC</title>\r\n</head>\r\n<body dir=\"ltr\" style=\"padding:0px\">\r\n  <div style=\"background-color: #040063;text-align:center;width:100%;\">\r\n<img src=\"{RootUrl}/CITC/images/email_header.jpg\" min-width=\"100%\" class=\"email_header\" style=\"border:1px solid #ddd;max-width:100%\">\r\n</div>\r\n    <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n        <tbody><tr>\r\n            <td class=\"email_conts\" style=\"padding:10px 20px;  font:11px Segoe UI,tahoma;  line-height:20px;  color:#404040;  text-align:right;  border:1px solid #eee;  border-top:none\">\r\n                <div dir=\"ltr\">\r\n				{body}\r\n</div>\r\n<div dir=\"rtl\">\r\n{bodyAr}\r\n</div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"email_footer\" width=\"600\" style=\"padding:10px 0;  background-color:#030062;  color:#fff;  font:11px Segoe UI,tahoma;  text-align:center\">\r\n                For your suggestions and comments, send us an e-mail: <a href=\"{ContactUsEmail}\" style=\"color:#fff;  font:11px Segoe UI,tahoma\">{ContactUsEmail}</a>\r\n            </td>\r\n        </tr>\r\n    </tbody></table>\r\n\r\n</body></html>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1501,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {Name}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n<p style=\"text-align: left;\">Kindly log in to Mannasah platform to study the request to attend a session added to your assignment box via the following link: {InternalUrl}</p><h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المشرف</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {InternalUrl}</p> \r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1502,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to Mannasah platform to study the request to attend a session added to your assignment box via the following link: {InternalUrl}", "المكرم {UserFullNameAr} المشرف \r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {InternalUrl}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1601,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to Mannasah platform to study the request to attend a session added to your assignment box via the following link: {InternalUrl}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المشرف</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {InternalUrl}</p> \r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1602,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to Mannasah platform to study the request to register a company added to your assignment box via the following link: {InternalUrl}", "المكرم {UserFullNameAr}\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب {RequestTypeAr} شركة المضاف لصندوق المهام الخاص بكم عبر الرابط التالي:{InternalUrl}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1701,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to the company registration platform to study the request to examine financial information added to your assignment box via the following link: {InternalUrl}\r\n    </p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المشرف</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة المعلومات المالية المضافة لصندوق المهام الخاص بكم عبر الرابط التالي: {InternalUrl}</p> \r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1702,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to the company registration platform to study the request to examine financial information added to your assignment box via the following link: {InternalUrl}", "المكرم {UserFullNameAr} المشرف\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة المعلومات المالية المضافة لصندوق المهام الخاص بكم عبر الرابط التالي: {InternalUrl}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1801,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn} Director of the Department</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to the company registration platform to approve the request to approve the {RequestType} request added to your assignment box via the following link: {InternalUrl}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} مدير الإدارة</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p >نأمل منكم التكرم &nbsp;بزيارة منصة تسجيل الشركات لاعتماد طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {InternalUrl}</p> \r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1802,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn} Director of the Department\r\n\r\nGreetings,\r\n\r\nKindly log in to Mannasah platform to approve the request to approve the {RequestType} request added to your assignment box via the following link: {InternalUrl}", "المكرم UserFullNameAr} مدير الإدارة\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم  بزيارة منصة تسجيل الشركات لاعتماد طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {InternalUrl}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1901,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to Mannasah platform to amend the notes received from the reviewers on your registration at CITC via the following link: {InternalUrl}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لتعديل الملاحظات الواردة على الطلب تسجيلكم في الهيئة عبر الرابط التالي: {ExternalUrl}</p> \r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1902,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nKindly log in to Mannasah platform to amend the notes received from the reviewers on your {RequestType} at CITC via the following link: {ExternalUrl}", "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لتعديل الملاحظات الواردة على الطلب {RequestTypeAr} في الهيئة عبر الرابط التالي: {ExternalUrl}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2001,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">We regret to inform you that your {RequestType} request with CITC is rejected for these reasons: {Reason} , You can review your request via the following link: {ExternalUrl}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأسف لإبلاغكم برفض طلب {RequestTypeAr} في منصة تسجيل الشركات بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{ExternalUrl}.</p> \r\n    <p>&nbsp;</p> \r\n    <p>الأسباب :&nbsp; {Reason}</p> \r\n\r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2002,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nWe regret to inform you that your {RequestType} request with CITC is rejected for these reasons: {Reason} , You can review your request via the following link: {ExternalUrl}", "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأسف لإبلاغكم برفض طلب {RequestTypeAr} في منصة تسجيل الشركات بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{ExternalUrl}.\r\n\r\n\r\n\r\n\r\nالأسباب :  {Reason}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2231,
                column: "HTML",
                value: "<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">Greetings,\r\n <p>\r\n Kindly be informed that the company profile will be expired after one month.\r\nSo please login to the portal to apply profile renew request\r\n</p> \r\n            </h3>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2502,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Kindly use the following code to activate your phone number: {Code} ", " نأمل استخدام الرمز التالي لتفعيل رقم الهاتف: {Code}\r\n  " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 101,
                column: "HTML",
                value: "<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"rtl\"><head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <title>CITC</title>\r\n</head>\r\n<body dir=\"ltr\" style=\"padding:0px\">\r\n    <img src=\"{RootUrl}/wwwroot/CITC/images/email_header.jpg\" width=\"598\" class=\"email_header\" style=\"border:1px solid #ddd\">\r\n    <table width=\"600\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n        <tbody><tr>\r\n            <td class=\"email_conts\" style=\"padding:10px 20px;  font:11px Segoe UI,tahoma;  line-height:20px;  color:#404040;  text-align:right;  border:1px solid #eee;  border-top:none\">\r\n                <div dir=\"ltr\">\r\n				{body}\r\n</div>\r\n<div dir=\"rtl\">\r\n{bodyAr}\r\n</div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"email_footer\" width=\"600\" style=\"padding:10px 0;  background-color:#030062;  color:#fff;  font:11px Segoe UI,tahoma;  text-align:center\">\r\n                For your suggestions and comments, send us an e-mail: <a href=\"{ContactUsEmail}\" style=\"color:#fff;  font:11px Segoe UI,tahoma\">{ContactUsEmail}</a>\r\n            </td>\r\n        </tr>\r\n    </tbody></table>\r\n\r\n</body></html>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1501,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear Admin. {Name}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n<p style=\"text-align: left;\">Kindly log in to Mannasah platform to study the request to attend a session added to your assignment box via the following link: {URL}</p><h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المشرف</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}</p> \r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1502,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear Admin. {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to Mannasah platform to study the request to attend a session added to your assignment box via the following link: {URL}", "المكرم {UserFullNameAr} المشرف \r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1601,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear Admin {UserFullNameEn}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to Mannasah platform to study the request to attend a session added to your assignment box via the following link: {URL}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المشرف</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}</p> \r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1602,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to Mannasah platform to study the request to register a company added to your assignment box via the following link: {URL}", "المكرم {UserFullNameAr}\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب {RequestTypeAr} شركة المضاف لصندوق المهام الخاص بكم عبر الرابط التالي:{URL}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1701,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear Admin {UserFullNameEn}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to the company registration platform to study the request to examine financial information added to your assignment box via the following link: {URL}\r\n    </p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المشرف</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة المعلومات المالية المضافة لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}</p> \r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1702,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear Admin. {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to the company registration platform to study the request to examine financial information added to your assignment box via the following link: {URL}", "المكرم {UserFullNameAr} المشرف\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة المعلومات المالية المضافة لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1801,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn} Director of the Department</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to the company registration platform to approve the request to approve the {RequestType} request added to your assignment box via the following link: {URL}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} مدير الإدارة</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p >نأمل منكم التكرم &nbsp;بزيارة منصة تسجيل الشركات لاعتماد طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}</p> \r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1802,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn} Director of the Department\r\n\r\nGreetings,\r\n\r\nKindly log in to Mannasah platform to approve the request to approve the {RequestType} request added to your assignment box via the following link: {URL}", "المكرم UserFullNameAr} مدير الإدارة\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم  بزيارة منصة تسجيل الشركات لاعتماد طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1901,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to Mannasah platform to amend the notes received from the reviewers on your registration at CITC via the following link: {URL}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لتعديل الملاحظات الواردة على الطلب تسجيلكم في الهيئة عبر الرابط التالي: {URL}</p> \r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1902,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nKindly log in to Mannasah platform to amend the notes received from the reviewers on your {RequestType} at CITC via the following link: {URL}", "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لتعديل الملاحظات الواردة على الطلب {RequestTypeAr} في الهيئة عبر الرابط التالي: {URL}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2001,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">We regret to inform you that your {RequestType} request with CITC is rejected for these reasons: {Reason} , You can review your request via the following link: {URL}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأسف لإبلاغكم برفض طلب {RequestTypeAr} في منصة تسجيل الشركات بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{URL}.</p> \r\n    <p>&nbsp;</p> \r\n    <p>الأسباب :&nbsp; {Reason}</p> \r\n\r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2002,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nWe regret to inform you that your {RequestType} request with CITC is rejected for these reasons: {Reason} , You can review your request via the following link: {URL}", "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأسف لإبلاغكم برفض طلب {RequestTypeAr} في منصة تسجيل الشركات بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{URL}.\r\n\r\n\r\n\r\n\r\nالأسباب :  {Reason}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2231,
                column: "HTML",
                value: "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n <p>\r\nيرجى العلم أنه باقى شهر على انتهاء صلاحية ملف الشرك .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة.\r\n</p> \r\n            </h3>\"");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2502,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "رمز التفعيل : {Code}  نأمل استخدام الرمز لتفعيل رقم الهاتف\r\n  \r\n Code : {Code} please use this code to activate your number", "رمز التفعيل : {Code}  نأمل استخدام الرمز لتفعيل رقم الهاتف\r\n  \r\n Code : {Code} please use this code to activate your number" });
        }
    }
}
