using System;
using System.Collections.Generic;
using System.Text;

namespace SysCom
{
    /// <summary>
    /// Attachment of an MMT.
    /// Provide the operation of equal.
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Construction, Get the File Name and the File Extension
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="FileExtension"></param>
        public Attachment(String FileName, String FileExtension)
        {
            myFileName = FileName;
            myFileExtension = FileExtension;
        }

        /// <summary>
        /// Default Construction
        /// </summary>
        public Attachment(){}

        /// <summary>
        /// Operation ==.
        /// Two attachment are equaled only when they have the same
        /// File name and File Extension.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Boolean operator ==(Attachment lhs, Attachment rhs)
        {
            if (!lhs.FileName.Equals(rhs.FileName)) return false;
            return lhs.FileExtension.Equals(rhs.FileExtension);
        }

        /// <summary>
        /// Operation !=.
        /// return ! Operation ==
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Boolean operator !=(Attachment lhs, Attachment rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// System Requirement
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Boolean Equals(object obj)
        {
 	         return this == (Attachment)obj;
        }

        /// <summary>
        /// System Requirement
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private String myFileName = null;
        /// <summary>
        /// Gets or sets the filename of the Attachment.
        /// </summary>
        public String FileName
        {
            get { return myFileName; }
            set { myFileName = value; }
        }

        /// <summary>
        /// Gets or sets the file extension of the Attachment.
        /// </summary>
        private String myFileExtension = null;
        public String FileExtension
        {
            get { return myFileExtension; }
            set { myFileExtension = value; }
        }

        /// <summary>
        /// Gets or sets the download times of the Attachment.
        /// </summary>
        private Int32 myDownLoadTimes = 0;
        public Int32 DownLoadTimes
        {
            get { return myDownLoadTimes; }
            set { myDownLoadTimes = value; }
        }
    }
}
