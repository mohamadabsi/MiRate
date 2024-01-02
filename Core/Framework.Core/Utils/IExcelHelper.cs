using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Utils
{
    public interface IExcelHelper<T>
    {
        Task<Guid> ExportAndSaveFile(ExcelFileInfo<T> excelFile);
    }


    public class ExcelFileInfo<T>
    {
        public string FileName { get; set; }

        public bool AddDateToName { get; set; }

        public List<ExcellFileTabInfo<T>> FileTabs { get; set; }
    }

    public class ExcellFileTabInfo<T>
    {
        public string TabName { get; set; }

        public bool AddDateToName { get; set; }

        public List<T> Data { get; set; }


    }



}
