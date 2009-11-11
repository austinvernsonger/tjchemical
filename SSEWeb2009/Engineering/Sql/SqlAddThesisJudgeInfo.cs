using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddThesisJudgeInfo:ISql
    {
        private string _teacherID;
        private int _isLeader;
        private string _studentID;

        public SqlAddThesisJudgeInfo(string teacherID, int isLeader, string studentID)
        {
            _teacherID = teacherID;
            _isLeader = isLeader;
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into ThesisJudgeInfo(TeacherID,IsLeader,StudentID) values('" + _teacherID + "','" + _isLeader + "','" + _studentID + "')";
        }

        #endregion
    }
}
