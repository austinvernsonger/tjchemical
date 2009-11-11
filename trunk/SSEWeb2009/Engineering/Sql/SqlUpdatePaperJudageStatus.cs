using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdatePaperJudageStatus:ISql
    {
        private PaperJudge _pj;

        public SqlUpdatePaperJudageStatus(PaperJudge pj)
        {
            _pj = pj;
        }

        #region ISql 成员

        public string GetSql()
        {
            DateTime dtNow = System.DateTime.Now;

            if (_pj.JudgeStatue != -1)
            {
                return "update ThesisJudgeInfo Set JudgeTime = '" + dtNow + "',IsCriterion='" + _pj.Criterion + "',JudgeResult='" + _pj.Result + "', JudgeStatue='"+_pj.JudgeStatue+"' where StudentID = '" + _pj.StudentID + "' and TeacherID='" + _pj.Teacherid + "'";
            }
            else
            {
                return "update ThesisJudgeInfo Set JudgeTime = '" + dtNow + "',IsCriterion='" + _pj.Criterion + "',JudgeResult='" + _pj.Result + "' where StudentID = '" + _pj.StudentID + "' and TeacherID='" + _pj.Teacherid + "'";
            }
        }

        #endregion
    }
}
