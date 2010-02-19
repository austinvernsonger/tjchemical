using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
using SMBL.Operation;
using System.Data;

namespace IdentifyLibrary
{
    public class BasicInfoEx
    {
        public static bool CheckAdmin(String ID)
        {
            Sql.SqlCheckAdmin QueryString = new Sql.SqlCheckAdmin();
            QueryString.SetSelectId(ID);
            Ops.OpIdentifyQuery OpsQuery = new IdentifyLibrary.Ops.OpIdentifyQuery(QueryString);
            OpsQuery.Do();
            if (OpsQuery.Ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static bool CheckStudent(String ID)
        {
            Sql.SqlCheckStudent qs = new Sql.SqlCheckStudent();
            qs.SetSelectId(ID);
            Ops.OpIdentifyQuery op = new IdentifyLibrary.Ops.OpIdentifyQuery(qs);
            op.Do();
            if (op.Ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
