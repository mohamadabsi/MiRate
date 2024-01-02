using Framework.Core.Base;
using Framework.Core.Ddd.Application;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Core.Contracts
{
    public interface IUserService<T>: IApplicationService
    {       
        T CurrentUser { get; }

        Task<T> GetCurrentUser();

        Task<T> GetCompanyUser(Guid userId);
      
        Task<bool> IsAuthenticated();

        Task<bool> IsAuthorized(string allowedRoles);

        Task<List<LookupVM>> GetUsersInRole(SystemUserRole reviewer);

        Task<List<T>> GetUsersByRoleId(int roleId);

        Task<T> GetUser(string userName);
        Task<T> GetUserByNameAr(string nameAr);
        T GetUserById(Guid id);
 

        Task<T> GetUser(Guid userId);

        List<string> GetActiveUserEmails();

        ApplicationRoleVM GetRoleById(int roleId);
        Task AddUser(T model);
        Task<T> GetUserByName(string userName);
        Task<List<LookupVM>> GetUsersInRoleReviewer();

    }
}
