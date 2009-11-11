using System;
using System.Collections.Generic;
using System.Text;

namespace SysCom.Ops
{
    /// <summary>
    /// Recover the MMT.
    /// </summary>
    class Recover : MMTOps
    {
        public override void processDelegate()
        {
            //myProcessor.Execute(new Sql.sqlMMTRecover(myContent.myId));
            myProcessor.Producer( "P_UPD_STATUS_MMT", myContent.myId, 0 );
        }
    }
}
