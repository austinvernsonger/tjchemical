using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.SimpleHtmlGenerator
{
    public class SimpleHtmlBuilder:IHtmlable
    {
        StringBuilder m_sbuilder=new StringBuilder();
        public SimpleHtmlBuilder(){}
        public void Append(IHtmlable htmlable)
        {
            m_sbuilder.Append(htmlable.GetStringBuilder());
        }
        StringBuilder IHtmlable.GetStringBuilder()
        {
            return m_sbuilder;
        }
    }
}
