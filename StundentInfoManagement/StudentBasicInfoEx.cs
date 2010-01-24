using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
using SMBL.Operation;
using StundentInfoManagement.Ops;
using System.Data;
namespace StundentInfoManagement
{
    public class StudentBasicInfoEx
    {
        public static DataSet SelectBasicInfo(String StudentID)
        {
            Sql.SqlSelectAllStudentBasicInfo QueryString = new Sql.SqlSelectAllStudentBasicInfo();
            QueryString.SetSelectId(StudentID);
            OpStudentMngQuery OpsQuery = new OpStudentMngQuery(QueryString);
            OpsQuery.Do();
            return OpsQuery.Ds;
        }
        public static bool CheckAdmin(String ID)
        {
            Sql.SqlCheckAdmin QueryString = new Sql.SqlCheckAdmin();
            QueryString.SetSelectId(ID);
            OpStudentMngQuery OpsQuery = new OpStudentMngQuery(QueryString);
            OpsQuery.Do();
            if (OpsQuery.Ds.Tables[0].Columns.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
