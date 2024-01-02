// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enums.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Framework.Core.DataAnnotations;

namespace Framework.Core
{
    /// <summary>
    /// The calendar type.
    /// </summary>
    public enum CalendarType
    {
        /// <summary>
        ///     The ummalqura.
        /// </summary>
        ummalqura,

        /// <summary>
        ///     The gregorian.
        /// </summary>
        gregorian
    }

    public enum ListViewMode
    {
        Grid,
        Cards,
        Calender
    }

    public enum YesNo
    {
        [LookupLocalization("نعم", "Yes")]
        Yes = 0,
        [LookupLocalization("لا", "No")]
        No = 1
    }
    public enum ControlDirections
    {
        Left,
        Right,
        None
    }
    public enum ViewModes
    {
        New,
        Edit,
        View,
        Display,
        Review,
        Search,
        Returned

    }

    public enum SaveModes   
    {
        Draft,
        Submit

    }

    public enum SystemUserRole
    {
        [LookupLocalization("مدير النظام", "System Admin")]
        SystemAdmin = 100,

        [LookupLocalization("مدير حساب الشركة", "Company Account Manager")]
        CompanyAccountManager = 200,

        [LookupLocalization("المدير العام للادارة", "General Manager")]
        ItDirector = 400,

        [LookupLocalization("مشرف ادارة تقنية المعلومات", "Information Technology Department Supervisor")]
        ItSupervisor = 600,

        [LookupLocalization("مراجع ", "Reviewer")]
        Reviewer = 700,

        [LookupLocalization("قطاعات الهيئة  ", "Sectors of the Authority")]
        Sector = 500,
        [LookupLocalization("مسؤول برامج الدعم", "Support Program Offical")]
        SupportProgramOfficial = 800,
        [LookupLocalization("مدير إدارة برامج الدعم", "Support Program Manager")]
        SupportProgramOfficer = 850,
        [LookupLocalization("مسؤول التواصل", "Communication officer")]
        CommunicationOfficer = 900

    }


    /// <summary>
    ///     The number type.
    /// </summary>
    public enum NumberType
    {
        /// <summary>
        ///     The fixe d_ line.
        /// </summary>
        FIXED_LINE,

        /// <summary>
        ///     The mobile.
        /// </summary>
        MOBILE,

        /// <summary>
        ///     The fixe d_ lin e_ o r_ mobile.
        /// </summary>
        FIXED_LINE_OR_MOBILE,

        /// <summary>
        ///     The tol l_ free.
        /// </summary>
        TOLL_FREE,

        /// <summary>
        ///     The premiu m_ rate.
        /// </summary>
        PREMIUM_RATE,

        /// <summary>
        ///     The share d_ cost.
        /// </summary>
        SHARED_COST,

        /// <summary>
        ///     The voip.
        /// </summary>
        VOIP,

        /// <summary>
        ///     The persona l_ number.
        /// </summary>
        PERSONAL_NUMBER,

        /// <summary>
        ///     The pager.
        /// </summary>
        PAGER,

        /// <summary>
        ///     The uan.
        /// </summary>
        UAN,

        /// <summary>
        ///     The voicemail.
        /// </summary>
        VOICEMAIL,

        /// <summary>
        ///     The unknown.
        /// </summary>
        UNKNOWN
    }

    /// <summary>
    /// The check list item type.
    /// </summary>
    public enum CheckListItemType
    {
        /// <summary>
        /// The sector.
        /// </summary>
        Sector,

        /// <summary>
        /// The sub sector.
        /// </summary>
        SubSector,

        /// <summary>
        /// The exam.
        /// </summary>
        Exam,

        /// <summary>
        /// The course.
        /// </summary>
        Course,

        /// <summary>
        /// The competency.
        /// </summary>
        Competency,

        /// <summary>
        /// The competency element.
        /// </summary>
        CompetencyElement,

        /// <summary>
        /// The performance criteria.
        /// </summary>
        PerformanceCriteria,

        /// <summary>
        /// The assessment judgment.
        /// </summary>
        AssessmentJudgment,

        /// <summary>
        /// The expert.
        /// </summary>
        Expert,

        /// <summary>
        /// The folder.
        /// </summary>
        Folder,

        /// <summary>
        /// The sub folder.
        /// </summary>
        SubFolder,

        /// <summary>
        /// The period.
        /// </summary>
        Period,

        /// <summary>
        /// The organization.
        /// </summary>
        Organization,

        /// <summary>
        /// The event
        /// </summary>
        Event,

        /// <summary>
        /// The exam profile.
        /// </summary>
        ExamProfile,
    }

    public enum FormatEnum
    {
        Json = 1,
        xlsx = 2,
        Pdf = 3,
        Word = 4,
        Html = 5,
        Xml = 6
    }

    public enum FormatType
    {
        A4,
        A3,
        Letter
    }

    public enum OrientationEnum
    {
        Portrait = 0,
        Landscape = 1
    }

    public enum CreatorEnum
    {
        [LookupLocalization("مستخدم", "EmployeeUser")]
        EmployeeUser = 0,
        [LookupLocalization("شركة", "CompanyUser")]
        CompanyUser = 1
    }

    public enum TypeEnum
    {
        [LookupLocalization("فرد", "Single")]
        Single = 0,
        [LookupLocalization("مجموعة", "Group")]
        Group = 1
    }

    public enum TypeReceivedEnum
    {
        [LookupLocalization("الكل", "All")]
        All = 0,
        [LookupLocalization("المستلمة", "Received")]
        Received = 1,
        [LookupLocalization("غير مستلمة", "Not Received")]
        NotReceived = 2
    }


    public enum ActionEnum
    {  
        [LookupLocalization("تسجيل الدخول داخلى", "Login Internal")]
        LoginInternal = 1,
        [LookupLocalization("تسجيل الدخول خارجى", "Login External")]
        LoginExternal = 2,
        [LookupLocalization("تحميل ملف", "Upload File")]
        UploadAttachment = 3,
        [LookupLocalization("تنزيل ملف", "Download File")]
        Download = 4
    }

    public enum ActionLogsEnum
    {
        [LookupLocalization("تسجيل الدخول داخلى", "Login Internal")]
        LoginInternal = 1,
        [LookupLocalization("تسجيل الدخول خارجى", "Login External")]
        LoginExternal = 2,
        [LookupLocalization("مستخدم جهات ذات علاقة", "Related user")]
        RelatedUser = 4,
        [LookupLocalization("تغير الصلاحيات", "Change Rules")]
        ChangeRules = 5
    }

    public enum ActionLogsFilterEnum
    {
        [LookupLocalization("تسجيل الدخول داخلى", "Login Internal")]
        LoginInternal = 1,
        [LookupLocalization("تسجيل الدخول خارجى", "Login External")]
        LoginExternal = 2,
        [LookupLocalization("مستخدم جهات ذات علاقة", "Related user")]
        RelatedUser = 4
    }

    public enum FilterDateEnum
    {
        [LookupLocalization("ترتيب بناء على اخر اضافة", "Created On")]
        CreatedOn = 1,
        [LookupLocalization("ترتيب بناء على اخر التعديلات", "Updated On")]
        UpdatedOn = 2
    }

    public enum SortEnum
    {
        [LookupLocalization("تصاعدي", "Ascending")]
        Ascending = 1,
        [LookupLocalization("تنازلي", "Descending")]
        Descending = 2
    }

    public enum ExportType
    {
        Pdf = 1,
        Excel = 2
    }

    public enum OperationLogEnum
    {
        Add = 1,
        Update=2,
        Delete = 3
    }


    public enum OperationStatusEnum
    {
        [LookupLocalization("مفعل", "Active")]
        Active = 1,
        [LookupLocalization("غير مفعل", "InActive")]
        InActive = 2
    }
}