using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;

namespace SysCom.Ops
{
    /// <summary>
    /// Operation to add the label to the database.
    /// @Auhtor: Push
    /// </summary>
    class addLabel : DBOperation
    {
        String myId;
        String myLabel;

        public addLabel(String Id, String Label)
        {
            myId = Id;
            myLabel = Label;
            myBindDBName = "Information";
        }

        public override void processDelegate()
        {
            //base.processDelegate();
            //myProcessor.Execute(new Sql.sqlAddLabel(myId, myLabel));
            myProcessor.Producer( "P_ADD_LABEL_MMT", myId, myLabel );
        }
    }
}
