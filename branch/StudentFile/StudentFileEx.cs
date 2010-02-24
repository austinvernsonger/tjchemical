using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
using SMBL.Operation;
using System.Data;

namespace StudentFile
{
    public class StudentFileEx
    {
        public static DataSet SelectAllStudentFile()
        {
            Sql.SqlSelectAllStudentFile qs = new StudentFile.Sql.SqlSelectAllStudentFile();
            Ops.OpStudentFileQuery op = new StudentFile.Ops.OpStudentFileQuery(qs);
            op.Do();
            return op.Ds;
        }
        public static bool DeleteStudentFile(String ID)
        {
            Sql.SqlDeleteStudentFile qs = new StudentFile.Sql.SqlDeleteStudentFile();
            qs.GetID(ID);
            Ops.OpStudentFileExec op = new StudentFile.Ops.OpStudentFileExec(qs);
            return op.Do();
        }
        public static DataSet SelectStudentFileQuery(String ID,String strName,Int16 iClass)
        {
            Sql.SqlSelectStudentFileQuery qs = new StudentFile.Sql.SqlSelectStudentFileQuery();
            qs.GetConditon(ID, strName,iClass);
            Ops.OpStudentFileQuery op = new StudentFile.Ops.OpStudentFileQuery(qs);
            op.Do();
            return op.Ds;
        }
        public static bool CheckStudent(String ID)
        {
            Sql.SqlSelectSingleStudent qs = new StudentFile.Sql.SqlSelectSingleStudent();
            qs.GetID(ID);
            Ops.OpStudentFileQuery op = new StudentFile.Ops.OpStudentFileQuery(qs);
            op.Do();
            if (op.Ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static bool CheckStudentTable(String ID)
        {
            Sql.SqlSelectStudentSingleInStudent qs = new StudentFile.Sql.SqlSelectStudentSingleInStudent();
            qs.GetID(ID);
            Ops.OpStudentFileQuery op = new StudentFile.Ops.OpStudentFileQuery(qs);
            op.Do();
            if (op.Ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static bool InsertStudentFile(String ID)
        {
            Sql.SqlInsertStudentFile qs = new StudentFile.Sql.SqlInsertStudentFile();
            qs.GetID(ID);
            Ops.OpStudentFileExec op = new StudentFile.Ops.OpStudentFileExec(qs);
            return op.Do();
        }
        public static DataSet SelectSingleStudentFileInfo(String ID)
        {
            Sql.SqlSelectSingleStudentFileInfo qs = new StudentFile.Sql.SqlSelectSingleStudentFileInfo();
            qs.GetID(ID);
            Ops.OpStudentFileQuery op = new StudentFile.Ops.OpStudentFileQuery(qs);
            op.Do();
            return op.Ds;
        }
        public static DataSet SelectStudentArchivesContent(String ID)
        {
            Sql.SqlSelectStudentArchivesContent qs = new StudentFile.Sql.SqlSelectStudentArchivesContent();
            qs.GetID(ID);
            Ops.OpStudentFileQuery op = new StudentFile.Ops.OpStudentFileQuery(qs);
            op.Do();
            return op.Ds;
        }
        public static bool InsertStudentArchivesContent(String strTitle,String strContent,String strRemark,String StudentID)
        {
            Sql.SqlInsertStudentArchivesContent qs = new StudentFile.Sql.SqlInsertStudentArchivesContent();
            qs.GetInsertContent(strTitle, strContent, strRemark, StudentID);
            Ops.OpStudentFileExec op = new StudentFile.Ops.OpStudentFileExec(qs);
            return op.Do();
        }
        public static bool DeleteStudentArchivesContent(String strTitle,String StudentID)
        {
            Sql.SqlDeleteStudentArchivesContent qs = new StudentFile.Sql.SqlDeleteStudentArchivesContent();
            qs.GetID(strTitle, StudentID);
            Ops.OpStudentFileExec op = new StudentFile.Ops.OpStudentFileExec(qs);
            return op.Do();
        }
        public static bool UpdateStudentArchives(Int16 iMemberInfo,Int16 iPartyMemberInfo,String strFileCreateTime,String strFileSource,
            String strFileSourceType, String strGraduationTime, String strFileSendTime,String strFileSendCompany, String strFileSendCompanyAddress,
            String strFileSendCompanyCode, String strFileSendCompanyContact, String strFileSendCompanyPhone,String strFileSendCompanyType,Int16 iStoreFile,
            String strStoreFileStartTime, String StudentID)
        {
            Ops.OpStudentFileProducer op = new StudentFile.Ops.OpStudentFileProducer("P_UPDATE_ARCHIVES",iMemberInfo,iPartyMemberInfo, strFileCreateTime, strFileSource,
             strFileSourceType,  strGraduationTime, strFileSendTime, strFileSendCompany,  strFileSendCompanyAddress,
             strFileSendCompanyCode,  strFileSendCompanyContact,  strFileSendCompanyPhone, strFileSendCompanyType,iStoreFile,
             strStoreFileStartTime,  StudentID);
            op.Do();
            return Convert.ToBoolean(op.ExecuteResult);
        }
        public static DataSet SelectStudentArchivesNew(String ID)
        {
            Sql.SqlSelectStudentArchivesNew qs = new StudentFile.Sql.SqlSelectStudentArchivesNew();
            qs.GetID(ID);
            Ops.OpStudentFileQuery op = new StudentFile.Ops.OpStudentFileQuery(qs);
            op.Do();
            return op.Ds;
        }
        public static bool DeleteArchivesNew(Int64 ID, String StudentID)
        {
            Sql.SqlDeleteArchivesNew qs = new StudentFile.Sql.SqlDeleteArchivesNew();
            qs.GetID(ID, StudentID);
            Ops.OpStudentFileExec op = new StudentFile.Ops.OpStudentFileExec(qs);
            return op.Do();
        }
        public static bool InsertArchivesNew(String strAddTime,String strContent,String strAddPeople,String strRemark,String strStudentID)
        {
            Sql.SqlInsertStudentArchivesNew qs = new StudentFile.Sql.SqlInsertStudentArchivesNew();
            qs.GetContent(strAddTime, strContent, strAddPeople, strRemark, strStudentID);
            Ops.OpStudentFileExec op = new StudentFile.Ops.OpStudentFileExec(qs);
            return op.Do();
        }
    }
}
