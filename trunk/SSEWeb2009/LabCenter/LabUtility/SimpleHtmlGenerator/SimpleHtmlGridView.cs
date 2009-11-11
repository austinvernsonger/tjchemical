using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace LabCenter.LabUtility.SimpleHtmlGenerator
{
    public class SimpleHtmlGridView:IHtmlable
    {
        StringBuilder m_sbuilder=new StringBuilder();
        private SimpleHtmlGridView(){}
        public SimpleHtmlGridView(GridView gv)
        {
            if(gv!=null)
            {
                m_sbuilder.Append("<table border=\"1px\">");
                m_sbuilder.Append("<tr>");
                if(0==gv.Columns.Count)
                {
                    m_sbuilder.Append("<td>无列名</td>");
                }
                else
                {
                    for (int i = 0; i != gv.Columns.Count;++i )
                    {
                        m_sbuilder.Append("<td>");
                        m_sbuilder.Append(gv.Columns[i].HeaderText);
                        m_sbuilder.Append("</td>");
                    }
                }
                m_sbuilder.Append("</tr>");
                if(0==gv.Rows.Count)
                {
                    m_sbuilder.Append("<tr><td>无内容</td></tr>");
                }
                else
                {
                    for(int i=0;i!=gv.Rows.Count;++i)
                    {
                        m_sbuilder.Append("<tr>");
                        for (int j = 0; j != gv.Rows[i].Cells.Count;++j )
                        {
                            m_sbuilder.Append("<td>");
                            m_sbuilder.Append(gv.Rows[i].Cells[j].Text);
                            m_sbuilder.Append("</td>");
                        }
                        m_sbuilder.Append("</tr>");
                    }
                }
                m_sbuilder.Append("</table>");
            }
        }
        StringBuilder IHtmlable.GetStringBuilder()
        {
            return m_sbuilder;
        }
    }
}
