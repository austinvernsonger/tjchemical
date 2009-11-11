using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace AlumnusRecord.Sql
{
    class SqlInsert : ISql
    {
        private string i;
        public SqlInsert(string i)
        {
            this.i = i;
        }

        #region ISql 成员

        public string GetSql()
        {
            return @"INSERT INTO Graduate(Name,StudentID,Graduate.Password,Origin,TeachingPoint,GraduateYear,HeadPicture,WorkPlace,WorkAddress,Phone,Email,Summary,Publicity,Degree) VALUES ('韦勐', '" + i + @"', '111','山东','同济本部','2009',null,'张江','sap公司','13232323232','weimeng@yahoo.com.cn','sumry韦',1,1)";
        }

        #endregion
    }
}
