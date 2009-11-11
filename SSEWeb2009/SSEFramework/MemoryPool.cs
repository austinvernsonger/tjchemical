using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;
using System.Data;

namespace Functions.SSEFW
{
    public class MemoryPool
    {
        public DataSet test()
        {
            DataSet test = new DataSet();
            test.ReadXml(SMBL.Global.WebSite.AppPath + "\\sse_framework.sitemap");
            return test;
        }
    }
}
