using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
using SMBL.Operation;

namespace SysCom
{
    public class BasicStudentInfo
    {
        public String m_StudentID;
        public String m_StudentName;
        public String m_StudentPassWord;
        public int m_Gender;
        public String m_Major;
        public String m_LengthOfSchooling;
        public String m_Degree;

        public BasicStudentInfo(String StudentID, String StudentName, String StudentPassWord, int Gender, String Major, String LengthOfSchooling, String Degree)
        {
            m_StudentID = StudentID;
            m_StudentName = StudentName;
            m_StudentPassWord = StudentPassWord;
            m_Gender = Gender;
            m_Major = Major;
            m_LengthOfSchooling = LengthOfSchooling;
            m_Degree = Degree;
        }

        public void InserNewStudent()
        {
            Ops.OpBiExecute op1 = new Ops.OpBiExecute("Account", new Sql.SqlStudentInsertToAccount(this));
            op1.Do();
            Ops.OpBiExecute op2 = new Ops.OpBiExecute("BasicInfo", new Sql.SqlStudentInsertToStudent(this));
            op2.Do();
        }

        public static DataSet GetStudentTable()
        {
            Ops.OpBiQuery op = new SysCom.Ops.OpBiQuery("BasicInfo", new Sql.SqlGetStudentTable());
            op.Do();
            return op.Ds;
        }

        public static BasicStudentInfo GetStudentInfo(String StudentID)
        {
            Ops.OpBiQuery op = new SysCom.Ops.OpBiQuery("BasicInfo", new Sql.SqlGetStudentInfo(StudentID));
            op.Do();
            BasicStudentInfo BSI = new BasicStudentInfo(op.Ds.Tables[0].Rows[0]["StudentID"].ToString(), op.Ds.Tables[0].Rows[0]["Name"].ToString(), "", op.Ds.Tables[0].Rows[0]["Gender"].ToString() == "True" ? 1 : 0, op.Ds.Tables[0].Rows[0]["Major"].ToString(), op.Ds.Tables[0].Rows[0]["LengthOfSchooling"].ToString(), op.Ds.Tables[0].Rows[0]["Degree"].ToString());
            return BSI;
        }

        public void UpdateStudent()
        {
            Ops.OpBiExecute op1 = new Ops.OpBiExecute("BasicInfo", new Sql.SqlUpdateStudent(this));
            op1.Do();
        }

        public static void DelStudentAccount(String StudentID)
        {
            Ops.OpBiExecute op1 = new Ops.OpBiExecute("BasicInfo", new Sql.SqlStudentDelFromStudent(StudentID));
            op1.Do();
            Ops.OpBiExecute op2 = new Ops.OpBiExecute("Account", new Sql.SqlStudentDelFromoAccount(StudentID));
            op2.Do();
        }
    }
}
