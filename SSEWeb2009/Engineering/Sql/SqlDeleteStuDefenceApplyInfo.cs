﻿using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteStuDefenceApplyInfo:ISql
    {
        private string _studentID;

        public SqlDeleteStuDefenceApplyInfo(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "delete from DefenceApplicationStatus where StudentID ='" + _studentID + "'";
        }

        #endregion
    }
}
