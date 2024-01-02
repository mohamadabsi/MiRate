using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Core.Contracts
{
    public interface IWrokFlowClientService<T>
    {
        Task<RequestVM> CreateRequest(CreateRequestVM<T> model);
        Task<bool> ReSubmitRequest(Guid requestId, string nameAr, string nameEn);
        Task<RequestVM> InquiryStatus(Guid requestId); 
        Task<bool> DeleteRequest(Guid requestId);
        Task<Guid> GetRequstIdByRequstNumber(string RequestNumber);
        Task<List<RequestVM>> GetAllRequstsByIds(List<Guid> supportProgramIds);

    }
}
