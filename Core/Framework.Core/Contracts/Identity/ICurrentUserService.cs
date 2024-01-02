// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUsersService.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Contracts
{
    using Framework.Core.Ddd.Application;
    #region usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion


    public interface ICurrentUserService //: IApplicationService
    {
        string CurrentUserName { get; }
        //Guid CurrentUserId { get; }
        //IList<string> CurrentUserRoles { get; }

        Task<object> GetCurrentUser();
    }

}