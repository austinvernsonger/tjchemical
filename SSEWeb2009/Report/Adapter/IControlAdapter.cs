using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Report.Descriptor;
using System.Web.UI;
using Report.Controls;
using System.Collections;

namespace Report.Adapter
{
    public interface IControlAdapter
    {
        string GetResult();
        IItemControl CreateControl(TemplateControl Parent);
        IControlAdapter Clone();
        void SetDescriptor(Report.Descriptor.AbstractDescriptor Desc);
        void SetMessage(ArrayList StringArray);
        void RefreshControl();
    }
}
