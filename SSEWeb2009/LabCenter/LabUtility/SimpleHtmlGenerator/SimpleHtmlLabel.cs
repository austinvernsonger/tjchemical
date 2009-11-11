using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace LabCenter.LabUtility.SimpleHtmlGenerator
{
    public class SimpleHtmlLabel:IHtmlable
    {
        StringBuilder m_sbuilder=new StringBuilder();
        public SimpleHtmlLabel(Label lbl)
        {
            m_sbuilder.Append(lbl.Text);
        }
        StringBuilder IHtmlable.GetStringBuilder()
        {
            return m_sbuilder;
        }
    }
}
