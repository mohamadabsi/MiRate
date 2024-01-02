// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebNotificationUsers.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Notifications.Entities
{
    using Framework.Core.Base;
    #region usings

    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    /// <summary>
    /// The web notification users.
    /// </summary>
    [Table("WebNotificationUsers", Schema = "Notifications")]
    public class WebNotificationUsers:EntityBase
    {
        /// <summary>
        /// Gets or sets the asp net users id.
        /// </summary>
        public Guid? AspNetUsersId { get; set; }

      

        /// <summary>
        /// Gets or sets a value indicating whether is notified.
        /// </summary>
        public bool IsNotified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is seen.
        /// </summary>
        public bool IsSeen { get; set; }

        /// <summary>
        /// Gets or sets the notified date time.
        /// </summary>
        public DateTime? NotifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the seen date time.
        /// </summary>
        public DateTime? SeenDateTime { get; set; }

        /// <summary>
   
        /// <summary>
        /// Gets or sets the web notification.
        /// </summary>
        public WebNotification WebNotification { get; set; }

        /// <summary>
        /// Gets or sets the web notification id.
        /// </summary>
        public Guid WebNotificationId { get; set; }
    }
}