using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class SqlAddTuitionInfo : ISql
    {
         private TuitionInfo tuInfo;

        public SqlAddTuitionInfo(TuitionInfo tu)
        {
           tuInfo = tu;
        }

        #region ISql 成员

        public string GetSql()
        {
            if (tuInfo.Remark != null)
            {
                return "insert into TuitionInfo(StuID,ActualMoney,MustMoney,PaymentTerm,PaymentTime,Remark) values('" + tuInfo.StudID + "','" + tuInfo.ActualMoney + "','" + tuInfo.MustMoney + "','" + Convert.ToInt32(tuInfo.PaymentTerm) + "','" + System.DateTime.Now + "','" + tuInfo.Remark + "')";
            }
            else
            {
                return "insert into TuitionInfo(StuID,ActualMoney,MustMoney,PaymentTerm,PaymentTime) values('" + tuInfo.StudID + "','" + tuInfo.ActualMoney + "','" + tuInfo.MustMoney + "','" + Convert.ToInt32(tuInfo.PaymentTerm) + "','" + System.DateTime.Now + "')";
            }
        }

        #endregion
    }
    
}
