using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.SimpleHtmlGenerator
{
    public class SimpleHtmlbr:IHtmlable
    {
        StringBuilder m_sbuilder=new StringBuilder();
        public SimpleHtmlbr()
        {
            m_sbuilder.Append("<br/>");
        }
        public SimpleHtmlbr(int brcount)
        {
            for(int i=0;i<brcount;++i)
            {
                m_sbuilder.Append("<br/>");
            }
        }
        StringBuilder IHtmlable.GetStringBuilder()
        {
            return m_sbuilder;
        }
    }
}
