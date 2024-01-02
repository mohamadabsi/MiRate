using FluentValidation;
using Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Res = Localization.Resources.AppResources;

namespace Framework.Core.Application.Validators
{
    public static class SharedValidations
    {
        private static readonly Regex EnglishLettersOnly = new Regex(@"^[a-zA-Z\s _\-\/]*$");


        private static readonly Regex OnlyLettersAndNumbersRegEx = new Regex(@"^[a-zA-Z\s0-9 _,(){}.?\-\/]*$");

        private static readonly Regex OnlyLettersAndNumbersUsernameRegEx = new Regex(@"^[a-zA-Z\s0-9 @._\-\/]*$");
        
                private static readonly Regex ArabicCharOnly = new Regex(@"^[\u0621-\u064A\040]+$");

        private static readonly Regex ArabicLettersOnly = new Regex(@"^[\u0600-\u06FF\u003A\0-9s {}()?._\s _\-\/]{0,4000}$");

        private static readonly Regex ArabicLettersAndEnlgishOnly = new Regex(@"^[\u0600-\u06FF\u003A\0-9s _,(){}.?\-\/a-zA-Z\s _\-\/]{0,4000}$");

        private static readonly Regex ComplexPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$");

        private static readonly Regex OnlyNumbersRegEx = new Regex(@"^[0-9\.]*$");

        private static readonly Regex EmailAddressRegEx = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,50}$");

        private static readonly Regex UrlRegEx = new Regex(@"^(http)[(s) ?:\/\/(www\.)a-zA-Z0-9---@:%._\+~#=]{2,256}\.[a-zA-Z]{2,20}\b([-a-zA-Z0-9@:%_\+.~#?&\/=]*)$");

        private static readonly Regex OnlyUserWithDomainRegEx = new Regex(@"^[a-zA-Z0-9_.\\]*$");

        private static readonly Regex OnlyChar = new Regex(@"^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z ]{2,20}$");

        public static IRuleBuilderOptions<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.Matches(ComplexPassword)
                .WithMessage(AppLocalizer["PasswordIsNotComplex"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, string> OnlyLetters<T>(this IRuleBuilder<T, string> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.Matches(EnglishLettersOnly)
                .WithMessage(AppLocalizer["Message_LatinLetters"]);
            return rule;

        }

        public static IRuleBuilderOptions<T, string> OnlyChars<T>(this IRuleBuilder<T, string> ruleBuilder,
     IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.Matches(OnlyChar)
                .WithMessage(AppLocalizer["OnlyLettersRequired"]);
            return rule;

        }

        public static IRuleBuilderOptions<T, string> OnlyLettersAndNumbers<T>(this IRuleBuilder<T, string> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)

        {
            var rule = ruleBuilder.Matches(OnlyLettersAndNumbersRegEx)
                .WithMessage(AppLocalizer["Message_LatinLettersAndNumber"]);
            return rule;
        }


        public static IRuleBuilderOptions<T, string> OnlyLettersForUserName<T>(this IRuleBuilder<T, string> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)

        {
            var rule = ruleBuilder.Matches(OnlyLettersAndNumbersUsernameRegEx)
                .WithMessage(AppLocalizer["Message_LatinLettersAndNumber"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, string> OnlyArabicLetters<T>(this IRuleBuilder<T, string> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.Matches(ArabicLettersOnly)
                .WithMessage(AppLocalizer["OnlyArabicLetters"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, string> OnlyArabicLettersChar<T>(this IRuleBuilder<T, string> ruleBuilder,
        IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.Matches(ArabicCharOnly)
                .WithMessage(AppLocalizer["OnlyArabicLetters"]);
            return rule;
        }
        

        public static IRuleBuilderOptions<T, string> OnlyArabicOrEnglsihLetters<T>(this IRuleBuilder<T, string> ruleBuilder,
           IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.Matches(ArabicLettersAndEnlgishOnly)
                .WithMessage(AppLocalizer["OnlyArabicLetters"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, string> OnlyUserWithDomain<T>(this IRuleBuilder<T, string> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.Matches(OnlyUserWithDomainRegEx)
                .WithMessage(AppLocalizer["Message_LatinLettersAndNumber"]);
            return rule;
        }



        public static IRuleBuilderOptions<T, string> NoScriptAllowed<T>(this IRuleBuilder<T, string> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.Matches(@"^[^<>{}]+$")
                .WithMessage(AppLocalizer["ScriptsNotAllowedErrorMessage"]);
            return rule;
        }


        public static IRuleBuilderOptions<T, string> Required<T>(this IRuleBuilder<T, string> ruleBuilder, IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.NotEmpty()
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, Guid> Required<T>(this IRuleBuilder<T, Guid> ruleBuilder, IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.NotEmpty()
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, string> Url<T>(this IRuleBuilder<T, string> ruleBuilder, IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.Matches(UrlRegEx)
              .WithMessage(AppLocalizer[nameof(Res.Message_UrlNOtValid)]);
            return rule;


            //bool UrlIsValidUri(string url) => Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var outUri);

            //return ruleBuilder.Must(UrlIsValidUri).WithMessage(AppLocalizer[nameof(Res.Message_UrlNOtValid)]);
        }



        public static IRuleBuilderOptions<T, DateTime> Required<T>(this IRuleBuilder<T, DateTime> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.NotEmpty()
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, int?> Required<T>(this IRuleBuilder<T, int?> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.NotEmpty()
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, long?> Required<T>(this IRuleBuilder<T, long?> ruleBuilder,
          IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.NotEmpty()
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, int> Required<T>(this IRuleBuilder<T, int> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.NotEmpty()
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }
        public static IRuleBuilderOptions<T, long> Required<T>(this IRuleBuilder<T, long> ruleBuilder,
          IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.NotEmpty()
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }


        public static IRuleBuilderOptions<T, DateTime?> Required<T>(this IRuleBuilder<T, DateTime?> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.NotEmpty()
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, DateTime?> BeforeToDate<T>(this IRuleBuilder<T, DateTime?> ruleBuilder,
            Expression<Func<T, DateTime?>> toDateExpression,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.LessThan(toDateExpression).WithMessage(AppLocalizer["StartDateMustBeLessThanOrEqualToEndDate"]);

            return rule;
        }

        public static IRuleBuilderOptions<T, DateTime> BeforeToday<T>(this IRuleBuilder<T, DateTime> ruleBuilder
            , IStringLocalizer<AppResources> AppLocalizer,
            bool includeToday = true)
        {
            if (includeToday)
            {
                var rule1 = ruleBuilder.LessThanOrEqualTo(a => DateTime.Now)
                            .WithMessage(AppLocalizer["BeforeTodayMessage"]);
                return rule1;
            }
            var rule2 = ruleBuilder.LessThan(a => DateTime.Now)
            .WithMessage(AppLocalizer["BeforeTodayMessage"]);
            return rule2;
        }


        public static IRuleBuilderOptions<T, DateTime> DateGreaterThanDate<T>(this IRuleBuilder<T, DateTime> ruleBuilder
       , DateTime SecondDate, IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.GreaterThan(a => SecondDate)
            .WithMessage(AppLocalizer["MessageDateGreaterThanDate"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, DateTime> DateLessThanDate<T>(this IRuleBuilder<T, DateTime> ruleBuilder
        , DateTime SecondDate, IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.LessThan(a => SecondDate)
            .WithMessage(AppLocalizer["MessageDateLessThanDate"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, DateTime?> DateGreaterThanDate<T>(this IRuleBuilder<T, DateTime?> ruleBuilder
     , DateTime SecondDate, IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.GreaterThan(a => SecondDate)
            .WithMessage(AppLocalizer["MessageDateGreaterThanDate"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, DateTime?> DateLessThanDate<T>(this IRuleBuilder<T, DateTime?> ruleBuilder
        , DateTime SecondDate, IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.LessThan(a => SecondDate)
            .WithMessage(AppLocalizer["MessageDateLessThanDate"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, DateTime> AfterToday<T>(this IRuleBuilder<T, DateTime> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer,
            bool includeToday = true)
        {
            if (includeToday)
            {
                var rule1 = ruleBuilder.GreaterThanOrEqualTo(a => DateTime.Now)
                            .WithMessage(AppLocalizer["AfterTodayMessage"]);
                return rule1;
            }

            var rule2 = ruleBuilder.GreaterThan(a => DateTime.Now)
            .WithMessage(AppLocalizer["AfterTodayMessage"]);
            return rule2;
        }


        public static IRuleBuilderOptions<T, decimal> Required<T>(this IRuleBuilder<T, decimal> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.NotEmpty()
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }
        public static IRuleBuilderOptions<T, float> Required<T>(this IRuleBuilder<T, float> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.NotEmpty()
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }


        public static IRuleBuilderOptions<T, float> GreaterThanZero<T>(this IRuleBuilder<T, float> ruleBuilder,
          IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.GreaterThan(0)
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }
        public static IRuleBuilderOptions<T, float?> GreaterThanZero<T>(this IRuleBuilder<T, float?> ruleBuilder,
         IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.GreaterThan(0)
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, int> GreaterThanZero<T>(this IRuleBuilder<T, int> ruleBuilder,
        IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.GreaterThan(-1)
                .WithMessage(AppLocalizer["LessThanZeroValidationMessage"]);
            return rule;
        }
        public static IRuleBuilderOptions<T, int?> GreaterThanZero<T>(this IRuleBuilder<T, int?> ruleBuilder,
         IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.GreaterThan(0)
                .WithMessage(AppLocalizer["LessThanZeroValidationMessage"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, long> GreaterThanZero<T>(this IRuleBuilder<T, long> ruleBuilder,
      IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.GreaterThan(0)
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }
        public static IRuleBuilderOptions<T, long?> GreaterThanZero<T>(this IRuleBuilder<T, long?> ruleBuilder,
         IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.GreaterThan(0)
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }
        public static IRuleBuilderOptions<T, decimal> GreaterThanZero<T>(this IRuleBuilder<T, decimal> ruleBuilder,
         IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.GreaterThan(0)
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }


        public static IRuleBuilderOptions<T, decimal?> GreaterThanZero<T>(this IRuleBuilder<T, decimal?> ruleBuilder,
         IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.GreaterThan(0)
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, string> GreaterThanZero<T>(this IRuleBuilder<T, string> ruleBuilder,
       IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.Matches(@"0^[\d]+$")
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, List<R>> Required<T, R>(this IRuleBuilder<T, List<R>> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.NotEmpty()
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, Guid?> Required<T>(this IRuleBuilder<T, Guid?> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.NotEmpty()
                .WithMessage(AppLocalizer["Required"]);
            return rule;
        }
        public static IRuleBuilderOptions<T, string> OnlyNumbers<T>(this IRuleBuilder<T, string> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.Matches(@"^[0-9]*$")
                .WithMessage(AppLocalizer["NumberOnlyErrorMessage"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, string> OnlyNumbersD<T>(this IRuleBuilder<T, string> ruleBuilder,
           IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder.Matches(@"^-?[0-9]*\.?[0-9]+$")
                .WithMessage(AppLocalizer["NumberOnlyErrorMessage"]);
            return rule;
        }

        public static IRuleBuilderOptions<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
         
            var rule = ruleBuilder.Must(a => a.StartsWith("00966") || a.StartsWith("9200") || a.StartsWith("05"))
                .WithMessage(AppLocalizer["PhoneNumberErrorMessage"]).When(a=>a != null);
            return rule;
        }


        public static IRuleBuilderOptions<T, string> ValidateCommonRules<T>(this IRuleBuilder<T, string> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer, int maximumLength = 100, string value = "100")
        {
            var rule = ruleBuilder
                 .MaximumLength(maximumLength).WithMessage(string.Format(AppLocalizer["MaxLengthMessageError"], maximumLength));


            return rule;
        }

        public static IRuleBuilderOptions<T, string> MaxLenthCommonRules<T>(this IRuleBuilder<T, string> ruleBuilder, int lenth, IStringLocalizer<AppResources> AppLocalizer)
        {
            var rule = ruleBuilder
                 .MaximumLength(lenth)
                 .WithMessage(string.Format(AppLocalizer["MaxLengthMessageError"], lenth));
            return rule;
        }

        public static IRuleBuilderOptions<T, string> Email<T>(this IRuleBuilder<T, string> ruleBuilder,
            IStringLocalizer<AppResources> AppLocalizer)
        {
            
            var rule = ruleBuilder.Matches(EmailAddressRegEx)
                .WithMessage(AppLocalizer["InvalidEmailAddressMessage"]);
            return rule;
        }







    }


    public class StringValidator : AbstractValidator<string>
    {
        public StringValidator(IStringLocalizer<AppResources> AppLocalizer)
        {
            RuleFor(model => model).Matches(@"^[^<>{}]+$")
                .WithMessage(AppLocalizer["ScriptsNotAllowedErrorMessage"]);
        }
    }

}
