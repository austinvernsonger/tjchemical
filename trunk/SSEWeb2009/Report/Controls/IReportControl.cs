using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Controls
{
    public interface IReportControl
    {
        void SetReportDescriptorFilePath(string path);
        void SetReportResultFilePath(string path);
        bool SaveResult();
        bool SaveDescriptor();
        void SetKeyValue(string value);
    }
}
