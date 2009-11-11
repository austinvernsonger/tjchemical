using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using System.IO;
using System.Web.UI;
using System.Data;

namespace Report.Serializer
{
    public class ResultSerializer
    {
        private string m_Path;
        private string m_PrimKey = String.Empty;
        private DataSet m_DataSet;
        private string m_ErrorMessage = "";

        public DataSet DataSet
        {
            get { return m_DataSet; }
            set { m_DataSet = value; }
        }



        public string PrimKey
        {
            get { return m_PrimKey; }
            set { m_PrimKey = value; }
        }
        public string Path
        {
            get;
            set;
        }

        /// <summary>
        /// return the last error.if no error, return ""
        /// </summary>
        /// <returns>error message</returns>
        public string GetLastError()
        {
            return m_ErrorMessage;
        }

        public ResultSerializer(string path, string primKey)
        {
            this.PrimKey = primKey;
            this.Path = path;
            m_DataSet = new DataSet("test");

        }

        public bool Serialize(List<KeyValuePair<string, string>> resultArray)
        {
            if (resultArray.Count == 0)
            {
                m_ErrorMessage = "No records to be saved";
                return false;
            }
            m_DataSet = new DataSet("test");


            //the first time to save a record
            if (!DeserializeDataSet())
            {
                //save a new record to file
                DataTable dt = new DataTable("new");
                foreach (KeyValuePair<string, string> pr in resultArray)
                {
                    dt.Columns.Add(pr.Key);
                }
                //the data row schema is from the array list
                DataRow dr = PrepareDataRow(resultArray, dt.NewRow());
                dt.Rows.Add(dr);
                m_DataSet.Clear();
                m_DataSet.Tables.Add(dt);
                return SaveAll();
            }
 
            //if there are already some records,then check whether
            //their columns is same to the new record's column
            if (!CheckColumn(resultArray))
            {
                m_ErrorMessage = "Unfit record structure";
                return false;
            }            
            //this is not the first time to insert a record
            //check if one column is primary key
            bool isPrim = false;
            string primValue = "";
            if (!m_PrimKey.Equals(""))
            {
                foreach (KeyValuePair<string, string> item in resultArray)
                {
                    if (item.Key.Equals(PrimKey))
                    {
                        isPrim = true;
                        primValue = item.Value;
                        break;
                    }
                }
            }
            if (isPrim == true)
            {
                //if there is a primary key
                //try to find the related row
                DataRow dr=FindRecord(primValue);
                if(dr!=null)
                {
                    //the related row is found ,update it
                    foreach (KeyValuePair<string, string> item in resultArray)
                    {
                        dr[item.Key] = item.Value;
                    }
                    return SaveAll();
                }

                //there is no related row,just add it
            }
            //there is no primary key,just add the record,too

            DataRow drow = PrepareDataRow(resultArray, m_DataSet.Tables[0].NewRow());
            m_DataSet.Tables[0].Rows.Add(drow);
            //save the entire dataset
            return SaveAll();
        }

        private DataRow FindRecord(string primValue)
        {
            if (m_DataSet==null||m_DataSet.Tables.Count==0)
            {
                m_ErrorMessage = "No records";
                return null;
            }
            DataRowCollection drc = m_DataSet.Tables[0].Rows;
            DataRow dr;
            for (int i = 0; i < drc.Count; i++)
            {
                dr = drc[i];
                if (dr[m_PrimKey].ToString().Equals(primValue))
                {
                    return dr;
                }
            }
            return null;
        }

        private bool SaveAll()
        {
            try
            {
                using (FileStream fs = new FileStream(Path, FileMode.Create, FileAccess.ReadWrite))
                {
                    m_DataSet.WriteXml(fs, XmlWriteMode.WriteSchema);
                }
            }
            catch (System.Exception e)
            {
                e.ToString();
                m_ErrorMessage = "Unable to write result to file";
                return false;
            }
            return true;
        }

        private bool CheckColumn(List<KeyValuePair<string, string>> resultArray)
        {
            foreach (KeyValuePair<string, string> pair in resultArray)
            {
                if (!m_DataSet.Tables[0].Columns.Contains(pair.Key))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// return deserialized record
        /// before use this function ,the Primkey should be set first
        /// if no such record, return null array list
        /// </summary>
        /// <returns></returns>
        public List<KeyValuePair<string, string>> DeserializeRecord(string PrimaryKeyValue)
        {
            if (m_PrimKey.Equals("") || m_PrimKey == null || PrimaryKeyValue.Equals("") || PrimaryKeyValue == null)
            {
                m_ErrorMessage = "Primary key and value are needed to find a record";
                return null;
            }
            if (!DeserializeDataSet())
            {
                return null;
            }
            else
            {
                DataRow dr = FindRecord(PrimaryKeyValue);
                if (dr==null)
                {
                    m_ErrorMessage = "No such record";
                    return null;
                }
                List<KeyValuePair<string, string>> resultlist = new List<KeyValuePair<string, string>>();
                DataColumnCollection dcc = dr.Table.Columns;

                for (int i = 0; i < dcc.Count; i++)
                {
                    resultlist.Add(new KeyValuePair<string, string>(dcc[i].ToString(), dr[dcc[i]].ToString()));
                }
                return resultlist;
            }
        }

        public bool Deserialize()
        {
            if (!DeserializeDataSet())
            {
                return false;
            }
            return true;
        }

        public bool clear()
        {
            try
            {
                FileStream fs = new FileStream(Path, FileMode.Truncate, FileAccess.ReadWrite);
                fs.Close();
            }
            catch (System.Exception e)
            {
                e.ToString();
            	m_ErrorMessage="Failed to clear Results";
                return false;
            }
            return true;
        }

        private bool DeserializeDataSet()
        {
            m_DataSet.Clear();
            try
            {
                using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    m_DataSet.ReadXml(fs, XmlReadMode.Auto);
                }
            }
            catch (System.Exception e)
            {
                e.ToString();
                m_ErrorMessage = "No records read from file";
                return false;
            }
            if (m_DataSet.Tables.Count == 0)
            {
                m_ErrorMessage = "No records read from file";
                return false;
            }
            if (m_DataSet.Tables[0].Rows.Count == 0)
            {
                m_ErrorMessage = "No records read from file";
                return false;
            }

            return true;
        }
        /// <summary>
        /// prepare a row to be saved to file
        /// </summary>
        /// <param name="resultList">record content</param>
        /// <param name="drIn">a row with schema</param>
        /// <returns></returns>
        private DataRow PrepareDataRow(List<KeyValuePair<string, string>> resultList, DataRow drIn)
        {
            DataRow dr = drIn;
            foreach (KeyValuePair<string, string> pair in resultList)
            {
                dr[pair.Key] = pair.Value;
            }

            return dr;
        }
    }
}
