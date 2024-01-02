﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationException.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Notifications.ViewModels
{
    #region usings

    using System;

    #endregion

    /// <summary>
    ///     The notification exception.
    /// </summary>
    public class NotificationException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NotificationException" /> class.
        /// </summary>
        public NotificationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public NotificationException(string message)
            : base(message)
        {
        }
    }
}