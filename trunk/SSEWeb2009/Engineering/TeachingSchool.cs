using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Department.Engineering
{
    public class TeachingSchool
    {
        #region Member Variables

        private string  _teaSchoolID;
        private string _teaSchoolName;
        private string _password;

        #endregion

        #region Constructor

        public TeachingSchool() { }

        #endregion

        #region Public Properties

        public string TeaSchoolID
        {
            set { _teaSchoolID = value; }
            get { return _teaSchoolID; }
        }

        public string TeaSchoolName
        {
            set { _teaSchoolName = value; }
            get { return _teaSchoolName; }
        }

        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }

        #endregion
   
        #region GetFunctions

        /// <summary>
        /// 获取所有教学点的信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetTeaSchool()
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeaSchoolInfo());
            op.Do();
            return op.Ds;
        }

        public DataSet GetTeaSchoolList()
        {
            DataSet ds = GetTeaSchool();
            DataRow dr = ds.Tables[0].NewRow();
            dr[1] = "请选择教学点";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    //DataRow dr = ds.Tables[0].NewRow();
            //    //dr[1] = "请选择教学点";
            //    //ds.Tables[0].Rows.InsertAt(dr, 0);
            //}
            return ds;
        }

        /// <summary>
        /// 根据教学点编号，返回教学点信息
        /// </summary>
        /// <param name="tSchoolID">教学点编号</param>
        /// <returns></returns>
        public DataSet GetTeaSchoolInfoBytSchoolID(string tSchoolID)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeaSchoolInfoBytSchoolID(tSchoolID));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据教学点名称，返回教学点信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataSet GetTeaSchoolInfoBytSchoolName(string name)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTeaSchoolInfoBytSchoolName(name));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 根据年级，返回相应的教学点
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public DataSet GetTeaSchoolSet(string grade)
        {
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTSchooling(grade));
            op.Do();
            return op.Ds;
        }

        /// <summary>
        /// 对返回教学点信息的扩展
        /// </summary>
        /// <param name="selValue"></param>
        /// <returns></returns>
        public DataSet GetTeaSchool(string selValue)
        {
            DataSet ds = GetTeaSchoolSet(selValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "--请选择教学点--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                return ds;
            }
            return null;
        }

        #endregion

        #region AddFunctions

        /// <summary>
        /// 添加新教学点
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public bool AddNewTeaSchoolInfo(TeachingSchool ts)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlAddNewTeaSchoolInfo(ts));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }


        #endregion

        #region UpdateFunctions

        /// <summary>
        /// 更新已有教学点信息
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public bool UpdateTeaSchoolInfo(TeachingSchool ts)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateTeaSchoolInfo(ts));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
