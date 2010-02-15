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
    public class WorkUnitInfoEx
    {
        public static DataSet SelectAllWorkUnitName()
        {
            Sql.SqlSelectAllWorkUnitName QueryString = new Sql.SqlSelectAllWorkUnitName();
            OpStudentMngQuery OpsQuery = new OpStudentMngQuery(QueryString);
            OpsQuery.Do();
            return OpsQuery.Ds;
        }
        public static bool AddWorkUnitName(string WUN)
        {
            Sql.SqlAddWorkUnitName ExString = new Sql.SqlAddWorkUnitName();
            ExString.GetWorkUnitName(WUN);
            OpStudentMngExec OpsEx = new OpStudentMngExec(ExString);
            return OpsEx.Do();
        }
        public static bool DeleteWorkUnitName(string WUID)
        {
            Sql.SqlDeleteWorkUnitName ExString = new Sql.SqlDeleteWorkUnitName();
            ExString.GetSelectedID(WUID);
            OpStudentMngExec OpsEx = new OpStudentMngExec(ExString);
            return OpsEx.Do();
        }
    }
}
