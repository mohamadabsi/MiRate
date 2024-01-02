//using Framework.Attachments.Model;
//using Framework.Attachments.ViewModels;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;
//using System.Web.Http;

//namespace Framework.Attachments.Pages
//{
//    public class Files :ApiController
//    {
//        private readonly IAttachmentsService attachmentsService;
//        private readonly IFileValidator fileValidator;

//        // public FilescModel(IAttachmentsService attachmentsServiceIFileValidator fileValidator) : base(alertManager)
//        // {
//        //     this.attachmentsService = attachmentsService;
//        //     this.fileValidator = fileValidator;
//        // }
//        public IActionResult OnGet(Guid attachmentId)
//        {
//            var attachment = this.attachmentsService.GetAttachment(attachmentId);
//            return null;// File(attachment.Content, attachment.ContentType, attachment.FileName ?? "file.pdf");
//        }
//        // public IActionResult OnGetDeleteFile(Guid attachmentId)
//        // {
//        //     this.attachmentsService.DeleteAttachment(attachmentId);
//        //     return Created();
//        // }
//        public async Task<IActionResult> OnPost(UploadFileVM uploadeFileVM)
//        {

//            uploadeFileVM.TypeId = (uploadeFileVM.TypeId > 0) ? uploadeFileVM.TypeId : 100;
//            var filePath = Path.GetTempFileName();
//            var file = uploadeFileVM.File;
//            var validationResult = fileValidator.ValidateFileType(uploadeFileVM);
//            if (!string.IsNullOrEmpty(validationResult))
//                return new JsonResult(new AttachmentVM() { Success = false, ErrorMessage = validationResult });

//            using (var inputStream = new FileStream(filePath, FileMode.Create))
//            {
//                var attachmentVM = new AttachmentVM() { AttachmentTypeId = uploadeFileVM.TypeId };
//                // read file to stream
//                await file.CopyToAsync(inputStream);
//                // stream to byte array
//                byte[] array = new byte[inputStream.Length];

//                validationResult = fileValidator.ValidateFileSize(inputStream, file.Length, uploadeFileVM.TypeId);
//                if (!string.IsNullOrEmpty(validationResult))
//                    return new JsonResult(new AttachmentVM() { Success = false, ErrorMessage = validationResult });


//                inputStream.Seek(0, SeekOrigin.Begin);
//                inputStream.Read(array, 0, array.Length);
//                var uploadedFilePath = file.FileName.Split('\\');
//                attachmentVM.FileName = uploadedFilePath[uploadedFilePath.Length - 1];
//                var arr = file.FileName.Split('.');
//                attachmentVM.Extention = arr[arr.Length - 1];
//                attachmentVM.ContentType = file.ContentType;
//                attachmentVM.DescriptionEn = file.ContentDisposition;
//                attachmentVM.DescriptionAr = file.ContentDisposition;
//                attachmentVM.Content = array;
//                var result = attachmentsService.SaveFile(attachmentVM);
//                return new JsonResult(result);
//            }
//        }

//        public async Task<IActionResult> OnPostImage(UploadFileVM uploadeFileVM)
//        {
//            uploadeFileVM.TypeId = (uploadeFileVM.TypeId > 0) ? uploadeFileVM.TypeId : 100;
//            var filePath = Path.GetTempFileName();
//            var file = uploadeFileVM.File;
//            var validationResult = fileValidator.ValidateFileType(uploadeFileVM);
//            if (!string.IsNullOrEmpty(validationResult))
//                return new JsonResult(new AttachmentVM() {Success = false, ErrorMessage = validationResult});

//            using (var inputStream = new FileStream(filePath, FileMode.Create))
//            {
//                var attachmentVM = new AttachmentVM() {AttachmentTypeId = uploadeFileVM.TypeId};
//                // read file to stream
//                await file.CopyToAsync(inputStream);
//                // stream to byte array
//                byte[] array = new byte[inputStream.Length];

//                validationResult = fileValidator.ValidateFileSize(inputStream, file.Length, uploadeFileVM.TypeId);
//                if (!string.IsNullOrEmpty(validationResult))
//                    return new JsonResult(new AttachmentVM() {Success = false, ErrorMessage = validationResult});


//                inputStream.Seek(0, SeekOrigin.Begin);
//                inputStream.Read(array, 0, array.Length);
//                var uploadedFilePath = file.FileName.Split('\\');
//                attachmentVM.FileName = uploadedFilePath[uploadedFilePath.Length - 1];
//                var arr = file.FileName.Split('.');
//                attachmentVM.Extention = arr[arr.Length - 1];
//                attachmentVM.ContentType = file.ContentType;
//                attachmentVM.DescriptionEn = file.ContentDisposition;
//                attachmentVM.DescriptionAr = file.ContentDisposition;
//                attachmentVM.Content = array;
//                var OldAttachement=new AttachmentVM();
//                if (uploadeFileVM.AttachementId.HasValue)
//                {
//                  OldAttachement = attachmentsService.GetAttachment(uploadeFileVM.AttachementId);

//                    attachmentVM.OldContent = OldAttachement.Content;
//                    attachmentVM.Id = uploadeFileVM.AttachementId.Value;
//                }
//                var result = attachmentsService.UpdateFile(attachmentVM);
//                return new JsonResult(result);


//            }
//        }

//        public async Task<IActionResult> OnPostMulti(UploadFileVM uploadeFileVM)
//        {
//            uploadeFileVM.TypeId = (uploadeFileVM.TypeId > 0) ? uploadeFileVM.TypeId : 100;
//            var filePath = Path.GetTempFileName();
//            var file = uploadeFileVM.File;
//            var validationResult = fileValidator.ValidateFileType(uploadeFileVM);
//            if (!string.IsNullOrEmpty(validationResult))
//                return new JsonResult(new AttachmentVM() { Success = false, ErrorMessage = validationResult });

//            using (var inputStream = new FileStream(filePath, FileMode.Create))
//            {
//                var attachmentVM = new AttachmentVM() { AttachmentTypeId = uploadeFileVM.TypeId };
//                // read file to stream
//                await file.CopyToAsync(inputStream);
//                // stream to byte array
//                byte[] array = new byte[inputStream.Length];

//                validationResult = fileValidator.ValidateFileSize(inputStream, file.Length, uploadeFileVM.TypeId);
//                if (!string.IsNullOrEmpty(validationResult))
//                    return new JsonResult(new AttachmentVM() { Success = false, ErrorMessage = validationResult });


//                inputStream.Seek(0, SeekOrigin.Begin);
//                inputStream.Read(array, 0, array.Length);
//                var uploadedFilePath = file.FileName.Split('\\');
//                attachmentVM.FileName = uploadedFilePath[uploadedFilePath.Length - 1];
//                var arr = file.FileName.Split('.');
//                attachmentVM.Extention = arr[arr.Length - 1];
//                attachmentVM.ContentType = file.ContentType;
//                attachmentVM.DescriptionEn = file.ContentDisposition;
//                attachmentVM.DescriptionAr = file.ContentDisposition;
//                attachmentVM.Content = array;
//                attachmentVM.RequestId = uploadeFileVM.RequestId;
//                var result = attachmentsService.SaveFile(attachmentVM);
//                return new JsonResult(result);
//            }
//        }

//        // public async Task OnPostUploadFile(IList<IFormFile> files)
//        // {
//        //     var filePath = Path.GetTempFileName();
//        //     foreach (var formFile in Request.Form.Files)
//        //     {
//        //         if (formFile.Length > 0)
//        //         {
//        //             using (var inputStream = new FileStream(filePath, FileMode.Create))
//        //             {
//        //                 // read file to stream
//        //                 await formFile.CopyToAsync(inputStream);
//        //                 // stream to byte array
//        //                 byte[] array = new byte[inputStream.Length];
//        //                 inputStream.Seek(0, SeekOrigin.Begin);
//        //                 inputStream.Read(array, 0, array.Length);
//        //                 // get file name
//        //                 string fName = formFile.FileName;
//        //             }
//        //         }
//        //     }
//        // }


//        public IActionResult OnGetImageEditor(Guid attachmentId )
//        {
//            return null ;// ViewComponent("ImageEditor", attachmentId );
//        }

//    }
//}
