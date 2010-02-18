using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;

namespace SysCom.Ops
{
    /// <summary>
    /// Basic Operation Class of MMT Library.
    /// Provider the attributes of the MMT, which will be used to 
    /// generate the sql sentence by the ISql interface.
    /// </summary>
    class MMTOps : DBOperation
    {
        public MMTOps()
        {
           BindDBName = "TjMedical";
        }
        /// <summary>
        /// The Content
        /// </summary>
        protected MMTContent myContent;
        /// <summary>
        /// Gets or sets the content
        /// </summary>
        public MMTContent Content
        {
            get { return myContent; }
            set { myContent = value; }
        }

        /// <summary>
        /// The Content's Extra Information
        /// </summary>
        protected MMTContentEx myContentEx;
        /// <summary>
        /// Gets or sets the contentEx
        /// </summary>
        public MMTContentEx ContentEx
        {
            get { return myContentEx; }
            set { myContentEx = value; }
        }
    }
}
