using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlAddEquipment:ISql
    {
        string m_id;
        string m_name;
        string m_model;
        string m_format;
        string m_accout;
        string m_price;
        string m_date;
        string m_factory;
        string m_status;
        string m_location;
        string m_location2;
        string m_user;
        string m_admin;
        string m_remark;
        public SqlAddEquipment(string id, string name,string model,string format,string accout,
            string  price,string date,string factory,string status,string location,string location2,
            string user,string admin,string remark)
        {
            m_id = id;
            m_name = name;
            m_model = model;
            m_format = format;
            m_accout = accout;
            m_price = price;
            m_date = date;
            m_factory = factory;
            m_status = status;
            m_location = location;
            m_location2 = location2;
            m_user = user;
            m_admin = admin;
            m_remark = remark;
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            string sql = "insert into DeviceInfo" + " values('"+m_id + "','" + m_name + "','" +  m_model + "','" +m_format + "'," + m_accout + "," + m_price + ",'"+ m_date + "','" + m_factory + "','" + m_status + "','" + m_location + "','" + m_location2 + "','" + m_user + "','" + m_admin + "','" + m_remark + "')";
            return sql;

        }

        #endregion
    }
}
