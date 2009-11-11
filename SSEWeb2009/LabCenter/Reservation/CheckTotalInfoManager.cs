using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LabCenter.Reservation.Ops;
using LabCenter.Reservation.Sql;

namespace LabCenter.Reservation
{
    public class CheckTotalInfoManager
    {
        private static string m_DbName = "LabCenter";
        public String ErrorMsg = "";
        
        public DataSet GetTotalInfo(string termnumber,List<int> expIDlist)
        {
            OpReservationQuery q = new OpReservationQuery(m_DbName,
                new SqlgetTotalInfo(termnumber, expIDlist));
            q.Do();

            expIDlist.Sort();

            List<KeyValuePair<int, string>> kvp = GetExpListAsc(expIDlist);
            
            DataColumnCollection dcc = q.Ds.Tables[0].Columns;
            dcc[0].ColumnName = "Ñ§ºÅ";
            int expColumnIndex=1;
            int expcount=0;
            foreach(int i in expIDlist)
            {
                dcc[expColumnIndex + expcount].ColumnName = kvp[expcount].Value;
                ++expcount;
            }
            return q.Ds;
        }
        public DataSet GetTotalInfo(String termnumber)
        {
            int term;
            if (!int.TryParse(termnumber,out term))
            {
                return null;
            }
            else
            {
                return GetTotalInfo(termnumber, GetExperiment(term));
            }
        }
        public List<int> GetExperiment(int Term)
        {
            OpReservationQuery i = new OpReservationQuery(m_DbName, new SqlgetTermExperiments(Term));
            i.Do();
            List<int> ret=new List<int>(20);
            foreach (DataRow dr in i.Ds.Tables[0].Rows)
            {
                ret.Add((int)dr.ItemArray[0]);
            }
            return ret;
        }
        public List<KeyValuePair<int,string>> GetAllExpListAsc()
        {
            DataSet expds = BackManager.GetExperiment();
            
            List<KeyValuePair<int, string>> pairlist = new List<KeyValuePair<int, string>>(20);

            foreach (DataRow drc in expds.Tables[0].Rows)
            {
                Object[] ia = drc.ItemArray;
                KeyValuePair<int, string> kvp = new KeyValuePair<int, string>((int)ia[0], (string)ia[1]);
                pairlist.Add(kvp);
            }
            return pairlist;
            
        }
        List<KeyValuePair<int,string>> GetExpListAsc(List<int> expIDlist)
        {
            DataSet expds = BackManager.GetExperiment();
            List<KeyValuePair<int, string>> pairlist = new List<KeyValuePair<int, string>>(20);
            int curExpinAll=0;
            foreach(int curExpinList in expIDlist)
            {
                while(curExpinAll<expds.Tables[0].Rows.Count)
                {
                    if(curExpinList==(int)expds.Tables[0].Rows[curExpinAll].ItemArray[0])
                    {
                        break;
                    }
                    ++curExpinAll;
                }
                if (curExpinAll >= expds.Tables[0].Rows.Count)
                    break;
                Object[] ia = expds.Tables[0].Rows[curExpinAll].ItemArray;
                KeyValuePair<int,string> kvp = new KeyValuePair<int, string>((int)ia[0], (string)ia[1]);
                pairlist.Add(kvp);
                ++curExpinAll;
            }
            return pairlist;
        }
    }
}
