using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace LabCenter.LabUtility.SimpleHtmlGenerator
{
    public class SimpleHtmlTextbox:IHtmlable
    {
        StringBuilder m_sbuilder=new StringBuilder();
        private SimpleHtmlTextbox(){}
        public SimpleHtmlTextbox(TextBox tb)
        {
            m_sbuilder.Append("<input type=\"text\" value=\"" + tb.Text + "\" />");
        }
        StringBuilder IHtmlable.GetStringBuilder()
        {
            return m_sbuilder;
        }
    }
}
