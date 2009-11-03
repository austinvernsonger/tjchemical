
using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    class sqlMMTGetList : ISql
    {
        private String myMode;
        private String myDepartment;
        private String myKeyWord = null;
        private String mylastModifyTime = null;
        private String mylastModifyTimeI = null;
        private String myLabel = null;
        private String myInternal = null;
        private String myMgrUse = null;

        public sqlMMTGetList(Int32 Department, String Mode, String KeyWord, Boolean MgrUse)
        {
            myDepartment = (Department == 0) ? null : "DepartmentId=" + Department.ToString();
            myMode = "Mode='" + Mode + "'";
            myKeyWord = (KeyWord == null) ? null : "Title LIKE '%" + KeyWord + "%'";
            myMgrUse = MgrUse ? null : "State=0";
        }

        public sqlMMTGetList(Int32 Department, String Keyword, String Label, Boolean Internal, Boolean MgrUse)
        {
            myDepartment = (Department == 0) ? null : "DepartmentId=" + Department.ToString();
            myMode = "Mode='notice'";
            myKeyWord = (Keyword == null) ? null : "Title LIKE '%" + Keyword + "%'";
            myLabel = (Label == null || Label == "") ? null : "Label='" + Label + "'";
            myInternal = (Internal) ? "IsInternal=1" : "IsInternal=0";
            myMgrUse = MgrUse ? null : "State=0";
        }

        public sqlMMTGetList(Int32 Department, String Keyword, String Label, Boolean Internal, DateTime Date, Boolean MgrUse)
        {
            myDepartment = (Department == 0) ? null : "DepartmentId=" + Department.ToString();
            myMode = "Mode='notice'";
            myKeyWord = (Keyword == null) ? null : "Title LIKE '%" + Keyword + "%'";
            myLabel = (Label == null || Label == "") ? null : "Label='" + Label + "'";
            myInternal = (Internal) ? "IsInternal=1" : "IsInternal=0";
            //mylastModifyTime = "DATEDIFF(day,LastModifyTime,'" + Date.ToShortDateString() + "')=0";
            String year = Date.Year.ToString();
            String month = Date.Month.ToString();
            if (month.Length == 1) month = "0" + month;
            String day = Date.Day.ToString();
            if (day.Length == 1) day = "0" + day;

            String str_date = year + month + day;

            mylastModifyTime = "CONVERT(varchar(8), LastModifyTime, 112)='" + str_date +"'";
            mylastModifyTimeI = "CONVERT(varchar(8), I.LastModifyTime, 112)='" + str_date + "'";
            myMgrUse = MgrUse ? null : "State=0";
        }

        #region ISql Members

        /*
         * SELECT ID, Title, ClickCount FROM Information WHERE Department=XX AND Mode=XX AND Title LIKE %XX% ORDER BY LastModifyTime DESC
         * SELECT Info.ID, Info.Title, Info.ClickCount FROM Information AS Info, Information_Label AS LB
         *  WHERE Info.Department=XX AND Info.Mode=notice AND LB.Label=XX AND Info.Internal=XX AND Info.LastModifyTime=XX
         *  ORDER BY Info.LastModifyTime DESC
         *  select * from table where convert(varchar(8),lastmodifiedtime,112)='20041020'
         */
        /// <summary>
        /// Sql
        /// </summary>
        /// <returns></returns>
        public string GetSql()
        {
            if (myLabel == null)
            {
                return "SELECT ID, Title, ClickCount, CONVERT(varchar(30), LastModifyTime, 23) as LastModifyTime, State FROM Information" +
                    " WHERE " + myMode +
                    ((myDepartment == null) ? null : " AND " + myDepartment) +
                    ((myKeyWord == null) ? null : " AND " + myKeyWord) +
                    ((mylastModifyTime == null) ? null : " AND " + mylastModifyTime) +
                    ((myInternal == null) ? null : " AND " + myInternal) +
                    ((myMgrUse == null) ? null : " AND " + myMgrUse) +
                    " ORDER BY LastModifyTime DESC";
            }
            else
            {
                return "SELECT I.ID, I.Title, I.ClickCount, CONVERT(varchar(30), I.LastModifyTime, 23) as LastModifyTime, I.State FROM Information as I, Information_Label as L" + 
                    " WHERE I." + myMode + " AND L." + myLabel + " AND L.InformationID=I.ID" + 
                    ((myDepartment == null) ? null : " AND I." + myDepartment) +
                    ((myKeyWord == null) ? null : " AND I." + myKeyWord) +
                    ((mylastModifyTime == null) ? null : " AND " + mylastModifyTimeI) +
                    ((myInternal == null) ? null : " AND I." + myInternal) +
                    ((myMgrUse == null) ? null : " AND I." + myMgrUse) +
                    " ORDER BY I.LastModifyTime DESC";
            }
        }

        #endregion
    }
}
