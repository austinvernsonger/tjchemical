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
    public class DepartmentInfoEx
    {
        public static DataSet SelectAllDepartName()
        {
            Sql.SqlSelectAllDepartment QueryString = new Sql.SqlSelectAllDepartment();
            OpStudentMngQuery OpsQuery = new OpStudentMngQuery(QueryString);
            OpsQuery.Do();
            return OpsQuery.Ds;
        }
        public static bool AddDepartName(string DpN)
        {
            Sql.SqlAddDepartmentName ExecString = new Sql.SqlAddDepartmentName();
            ExecString.GetDepartmentName(DpN);
            OpStudentMngExec OpsExec = new OpStudentMngExec(ExecString);
            return OpsExec.Do();          
        }
        public static bool DeleteDepartName(string DpId)
        {
            Sql.SqlDeleteDepartmentName ExecString = new Sql.SqlDeleteDepartmentName();
            ExecString.SetSelectedID(DpId);
            OpStudentMngExec OpsExec = new OpStudentMngExec(ExecString);
            return OpsExec.Do();
        }
    }
}
