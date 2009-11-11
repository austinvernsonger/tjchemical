using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;

namespace SysCom.Ops
{
    /// <summary>
    /// Update the MMT to the update statue.
    /// @Author: Push
    /// </summary>
    class Update : MMTOps
    {
        public override void processDelegate()
        {
            // Update the Main Content.
            Sql.sqlMMTUpdate myUpdate = new SysCom.Sql.sqlMMTUpdate(myContent, myContentEx);
            myProcessor.Execute(myUpdate);
            postContent myPostContent = new postContent(myContent.myId, myContent.myContent);
            myPostContent.Do();

            // Update the Extra Information
            myUpdate.Mode = SysCom.Sql.sqlMMTUpdate.UpdateMode.ExInfor;
            myProcessor.Execute(myUpdate);
        }
    }
}
