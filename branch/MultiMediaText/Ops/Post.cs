using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;

namespace SysCom.Ops
{
    /// <summary>
    /// Create a New MMT record in the database.
    /// @Author: Push
    /// </summary>
    class Post : MMTOps
    {
        /// <summary>
        /// Execute the Insert SQL Sentenct by invoking the sqlMMTPost interface.
        /// </summary>
        public override void processDelegate()
        {
            myProcessor.Producer( "P_CREATE_MMT",
                    myContent.myId,
                    myContent.myTitle,
                    myContent.myPostor,
                    myContent.myDepartment,
                    myContent.myHasAttachment ? 1 : 0,
                    myContent.myHasExInfo ? 1 : 0,
                    myContent.myIsInternal ? 1 : 0,
                    myContent.myMode );

            postContent myPostContent = new postContent(myContent.myId, myContent.myContent);
            
            if (!myPostContent.Do()) throw new Exception("Error has been occured during post the Content!");

            // Insert the Extra information
            if (myContent.myHasExInfo)
            {
                myProcessor.Producer( "P_ADD_EXINFO_MMT",
                    myContent.myId,
                    myContentEx.myStartTime,
                    myContentEx.myEndTime,
                    myContentEx.myLocation,
                    myContentEx.myReportFormId,
                    myContentEx.myReportDataSet );
            }
            // Insert the Attachment information
            if (myContent.myHasAttachment)
            {
                foreach ( Attachment attach in myContent.myAttachments )
                {
                    myProcessor.Producer( "P_ADD_ATTACH_MMT",
                        myContent.myId,
                        string.Format( "{0}.{1}", attach.FileName, attach.FileExtension ) );
                }
            }
            // Insert the lables
            if (myContent.myLabels.Count > 0)
            {
                foreach ( string lbStr in myContent.myLabels )
                {
                    myProcessor.Producer( "P_ADD_LABEL_MMT",
                        myContent.myId,
                        lbStr );
                }
            }
        }
    }
}
