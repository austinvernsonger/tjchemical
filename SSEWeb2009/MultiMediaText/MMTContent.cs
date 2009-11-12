﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SysCom
{
    /// <summary>
    /// MultiMedia Text Content
    /// This class is the data set of the library.
    /// It is a private class so that no up-layer application could view it. 
    /// The data stored in this class contains all parts of the MMT library,
    /// we provide a string to store the content of the MMT, and some attri-
    /// butes to store the information about the MMT.
    /// @Author: Push
    /// @Date: 2009-05-05
    /// </summary>
    class MMTContent
    {
        /// <summary>
        /// Id of a MMT instance.
        /// The id shoule be generated by the IdGenerator.
        /// </summary>
        public String myId = null;

        /// <summary>
        /// The Postor of the MMT.
        /// This attribute should be set to the user who post the MMT. A
        /// user's id could be a series number of 5 or 8 bits.
        /// </summary>
        public String myPostor = null;

        /// <summary>
        /// Title of a MMT instance.
        /// The MAX length of the title should within 64 utf-8 words.
        /// </summary>
        public String myTitle = null;

        /// <summary>
        /// The Content of the MMT.
        /// This attribute contains all texts the MMT want to post. The 
        /// value stored by this attribute should be put into a XML file
        /// or even an plaint text file. 
        /// And this attribute should pass the FILTER first to sure the 
        /// information it contains is safe.
        /// </summary>
        public String myContent = null;

        /// <summary>
        /// The Department of the MMT to be post to.
        /// The department attribute should be the id bind with the specified
        /// department. The relationship of the id and the department could be 
        /// found in the enumration DPMNT.
        /// </summary>
        public Int32 myDepartment = 0;

        /// <summary>
        /// Last Modify Time of a MMT instance.
        /// When the MMT instance is a new one, the time should be set to the
        /// current time so that it means the post time.
        /// Actually the time should always set to the current time when 
        /// MMT want to do any operations. 
        /// </summary>
        public DateTime myLastModifyTime = DateTime.Now;

        /// <summary>
        /// The times the MMT been viewed.
        /// Automactially increase when get the MMT from the database.
        /// </summary>
        public Int32 myViewTimes = 0;

        /// <summary>
        /// Whether the MMT has been mark deleted. 
        /// If the value is true, the MMT is still available. Otherwise,
        /// the MMT has been mark deleted and can not be opearted beside
        /// being recoverd.
        /// </summary>
        public Boolean myMarkDeleted = false;

        /// <summary>
        /// Whether the MMT contains attachments or not.
        /// If the value is true, than check the attachment table to get
        /// the attachments bind with the MMT instance.
        /// </summary>
        public Boolean myHasAttachment = false;

        /// <summary>
        /// Set the file array of the attachement read from the database 
        /// if the MMT contains attachments specified by myHasAttachment
        /// </summary>
        public List<Attachment> myAttachments = new List<Attachment>();

        /// <summary>
        /// Check if the MMT instance contains the Extra-Information. If 
        /// the MMT instance does it, the attribute, myExInfo, should re-
        /// fer to an MMTContentEx class, otherwise, should be set to null.
        /// </summary>
        public Boolean myHasExInfo = false;

        /// <summary>
        /// Is Internal MMT.
        /// Mark this MMT to be an internal use or public message.
        /// </summary>
        public Boolean myIsInternal = false;

        /// <summary>
        /// The labels of the MMT
        /// This attribute will be stored in the relationship table of 
        /// MMT and Labels.
        /// </summary>
        public List<String> myLabels = new List<string>();

        /// <summary>
        /// The mode of the MMT.
        /// Should be passage, news, notice, activity or registration
        /// </summary>
        public String myMode = "passage";
    }
}