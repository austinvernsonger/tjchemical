﻿using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class SqlDeleteTeacherOrdinary:ISql
    {
        private string SelectId;
        public void SetSelectId(string id)
        {
            SelectId = id;
        }
        public string GetSql()
        {
            return "delete from TeacherOrdinary where TeacherID = '" + SelectId + "'";
        }
    }
}
