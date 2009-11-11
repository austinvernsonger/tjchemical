using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.SimpleHtmlGenerator
{
    public class SimpleHtmlText:IHtmlable
    {
        StringBuilder m_sbuilder=new StringBuilder();
        private SimpleHtmlText(){}
        public SimpleHtmlText(string s)
        {
            m_sbuilder.Append(s);
        }
        StringBuilder IHtmlable.GetStringBuilder()
        {
            return m_sbuilder;
        }
    }
}
