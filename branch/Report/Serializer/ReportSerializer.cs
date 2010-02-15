using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Xml.Serialization;
using Report.Descriptor;

namespace Report.Serializer
{
    public class ReportSerializer
    {
        private string m_Path;
        public string Path
        {
            get;
            set;
        }

        public ReportSerializer(string path)
        {
            this.Path = path;
        }

        public bool Serialize(Report.Descriptor.ReportDescriptor desc)
        {
            try
            {
                using (FileStream fs = new FileStream(Path, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer x = new XmlSerializer(typeof(Report.Descriptor.ReportDescriptor));
                    x.Serialize(fs, desc);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public Report.Descriptor.ReportDescriptor Deserialize()
        {
            try
            {
                using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer x = new XmlSerializer(typeof(Report.Descriptor.ReportDescriptor));
                    ReportDescriptor report = x.Deserialize(fs) as Report.Descriptor.ReportDescriptor;
                    report.RefreshParentReference();
                    return report;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
    }
}
