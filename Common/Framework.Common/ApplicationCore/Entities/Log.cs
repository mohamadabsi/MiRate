// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Framework.Core.Base;
using System;

namespace Framework.Core.CommonTables.Entities
{
    #region usings

    #endregion

    public class Log:EntityBase
    {
        public Guid Id { get; set; }
        public string Host { get; set; }
        public string MachineName { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; }
        public string LogLevel { get; set; }
        public string Logger { get; set; }
        public string UserAgent { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string HttpMethod { get; set; }
        public string CallSite { get; set; }
        public string ActivityId { get; set; }
    }
}