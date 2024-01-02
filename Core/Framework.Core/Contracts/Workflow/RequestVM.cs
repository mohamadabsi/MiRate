using Framework.Core.Base;
using System;

namespace Framework.Core.Contracts
{
    public class CreateRequestVM<T> 
    {
        public Guid OwnerId { get; set; }    

        public RequestTypes Type { get; set; }
     
        public Guid Id { get;  set; }

        public string CompanyName { get; set; }

        public string CompanyNameEn { get; set; }

       public bool IntrestInSupportProgramm { get; set; }

        public T SubmitterUser { get; set; }
        public T AssignedUser { get; set; }


    }

    public class RequestVM
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public string StatusNameAr { get; set; }

        public bool IntrestInSupportProgramm { get; set; }

        public Guid? AssignedToUserId { get; set; }


        public RequestTypes Type { get; set; }

        public string Comment { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
