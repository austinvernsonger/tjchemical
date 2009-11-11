using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Report.Descriptor;
using Report.Adapter;

namespace Report.Generator
{
    public class ReportGenerator
    {
        private ReportDescriptor reportDesc;
        System.Web.UI.TemplateControl control;
        ControlCollection cc;
        bool IsEdit;

        public ReportGenerator(ReportDescriptor Desc, System.Web.UI.TemplateControl control, ControlCollection cc,bool IsEdit)
        {
        }

        public void Refresh()
        {
            if (IsEdit)
            {
                GenerateEditControl(control, cc);
            }
            else
            {
                GenerateDisplayControl(control, cc);
            }
        }

        public void GenerateDisplayControl(System.Web.UI.TemplateControl control, ControlCollection cc)
        {

        }

        public void GenerateEditControl(System.Web.UI.TemplateControl control,ControlCollection cc)
        {

        }

        public string getresult()
        {
            string str = "";
            return str;
        }
    }
}
