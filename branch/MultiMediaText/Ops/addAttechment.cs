using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;

namespace SysCom.Ops
{
    /// <summary>
    /// Add an attechment to the database.
    /// @Auhtor: Push
    /// </summary>
    class addAttechment : DBOperation
    {
        String myId;
        String myFileName;
        String myFileExtension;

        public addAttechment(String Id, String FileName, String FileExtension)
        {
            myId = Id;
            myFileName = FileName;
            myFileExtension = FileExtension;
            myBindDBName = "Information";
        }

        public override void processDelegate()
        {
            //base.processDelegate();
            //myProcessor.Execute(new Sql.sqlAddAttachment(myId, myFileName, myFileExtension));
            myProcessor.Producer( "P_ADD_ATTACH_MMT",
                myId,
                string.Format( "{0}.{1}", myFileName, myFileExtension ) );
        }
    }
}
