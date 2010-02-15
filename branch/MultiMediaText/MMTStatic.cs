using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SysCom
{
    public static class MMTStatic
    {
        public static DataSet GetList(Int32 DepartmentId, String Mode, String KeyWord, Boolean MgrUse, Boolean Report)
        {
            if (Mode.ToLower().Equals("notice"))
                GetNotice(DepartmentId, KeyWord, null, false, MgrUse, Report);
            Ops.GetMMTList getList = new SysCom.Ops.GetMMTList(new SysCom.Sql.sqlMMTGetList(DepartmentId, Mode, KeyWord, MgrUse, Report));
            getList.Do();
            return getList.Result;
        }

        public static DataSet GetNotice(Int32 DepartmentId, String Keyword, String Label, Boolean Internal, Boolean MgrUse, Boolean Report)
        {
            Ops.GetMMTList getList = new SysCom.Ops.GetMMTList(new SysCom.Sql.sqlMMTGetList(
                DepartmentId, Keyword, Label, Internal, MgrUse, Report));
            getList.Do();
            //String tmp = getList.GetLastError();
            return getList.Result;
        }

        public static DataSet GetNotice(Int32 DepartmentId, String Keyword, String Label, Boolean Internal, DateTime Date, Boolean MgrUse, Boolean Report)
        {
            Ops.GetMMTList getList = new SysCom.Ops.GetMMTList(new SysCom.Sql.sqlMMTGetList(
                DepartmentId, Keyword, Label, Internal, Date, MgrUse, Report));
            getList.Do();
            return getList.Result;
        }

        public static Boolean Delete(String MMTID)
        {
            MMTContent myContent = new MMTContent();
            myContent.myId = MMTID;
            Ops.Delete delMMT = new SysCom.Ops.Delete();
            delMMT.Content = myContent;
            return delMMT.Do();
        }

        public static Boolean MarkDelete(String MMTID)
        {
            MMTContent myContent = new MMTContent();
            myContent.myId = MMTID;
            Ops.MarkDel markDeleted = new SysCom.Ops.MarkDel();
            markDeleted.Content = myContent;
            return markDeleted.Do();
        }

        public static Boolean Recover(String MMTID)
        {
            MMTContent myContent = new MMTContent();
            myContent.myId = MMTID;
            Ops.Recover recoverMMT = new SysCom.Ops.Recover();
            recoverMMT.Content = myContent;
            return recoverMMT.Do();
        }

        public static bool Download( string MMTID, string FileName )
        {
            return Ops.doProducer.DoProc( "P_DOWNLOAD_MMT", MMTID, FileName );
        }
    }
}
