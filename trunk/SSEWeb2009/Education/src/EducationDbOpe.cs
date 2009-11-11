using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Education.Sql;
using SMBL.Interface.Database;

namespace Education.src
{
    ///<summary>
    /// 功能类：教务模块访问数据库的功能类
    /// 作者：JerryChen
    /// 最近一次修改时间：2009-7-28
    ///</summary>
    public class EducationDbOpe
    {
        public enum myAuthorityset
        {
            administrator = 1,
            teacher ,
            master,
            teacherassistant ,
            graduating ,
            groupleader ,
            groupmember ,
            undergraduate ,
            visitor 
        }
        private String mId;

        public myAuthorityset GetAuthority(String strId)
        {
            mId = strId;
            myAuthorityset authority = IsStudent();
            if (authority != myAuthorityset.visitor)
            {
                return authority;
            }
            if (mId.Length==5)
            {
                return myAuthorityset.teacher;
            }
            if (mId.Length==10&&IsScienceMaster())
            {
                return myAuthorityset.master;
            }
            if (IsAdministrator())
            {
                return myAuthorityset.administrator;
            }
            return myAuthorityset.visitor;
        }

        public myAuthorityset IsStudent()
        {
            String SQL = "SELECT * FROM Account WHERE AccountID=" + mId;
            if (DoQuery(SQL).Tables[0].Rows.Count == 0)
            {
                return myAuthorityset.visitor;
            }
            if (mId.Length == 6)
            {
                if (IsGraduating())
                {
                    return myAuthorityset.graduating;
                }
                if (IsTeacherAssistant())
                {
                    return myAuthorityset.teacherassistant;
                }
                if (IsLeader())
                {
                    return myAuthorityset.groupleader;
                }
                if (IsMember())
                {
                    return myAuthorityset.groupmember;
                }
            }
            return myAuthorityset.visitor;
        }
        
        public bool IsGraduating()
        {
            String SQL = "SELECT Grade FROM Student WHERE StudentID=" + mId;
            DataSet ds = DoQuery(SQL);
            if (ds.Tables[0].Rows[0][0] == "4")
            {
                return true;
            }
            return false;
        }

        public bool IsTeacherAssistant()
        {
            String SQL = "SELECT Examine_state FROM Assistant_apply WHERE StudentID=" + mId;
            DataSet ds = DoQuery(SQL);
            int rowNum = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rowNum;i++ )
            {
                if (ds.Tables[0].Rows.Find(1)==null)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsLeader()
        {
            String SQL = "SELECT Examine_state FROM Create WHERE LeaderID=" + mId;
            DataSet ds = DoQuery(SQL);
            if (ds.Tables[0].Rows.Find(1)==null)
            {
                return true;
            }
            return false;
        }

        public bool IsMember()
        {
            String SQL = "SELECT * FROM CreateMember WHERE MemberID=" + mId;
            DataSet ds = DoQuery(SQL);
            if (ds.Tables[0].Rows.Count!=0)
            {
                return true;
            }
            return false;
        }



        public bool IsAdministrator()
        {
            String SQL = "SELECT * FROM Administrator WHERE AdminID=" + mId;
            if (DoQuery(SQL).Tables[0].Rows.Count != 0)
            {
                return true;
            }
            return false;
        }

        public bool IsScienceMaster()
        {
            String SQL = "SELECT * FROM ScienceMaster WHERE masterID=" + mId;
            if (DoQuery(SQL).Tables[0].Rows.Count != 0)
            {
                return true;
            }
            return false;
        }

        static public String GetNameByID(String Id)
        {
            String SQL = "select Name from Student where StudentID=" + Id + "";
            DataSet ds = DoQuery(SQL);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        static public DataSet DoQuery(String SQL)
        {
            sqlEducation theSql=new sqlEducation(SQL);
            Ops.opsEducationQurey query = new Ops.opsEducationQurey(theSql,"Education");
            query.Do();
            return query.mResult;
        }

        static public bool DoExecute( ISql SQL)
        {
            Ops.opsEducationExec execute = new Ops.opsEducationExec(SQL, "Education");
            execute.Do();
            return true;
        }

        static public DataSet DoQuery(String SQL,String dataBase)
        {
            sqlEducation theSql = new sqlEducation(SQL);
            Ops.opsEducationQurey query = new Ops.opsEducationQurey(theSql, dataBase);
            query.Do();
            return query.mResult;
        }

    }
}
