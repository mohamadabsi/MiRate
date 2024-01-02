using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Notifications.Infrastructure.Data.Migrations
{
    public partial class Notifications_FixNotificationTemplat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1501,
                column: "HTML",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {UserFullNameEn}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n<p style=\"text-align: left;\">Kindly log in to Mannasah platform to study the request to attend a session added to your assignment box via the following link: {InternalUrl}</p><h3>");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Notifications",
                table: "NotificationTemplate",
                keyColumn: "Id",
                keyValue: 1501,
                column: "HTML",
                value: "<h2 style=\"color:#030062; font-size:15px; line-height:25px; text-align:justify;font-weight:bold;\">Dear {Name}</h2>\r\n<h3 style=\"text-align:justify;font-weight:normal;\">Greetings,\r\n<p style=\"text-align: left;\">Kindly log in to Mannasah platform to study the request to attend a session added to your assignment box via the following link: {InternalUrl}</p><h3>");
        }
    }
}
