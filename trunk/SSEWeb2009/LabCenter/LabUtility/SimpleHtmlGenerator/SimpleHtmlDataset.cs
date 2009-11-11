using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LabCenter.LabUtility.SimpleHtmlGenerator
{
    public class SimpleHtmlDataset:IHtmlable
    {
        StringBuilder m_sbuilder=new StringBuilder();
        private SimpleHtmlDataset(){}
        public SimpleHtmlDataset(DataSet ds)
        {
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                m_sbuilder.Append("<table border=\"1px\">");
                m_sbuilder.Append("<tr>");
                if (0 == dt.Columns.Count)
                {
                    m_sbuilder.Append("<td>无列名</td>");
                }
                else
                {
                    for (int i = 0; i != dt.Columns.Count; ++i)
                    {
                        m_sbuilder.Append("<td>");
                        m_sbuilder.Append(dt.Columns[i].ColumnName);
                        m_sbuilder.Append("</td>");
                    }
                }
                m_sbuilder.Append("</tr>");
                if (0 == dt.Rows.Count)
                {
                    m_sbuilder.Append("<tr><td>无内容</td></tr>");
                }
                else
                {
                    for (int i = 0; i != dt.Rows.Count; ++i)
                    {
                        m_sbuilder.Append("<tr>");
                        for (int j = 0; j != dt.Rows[i].ItemArray.Length; ++j)
                        {
                            m_sbuilder.Append("<td>");
                            m_sbuilder.Append(dt.Rows[i].ItemArray[j].ToString());
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
