using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Report.Controls;

namespace Report.Adapter
{
    public class AdminCheckControlAdapter:AbstractControlAdapter
    {
        public override IControlAdapter Clone()
        {
            return new AdminCheckControlAdapter();
        }

        protected override Report.Controls.IItemControl CreateDisplayControl(TemplateControl target)
        {
            return target.LoadControl("~/Report/Control/DisplayControl/AdminCheckDisplayControl.ascx") as IItemControl;
        }

        protected override Report.Controls.IItemControl CreateEditControl(TemplateControl target)
        {
            return target.LoadControl("~/Report/Control/EditControl/AdminCheckEditControl.ascx") as IItemControl;
        }
    }
}
