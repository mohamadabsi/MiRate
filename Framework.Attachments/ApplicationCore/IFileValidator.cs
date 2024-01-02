using Framework.Attachments.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Framework.Attachments
{
    public interface IFileValidator
    {
        string ValidateFileType(UploadFileVM model);

        string ValidateFileSize(FileStream stream, long length, int fileTypeId);
    }
}
