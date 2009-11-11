using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;


namespace SysCom
{
    /// <summary>
    /// Class MMT: Multi Media Text
    /// This class is a summary of all interfaces provider by this library.
    /// Bind with a user control named MMT, this object can be re-used anywhere.
    /// </summary>
    public class MMT
    {
        //////////////////////////////////////////////////////////////////////
        // Attributes
        //////////////////////////////////////////////////////////////////////

        /// <summary>
        /// The Basic information of an MMT instance.
        /// More detail of the structure please reader the comments in the file.
        /// </summary>
        MMTContent myContent = null;

        /// <summary>
        /// The Extra-information of an MMT instance.
        /// </summary>
        MMTContentEx myContentEx = null;

        /// <summary>
        /// Gets the MMT passage's ID.
        /// </summary>
        public String ID { get { return myContent.myId; } set { myContent.myId = value; } }

        /// <summary>
        /// Gets the postor's id of the MMT instance.
        /// </summary>
        public String PosterId
        {
            get { return (myContent == null) ? null : myContent.myPostor; }
        }

        /// <summary>
        /// Gets the department's id of the MMT instance.
        /// </summary>
        public Int32 DepartmentId
        {
            get { return (myContent == null) ? 0 : myContent.myDepartment; }
        }

        /// <summary>
        /// Gets the view times of the MMT instance.
        /// </summary>
        public Int32 ViewTimes
        {
            get { return (myContent == null) ? 0 : myContent.myViewTimes; }
        }

        /// <summary>
        /// Gets or sets the title of the MMT instance.
        /// </summary>
        public String Title
        {
            get { return (myContent == null) ? null : myContent.myTitle; }
            set { if (this.IsValidated) myContent.myTitle = value; }
        }

        /// <summary>
        /// Gets or sets the content of the MMT instance.
        /// </summary>
        public String Content
        {
            get { return (myContent == null) ? null : myContent.myContent; }
            set { if (this.IsValidated) myContent.myContent = value; }
        }

        /// <summary>
        /// Last Modify Time
        /// </summary>
        public DateTime LastModifyTime
        {
            get { return ( myContent == null ) ? DateTime.MinValue : myContent.myLastModifyTime; }
        }

        /// <summary>
        /// Add a label to the MMT instance.
        /// </summary>
        /// <param name="Label"></param>
        public Boolean AddLabel(String Label)
        {
            // Add a lebel to the MMT instance.
            if (this.IsValidated)
            {
                // Add when does not contain the label
                if (!myContent.myLabels.Contains(Label))
                {
                    if (myExisted)
                    {
                        Ops.addLabel myAddLabel = new SysCom.Ops.addLabel(myContent.myId, Label);
                        if (!myAddLabel.Do())
                        {
                            myLastErrorMsg = myAddLabel.GetLastError();
                            return false;
                        }
                    }
                    myContent.myLabels.Add(Label);
                }
            }
            return true;
        }

        /// <summary>
        /// Delete a label from the label list of the MMT instance.
        /// Return false if the label doesn't existed.
        /// </summary>
        /// <param name="Label">Label to be deleted</param>
        /// <returns>Statue of the operation</returns>
        public Boolean DeleteLabel(String Label)
        {
            // Delete the label specified by the parameter.
            if (this.IsValidated)
            {
                if (!myContent.myLabels.Remove(Label)) return false;
                // Delete from the database.
                Ops.delLabel tmpDelLabel = new SysCom.Ops.delLabel(myContent.myId, Label);
                if (tmpDelLabel.Do()) return true;
                myLastErrorMsg = tmpDelLabel.GetLastError();
                return false;
            }
            // Invalidated
            return false;
        }

        /// <summary>
        /// Gets the Label List of the MMT instance.
        /// </summary>
        public List<String> Labels
        {
            get { return (myContent == null) ? null : myContent.myLabels; }
        }

        public Boolean HasAttachment
        {
            get { return (myContent == null) ? false : myContent.myHasAttachment; }
            set { if (this.IsValidated) myContent.myHasAttachment = value; }
        }

        /// <summary>
        /// Add attechment to the MMT instance.
        /// </summary>
        /// <param name="AttechmentName">File Name</param>
        /// <param name="AttechmentExt">File Extension</param>
        public Boolean AddAttechment(String AttechmentName, String AttechmentExt)
        {
            // Add the attechment to the MMT instance.
            if (!this.IsValidated) { myLastErrorMsg = "Invalidate MMT."; return false; }
            if (!myContent.myAttachments.Contains(new Attachment(AttechmentName, AttechmentExt)))
            {
                if (myExisted)
                {
                    Ops.addAttechment myAddAttech = new SysCom.Ops.addAttechment(myContent.myId, AttechmentName, AttechmentExt);
                    if (!myAddAttech.Do())
                    {
                        myLastErrorMsg = myAddAttech.GetLastError();
                        return false;
                    }
                }
                myContent.myAttachments.Add(new Attachment(AttechmentName, AttechmentExt));
                myContent.myHasAttachment = true;
            }
            return true;
        }

        /// <summary>
        /// Delete an attechment from the MMT instance.
        /// </summary>
        /// <param name="AttechmentName">File Name</param>
        /// <param name="AttechmentExt">File Extension</param>
        /// <returns>Statue of the operation</returns>
        public Boolean DeleteAttechment(String AttechmentName, String AttechmentExt)
        {
            // Delete the attechment of the MMT instance.
            if (this.IsValidated)
            {
                Ops.delAttachment myDelAttach = new SysCom.Ops.delAttachment(myContent.myId, AttechmentName, AttechmentExt);
                Boolean rtnResult = myContent.myAttachments.Remove(
                    new Attachment(AttechmentName, AttechmentExt));
                if (rtnResult)
                {
                    rtnResult = myDelAttach.Do();
                    // Roll back
                    if (!rtnResult)
                    {
                        myContent.myAttachments.Add(new Attachment(AttechmentName, AttechmentExt));
                        myLastErrorMsg = myDelAttach.GetLastError();
                    }
                }

                return rtnResult;
            }
            return false;
        }

        /// <summary>
        /// Gets the attechment list of the MMT instance.
        /// </summary>
        public List<Attachment> Attechments
        {
            get { return (myContent == null) ? null : myContent.myAttachments; }
        }

        /// <summary>
        /// Gets or sets the internal flag of the MMT instance.
        /// </summary>
        /// <returns>Is Internal</returns>
        public Boolean IsInternal
        {
            get { return (myContent == null) ? false : myContent.myIsInternal; }
            set { if (this.IsValidated) myContent.myIsInternal = value; }
        }

        /// <summary>
        /// Gets or sets the Start time of the MMT instance.
        /// </summary>
        public DateTime StartTime
        {
            get { return (myContentEx == null) ? Convert.ToDateTime(false) : myContentEx.myStartTime; }
            set
            {
                if (this.IsValidated)
                {
                    myContentEx.myStartTime = value;
                    myContent.myHasExInfo = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the End time of the MMT instance.
        /// </summary>
        public DateTime EndTime
        {
            get { return (myContentEx == null) ? Convert.ToDateTime(false) : myContentEx.myEndTime; }
            set
            {
                if (this.IsValidated)
                {
                    if (value <= myContentEx.myStartTime) myContentEx.myEndTime = myContentEx.myStartTime;
                    else myContentEx.myEndTime = value;
                    myContent.myHasExInfo = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the location of the MMT instance.
        /// </summary>
        public String Location
        {
            get { return (myContentEx == null) ? null : myContentEx.myLocation; }
            set 
            {
                if (this.IsValidated)
                {
                    myContentEx.myLocation = value;
                    myContent.myHasExInfo = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Report Form's Id
        /// The start time and end time will be check before setting.
        /// If the start time and end time haven't been set, they will
        /// be set to now automatically.
        /// </summary>
        public String ReportFormId
        {
            get { return (myContentEx == null) ? null : myContentEx.myReportFormId; }
            set 
            {
                if (this.IsValidated)
                {
                    myContentEx.myReportFormId = value;
                    myContent.myHasExInfo = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Report DataSet's Id
        /// If the Report Form's Id is null, this attribute will be 
        /// ommited when post or update.
        /// </summary>
        public String ReportDataSet
        {
            get { return (myContentEx == null) ? null : myContentEx.myReportDataSet; }
            set { if (this.IsValidated) myContentEx.myReportDataSet = value; }
        }

        /// <summary>
        /// If the MMT has Ex information
        /// </summary>
        public Boolean HasExInfo
        { get { return (myContent == null) ? false : myContent.myHasExInfo; } }

        public String Mode
        {
            get { return (myContent == null) ? null : myContent.myMode; }
            set { if (this.IsValidated) myContent.myMode = value; }
        }

        /// <summary>
        /// Check if the MMT is validated.
        /// If the MMT is not validated, all operations will be abandoned.
        /// </summary>
        public Boolean IsValidated
        {
            get { return (myContent == null) ? false : !myContent.myMarkDeleted; }
        }

        /// <summary>
        /// My Last Error Message.
        /// Set by the Method of MMT.
        /// </summary>
        private String myLastErrorMsg = null;

        /// <summary>
        /// Internal Usage.
        /// </summary>
        private Boolean myExisted = false;

        //////////////////////////////////////////////////////////////////////
        // Method
        //////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Construction One.
        /// Get the information from the database via the specified MMT Id.
        /// if the Id doesn't existed, all thing will be set to null.
        /// </summary>
        /// <param name="MMTId">MMT's Id</param>
        public MMT(String MMTId)
        {
            // Get the MMT via the specified Id.
            SysCom.Ops.GetMMT op_getMMT = new SysCom.Ops.GetMMT();
            // Initialize Content
            myContent = new MMTContent();
            // Set Id
            myContent.myId = MMTId;
            myContentEx = new MMTContentEx();
            op_getMMT.Content = myContent;
            op_getMMT.ContentEx = myContentEx;
            // Get the MMT
            if (!op_getMMT.Do())
            {
                this.myLastErrorMsg = op_getMMT.GetLastError();
                myContent = null;
                return;
            }
            //myContentEx = new MMTContentEx();
            myContent = op_getMMT.Content;
            myContentEx = op_getMMT.ContentEx;
            myExisted = true;
            // Get the data.
        }

        /// <summary>
        /// Construction Two.
        /// Create an MMT via the specified Poster's Id and the Department Id.
        /// If the parameters are invalidated, all things will be set to null
        /// and the validated information of this MMT will be set to false;
        /// </summary>
        /// <param name="PosterId"></param>
        /// <param name="DepartmentId"></param>
        public MMT(String PosterId, Int32 DepartmentId)
        {
            // Create new MMT via the specified information.
            myContent = new MMTContent();
            myContentEx = new MMTContentEx();
            myContent.myPostor = PosterId;
            myContent.myDepartment = DepartmentId;
            myContent.myId = IdGenerator.GenerateId();
            //myContent.myLastModifyTime = DateTime.Now;
        }

        private Boolean doOperation(Ops.MMTOps op_MMT, String ErrorMsg)
        {
            if (!this.IsValidated)
            {
                this.myLastErrorMsg = ErrorMsg;
                return false;
            }
            op_MMT.Content = this.myContent;
            op_MMT.ContentEx = this.myContentEx;
            if (!op_MMT.Do())
            {
                this.myLastErrorMsg = op_MMT.GetLastError();
                return false;
            }
            this.myLastErrorMsg = "Successful.";
            return true;
        }

        /// <summary>
        /// Post the MMT according to the information be specified.
        /// </summary>
        /// <returns></returns>
        public Boolean Post()
        {
            // Post the MMT
            return this.doOperation(new SysCom.Ops.Post(), "Empty MMT.");
        }

        public Boolean Update()
        {
            // Update the MMT
            myContent.myLastModifyTime = DateTime.Now;
            return this.doOperation(new SysCom.Ops.Update(), "Invalidate MMT.");
        }

        public Boolean MarkDelete()
        {
            // MarkDelete the MMT
            return this.doOperation(new SysCom.Ops.MarkDel(), "Been mark deleted already.");
        }

        public Boolean Recover()
        {
            // Recover the MMT
            return this.doOperation(new SysCom.Ops.Recover(), "Validate MMT already.");
        }

        public Boolean Delete()
        {
            // Directly delete the MMT
            return this.doOperation(new SysCom.Ops.Delete(), "Invalidate MMT.");
        }

        public Boolean GetContent()
        {
            if (myExisted)
            {
                Ops.getContent contentGet = new SysCom.Ops.getContent(myContent.myId);
                if (contentGet.Do())
                {
                    myContent.myContent = contentGet.Content;
                    return true;
                }
                else myLastErrorMsg = contentGet.GetLastError();
            }
            else myLastErrorMsg = "Invalidate MMT.";
            return false;
        }

        /// <summary>
        /// Return the content's virtual path.
        /// </summary>
        /// <returns></returns>
        public String GetContentFile()
        {
            if (myExisted) return "Information/" + myContent.myId + ".html";
            else return null;
        }

        public String GetLastError()
        {
            // Get the last error occured during the operation.
            return myLastErrorMsg;
        }
    }
}
