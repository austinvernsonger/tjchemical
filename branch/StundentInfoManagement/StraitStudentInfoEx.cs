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
    public class StraitStudentInfoEx
    {
        public static DataSet SelectAllStraitStudent()
        {
            Sql.SqlSelectAllStraitStudent qs = new StundentInfoManagement.Sql.SqlSelectAllStraitStudent();
            Ops.OpStudentMngQuery op = new OpStudentMngQuery(qs);
            op.Do();
            return op.Ds;
        }
        public static bool DeleteStraitStudent(String ID)
        {
            Sql.SqlDeleteStraitStudent qs = new StundentInfoManagement.Sql.SqlDeleteStraitStudent();
            qs.GetID(ID);
            Ops.OpStudentMngExec op = new OpStudentMngExec(qs);
            return op.Do();
        }
        public static DataSet StraitStudentQuery(String ID,String strName,Int16 iClass,Int16 Degree)
        {
            Sql.SqlSelectStraitStudentByQuery qs = new StundentInfoManagement.Sql.SqlSelectStraitStudentByQuery();
            qs.GetCondition(ID, strName, iClass,Degree);
            Ops.OpStudentMngQuery op = new OpStudentMngQuery(qs);
            op.Do();
            return op.Ds;
        }
        public static bool HasStraitStudent(String ID)
        {
            Sql.SqlSelectStraitStudentByQuery qs = new StundentInfoManagement.Sql.SqlSelectStraitStudentByQuery();
            qs.GetCondition(ID, "", -1,-1);
            Ops.OpStudentMngQuery op = new OpStudentMngQuery(qs);
            op.Do();
            if (op.Ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static bool AddStraitStudent(String ID)
        {
            Sql.SqlAddStraitStudent qs = new StundentInfoManagement.Sql.SqlAddStraitStudent();
            qs.GetID(ID);
            Ops.OpStudentMngExec op = new OpStudentMngExec(qs);
            return op.Do();
        }
        public static DataSet SelectStraitStudentBasicInfo(String ID)
        {
            Sql.SqlSelectStraitStudentBasicInfo qs = new StundentInfoManagement.Sql.SqlSelectStraitStudentBasicInfo();
            qs.GetID(ID);
            Ops.OpStudentMngQuery op = new OpStudentMngQuery(qs);
            op.Do();
            return op.Ds;
        }
        public static bool UpdateStraitStudent(String StudentID,Int16 RegisteredResidenceBeforeSchool,String FamilyMemberNum,String FamilySalary,
	Int16 DiBao,Int16 GuCan,Int16 SingleParent,Int16 MartyrChild,Int16 Apply,String ExplainThings,Int16 StraitDegree)
        {
            Ops.OpStudentMngProducer op = new OpStudentMngProducer("P_UPDATE_STRAITSTUDENTINFO",StudentID, RegisteredResidenceBeforeSchool,FamilyMemberNum,FamilySalary,
	 DiBao, GuCan, SingleParent, MartyrChild, Apply,ExplainThings, StraitDegree);
            op.Do();
            return Convert.ToBoolean(op.ExecuteResult);
        }
    }
}
