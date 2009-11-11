using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Reservation.Sql;
using LabCenter.Reservation.Ops;

namespace LabCenter.Reservation
{
    public class BadRecordMgr
    {
        static string m_DbName = "LabCenter";
        public static String ErrorMsg = "";

        public DataSet GetBadRecords()
        {
            OpReservationQuery op = new OpReservationQuery(m_DbName,new SqlgetBadRecords());
            op.Do();
            op.Ds.Tables[0].Columns[0].ColumnName = "账号";
            op.Ds.Tables[0].Columns[1].ColumnName = "不良记录时间";
            op.Ds.Tables[0].Columns[2].ColumnName = "详细信息";
            return op.Ds;
        }
    }
}
