using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
using System.Data;

namespace Department.Engineering
{
    public class AuthorityManage
    {
        public AuthorityManage()
        { }

        public static bool HasAuthorities(string ID, string index)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlHasAuthority(ID, index));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
