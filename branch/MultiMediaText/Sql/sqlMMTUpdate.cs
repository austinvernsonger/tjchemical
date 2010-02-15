using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;


namespace SysCom.Sql
{
    /// <summary>
    /// Update the MMT instance to the update statue.
    /// @Author: Push
    /// </summary>
    class sqlMMTUpdate : OldtoNewSql
    {
        /// <summary>
        /// Update mode: MainContent and Extra-Information
        /// </summary>
        public enum UpdateMode { MainContent, ExInfor }
        private UpdateMode myMode = UpdateMode.MainContent;
        public UpdateMode Mode
        {
            set { myMode = value; }
        }

        /// <summary>
        /// My Attributes
        /// </summary>
        MMTContent myContent = null;
        MMTContentEx myContentEx = null;

        public sqlMMTUpdate(MMTContent Content, MMTContentEx ContentEx)
        {
            myContent = Content;
            myContentEx = ContentEx;
        }

        #region ISql Members

        public override string GetSql()
        {
            /*
             * MainContent:
             * UPDATE Information SET Title, LastModifyTime WHERE ID;
             * ExInfor:
             * UPDATE InformationExtends SET StartTime, EndTime, 
             * Location, RegistrationFormFileName, RegistrationRecordFileName
             * WHERE ID
             */
            switch (myMode)
            {
                case UpdateMode.MainContent:
                    return "UPDATE Information SET Title='" + myContent.myTitle + "', LastModifyTime='" +
                        myContent.myLastModifyTime + "' WHERE ID='" + myContent.myId + "'";
                case UpdateMode.ExInfor:
                    return "UPDATE InformationExtends SET StartTime='" + myContentEx.myStartTime +
                        "', EndTime='" + myContentEx.myEndTime + "', Location='" + myContentEx.myLocation +
                        "', RegistrationFormFileName='" + myContentEx.myReportFormId + "', RegistrationRecordFileName='" +
                        myContentEx.myReportDataSet + "' WHERE InformationID='" + myContent.myId + "'";
                default: return null;
            }
        }

        #endregion
    }
}
