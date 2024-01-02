using Framework.Core.DataAnnotations;

namespace Framework.Core.Contracts
{
    public enum RequestTypes
    {
        [LookupLocalization("طلب تسجيل شركة", "Profile registration request")]
        Registration = 100,

        [LookupLocalization("تذكرة", "Ticket")]
        Ticket = 200,

        [LookupLocalization("طلب تعديل ملف الشركة", "Profile edit request")]
        Edit = 300,

        [LookupLocalization("طلب تجديد ملف الشركة", "Profile renew request")]
        Renew = 400,

        [LookupLocalization("طلب إلغاء ملف الشركة", "Cancel Profile Request")]
        Cancel = 500,
        [LookupLocalization("تسجيل برنامج الدعم", "Support Program")]
        SupportProgram = 600,

        [LookupLocalization("تسجيل منتج", "Product Request")]
        ProductRequest = 700
    }
}
