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

namespace Report.Descriptor.Collection
{
    [XmlInclude(typeof(ItemDescriptor)),XmlInclude(typeof(ReportDescriptor))]
    public class ItemList:System.Collections.Generic.List<AbstractDescriptor>
    {

    }
}
