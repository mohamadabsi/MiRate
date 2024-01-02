// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeSmsService.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Framework.Core.Utils;
using Framework.Notifications.ViewModels;
using System.Threading.Tasks;

namespace Framework.Notifications.Services
{
    /// <summary>
    ///     The default sms service.
    /// </summary>
    public class SmsService : ISmsService
    {
        private readonly IRestProxy restProxy;

        public SmsService(IRestProxy restProxy)
        {
            this.restProxy = restProxy;
        }
        /// <summary>
        /// The send sms.
        /// </summary>
        /// <param name="smsMessage">
        /// The sms message.
        /// </param>
        /// <param name="notificationSettings">
        /// The notification settings.
        /// </param>


        public async Task<SendSMSResponse> SendSms(SmsMessage smsMessage)
        {
            this.restProxy.InitializeConfiguration("CITC_SMS");

            var message = new CITCSMSMessage(this.restProxy.Config, mobile: smsMessage.PhoneNumber, smsMessage.Text, "1");

           var response = await this.restProxy.Post<SendSMSResponse, CITCSMSMessage>(message, "SMSService/SendSMS");

            return response; 
        }
    }

    public class CITCSMSMessage
    {


        public CITCSMSMessage(ProxyConfiguration config, string mobile, string message, string tag)
        {
            this.UserAccount = config.ApiUserName;
            this.Password = config.ApiUserPassword;
            this.Mobile = mobile;
            this.Message = message;
            this.Tag = tag;
            this.SendDateTime = "0";
        }

        public string UserAccount { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Message { get; set; }
        public string Tag { get; set; }
        public string SendDateTime { get; set; }
    }


    public class SendSMSResponse
    {
        public string[] Errors { get; set; }
        public int ErrorsCount { get; set; }
        public Result Result { get; set; }
    }

    public class Result
    {
        public int SMSID { get; set; }
        public string Description { get; set; }
    }
}