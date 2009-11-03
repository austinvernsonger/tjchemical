
using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;

namespace SysCom.Ops
{
    /// <summary>
    /// Mark Delete the MMT.
    /// @Author: Push
    /// </summary>
    class MarkDel : MMTOps
    {
        public override void processDelegate()
        {
            //myProcessor.Execute(new Sql.sqlMMTMarkDel(myContent.myId));
            myProcessor.Producer( "P_UPD_STATUS_MMT", myContent.myId, 1 );
        }
    }
}
