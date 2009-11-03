
using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;

namespace SysCom.Ops
{
    /// <summary>
    /// Delete the MMT From the Database.
    /// The relationship of the MMT in the database will be delete
    /// automatically by the database itself.
    /// @Author: Push
    /// </summary>
    class Delete : MMTOps
    {
        /// <summary>
        /// Do not need to delete the Ex Files.
        /// </summary>
        public override void processDelegate()
        {
            //myProcessor.Execute(new Sql.sqlMMTDelete(myContent.myId));
            myProcessor.Producer( "P_DELETE_MMT", myContent.myId );
        }
    }
}
