﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_RequestTypeAr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 1801,
                column: "HTMLAr",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} مدير الإدارة</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p >نأمل منكم التكرم &nbsp;بزيارة منصة تسجيل الشركات لاعتماد طلب {RequestTypeAr} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}</p> \r\n            </h3>");

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
                column: "HTML",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to Mannasah platform to amend the notes received from the reviewers on your registration at CITC via the following link: {URL}</p>\r\n</h3>");

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
                column: "HTMLAr",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأسف لإبلاغكم برفض طلب {RequestTypeAr} في منصة تسجيل الشركات بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{URL}.</p> \r\n    <p>&nbsp;</p> \r\n    <p>الأسباب :&nbsp; {Reason}</p> \r\n\r\n            </h3>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2002,
                column: "HTMLAr",
                value: "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأسف لإبلاغكم برفض طلب {RequestTypeAr} في منصة تسجيل الشركات بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{URL}.\r\n\r\n\r\n\r\n\r\nالأسباب :  {Reason}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1501,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear Admin. {Name}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n<p style=\"text-align: left;\">Kindly log in to the company Mannasah platform to study the request to attend a session added to your assignment box via the following link: {URL}</p><h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المشرف</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب حضور جلسة المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}</p> \r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1502,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear Admin. {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to the company Mannasah platform to study the request to attend a session added to your assignment box via the following link: {URL}", "المكرم {UserFullNameAr} المشرف \r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب حضور جلسة المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1601,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear Admin {UserFullNameEn}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to the company Mannasah platform to study the request to attend a session added to your assignment box via the following link: {URL}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المشرف</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب حضور جلسة المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}</p> \r\n            </h3>" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1602,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to the company Mannasah platform to study the request to register a company added to your assignment box via the following link: {URL}", "المكرم {UserFullNameAr}\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب تسجيل شركة المضاف لصندوق المهام الخاص بكم عبر الرابط التالي:{URL}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1801,
                column: "HTMLAr",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} مدير الإدارة</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p >نأمل منكم التكرم &nbsp;بزيارة منصة تسجيل الشركات لاعتماد طلب {RequestType} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}</p> \r\n            </h3>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1802,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn} Director of the Department\r\n\r\nGreetings,\r\n\r\nKindly log in to the company Mannasah platform to approve the request to approve the {RequestType} request added to your assignment box via the following link: {URL}", "المكرم UserFullNameAr} مدير الإدارة\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم  بزيارة منصة تسجيل الشركات لاعتماد طلب {RequestType} المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1901,
                column: "HTML",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to the company Mannasah platform to amend the notes received from the reviewers on your registration at CITC via the following link: {URL}</p>\r\n</h3>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1902,
                columns: new[] { "HTML", "HTMLAr" },
                values: new object[] { "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nKindly log in to the company Mannasah platform to amend the notes received from the reviewers on your {RequestType} at CITC via the following link: {URL}", "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لتعديل الملاحظات الواردة على الطلب تسجيلكم في الهيئة عبر الرابط التالي: {URL}" });

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2001,
                column: "HTMLAr",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأسف لإبلاغكم برفض طلب {RequestType} في منصة تسجيل الشركات بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{URL}.</p> \r\n    <p>&nbsp;</p> \r\n    <p>الأسباب :&nbsp; {Reason}</p> \r\n\r\n            </h3>");

            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2002,
                column: "HTMLAr",
                value: "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأسف لإبلاغكم برفض طلب {RequestType} في منصة تسجيل الشركات بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{URL}.\r\n\r\n\r\n\r\n\r\nالأسباب :  {Reason}");
        }
    }
}
