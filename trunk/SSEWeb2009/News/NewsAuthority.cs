using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SysCom.Ops;
using SysCom.Sql;
namespace SysCom
{
    public class NewsAuthority
    {
        public static Boolean HaveAuthority(String id)
        {
            OpsNewsQuery i = new OpsNewsQuery("BasicInfo", new sqlGetAuthority(id));
            i.Do();
            int count = i.Ds.Tables[0].Rows.Count;
            return (count > 0);
        }

        public static Boolean DeleteNewAuthority(String id)
        {
            OpsNewsExecute i = new OpsNewsExecute("BasicInfo", new sqlDeleteNewsAuthority(id));
            i.Do();
            return i.ExecuteResult;
        }

        public static Boolean CreateNewsAuthority(String id, String name)
        {
            OpsNewsExecute i = new OpsNewsExecute("BasicInfo", new sqlCreateNewsAuthority(id, name));
            i.Do();
            return i.ExecuteResult;
        }

        public static DataSet GetNewsAuthorityList()
        {
            OpsNewsQuery i = new OpsNewsQuery("BasicInfo", new sqlGetNewsAthuoutyList());
            i.Do();
            return i.Ds;
        }
    }
}
