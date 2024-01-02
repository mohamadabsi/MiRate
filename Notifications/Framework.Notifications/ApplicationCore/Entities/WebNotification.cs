// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebNotification.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Notifications.Entities
{
    using Framework.Core.Base;
    using Framework.Core.Globalization;
    #region usings

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    /// <summary>
    /// The web notification.
    /// </summary>
    [Table("WebNotification", Schema = "Notifications")]
    public class WebNotification:EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebNotification"/> class.
        /// </summary>
        public WebNotification()
        {
            this.WebNotificationUsers = new HashSet<WebNotificationUsers>();
        }


        /// <summary>
        /// Gets or sets the message content.
        /// </summary>
        public string MessageContentAr { get; set; }

        /// <summary>
        /// Gets or sets the message content en.
        /// </summary>


        public string MessageContentEn { get; set; }

        /// <summary>
        /// Gets the message content.
        /// </summary>
        [NotMapped]
        public string MessageContent => CultureHelper.IsArabic ? this.MessageContentAr : this.MessageContentEn;


        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the web notification users.
        /// </summary>
        public ICollection<WebNotificationUsers> WebNotificationUsers { get; set; }
    }
}