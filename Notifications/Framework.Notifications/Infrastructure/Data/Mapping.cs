using Framework.Core.Base;
using Framework.Core.Data.Mapping;
using Framework.Core.Extensions;
using Framework.Notifications.Entities;
using Framework.Notifications.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Resources;

namespace Framework.Notifications.Data
{

    public class NotificationEmailDetailsMapping : EntityTypeConfiguration<NotificationQueue>
    {
        public override void Configure(EntityTypeBuilder<NotificationQueue> builder)
        {
            builder.ToTable(nameof(NotificationQueue), "Notifications");
            builder.Property(d => d.Message).HasMaxLength(5000);
            builder.Property(d => d.SendErrorMessage).HasMaxLength(1000);
        }
    }
    public class NotificationTypeMapping : EntityTypeConfiguration<NotificationType>
    {
        public override void Configure(EntityTypeBuilder<NotificationType> builder)
        {
            builder.ToTable(nameof(NotificationType), "Notifications");

            var list = typeof(NotificationTypes).GetEnumLookups();
            builder.HasData(list);
        }
    }
    public class NotificationSettingsMapping : EntityTypeConfiguration<NotificationSetting>
    {
        public override void Configure(EntityTypeBuilder<NotificationSetting> builder)
        {
            builder.ToTable(nameof(NotificationSetting), "Notifications");

            builder.HasData(new NotificationSetting(10,  "DisableSMSNotifications", "FALSE"));
            builder.HasData(new NotificationSetting(20,  "DisableEmailNotifications", "FALSE"));
            builder.HasData(new NotificationSetting(30,  "EmailSubjectAr", "Tasjeel Tech"));
            builder.HasData(new NotificationSetting(40,  "SmtpServer", "exch-array.citc.gov.sa"));
            builder.HasData(new NotificationSetting(50,  "SmtpUserName", "Tasjeeltech@citc.gov.sa"));
            builder.HasData(new NotificationSetting(60,  "SmtpPassword", "AzswQ@123753@zizadqhhdone"));
            builder.HasData(new NotificationSetting(70,  "IsSmtpAuthenticated", "TRUE"));
            builder.HasData(new NotificationSetting(80,  "SmtpPort", "587"));
            builder.HasData(new NotificationSetting(90,  "SmtpEnableSSL", "FALSE"));
            builder.HasData(new NotificationSetting(100, "EmailFromAddress", "Tasjeeltech@citc.gov.sa"));
            builder.HasData(new NotificationSetting(110, "EmailFromName", "Tasjeel Tech"));
            builder.HasData(new NotificationSetting(120, "ContactUsEmail", "Tasjeeltech@citc.gov.sa"));
            builder.HasData(new NotificationSetting(130, "EmailSubject", "Tasjeel Tech"));
            builder.HasData(new NotificationSetting(140, "ApplicationUrl", "http://localhost:44309/"));
        }
    }
    public class NotificationTemplateMapping : EntityTypeConfiguration<NotificationTemplate>
    {
        private static global::System.Globalization.CultureInfo resourceCulture;
        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = 
                        new global::System.Resources.ResourceManager("Framework.Notifications.NotificationTemplatesRes",
                                                                     typeof(NotificationTemplatesRes).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        public override void Configure(EntityTypeBuilder<NotificationTemplate> builder)
        {
            builder.ToTable(nameof(NotificationTemplate), "Notifications");                        


            builder.Property(et => et.HTML).HasMaxLength(5000);
             

            SeedTemplates(builder);
        }



        /// <summary>
        /// Auto seed for notifications templates by adding it in the notifications resoureces follwoing the naming rules
        /// and add the same base name in the enum of the notifications templates.
        /// </summary>
        /// <Description>
        /// It will loop on the enum items and get the template from the resource file by the enum item name if the i == 1 if the i == 2 it will get the sms 
        /// templates based on the same base name 
        /// </Description>
        /// <param name="builder"></param>
        private static void SeedTemplates(EntityTypeBuilder<NotificationTemplate> builder)
        {

            var Templates = typeof(NotificationTemplates).GetEnumLookups();
            
            var ToSeedLst = new List<NotificationTemplate>();

            foreach (var item in Templates)
            {
                FillTemplate(ToSeedLst, item, NotificationTypes.Email);

                FillTemplate(ToSeedLst, item, NotificationTypes.Sms);

            }
            builder.HasData(ToSeedLst);

        }

        private static void FillTemplate(List<NotificationTemplate> ToSeedLst, LookupEntityBase item, NotificationTypes notificationType)
        {
            var NotificationTemp = new NotificationTemplate
            {
                Subject = item.NameEn,
                SubjectAr = item.NameAr,
                IsActive = true,
                IsDeleted = false,
                NameEn = item.Value,
                NotificationTypeId = (int)notificationType,
                NameAr = item.Value,
            };
            switch (notificationType)
            {
                case NotificationTypes.Email:
                    NotificationTemp.Id = item.Id+1;
                    NotificationTemp.HTML = ResourceManager.GetString(item.Value, resourceCulture);
                    NotificationTemp.HTMLAr = ResourceManager.GetString(item.Value + "Ar", resourceCulture);
                    break;
                case NotificationTypes.Sms:
                    NotificationTemp.Id = item.Id + 2;
                    NotificationTemp.HTML = ResourceManager.GetString(item.Value + "SMS", resourceCulture);
                    NotificationTemp.HTMLAr = ResourceManager.GetString(item.Value + "SMSAr", resourceCulture);
                    break;
                case NotificationTypes.MobileNotification:
                    break;
             
            }
            if (NotificationTemp.HTML == item.Value || 
                NotificationTemp.HTML == null ||
                NotificationTemp.HTMLAr == null)
            {
                return;
            }
            ToSeedLst.Add(NotificationTemp);
        }
    }

}
