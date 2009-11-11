using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Education.Sql
{
    public class sqlAgreeAssistant:ISql
    {
        int mApplyNum=0;
      public  sqlAgreeAssistant(int num)
        {
            mApplyNum=num;
        }
            /// <summary>
        /// Get Sql Sentence
        /// </summary>
        #region ISql members
        public string GetSql()
        {
            return "update assiatant_apply set examine_state = 1 where apply_num ="+mApplyNum.ToString();
        }
        #endregion
    }
}
