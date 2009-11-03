

using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;
using SMBL.Interface.Document;

namespace SysCom.Ops
{
    /// <summary>
    /// Get the content from the file of the specified MMTId
    /// @Author: Push
    /// </summary>
    class getContent : DocOperation
    {
        String myContent = null;
        /// <summary>
        /// Gets the content of the MMT.
        /// </summary>
        public String Content
        {
            get { return myContent; }
        }

        /// <summary>
        /// Construction.
        /// </summary>
        /// <param name="Id"></param>
        public getContent(String Id)
        {
            myBindFilePath = SMBL.Global.WebSite.AppPath + "\\Information\\" + Id + ".html";
        }

        /// <summary>
        /// Read To End.
        /// </summary>
        public override void processDelegate()
        {
            myContent = myProcessor.RealToEnd();
        }
    }
}
