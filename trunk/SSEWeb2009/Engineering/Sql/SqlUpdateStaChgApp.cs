using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateStaChgApp : ISql
    {       
            private int _applyID;
            private int  _appResult;
            private string _appRemark;

            public SqlUpdateStaChgApp(int applyID, int applyResult, string applyRemark)
            {
                _applyID = applyID;
                _appResult = applyResult;
                _appRemark = applyRemark;

            }

            #region ISql 成员

            public string GetSql()
            {
                if (_appResult == 1)
                {
                    return "update StustatusChangeInfo Set ApplyResult = '" + _appResult + "',ApplyRemark = '" + _appRemark + "',Activiy=0 where StuStatusID = '" + _applyID + "'";
                }
                else
                {
                    return "update StustatusChangeInfo Set ApplyResult = '" + _appResult + "',ApplyRemark = '" + _appRemark + "',Activiy=2 where StuStatusID = '" + _applyID + "'";
                }
            }

            #endregion
        
    }
}
