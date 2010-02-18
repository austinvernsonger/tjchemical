using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;

namespace SysCom.Ops
{
    /// <summary>
    /// The operation to delete the attachment.
    /// @Author: Push
    /// </summary>
    class delAttachment : DBOperation
    {
        /// <summary>
        /// The Attributes
        /// </summary>
        String myId;
        String myFileName;
        String myFileExtension;

        public delAttachment(String Id, String FileName, String FileExtension)
        {
            myId = Id;
            myFileName = FileName;
            myFileExtension = FileExtension;
            BindDBName = "TjMedical";
        }

        public override void processDelegate()
        {
            myProcessor.Producer( "P_DEL_ATTACH_MMT", myId, 
                string.Format( "{0}.{1}", myFileName, myFileExtension ) );
        }
    }
}
///