﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;

namespace StundentInfoManagement.Sql
{
    class SqlSelectAllStudentBasicInfo : OldtoNewSql
    {
        public void SetSelectId(string id)
        {
            this.key = new object[] { "@Id" };
            this.value = new object[] { id.Trim() };
        }
        public override string GetSql()
        {
            return "select * from [Student] where StudentID = @Id";
        }
    }
}
