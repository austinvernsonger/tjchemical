using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Repair.Sql
{
    class SqlAddOtherOrder:ISql
    {
        string m_reporterid;
        string m_devname;
        string m_location;
        string m_discription;
        public SqlAddOtherOrder(string reporter_id, string devname, string location, string discription)
        {
            m_reporterid = reporter_id.Trim();
            m_devname = devname.Trim();
            m_location = location.Trim();
            m_discription = discription.Trim();
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "insert into OtherRepair(FacilityName,FacilityLocation," +
                            "Description,Reporter,State,UpdateTime) " +
                            "values('" + m_devname + "','" +
                            m_location + "','" +
                            m_discription + "','" +
                            m_reporterid + "',0,getdate())";
        }

        #endregion
    }
}
