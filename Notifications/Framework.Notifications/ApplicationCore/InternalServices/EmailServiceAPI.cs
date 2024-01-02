using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Framework.Notifications.Services
{
    public class EmailServiceAPI : IEmailServiceAPI
    {


        #region settings

        bool isDevMode = false;
        string userName = "";
        string password = "";
        string getTokenEndPoint = "";
        string sendEmailEndPoint = "";
        string aPIKey = "";
        string fromEmailId = "";
        string fromEmailPassword = "";
        string contentType = "multipart/form-data";
        string bodyType = "html";
        #endregion

        private readonly IConfiguration configuration;
        public EmailServiceAPI(IConfiguration configuration)
        {
            this.configuration = configuration;

            userName = configuration["CITC_Email_Service:UserName"];
            password = configuration["CITC_Email_Service:Password"];
            getTokenEndPoint = configuration["CITC_Email_Service:GetTokenEndPoint"];
            sendEmailEndPoint = configuration["CITC_Email_Service:SendEmailEndPoint"];
            aPIKey = configuration["CITC_Email_Service:APIKey"];
            fromEmailId = configuration["CITC_Email_Service:FromEmailId"];
            fromEmailPassword = configuration["CITC_Email_Service:FromEmailPassword"];
        }


        public async Task<string> OAuthToken()
        {

            try
            {
                if (isDevMode)
                    return "9684745525464630a4d7519a6620ddcae4858419fefc4ff8a4087a5c1cd19aaf";
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", userName, password))));
                    using (var response = await httpClient.PostAsync(getTokenEndPoint, null))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            dynamic returnedData = JsonConvert.DeserializeObject(jsonResponse.ToString());
                            return returnedData["token_type"].Value + " " + returnedData["access_token"].Value;
                        }
                        return null;
                    }
                }

            }
            catch (Exception e)
            {

                throw;
            }
        }



        public async Task<NotificationResponse> SendNotification(NotificationInfo notificationInfo)
        {
            try
            {
                NotificationResponse notificationResponseObj = new NotificationResponse();
                var httpClient = new HttpClient();
                if (isDevMode)
                {
                    return new NotificationResponse()
                    {
                        Status = new NotificationStatus()
                        {
                            Status = "true",
                            HttpCode = "200"
                        }
                    };
                }
                else
                {
                    var authToken = await OAuthToken();
                    using (httpClient = new HttpClient())
                    {
                        httpClient.DefaultRequestHeaders.Add("x-Gateway-APIKey", aPIKey);
                        httpClient.DefaultRequestHeaders.Add("Authorization", authToken);
                        httpClient.DefaultRequestHeaders.Add("ContentType", "multipart/form-data");
                        notificationInfo.bodyType = bodyType;
                        notificationInfo.from = fromEmailId;
                        notificationInfo.password = fromEmailPassword;
                        
                        HttpContent httpContent = JsonContent.Create(notificationInfo, new MediaTypeWithQualityHeaderValue(contentType));
                        using MultipartFormDataContent multipartContent = new();
                        multipartContent.Headers.ContentType.MediaType = "multipart/form-data";
                        multipartContent.Add(new StringContent(JsonConvert.SerializeObject(notificationInfo)), "email");



                        using (var response = await httpClient.PostAsync(sendEmailEndPoint, multipartContent))
                        {
                            notificationResponseObj = JsonConvert.DeserializeObject<NotificationResponse>(await response.Content.ReadAsStringAsync());
                        }
                    }
                }

                return notificationResponseObj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region Models

        public class NotificationInfo
        {
            public List<string> to { get; set; } = new List<string>();
            public List<string> cc { get; set; } = new List<string>();
            public List<string> bcc { get; set; } = new List<string>();
            public string subject { get; set; } 
            public string body { get; set; }

            public string bodyType { get; set; }

            public string from { get; set; }

            public string password { get; set; }
        }

        public class NotificationResponse
        {
            public NotificationStatus Status { get; set; }
        }
        public class NotificationStatus
        {
            public string Status { get; set; }
            public string HttpCode { get; set; }
            public string ErrorCode { get; set; }
            public string ErrorType { get; set; }
            public string ErrorDesc { get; set; }
        }

        #endregion
    }
}
