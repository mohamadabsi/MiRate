using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_AddApproveNotificationTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Notifications",
                table: "NotificationTemplate",
                columns: new[] { "Id", "ApplicationId", "CreatedBy", "CreatedOn", "Description", "HTML", "HTMLAr", "IsActive", "IsDeleted", "NameAr", "NameEn", "NotificationTypeId", "Subject", "SubjectAr" },
                values: new object[] { 2051, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">We are pleased to inform you that your {RequestType} request with CITC is approved  , You can review your request via the following link: {ExternalUrl}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نسعد لإبلاغكم بقبول طلب {RequestTypeAr} في منصة تسجيل الشركات بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الطلب والملاحظات:{ExternalUrl}.</p> \r\n \r\n            </h3>", true, false, "Submitter_RequestApproved", "Submitter_RequestApproved", 100, "Request status", "حالة طلب التسجيل" });

            migrationBuilder.InsertData(
                schema: "Notifications",
                table: "NotificationTemplate",
                columns: new[] { "Id", "ApplicationId", "CreatedBy", "CreatedOn", "Description", "HTML", "HTMLAr", "IsActive", "IsDeleted", "NameAr", "NameEn", "NotificationTypeId", "Subject", "SubjectAr" },
                values: new object[] { 2052, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nWe are please to inform you that your {RequestType} request with CITC is approved , You can review your request via the following link: {ExternalUrl}", "المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}\r\n\r\nتحية طيبة،\r\n\r\nيسعدنا لإبلاغكم بقبول طلب {RequestTypeAr} في منصة تسجيل الشركات بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الطلب والملاحظات:{ExternalUrl}.\r\n\r\n ", true, false, "Submitter_RequestApproved", "Submitter_RequestApproved", 200, "Request status", "حالة طلب التسجيل" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2051);

            migrationBuilder.DeleteData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 2052);
        }
    }
}
