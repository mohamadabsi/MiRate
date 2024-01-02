using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Base
{
    public class ReportBaseFilter : FilterBase
    {
        public Guid[] Ids { get; set; }

        public FormatEnum Format { get; set; }

        public OrientationEnum Orientation { get; set; }

        public bool Compress { get; set; }

        public string OrderedBy { get; set; }

        public int? CountryId { get; set; }
    }
}