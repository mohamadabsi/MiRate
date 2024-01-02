//using Framework.Web;

using System.Collections.Generic;

namespace Framework.Attachments.Models
{
    public class FileTypeInfo
    {
        public FileTypeInfo( string fileContentType,string extension )
        {
            this.FileContentType = fileContentType;
            this.Extension = extension;
        }
        public string Extension { get; set; }

        public string FileContentType { get; set; }


       
    }
}

