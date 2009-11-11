using Report.Descriptor;
using Report.ReportException;
using System.Web.UI;
using System.Web.UI.WebControls;
using Report.Controls;

namespace Report.Adapter
{
    public class TextControlAdapter:AbstractControlAdapter
    {

        public override IControlAdapter Clone()
        {
            return new TextControlAdapter();
        }

        protected override Report.Controls.IItemControl CreateDisplayControl(TemplateControl target)
        {
            return target.LoadControl("~/Report/Control/DisplayControl/TextDisplayControl.ascx") as IItemControl;
        }

        protected override Report.Controls.IItemControl CreateEditControl(TemplateControl target)
        {
          //  return target.LoadControl("~/Report/Control/EditControl/TextEditControl.ascx") as IItemControl;
            return target.LoadControl("~/Report/Control/EditControl/TextEditDraggableControl.ascx") as IItemControl;
        }
    }
}
