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

namespace Report.Descriptor
{
    public class DisplayDescriptor
    {
        public DisplayDescriptor()
        {
            EditMode = EditMode.Brief;
        }

        protected EditMode m_EditMode;
        [XmlIgnore]
        public EditMode EditMode
        {
            get
            {
                return m_EditMode;
            }
            set
            {
                m_EditMode = value;
            }
        }

        protected DisplayMode m_DisplayMode;
        [XmlIgnore]
        public DisplayMode DisplayMode
        {
            get
            {
                return m_DisplayMode;
            }
            set
            {
                m_DisplayMode = value;
            }
        }
    }

    public enum EditMode
    {
        Brief,
        Detail
    }

    public enum DisplayMode
    {
        Edit,
        DisplayFront,
        DisplayBack
    } 
}
