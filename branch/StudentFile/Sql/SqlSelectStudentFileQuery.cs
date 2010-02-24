﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StudentFile.Sql
{
    class SqlSelectStudentFileQuery : OldtoNewSql
    {
        private string returnstring;
        public void GetConditon(String ID,String strName,Int16 iClass)
        {
            this.key = new object[] { "@ID", "@Name","@Class" };
            this.value = new object[] { "%" + ID.Trim() + "%", "%" + strName.Trim() + "%" ,iClass};
            returnstring = "select S.StudentID,S.Name,S.Class from [Student] as S,[Archives] as T where S.StudentID = T.StudentID";
            if (ID!=String.Empty)
            {
                returnstring += " and T.StudentID like @ID";
            }
            if (strName!=String.Empty)
            {
                returnstring += " and S.Name like @Name";
            }
            if (iClass != -1)
            {
                returnstring += " and S.Class = @Class";
            }
        }
        public override string GetSql()
        {
            return returnstring;
        }
    }
}
