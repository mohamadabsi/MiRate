// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArabicTextOnlyAttribute.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.DataAnnotations
{
    #region usings

    using System;

    #endregion

    /// <summary>
    /// The arabic text only attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CompletionTrackableAttribute : Attribute
    {
        /// <summary>
      
        public CompletionTrackableAttribute()          
        {
        }


    }

}