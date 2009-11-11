using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddStudentPicture:ISql
    {
        private string _studentID;
        private string _path;
        private string _imageName;

        public SqlAddStudentPicture(string studentID, string path, string imageName)
        {
            _studentID = studentID;
            _path = path;
            _imageName = imageName;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Insert into AttachmentInfo(AttachName,CreateTime,CreateByUser,LastModifyTime,AttachNameUrl,Category) " +
                    "values('" + _imageName + "','" + System.DateTime.Now + "','" + _studentID + "','" + System.DateTime.Now + "','" + _path + "',6) ";
        }

        #endregion
    }
}
