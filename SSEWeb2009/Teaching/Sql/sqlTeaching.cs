using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Teaching.Sql
{
    /// <summary>
    /// 教学模块通用Sql语句生成器
    /// </summary>
    class sqlTeaching : ISql
    {
        
        String mSQL;

        public sqlTeaching(String SQL)
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
