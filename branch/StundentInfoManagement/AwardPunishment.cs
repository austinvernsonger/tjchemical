using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
using SMBL.Operation;
using StundentInfoManagement.Ops;
using System.Data;

namespace StundentInfoManagement
{
    public class AwardPunishment
    {
        public static DataSet SelectAllStudent()
        {
            Sql.SqlSelectAllAwardPunishmentStudent qs = new StundentInfoManagement.Sql.SqlSelectAllAwardPunishmentStudent();
            OpStudentMngQuery op = new OpStudentMngQuery(qs);
            op.Do();
            return op.Ds;
        }
        public static bool DeleteStudent(String ID)
        {
            Sql.SqlDeleteAwardPunishment qs = new StundentInfoManagement.Sql.SqlDeleteAwardPunishment();
            qs.GetID(ID);
            OpStudentMngExec op = new OpStudentMngExec(qs);
            return op.Do();
        }
        public static DataSet SelectByQuery(String ID,String strName,Int16 iClass)
        {
            Sql.SqlSelectAwardPunishmentByQuery qs = new StundentInfoManagement.Sql.SqlSelectAwardPunishmentByQuery();
            qs.GetCondition(ID, strName, iClass);
            OpStudentMngQuery op = new OpStudentMngQuery(qs);
            op.Do();
            return op.Ds;
        }
        public static DataSet SelectSingleContent(String ID)
        {
            Sql.SqlSelectSingleAwardPunishmentContent qs = new StundentInfoManagement.Sql.SqlSelectSingleAwardPunishmentContent();
            qs.GetID(ID);
            OpStudentMngQuery op = new OpStudentMngQuery(qs);
            op.Do();
            return op.Ds;
        }
        public static bool AddAwardPunishmentData(Int32 ID,String StudentID,String ApplyTime,Int16 iType,String strContext)
        {
            OpStudentMngProducer op = new OpStudentMngProducer("P_INSERT_REWARDSPENALTIES",ID, StudentID, ApplyTime, iType, strContext);
            op.Do();
            return Convert.ToBoolean(op.ExecuteResult);
        }
    }
}
