using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SMBL.Interface.Database;
namespace SysCom
{
    public class BasicTeacherInfo
    {
        
        public static void AccountInsert(SavingTeacherInfo m_TeacherInfo)
        {
            Sql.SqlInsertAccount newaccount =  new Sql.SqlInsertAccount();
            newaccount.SetTeacherInfo(m_TeacherInfo);
            sqlDo("Account", newaccount);
        }
        public static void TeacherInsert(SavingTeacherInfo m_TeacherInfo)
        {
            Sql.SqlInsertTeacher newTeacher = new Sql.SqlInsertTeacher();
            newTeacher.SetTeacherInfo(m_TeacherInfo);

            sqlDo("BasicInfo", newTeacher);
            if (m_TeacherInfo.GetIsTeacherOrdinary())
            {
                Sql.SqlInsertTeacherOrdinary newTeacherOrdinary = new Sql.SqlInsertTeacherOrdinary();
                newTeacherOrdinary.SetTeacherInfo(m_TeacherInfo);
                sqlDo("Teaching", newTeacherOrdinary);
            }
            else
            {
                Sql.SqlInsertTeacherExternal newTeacherExternal = new Sql.SqlInsertTeacherExternal();
                newTeacherExternal.SetTeacherInfo(m_TeacherInfo);
                sqlDo("Teaching", newTeacherExternal);
            }
        }
        public static DataSet QueryTeacherAll()
        {
            DataSet mResult = sqlQuery("BasicInfo",new Sql.SqlSelectTeacherAll());
            return mResult;
        }

        public static DataSet QueryTeacher(String SelectId)
        {
            Sql.SqlSelectTeacher SelectedTeacher = new Sql.SqlSelectTeacher();
            SelectedTeacher.SetSelectId(SelectId);
            DataSet mResult = sqlQuery("BasicInfo",SelectedTeacher);

            return mResult;
        }

        public static void TeahcerUpdate(SavingTeacherInfo m_TeacherInfo)
        {
            Sql.SqlTeacherUpdate teacherupdate = new Sql.SqlTeacherUpdate();
            teacherupdate.SetTeacherInfo(m_TeacherInfo);
            sqlDo("BasicInfo",teacherupdate);
        }

        public static void TeacherRowDelete(String SelectId)
        {
            Sql.SqlSelectTeacherOrdinary selectorteacher = new Sql.SqlSelectTeacherOrdinary();
            selectorteacher.SetSelectId(SelectId);
            DataSet mResult = sqlQuery("Teaching", selectorteacher);
            if (mResult.Tables[0].Rows.Count != 0)
            {
                Sql.SqlDeleteTeacherOrdinary deleteorteacher = new Sql.SqlDeleteTeacherOrdinary();
                deleteorteacher.SetSelectId(SelectId);
                sqlDo("Teaching", deleteorteacher);
            }
            Sql.SqlSelectTeacherExternal selectexteacher = new Sql.SqlSelectTeacherExternal();
            selectexteacher.SetSelectId(SelectId);
            mResult = sqlQuery("Teaching", selectexteacher);
            if (mResult.Tables[0].Rows.Count!=0)
            {
                Sql.SqlDeleteTeacherExternal deleteexteacher = new Sql.SqlDeleteTeacherExternal();
                deleteexteacher.SetSelectId(SelectId);
                sqlDo("Teaching", deleteexteacher);
            }
            Sql.SqlDeleteTeacher teacherdelete = new Sql.SqlDeleteTeacher();
            teacherdelete.SetSelectId(SelectId);
            sqlDo("BasicInfo", teacherdelete);
            Sql.SqlDeleteAccount accountdelete = new Sql.SqlDeleteAccount();
            accountdelete.SetSelectId(SelectId);
            sqlDo("Account", accountdelete);
            LoginInfo li=new LoginInfo();
            li.Username=SelectId;
            Login.Delete(li);
        }

        private static System.Data.DataSet sqlQuery(String DBName, ISql mSQL)
        {
            DataSet mResult;
            Ops.OpBiQuery execute = new Ops.OpBiQuery(DBName, mSQL);
            execute.Do();
            mResult = execute.Ds;
            return mResult;
        }
        private static void sqlDo(String DBName, ISql mSQL)
        {
            Ops.OpBiExecute execute = new Ops.OpBiExecute(DBName, mSQL);
            execute.Do();
        }




        public static Dictionary<string, string> GetTeacherIdAndName()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();   
            Ops.OpBiQuery i = new Ops.OpBiQuery("BasicInfo", new Sql.SqlGetTeacherIdAndName());
            i.Do();
            foreach (DataRow dr in i.Ds.Tables[0].Rows)
            {
                result.Add(dr["TeacherID"].ToString().TrimEnd(), dr["Name"].ToString().TrimEnd());
            }
            return result;
        }
        
    }
}
