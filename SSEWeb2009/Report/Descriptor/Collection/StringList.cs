using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Xml.Serialization;
using System.Collections;

namespace Report.Descriptor.Collection
{
    [XmlInclude(typeof(string))]
    public class StringList:System.Collections.Generic.List<string>
    {
    }
}
