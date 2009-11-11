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
using System.Collections;

namespace Report.Validator
{
    public interface IValidator
    {
        Boolean Validate(AbstractDescriptor Desc);
        ArrayList Message();
    }
}
