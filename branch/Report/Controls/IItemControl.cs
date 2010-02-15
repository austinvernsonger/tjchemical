using System;
using System.Collections.Generic;
using System.Text;
using Report.Descriptor;
using System.Web.UI;
using System.Collections;

namespace Report.Controls
{
    public interface IItemControl
    {
        void SetDescriptor(AbstractDescriptor Desc);
        string GetResult();
        void SetEditable(Boolean editable);
        void SetMessage(ArrayList StringList);
        void RefreshControl();
    }
}
