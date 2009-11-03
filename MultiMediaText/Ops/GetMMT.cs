
using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;
using SMBL.Interface.Database;

namespace SysCom.Ops
{
    /// <summary>
    /// The operation to get an MMT from the database
    /// @Author: Push
    /// </summary>
    class GetMMT : MMTOps
    {
        /// <summary>
        /// Query the database with different sql sentenct to get the whole MMT
        /// </summary>
        public override void processDelegate()
        {
            //Sql.sqlMMTGet myGet = new SysCom.Sql.sqlMMTGet(myContent.myId);
            System.Data.DataSet myMainContent = myProcessor.Producer( "P_GET_MMT", myContent.myId );
            // Get Value From the Result...
            System.Data.DataTable tmpTable = myMainContent.Tables[0];
            System.Data.DataRow tmpRow = tmpTable.Rows[0];
            myContent.myTitle = (String)tmpRow["Title"];
            myContent.myPostor = (String)tmpRow["PublisherID"];
            myContent.myLastModifyTime = Convert.ToDateTime(tmpRow["LastModifyTime"]);
            myContent.myDepartment = Convert.ToInt32(tmpRow["DepartmentID"]);
            myContent.myViewTimes = Convert.ToInt32(tmpRow["ClickCount"]);
            myContent.myMarkDeleted = Convert.ToBoolean(tmpRow["State"]);
            myContent.myHasAttachment = Convert.ToBoolean(tmpRow["HasAttachment"]);
            myContent.myHasExInfo = Convert.ToBoolean(tmpRow["HasExtends"]);
            myContent.myMode = (String)tmpRow["Mode"];
            
            // Get Content
            // getContent myGetContent = new getContent(myContent.myId);
            // myGetContent.Do();
            // myContent.myContent = myGetContent.Content;

            if (myContent.myHasExInfo)
            {
                //myGet.Mode = SysCom.Sql.sqlMMTGet.GetMode.ExInfor;
               // System.Data.DataSet myExInfor = myProcessor.Query(myGet);
                // Get the Value From the Resule...
                tmpTable = myMainContent.Tables [1];
                tmpRow = tmpTable.Rows[0];
                myContentEx.myStartTime = Convert.ToDateTime(tmpRow["StartTime"]);
                myContentEx.myEndTime = Convert.ToDateTime(tmpRow["EndTime"]);
                myContentEx.myLocation = (String)tmpRow["Location"];
                myContentEx.myReportFormId = (String)tmpRow["RegistrationFormFileName"];
                myContentEx.myReportDataSet = (String)tmpRow["RegistrationRecordFileName"];
            }
            if (myContent.myHasAttachment)
            {
                //myGet.Mode = SysCom.Sql.sqlMMTGet.GetMode.Attachment;
                //System.Data.DataSet myAttachment = myProcessor.Query(myGet);
                // Get the Attachment to the MMT
                tmpTable = myMainContent.Tables [2];
                for (int i = 0; i < tmpTable.Rows.Count; ++i)
                {
                    tmpRow = tmpTable.Rows[i];
                    Attachment tmpAttach = new Attachment(
                        (String)tmpRow["AttachmentFileName"], 
                        string.Empty);
                    tmpAttach.DownLoadTimes = Convert.ToInt32(tmpRow["DownloadCount"]);
                    myContent.myAttachments.Add(tmpAttach);
                }
            }
            //myGet.Mode = SysCom.Sql.sqlMMTGet.GetMode.Label;
            //System.Data.DataSet myLabel = myProcessor.Query(myGet);
            // Get the Label to the MMT
            tmpTable = myMainContent.Tables [3];
            for (int i = 0; i < tmpTable.Rows.Count; ++i)
            {
                tmpRow = tmpTable.Rows[i];
                myContent.myLabels.Add((String)tmpRow["Label"]);
            }
        }
    }
}
