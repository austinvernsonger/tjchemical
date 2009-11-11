using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LabCenter.Authority.Ops;
using LabCenter.Authority.Sql;
using LabCenter.LabUtility.PerInfoUtility;
using System.Xml;

namespace LabCenter.Authority
{
    public class AuthorityManage
    {
        private string m_DbName = "LabCenter";
        public String ErrorMsg = "";
        public bool AddManager(string memberid,string name)
        {
            OpAuthorityQuery i1=new OpAuthorityQuery(m_DbName,new SqlGetManager(memberid));
            i1.Do();
            if (i1.Ds.Tables[0].Rows.Count>0)
            {
                ErrorMsg="´ËÕÊºÅÒÑ´æÔÚÓÚ¹ÜÀíÔ±ÁĞ±íÖĞ";
                return false;
            }
            OpAuthorityExecute i2 = new OpAuthorityExecute(m_DbName, new SqlAddManager(memberid,
                name));
            if (!i2.Do())
            {
                ErrorMsg = "Ìí¼ÓÊ§°Ü";
                return false;
            }
            return true;
        }
        public bool DeleteManager(string memberid)
        {
            OpAuthorityExecute i = new OpAuthorityExecute(m_DbName, new SqlDelManager(memberid));
            if (!i.Do())
            {
                ErrorMsg = "É¾³ıÊ§°Ü";
                return false;
            }
            DeleteAuthority(memberid);
            return true;
        }
        public bool DeleteAuthority(string memberid)
        {
            OpAuthorityExecute i = new OpAuthorityExecute(m_DbName, new SqlDelAuthority(memberid));
            if (!i.Do())
            {
                ErrorMsg = "É¾³ıÊ§°Ü";
                return false;
            }
            return true;
        }
        public bool AddAuthority(string memberid,int index,int sonindex)
        {
            OpAuthorityExecute i = new OpAuthorityExecute(m_DbName, new SqlAddAuthority(memberid,index,sonindex));
            if (!i.Do())
            {
                ErrorMsg = "Ìí¼ÓÊ§°Ü";
                return false;
            }
            return true;
        }
        public bool TransferSuper(string superid,string objectid,String xmlfile)
        {
            OpAuthorityExecute i = new OpAuthorityExecute(m_DbName, new SqlSetManagerSuper(superid, false));
            if (!i.Do())
            {
                ErrorMsg = "ÒÆ½»Ê§°Ü";
                return false;
            }
            i = new OpAuthorityExecute(m_DbName, new SqlSetManagerSuper(objectid, true));
            if (!i.Do())
            {
                ErrorMsg = "ÒÆ½»Ê§°Ü";
                return false;
            }
            DeleteAuthority(objectid);
            ImportAuthorities(objectid, xmlfile);
            return true;
        }
        public DataSet GetAllManagers()
        {
            OpAuthorityQuery i = new OpAuthorityQuery(m_DbName, new SqlGetAllManagers());
            if (i.Do() && i.Ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtable = i.Ds.Tables[0];
                dtable.Columns[0].ColumnName = "ÕÊºÅ";
                dtable.Columns[1].ColumnName = "ĞÕÃû";
            }
            return i.Ds;
        }
        public DataSet GetManagersByID(string id)
        {
            OpAuthorityQuery i = new OpAuthorityQuery(m_DbName, new SqlGetManagersByID(id));
            if (i.Do() && i.Ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtable = i.Ds.Tables[0];
                dtable.Columns[0].ColumnName = "ÕÊºÅ";
                dtable.Columns[1].ColumnName = "ĞÕÃû";
            }
            return i.Ds;
        }
        public DataSet GetManagersByName(string name)
        {
            OpAuthorityQuery i = new OpAuthorityQuery(m_DbName, new SqlGetManagersByName(name));
            if (i.Do() && i.Ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtable = i.Ds.Tables[0];
                dtable.Columns[0].ColumnName = "ÕÊºÅ";
                dtable.Columns[1].ColumnName = "ĞÕÃû";
            }
            return i.Ds;
        }
        public bool HasFunction(String id,int index)
        {
            OpAuthorityQuery i = new OpAuthorityQuery(m_DbName, new SqlHasFunction(id,index));
            i.Do();
            if (i.Ds.Tables[0].Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasAuthority(String id,int index,int sonindex)
        {
            OpAuthorityQuery i = new OpAuthorityQuery(m_DbName, new SqlHasAuthority(id, index,sonindex));
            i.Do();
            if (i.Ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ImportAuthorities(String id,String filepath)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(filepath);
            XmlNode rootnode = xmldoc.SelectSingleNode("AllFunctions");
            XmlNodeList nodelist = rootnode.ChildNodes;
            if (nodelist != null)
            {
                foreach (XmlNode node in nodelist)
                {
                    int index = int.Parse(node.Attributes["index"].Value.ToString());
                    XmlNodeList nl = node.ChildNodes;                   
                    foreach (XmlNode nd in nl)
                    {
                        int sonindex = int.Parse(nd.Attributes["index"].Value.ToString());
                        AddAuthority(id, index, sonindex);
                    }                
                }
            }
        }
        public bool HasSuper()
        {
            OpAuthorityQuery i = new OpAuthorityQuery(m_DbName, new SqlGetSuper());
            i.Do();
            if (i.Ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsSuper(string id)
        {
            OpAuthorityQuery i = new OpAuthorityQuery(m_DbName, new SqlIsSuper(id));
            i.Do();
            if (i.Ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool AddSuper(string id)
        {
            string name = PersonInfoCtrl.GetNameByID(id);
            OpAuthorityExecute e = new OpAuthorityExecute(m_DbName, new SqlAddSuper(id, name));
            if (!e.Do())
            {
                return false;
            }
            else
            {
                return true;
            }          
        }
        public bool IsManager(string id)
        {
            OpAuthorityQuery i = new OpAuthorityQuery(m_DbName, new SqlGetByID(id));
            i.Do();
            if (i.Ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
