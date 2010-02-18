using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;

namespace SysCom.Ops
{
    /// <summary>
    /// Delete a label from the database.
    /// </summary>
    class delLabel : DBOperation
    {
        /// <summary>
        /// My attributes
        /// </summary>
        String myId;
        String myLabelToDelete;

        public delLabel(String Id, String Label)
        {
            myId = Id;
            myLabelToDelete = Label;
            BindDBName = "TjMedical";
        }
        public override void processDelegate()
        {
            //base.processDelegate();
            myProcessor.Producer( "P_DEL_LABEL_MMT", myId, myLabelToDelete );
        }
    }
}
