using AutoMapper;
using Framework.Attachments.Data;
using Framework.Attachments.Model;
using Framework.Attachments.ViewModels;
using Framework.Core;
using Framework.Core.Contracts;
using Framework.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//public string DownloadFileUrl => "/Files/Download/?attId="; // CommonsSettings.ApplicationRootUrl + 


//public int AttachmentsAllowedHeight { get; set; }

//public string AttachmentsAllowedTypes { get; set; }

//public int AttachmentsAllowedWidth { get; set; }

//public int AttachmentsMaxSize { get; set; }

//public string AttachmentsPath { get; set; }

//public bool SaveFilesToDatabase { get; set; }


namespace Framework.Attachments
{
    public class AttachmentsService : IAttachmentsService, IAttachmentsClientService
    {
        private readonly IAttachmentsRepository<Attachment> attachmentRepsitory;
        private readonly IAttachmentsRepository<AttachmentType> attachmentTypeRepsitory;
        private readonly IAttachmentsUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IMapper autoMapper;
        private readonly IAttachmentsRepository<AttachmentDownload> attachmentDownloadRepsitory;

        public AttachmentsService(IAttachmentsRepository<Attachment> attachmentRepsitory,
            IAttachmentsRepository<AttachmentType> attachmentTypeRepsitory,
            IAttachmentsUnitOfWork unitOfWork,
            IConfiguration configuration,
            IMapper autoMapper,
            IAttachmentsRepository<AttachmentDownload> attachmentDownloadRepsitory)
        {
            this.attachmentRepsitory = attachmentRepsitory;
            this.attachmentTypeRepsitory = attachmentTypeRepsitory;
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.autoMapper = autoMapper;
            this.attachmentDownloadRepsitory = attachmentDownloadRepsitory;
        }

        public void DeleteAttachment(Guid attachmentId)
        {
            var attachment = this.attachmentRepsitory.GetById(attachmentId);
            attachment.DeActivate();
          
            this.unitOfWork.SaveChanges();
        }

        public AttachmentVM GetAttachment(Guid? attachmentId)
        {
            var attachment = this.attachmentRepsitory.TableNoTracking.Where(a => a.Id == attachmentId && !a.IsDeleted)
                .Include(a => a.AttachmentContent)?.FirstOrDefault();
            var mappedAttach = autoMapper.Map<AttachmentVM>(attachment);
            if (attachment.AttachmentContent == null)
            {
                mappedAttach.Content = new byte[0] { };
                return mappedAttach;
            }
            mappedAttach.Content = attachment.AttachmentContent.Content;
            return mappedAttach;
        }
        public List<AttachmentVM> GetAttachmentByGroupId(Guid attachmentGroupId)
        {
            var attachment = this.attachmentRepsitory.TableNoTracking.Where(a => a.RequestId == attachmentGroupId && a.IsActive)
                .Include(a => a.AttachmentContent).ToList();
            var mappedAttach = autoMapper.Map<List<AttachmentVM>>(attachment);
            foreach (var item in mappedAttach)
            {
                item.Content = attachment.First(x => x.Id == item.Id).AttachmentContent.Content;
            }

            return mappedAttach;
        }

        public bool IsAttachmentByGroupContainAnyAttachment(Guid attachmentGroupId)
        {
            return this.attachmentRepsitory.TableNoTracking.Where(a => a.RequestId == attachmentGroupId && a.IsActive).Any();

        }


        public AttachmentVM GetAttachmentMetaData(Guid? attachmentId, AttachmentTypes type)
        {
            var fileType = this.attachmentTypeRepsitory.GetById((int)type);

            if (!attachmentId.HasValue || attachmentId == Guid.Empty)
                return new AttachmentVM() { AttachmentTypeId = (int)type, DescriptionEn = fileType?.Description };
            var attachment = this.attachmentRepsitory.GetById(attachmentId);
            var mappedAttach = autoMapper.Map<AttachmentVM>(attachment);
            if (mappedAttach != null)
                mappedAttach.DescriptionEn = fileType?.Description;
            return mappedAttach;
        }
        public IPagedList<AttachmentVM> GetAttachments(AttachmentsFilter filter)
        {
            var query = this.attachmentRepsitory.TableNoTracking.Where(a => a.IsActive);
            query = ApplyAttachmentsFilter(query, filter);

            var pagedResult = query
             .OrderByDescending(x => x.CreatedOn)
             .ToPagedList(filter.PageNumber, filter.PageSize);
            var mappedList = autoMapper.Map<List<AttachmentVM>>(pagedResult.ToList());
            var finalPagedList = new StaticPagedList<AttachmentVM>(mappedList, pagedResult);
            return finalPagedList;
        }

        private IQueryable<Attachment> ApplyAttachmentsFilter(IQueryable<Attachment> query, AttachmentsFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.FileName))
            {
                query = query.Where(e => e.FileName == filter.FileName.Trim());
            }

            if (!string.IsNullOrEmpty(filter.Extention))
            {
                query = query.Where(e => e.Extention.ToLower().Trim() == filter.Extention.ToLower().Trim());
            }

            if (filter.AttachmentType.HasValue)
            {
                query = query.Where(a => a.AttachmentTypeId == (int)filter.AttachmentType.Value);
            }

            if (filter.CreatedOnAfter != null)
            {
                query = query.Where(d => d.CreatedOn.Date >= filter.CreatedOnAfter);
            }
            if (filter.CreatedOnBefore != null)
            {
                query = query.Where(d => d.CreatedOn.Date <= filter.CreatedOnBefore);
            }

            //if (!string.IsNullOrEmpty(filter.CreatedBy))
            //{
            //    query = query.Where(c => c.CreatedBy.Trim() == filter.CreatedBy.Trim());
            //}

            return query;
        }

        public MultiUploaderVM GetUploaderVM(Guid requestId, int typeId, string templateName)
        {
            List<AttachmentVM> mappedList = new List<AttachmentVM>();
            if (requestId != Guid.Empty)
            {
                var attachments = this.attachmentRepsitory.TableNoTracking.Where(a => a.RequestId == requestId && a.IsActive)?.ToList();
                mappedList = autoMapper.Map<List<AttachmentVM>>(attachments);
            }
            return new MultiUploaderVM
            {
                Attachments = mappedList,
                RequestId = requestId,
                TypeId = typeId,
                TemplateName = templateName
            };
        }

        public AttachmentVM SaveFile(AttachmentVM attachmentVM)
        {
            attachmentVM.Id = Guid.NewGuid();
            var attachment = autoMapper.Map<AttachmentVM, Attachment>(attachmentVM);
            attachment.AttachmentContent = new AttachmentContent
            {
                Content = attachmentVM.Content,
                AttachmentId = attachmentVM.Id,

            };

            this.attachmentRepsitory.Insert(attachment,true);
            this.unitOfWork.SaveChanges();
            attachmentVM.Success = true;
            attachmentVM.Content = null;
            return attachmentVM;
        }
        public AttachmentVM UpdateFile(AttachmentVM attachmentVM)
        {
            // attachmentVM.Id = Guid.NewGuid();
            // var attachment = Mapper.Map<Attachment>(attachmentVM);
            var attachment = this.attachmentRepsitory.GetById(attachmentVM.Id);
            attachment.AttachmentContent.Content = attachmentVM.Content;
            // attachment.AttachmentContent.OldContent = attachmentVM.OldContent;
            if (attachmentVM.OldContent != null)
            {
                attachment.AttachmentContent.OldContent = attachmentVM.OldContent;
            }
             //logService.SaveCustomLogAsync(ActionEnum.UploadAttachment);
            this.unitOfWork.SaveChanges();
            attachmentVM.Success = true;
            attachmentVM.Content = null;
            return attachmentVM;
        }

        public void UpdateRequestId(Guid requestId, IEnumerable<Guid> attachmentIds)
        {
            foreach (var item in attachmentIds)
            {
                var attachment = this.attachmentRepsitory.TableNoTracking.FirstOrDefault(a => a.Id == item);
                attachment.RequestId = requestId;
                this.unitOfWork.SaveChanges();
            }
        }
        public byte[] GetAttachmentContent(Guid attachmentId)
        {
            var photoAttchment = GetAttachment(attachmentId);
            return photoAttchment.Content;
        }
        public string GetAttachmentBase64(Guid attachmentId)
        {
            var photoAttchment = GetAttachment(attachmentId);
            int size = photoAttchment.Content.Length;
            var formFile = photoAttchment.Content;
            if (size > 0)
            {
                var base64 = Convert.ToBase64String(formFile, 0, formFile.Length);
                return base64;
            }
            return "";
        }

        public string GetAttachmentUrl(Guid attachmentId, string fileDownloadBaseUrl = "")
        {
            if (string.IsNullOrEmpty(fileDownloadBaseUrl))
                fileDownloadBaseUrl = this.configuration.GetValue<string>("BaseUrl");
            var url = $"{fileDownloadBaseUrl}Attachments?attachmentId={attachmentId}";
            return url;
        }


        public AttachmentVM GetFileByName(string fileName)
        {
            var attachment = this.attachmentRepsitory.TableNoTracking.Where(a => a.FileName == fileName && !a.IsDeleted)
                .Include(a => a.AttachmentContent)?.FirstOrDefault();
            var mappedAttach = autoMapper.Map<AttachmentVM>(attachment);
            if (attachment.AttachmentContent == null)

            {
                mappedAttach.Content = new byte[0] { };
                return mappedAttach;
            }
            mappedAttach.Content = attachment.AttachmentContent.Content;
            return mappedAttach;
        }

        public async Task<AttachmentDownloadVM> DownlaodBy(AttachmentDownloadVM vm)
        {
            var attachmentDownloadItem = attachmentDownloadRepsitory
                .TableNoTracking
                .FirstOrDefault(att => att.AttachmentId == vm.AttachmentId && att.UserId == vm.UserId);

            if (attachmentDownloadItem != null)
            {
                return new AttachmentDownloadVM();
            }
            var attachmentDownload = autoMapper.Map<AttachmentDownload>(vm);
          //await  logService.SaveCustomLogAsync(ActionEnum.Download);

            var result = await this.attachmentDownloadRepsitory.InsertAsync(attachmentDownload, true);

            return autoMapper.Map<AttachmentDownloadVM>(result);
        }
    }
}
