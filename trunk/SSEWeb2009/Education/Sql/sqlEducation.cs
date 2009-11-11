using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Education.Sql
{
    /// <summary>
        /// 教务模块通用Sql语句生成器
        /// </summary>
    class sqlEducation:ISql
    { 
            String mSQL;

            public sqlEducation(String SQL)
            {
                mSQL = SQL;
            }

            /// <summary>
            /// Get Sql Sentence
            /// </summary>

            #region ISql Members

            public string GetSql()
            {
                return mSQL;
            }

            #endregion
    }
}
