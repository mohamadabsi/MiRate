// Copy rights to Tamer Mohammad 
using Framework.Attachments.Model;
using Framework.Attachments.Models;
using Framework.Attachments.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Framework.Attachments.Data;
namespace Framework.Attachments
{
    public class FileValidator : IFileValidator
    {
        private readonly IAttachmentsRepository<AttachmentType> attachmentTypeRepsitory;

        public FileValidator(IAttachmentsRepository<AttachmentType> attachmentTypeRepsitory)
        {
            this.attachmentTypeRepsitory = attachmentTypeRepsitory;
            //jpg,png,jpeg,gif,pdf,doc,docx,xls,xlsx,ppm,ppt,pptx,txt
        }


        public string ValidateFileType(UploadFileVM model)
        {
            var fileType = this.attachmentTypeRepsitory.GetById(model.TypeId);
            List<FileTypeInfo> filesList = FilesList;
            if (fileType != null)
            {
                var extensionList = fileType.AllowedFilesExtension.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                filesList = FilesList.Where(f => extensionList.Contains(f.Extension)).ToList();
            }
            var filePath = Path.GetTempFileName();
            var file = model.File;
            if (filesList.FirstOrDefault(f => f.FileContentType == file.ContentType) == null)
            {
                return $"Please upload file having extensions {filesList.Select(f => f.Extension).JoinAsString(", ")} only.";
            }
            string[] splittedFileName = file.FileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            if (splittedFileName.Length <= 1)
                return $"Please upload file having extensions {filesList.Select(f => f.Extension).JoinAsString(", ")} only.";
            if (FilesList.FirstOrDefault(f => f.Extension.ToLower() == splittedFileName[splittedFileName.Length - 1].ToLower()) == null)
                return $"Please upload file having extensions {filesList.Select(f => f.Extension).JoinAsString(", ")} only.";
            return "";
        }

        public string ValidateFileSize(FileStream stream, long length, int fileTypeId)
        {
            var fileType = this.attachmentTypeRepsitory.GetById(fileTypeId);
            string errorMessage = "";
            if (fileType == null)
            {
                errorMessage = (length > (1024 * 1024 * 5)) ? "Please upload file with size less than 5 MB." : "";
                return errorMessage;
            }
            if (length > (1024 * 1024 * fileType.MaxSizeInMegabytes))
            {
                errorMessage = $"Please upload file with size less than {fileType.MaxSizeInMegabytes} MB.";
                return errorMessage;

            }
            if (fileType.IsImage)
            {
                System.Drawing.Bitmap img = new System.Drawing.Bitmap(stream);

                if (fileType.ImageMaxHeight.HasValue)
                {
                    errorMessage = img.Height > fileType.ImageMaxHeight.Value ? $"Please upload image with height less than {fileType.ImageMaxHeight} pixel." : "";
                }
                if (string.IsNullOrEmpty(errorMessage) && fileType.ImageMaxWidth.HasValue)
                {
                    int w = img.Width;
                    errorMessage = img.Width > fileType.ImageMaxWidth.Value ? $"Please upload image with width less than {fileType.ImageMaxWidth} pixel." : "";
                }
                img.Dispose();
            }

            return errorMessage;

        }
        public static List<FileTypeInfo> FilesList
        {
            get
            {
                var list = new List<FileTypeInfo> {
                  
                    new FileTypeInfo("image/jpg", "jpg"),
                      new FileTypeInfo("image/jpeg", "jpeg"),
                    new FileTypeInfo("image/png", "png"),
                    new FileTypeInfo("image/gif", "gif"),
                    new FileTypeInfo("application/msword", "doc"),
                    new FileTypeInfo("application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx"),
                    new FileTypeInfo("application/vnd.ms-excel", "xls"),
                    new FileTypeInfo("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx"),
                    new FileTypeInfo("application/pdf", "pdf"),
                    new FileTypeInfo("image/x-portable-pixmap", "ppm"),
                    new FileTypeInfo("application/vnd.openxmlformats-officedocument.presentationml.presentation", "pptx"),
                    new FileTypeInfo("application/vnd.ms-powerpoint", "ppt"),
                    new FileTypeInfo("text/plain", "txt")
                };
                return list;
            }
        }
        private enum ImageFileExtension
        {
            none = 0,
            jpg = 1,
            jpeg = 2,
            bmp = 3,
            gif = 4,
            png = 5
        }
        private enum PDFFileExtension
        {
            none = 0,
            PDF = 1
        }
        public static bool IsValidFile(byte[] bytFile, string FileContentType)
        {

            if (FileContentType.Contains("jpg") | FileContentType.Contains("jpeg")
                | FileContentType.Contains("png") | FileContentType.Contains("bmp")
                | FileContentType.Contains("gif"))
                return isValidImageFile(bytFile, FileContentType);

            if (FileContentType.Contains("pdf"))
                return isValidPDFFile(bytFile);


            if (FileContentType.Contains("msword"))
                return isValidDocFile(bytFile);

            if (FileContentType.Contains("application/vnd.openxmlformats-officedocument.wordprocessingml.document"))
                return isValidDocxFile(bytFile);
            if (FileContentType.Contains("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
                return isValidDocxFile(bytFile);

            return false;
        }
        public static bool isValidImageFile(byte[] bytFile, string FileContentType)
        {
            bool isvalid = false;

            byte[] chkBytejpg = { 255, 216, 255, 224 };
            byte[] chkBytebmp = { 66, 77 };
            byte[] chkBytegif = { 71, 73, 70, 56 };
            byte[] chkBytepng = { 137, 80, 78, 71 };


            ImageFileExtension imgfileExtn = ImageFileExtension.none;

            if (FileContentType.Contains("jpg") | FileContentType.Contains("jpeg"))
            {
                imgfileExtn = ImageFileExtension.jpg;
            }
            else if (FileContentType.Contains("png"))
            {
                imgfileExtn = ImageFileExtension.png;
            }
            else if (FileContentType.Contains("bmp"))
            {
                imgfileExtn = ImageFileExtension.bmp;
            }
            else if (FileContentType.Contains("gif"))
            {
                imgfileExtn = ImageFileExtension.gif;
            }

            if (imgfileExtn == ImageFileExtension.jpg || imgfileExtn == ImageFileExtension.jpeg)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytejpg[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }


            if (imgfileExtn == ImageFileExtension.png)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytepng[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }


            if (imgfileExtn == ImageFileExtension.bmp)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 1; i++)
                    {
                        if (bytFile[i] == chkBytebmp[i])
                        {
                            j = j + 1;
                            if (j == 2)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            if (imgfileExtn == ImageFileExtension.gif)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (Int32 i = 0; i <= 1; i++)
                    {
                        if (bytFile[i] == chkBytegif[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }

            return isvalid;
        }

        public static bool isValidPDFFile(byte[] bytFile  )
        {
            byte[] chkBytepdf = { 37, 80, 68, 70 };
            bool isvalid = false;

        
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytepdf[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }        

            return isvalid;
        }

        public static bool isValidDocFile(byte[] bytFile )
        {
            byte[] chkByteDoc = { 208, 207, 17 };
            bool isvalid = false;

            if (bytFile.Length >= 3)
            {
                int j = 0;
                for (int i = 0; i <= 2; i++)
                {
                    if (bytFile[i] == chkByteDoc[i])
                    {
                        j = j + 1;
                        if (j == 2)
                        {
                            isvalid = true;
                        }
                    }
                }
            }


            return isvalid;
        }

        public static bool isValidDocxFile(byte[] bytFile  )
        {
            byte[] chkByteDoc = { 80, 75 };
            bool isvalid = false;

            if (bytFile.Length >= 2)
            {
                int j = 0;
                for (int i = 0; i <= 1; i++)
                {
                    if (bytFile[i] == chkByteDoc[i])
                    {
                        j = j + 1;
                        if (j == 2)
                        {
                            isvalid = true;
                        }
                    }
                }
            }
            return isvalid;
        }



    }
}
