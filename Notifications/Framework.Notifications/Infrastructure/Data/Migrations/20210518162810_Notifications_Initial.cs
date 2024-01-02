using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Notifications");

            migrationBuilder.CreateTable(
                name: "NotificationSetting",
                schema: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationType",
                schema: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationQueue",
                schema: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendStatusCode = table.Column<int>(type: "int", nullable: true),
                    SendErrorMessage = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LastSendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NotificationTypeId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationQueue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationQueue_NotificationType_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalSchema: "Notifications",
                        principalTable: "NotificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTemplate",
                schema: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: true),
                    HTML = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    HTMLAr = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    NotificationTypeId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationTemplate_NotificationType_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalSchema: "Notifications",
                        principalTable: "NotificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Notifications",
                table: "NotificationSetting",
                columns: new[] { "Id", "ApplicationId", "CreatedBy", "CreatedOn", "Description", "IsActive", "IsDeleted", "Key", "NameAr", "NameEn", "Value" },
                values: new object[,]
                {
                    { 10, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "DisableSMSNotifications", null, "DisableSMSNotifications", "FALSE" },
                    { 140, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "ApplicationUrl", null, "ApplicationUrl", "http://localhost:44309/" },
                    { 130, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "EmailSubject", null, "EmailSubject", "Tasjeel Tech" },
                    { 120, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "ContactUsEmail", null, "ContactUsEmail", "Tasjeeltech@citc.gov.sa" },
                    { 110, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "EmailFromName", null, "EmailFromName", "Tasjeel Tech" },
                    { 100, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "EmailFromAddress", null, "EmailFromAddress", "Tasjeeltech@citc.gov.sa" },
                    { 80, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "SmtpPort", null, "SmtpPort", "587" },
                    { 90, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "SmtpEnableSSL", null, "SmtpEnableSSL", "FALSE" },
                    { 60, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "SmtpPassword", null, "SmtpPassword", "AzswQ@123753@zizadqhhdone" },
                    { 50, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "SmtpUserName", null, "SmtpUserName", "Tasjeeltech@citc.gov.sa" },
                    { 40, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "SmtpServer", null, "SmtpServer", "exch-array.citc.gov.sa" },
                    { 30, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "EmailSubjectAr", null, "EmailSubjectAr", "Tasjeel Tech" },
                    { 20, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "DisableEmailNotifications", null, "DisableEmailNotifications", "FALSE" },
                    { 70, "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "IsSmtpAuthenticated", null, "IsSmtpAuthenticated", "TRUE" }
                });

            migrationBuilder.InsertData(
                schema: "Notifications",
                table: "NotificationType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "IsActive", "IsDeleted", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 300, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "MobileNotification", "MobileNotification" },
                    { 100, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "Email", "Email" },
                    { 200, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "Sms", "Sms" },
                    { 400, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "WebNotification", "WebNotification" }
                });

            migrationBuilder.InsertData(
                schema: "Notifications",
                table: "NotificationTemplate",
                columns: new[] { "Id", "ApplicationId", "CreatedBy", "CreatedOn", "Description", "HTML", "HTMLAr", "IsActive", "IsDeleted", "NameAr", "NameEn", "NotificationTypeId", "Subject", "SubjectAr" },
                values: new object[,]
                {
                    { 101, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"rtl\"><head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <title>CITC</title>\r\n</head>\r\n<body dir=\"ltr\" style=\"padding:0px\">\r\n    <img src=\"{RootUrl}\\wwwroot\\CITC\\images\\email_header.jpg\" width=\"598\" class=\"email_header\" style=\"border:1px solid #ddd\">\r\n    <table width=\"600\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n        <tbody><tr>\r\n            <td class=\"email_conts\" style=\"padding:10px 20px;  font:11px Segoe UI,tahoma;  line-height:20px;  color:#404040;  text-align:right;  border:1px solid #eee;  border-top:none\">\r\n                <div dir=\"ltr\">\r\n				{body}\r\n</div>\r\n<div dir=\"rtl\">\r\n{bodyAr}\r\n</div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"email_footer\" width=\"600\" style=\"padding:10px 0;  background-color:#030062;  color:#fff;  font:11px Segoe UI,tahoma;  text-align:center\">\r\n                For your suggestions and comments, send us an e-mail: <a href=\"{ContactUsEmail}\" style=\"color:#fff;  font:11px Segoe UI,tahoma\">{ContactUsEmail}</a>\r\n            </td>\r\n        </tr>\r\n    </tbody></table>\r\n\r\n</body></html>", "<html xmlns=\"http://www.w3.org/1999/xhtml\" dir=\"rtl\"><head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n    <title>CITC</title>\r\n</head>\r\n<body dir=\"ltr\" style=\"padding:0px\">\r\n    <img src=\"{RootUrl}\\wwwroot\\CITC\\images\\email_header.jpg\" width=\"598\" class=\"email_header\" style=\"border:1px solid #ddd\">\r\n    <table width=\"600\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n        <tbody><tr>\r\n            <td class=\"email_conts\" style=\"padding:10px 20px;  font:11px Segoe UI,tahoma;  line-height:20px;  color:#404040;  text-align:right;  border:1px solid #eee;  border-top:none\">\r\n                <div dir=\"ltr\">\r\n				{body}\r\n</div>\r\n<div dir=\"rtl\">\r\n{bodyAr}\r\n</div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"email_footer\" width=\"600\" style=\"padding:10px 0;  background-color:#030062;  color:#fff;  font:11px Segoe UI,tahoma;  text-align:center\">\r\n                For your suggestions and comments, send us an e-mail: <a href=\"{ContactUsEmail}\" style=\"color:#fff;  font:11px Segoe UI,tahoma\">{ContactUsEmail}</a>\r\n            </td>\r\n        </tr>\r\n    </tbody></table>\r\n\r\n</body></html>", true, false, "EmailLayoutTemplate", "EmailLayoutTemplate", 100, "EmailLayoutTemplate", "EmailLayoutTemplate" },
                    { 2502, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "رمز التفعيل : {Code}  نأمل استخدام الرمز لتفعيل رقم الهاتف\r\n  \r\n Code : {Code} please use this code to activate your number", "رمز التفعيل : {Code}  نأمل استخدام الرمز لتفعيل رقم الهاتف\r\n  \r\n Code : {Code} please use this code to activate your number", true, false, "NumberCodeVerification", "NumberCodeVerification", 200, "Mobile Confirmation", "توثيق رقم الهاتف" },
                    { 2252, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "\"Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\nGreetings,\r\nKindly be informed that  the company profile has been suspended due to the  expiration of the registration.\r\nSo please login to the portal to apply profile renew request.\"", "\"Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\nGreetings,\r\nKindly be informed that  the company profile has been suspended due to the  expiration of the registration.\r\nSo please login to the portal to apply profile renew request.\"", true, false, "ProfileExpiredNotification", "ProfileExpiredNotification", 200, "Profile expired notification alert", "إشعار بالنتهاء صلاحية التسجيل" },
                    { 2242, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "\"Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\nGreetings,\r\nKindly be informed that tommorrow the company profile will be expired.\r\nSo please login to the portal to apply profile renew request.\"", "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\nيرجى العلم أنه باقى يوم على انتهاء صلاحية ملف الشرك .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة. \"", true, false, "ProfileExpiringNotification", "ProfileExpiringNotification", 200, "Profile expiring notification alert", "إشعار بانتهاء صلاحية التسجيل اليوم" },
                    { 2232, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "\"Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\nGreetings,\r\nKindly be informed that  the company profile will be expired after one month.\r\nSo please login to the portal to apply profile renew request.\"", "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\nيرجى العلم أنه باقى شهر على انتهاء صلاحية ملف الشرك .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة. \r\n \"", true, false, "ProfilePreExpirationNotification", "ProfilePreExpirationNotification", 200, "Profile pre expiration notification alert", "إشعار بقرب انتهاء صلاحية التسجيل" },
                    { 2222, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\nGreetings,\r\nKindly be informed that  the company profile has been suspended due to the  expiration of the commercial registery.\r\nSo please make sure that the commercial registery renewed and login to the portal to reactivate the profile again.", "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\n  يرجى العلم أنه تم  تعليق الملف التعريفي للشركة بسبب   انتهاء صلاحية السجل التجاري.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لإعادة تفعيل ملف الشركة\"", true, false, "CRExpiredNotification", "CRExpiredNotification", 200, "CR expired notification alert", "إشعار بانتهاء السجل التجاري" },
                    { 2212, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "\"Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\nGreetings,\r\nKindly be informed that tomorrow the company profile will be suspended due to the  expiration of the commercial registery.\r\nSo please make sure that the commercial registery renewed and login to the portal to update this information.\"", "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\nيرجى العلم أنه غدا سيتم تعليق الملف التعريفي للشركة بسبب انتهاء صلاحية السجل التجاري اليوم.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لتحديث هذه المعلومات. \"", true, false, "CRExpiringNotification", "CRExpiringNotification", 200, "CR expiring notification alert", "إشعار بانتهاء السحل التجاري اليوم" },
                    { 2202, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "\"Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\nGreetings,\r\nKindly be informed that the company profile will be suspended due to the near expiration of the commercial registery.\r\nSo please make sure that the commercial registery renewed and login to the portal to update this information.\"", "\"المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\nتحية طيبة،\r\nيرجى العلم أنه سيتم تعليق الملف التعريفي للشركة بسبب قرب انتهاء صلاحية السجل التجاري.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لتحديث هذه المعلومات.\r\n \"", true, false, "CRPreExpirationNotification", "CRPreExpirationNotification", 200, "CR pre expiration notification alert", "إشعار بقرب انتهاء السجل التجاري" },
                    { 2002, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nWe regret to inform you that your registration request with CITC is rejected for these reasons: {Reason} , You can review your request via the following link: {URL}", "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأسف لإبلاغكم برفض طلب التسجيل في منصة تسجيل الشركات بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{URL}.\r\n\r\n\r\n\r\n\r\nالأسباب :  {Reason}", true, false, "Submitter_RequestRejected", "Submitter_RequestRejected", 200, "Request status", "حالة طلب التسجيل" },
                    { 1902, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dear {UserFullNameEn}, the authorized person for the company {CompanyName}\r\n\r\nGreetings,\r\n\r\nKindly log in to the company registration platform to amend the notes received from the reviewers on your registration at CITC via the following link: {URL}", "المكرم {UserFullNameAr} المفوض لشركة {CompanyName}\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لتعديل الملاحظات الواردة على الطلب تسجيلكم في الهيئة عبر الرابط التالي: {URL}", true, false, "Submitter_RequestNeedsMoreInfo", "Submitter_RequestNeedsMoreInfo", 200, "Please review the registration request for some notes.", "حالة طلب التسجيل" },
                    { 1802, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dear {UserFullNameEn} Director of the Department\r\n\r\nGreetings,\r\n\r\nKindly log in to the company registration platform to approve the request to approve the registration request added to your assignment box via the following link: {URL}", "المكرم UserFullNameAr} مدير الإدارة\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم  بزيارة منصة تسجيل الشركات لاعتماد طلب التسجيل المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}", true, false, "Director_HasNewRequestToReview", "Director_HasNewRequestToReview", 200, "A request has been submitted for approval", "إرسال طلب للاعتماد" },
                    { 1702, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dear Admin. {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to the company registration platform to study the request to examine financial information added to your assignment box via the following link: {URL}", "المكرم {UserFullNameAr} المشرف\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة المعلومات المالية المضافة لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}", true, false, "Supervisor_ReviewerApprovedTheRequest", "Supervisor_ReviewerApprovedTheRequest", 200, "A request has been submitted for review", "تم إرسال طلب للمراجعة" },
                    { 1602, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dear {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to the company registration platform to study the request to register a company added to your assignment box via the following link: {URL}", "المكرم {UserFullNameAr}\r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب تسجيل شركة المضاف لصندوق المهام الخاص بكم عبر الرابط التالي:{URL}", true, false, "Reviewer_AssignedOnRequestToReview", "Reviewer_AssignedOnRequestToReview", 200, "You have a new request to study", "طلب جديد للدراسة" },
                    { 1502, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dear Admin. {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nKindly log in to the company registration platform to study the request to attend a session added to your assignment box via the following link: {URL}", "المكرم {UserFullNameAr} المشرف \r\n\r\nتحية طيبة،\r\n\r\nنأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب حضور جلسة المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}", true, false, "Supervisor_RequestSubmittedWaitingForReview", "Supervisor_RequestSubmittedWaitingForReview", 200, "A request has been submitted for review", "تم إرسال طلب للمراجعة" },
                    { 1402, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dear {UserFullNameEn}\r\n\r\nGreetings,\r\n\r\nYour request has been successfully submitted , and it will be studied and answered within 15 days", "المكرم {UserFullNameAr}\r\n\r\nتحية طيبة،\r\n\r\nتمت إرسال طلبك بنجاح وستتم دراسته والرد عليكم خلال 15 يومًا من تاريخ تقديم الطلب.", true, false, "Submitter_RequestSubmittedSucessfully", "Submitter_RequestSubmittedSucessfully", 200, "Your request has been submitted", "تم إرسال طلبك بنجاح" },
                    { 4001, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dear {UserFullName} / Company {CompanyName}\r\n\r\n{Body}", "Dear {UserFullName} / Company {CompanyName}\r\n\r\n{Body}", true, false, "CompaniesMessageNotification", "CompaniesMessageNotification", 100, "Companies Messages Notification", "رسائل الشركات" },
                    { 3101, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<p>Dear {UserFullNameEn}</p>\r\n<p>Greetings,</p>\r\n<p>Please note that there are late request with number ({RequestNumber}) that no action has been taken on them yet .... Kindly take the necessary action ..</p>", "<p style=\"direction: rtl;\">المكرم {UserFullNameEn}</p>\r\n<p style=\"direction: rtl;\">تحية طيبة،</p>\r\n<p style=\"direction: rtl;\">نفيدكم بوجود طلب متأخر برقم {RequestNumber} لم يتم اتخاذ إجراء بشأنها بعد.... نأمل اتخاذ اللازم ..</p>", true, false, "EscalationReminderTemplate", "EscalationReminderTemplate", 100, "Request Escalated", "تم تصعيد الطلب" },
                    { 3001, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<p>Dear {UserFullNameEn}</p>\r\n<p>Greetings,</p>\r\n<p>Please note that there are late request with number ({RequestNumber}) that no action has been taken on them yet .... Kindly take the necessary action ..</p>", "<p style=\"direction: rtl;\">المكرم {UserFullNameEn}</p>\r\n<p style=\"direction: rtl;\">تحية طيبة،</p>\r\n<p style=\"direction: rtl;\">نفيدكم بوجود طلب متأخر برقم {RequestNumber} لم يتم اتخاذ إجراء بشأنها بعد.... نأمل اتخاذ اللازم ..</p>", true, false, "EscalationTemplate", "EscalationTemplate", 100, "Request Escalated", "تم تصعيد الطلب" },
                    { 1401, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n<p style=\"text-align: left;\">Your request has been successfully submitted , and it will be studied and answered within 15 days</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n<p>تمت إرسال طلبك بنجاح وستتم دراسته والرد عليكم خلال 15 يومًا من تاريخ تقديم الطلب.</p> \r\n            </h3>", true, false, "Submitter_RequestSubmittedSucessfully", "Submitter_RequestSubmittedSucessfully", 100, "Your request has been submitted", "تم إرسال طلبك بنجاح" },
                    { 1501, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear Admin. {Name}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n<p style=\"text-align: left;\">Kindly log in to the company registration platform to study the request to attend a session added to your assignment box via the following link: {URL}</p><h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المشرف</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب حضور جلسة المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}</p> \r\n            </h3>", true, false, "Supervisor_RequestSubmittedWaitingForReview", "Supervisor_RequestSubmittedWaitingForReview", 100, "A request has been submitted for review", "تم إرسال طلب للمراجعة" },
                    { 1601, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear Admin {UserFullNameEn}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to the company registration platform to study the request to attend a session added to your assignment box via the following link: {URL}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المشرف</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة طلب حضور جلسة المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}</p> \r\n            </h3>", true, false, "Reviewer_AssignedOnRequestToReview", "Reviewer_AssignedOnRequestToReview", 100, "You have a new request to study", "طلب جديد للدراسة" },
                    { 1701, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear Admin {UserFullNameEn}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to the company registration platform to study the request to examine financial information added to your assignment box via the following link: {URL}\r\n    </p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المشرف</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لدراسة المعلومات المالية المضافة لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}</p> \r\n            </h3>", true, false, "Supervisor_ReviewerApprovedTheRequest", "Supervisor_ReviewerApprovedTheRequest", 100, "A request has been submitted for review", "تم إرسال طلب للمراجعة" },
                    { 1801, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn} Director of the Department</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to the company registration platform to approve the request to approve the registration request added to your assignment box via the following link: {URL}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} مدير الإدارة</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p >نأمل منكم التكرم &nbsp;بزيارة منصة تسجيل الشركات لاعتماد طلب التسجيل المضاف لصندوق المهام الخاص بكم عبر الرابط التالي: {URL}</p> \r\n            </h3>", true, false, "Director_HasNewRequestToReview", "Director_HasNewRequestToReview", 100, "A request has been submitted for approval", "إرسال طلب للاعتماد" },
                    { 1901, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">Kindly log in to the company registration platform to amend the notes received from the reviewers on your registration at CITC via the following link: {URL}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأمل منكم التكرم بزيارة منصة تسجيل الشركات لتعديل الملاحظات الواردة على الطلب تسجيلكم في الهيئة عبر الرابط التالي: {URL}</p> \r\n            </h3>", true, false, "Submitter_RequestNeedsMoreInfo", "Submitter_RequestNeedsMoreInfo", 100, "Please review the registration request for some notes.", "حالة طلب التسجيل" },
                    { 3002, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dear {UserFullNameEn}\r\nGreetings,\r\nPlease note that there are late request with number ({RequestNumber}) that no action has been taken on them yet .... Kindly take the necessary action ..", "السيد المكرم {UserFullNameEn}\r\n\r\nتحية طيبة،\r\n\r\nنفيدكم بوجود طلب متأخر برقم {RequestNumber} لم يتم اتخاذ إجراء بشأنها بعد.... نأمل اتخاذ اللازم ..", true, false, "EscalationTemplate", "EscalationTemplate", 200, "Request Escalated", "تم تصعيد الطلب" },
                    { 2001, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}, the authorized person for the company {CompanyName}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n    <p style=\"text-align: left;\">We regret to inform you that your registration request with CITC is rejected for these reasons: {Reason} , You can review your request via the following link: {URL}</p>\r\n</h3>", "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"text-align:justify;font-weight:normal;\">تحية طيبة،\r\n    <p>نأسف لإبلاغكم برفض طلب التسجيل في منصة تسجيل الشركات بهيئة الاتصالات وتقنية المعلومات. للاطلاع على تفاصيل الرفض والملاحظات:{URL}.</p> \r\n    <p>&nbsp;</p> \r\n    <p>الأسباب :&nbsp; {Reason}</p> \r\n\r\n            </h3>", true, false, "Submitter_RequestRejected", "Submitter_RequestRejected", 100, "Request status", "حالة طلب التسجيل" },
                    { 2211, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "\"<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\"> Dear {UserFullNameEn}, the authorized person for the company {CompanyName} </h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\"> Greetings.  ،\r\n    <p>\r\nKindly be informed that tomorrow the company profile will be suspended due to the  expiration of the commercial registery.\r\nSo please make sure that the commercial registery renewed and login to the portal to update this information.</p> \r\n            </h3>\"", "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n <p>\r\nيرجى العلم أنه غدا سيتم تعليق الملف التعريفي للشركة بسبب انتهاء صلاحية السجل التجاري اليوم.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لتحديث هذه المعلومات.\r\n</p> \r\n            </h3>\"", true, false, "CRExpiringNotification", "CRExpiringNotification", 100, "CR expiring notification alert", "إشعار بانتهاء السحل التجاري اليوم" },
                    { 2221, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "\"<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\"> Dear {UserFullNameEn}, the authorized person for the company {CompanyName} </h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\"> Greetings.  ،\r\n    <p>\r\nKindly be informed that  the company profile has been suspended due to the  expiration of the commercial registery.\r\nSo please make sure that the commercial registery renewed and login to the portal to reactivate the profile again.</p> \r\n            </h3>\"", "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n <p>\r\nيرجى العلم أنه تم  تعليق الملف التعريفي للشركة بسبب   انتهاء صلاحية السجل التجاري.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لإعادة تفعيل ملف الشركة.\r\n</p> \r\n            </h3>\"", true, false, "CRExpiredNotification", "CRExpiredNotification", 100, "CR expired notification alert", "إشعار بانتهاء السجل التجاري" },
                    { 2231, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n <p>\r\nيرجى العلم أنه باقى شهر على انتهاء صلاحية ملف الشرك .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة.\r\n</p> \r\n            </h3>\"", "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n <p>\r\nيرجى العلم أنه باقى شهر على انتهاء صلاحية ملف الشرك .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة.\r\n</p> \r\n            </h3>\"", true, false, "ProfilePreExpirationNotification", "ProfilePreExpirationNotification", 100, "Profile pre expiration notification alert", "إشعار بقرب انتهاء صلاحية التسجيل" },
                    { 2241, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "\"<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\"> Dear {UserFullNameEn}, the authorized person for the company {CompanyName} </h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\"> Greetings. \r\n    <p>\r\nKindly be informed that tommorrow the company profile will be expired.\r\nSo please login to the portal to apply profile renew request.\r\n</p> \r\n            </h3>\"", "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n <p>\r\nيرجى العلم أنه باقى يوم على انتهاء صلاحية ملف الشرك .\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة.\r\n</p> \r\n            </h3>\"", true, false, "ProfileExpiringNotification", "ProfileExpiringNotification", 100, "Profile expiring notification alert", "إشعار بانتهاء صلاحية التسجيل اليوم" },
                    { 2251, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "\"<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\"> Dear {UserFullNameEn}, the authorized person for the company {CompanyName} </h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\"> Greetings. \r\n    <p>\r\nKindly be informed that  the company profile has been suspended due to the  expiration of the registration.\r\nSo please login to the portal to apply profile renew request.</p> \r\n            </h3>\"", "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n <p>\r\nيرجى العلم أنه تم  تعليق الملف التعريفي للشركة بسبب انتهاء صلاحية التسجيل.\r\nلذا يرجى  الدخول إلى البوابة لتقديم طلب تجديد لملف الشركة.\r\n</p> \r\n            </h3>\"", true, false, "ProfileExpiredNotification", "ProfileExpiredNotification", 100, "Profile expired notification alert", "إشعار بالنتهاء صلاحية التسجيل" },
                    { 2401, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<h2 style=\"color: #030062; font-size: 15px; line-height: 25px; text-align: justify; font-weight: bold;\">Dear {NameEn}</h2>\r\n<h3 style=\"text-align: justify; font-weight: normal;\">Greetings,</h3>\r\n<p style=\"text-align: left;\">Kindly use the following code to activate your email {Code} so you can keep procced</p>", "<h2 style=\"color: #030062; font-size: 15px; line-height: 25px; text-align: justify; font-weight: bold;\">المكرم {NameAr} \r\n<h3 style=\"text-align: justify; font-weight: normal;\">تحية طيبة،</h3>\r\n<p>.الرجاء إستخدام الرمز التالي لتفعيل البريد الإلكتروني {Code} </p>", true, false, "EmailCodeVerification", "EmailCodeVerification", 100, "Email confirmation", "توثيق البريد الإلكتروني" },
                    { 2201, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "\"<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\"> Dear {UserFullNameEn}, the authorized person for the company {CompanyName} </h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n    <p>Kindly be informed that the company profile will be suspended due to the near expiration of the commercial registery.\r\nSo please make sure that the commercial registery renewed and login to the portal to update this information.\r\n</p> \r\n            </h3>\"", "\"\r\n<h2 style=\"\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\"\">  المكرم {UserFullNameAr} المفوض لشركة {CompanyNameAr}</h2>\r\n            <h3 style=\"\"text-align:justify;font-weight:normal;\"\">تحية طيبة،\r\n    <p>يرجى العلم أنه سيتم تعليق الملف التعريفي للشركة بسبب قرب انتهاء صلاحية السجل التجاري.\r\nلذا يرجى التأكد من تجديد السجل التجاري والدخول إلى البوابة لتحديث هذه المعلومات.</p> \r\n            </h3>\"", true, false, "CRPreExpirationNotification", "CRPreExpirationNotification", 100, "CR pre expiration notification alert", "إشعار بقرب انتهاء السجل التجاري" },
                    { 3102, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dear {UserFullNameEn}\r\nGreetings,\r\nPlease note that there are late request with number ({RequestNumber}) that no action has been taken on them yet .... Kindly take the necessary action ..", "السيد المكرم {UserFullNameEn}\r\n\r\nتحية طيبة،\r\n\r\nنفيدكم بوجود طلب متأخر برقم {RequestNumber} لم يتم اتخاذ إجراء بشأنها بعد.... نأمل اتخاذ اللازم ..", true, false, "EscalationReminderTemplate", "EscalationReminderTemplate", 200, "Request Escalated", "تم تصعيد الطلب" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationQueue_NotificationTypeId",
                schema: "Notifications",
                table: "NotificationQueue",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTemplate_NotificationTypeId",
                schema: "Notifications",
                table: "NotificationTemplate",
                column: "NotificationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationQueue",
                schema: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationSetting",
                schema: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationTemplate",
                schema: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationType",
                schema: "Notifications");
        }
    }
}
