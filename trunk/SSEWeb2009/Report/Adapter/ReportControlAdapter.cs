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
using Report.ReportException;
using Report.Controls;

namespace Report.Adapter
{
    public class ReportControlAdapter:AbstractControlAdapter
    {
//         private ReportDescriptor reportDesc;
//         private IItemControl reportEditControl;
// 
//         #region IControlAdapter 成员
// 
//         public string GetResult()
//         {
//             return "";
//         }
// 
//         public void CreateDisplayControl(System.Web.UI.TemplateControl control, System.Web.UI.ControlCollection collection)
//         {
//             Panel Holder = new Panel();
//             Label label = new Label();
//             label.Text = reportDesc.Name;
//             Holder.Controls.Add(label);
//             collection.Add(Holder);
//         }
// 
//         public void CreateEditControl(System.Web.UI.TemplateControl control, System.Web.UI.ControlCollection collection)
//         {
//             reportEditControl = control.LoadControl("~/Report/EditControl/ReportEditControl.ascx") as IItemControl;
//             reportEditControl.SetDescriptor(reportDesc);
//             collection.Add(reportEditControl as System.Web.UI.Control);
//         }
// 
//         #endregion
// 
//         #region IControlAdapter 成员
// 
// 
//         public IControlAdapter Clone()
//         {
//             return new ReportControlAdapter();
//         }
// 
//         #endregion
// 
//         #region IControlAdapter 成员
// 
// 
//         public void SetDescriptor(AbstractDescriptor Desc)
//         {
//             if (Desc.Type == ItemType.REPORT && Desc is ReportDescriptor)
//             {
//                 reportDesc = Desc as ReportDescriptor;
//             }
//             else
//             {
//                 throw new UnMatchedTypeException();
//             }
//         }
// 
//         #endregion

        public override IControlAdapter Clone()
        {
            return new ReportControlAdapter();
        }

        protected override IItemControl CreateDisplayControl(TemplateControl target)
        {
            return target.LoadControl("~/Report/Control/DisplayControl/ReportDisplayControl.ascx") as IItemControl;
        }

        protected override IItemControl CreateEditControl(TemplateControl target)
        {
//            return target.LoadControl("~/Report/Control/EditControl/ReportEditControl.ascx") as IItemControl;
            return target.LoadControl("~/Report/Control/EditControl/ReportEditDraggableControl.ascx") as IItemControl;
        }
    }
}
