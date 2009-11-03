
using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;
using SMBL.Interface.Document;

namespace SysCom.Ops
{
    /// <summary>
    /// Operation to post the content to the file
    /// @Auhtor: Push
    /// </summary>
    class postContent : DocOperation
    {
        /// <summary>
        /// The content of the MMT.
        /// </summary>
        String myContent;

        public postContent(String Id, String Content)
        {
            myBindFilePath = SMBL.Global.WebSite.AppPath + "\\Information\\" + Id + ".html";
            myContent = Content;
        }

        /// <summary>
        /// Write the content to the file and save.
        /// </summary>
        public override void processDelegate()
        {
            System.IO.FileInfo _html = new System.IO.FileInfo(myBindFilePath);
            if (!_html.Exists) 
                myProcessor.New();
            myProcessor.Write(myContent);
            myProcessor.Save();
        }
    }
}
