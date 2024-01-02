using FluentValidation;
using System;

namespace Framework.Core.Ddd.Application
{
    public class DomainVaidatorBase<T> : AbstractValidator<T>,IDomainVaidator<T>
    {
        protected bool GreaterThanToday(DateTime requestedDate)
        {
            return requestedDate.Date > CommonsSettings.CurrentDate;
        }
        protected bool GreaterThanOrEqualToday(DateTime requestedDate)
        {
            return requestedDate.Date >= CommonsSettings.CurrentDate;
        }
      
        protected bool HasValidMobileNumber(string mobile)
        {
            return true;
            if (string.IsNullOrEmpty(mobile))
                return true;
            return Framework.Core.Utils.PhoneNumbers.IsValidNumber(mobile, Framework.Core.NumberType.MOBILE);
        }
        protected bool HasValidOfficeNumber(string dvm)
        {
            return true;
            if (string.IsNullOrEmpty(dvm))
                return true;
            return Framework.Core.Utils.PhoneNumbers.IsValidNumber(dvm, Framework.Core.NumberType.FIXED_LINE_OR_MOBILE);
        }
     
    }

}