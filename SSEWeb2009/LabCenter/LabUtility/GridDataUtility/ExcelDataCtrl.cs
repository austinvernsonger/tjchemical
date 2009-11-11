using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace LabCenter.LabUtility.GridDataUtility
{
    public class ExcelDataCtrl<T>:GridDataCtrl<T>
        where T:IInputable,new()
    {
        public override bool SqlToFile(string sql,string datasource,string tofilepath)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override List<T> FileToClass(string filepath)
        {
            return FileToClass(filepath, "Sheet1");
        }
        public List<T> FileToClass(string filepath,string sheetname)
        {
            List<T> ret = null;
            try
            {
                if (!_Open(filepath))
                {
                    throw new Exception();
                }
                if (!_GetDataSet(sheetname))
                {
                    throw new Exception();
                }
                if (_dataset.Tables.Count == 0)
                {
                    LastError = "Sheet中不存在表";
                    throw new Exception();
                }
                ret = new List<T>();
                DataTable dt = _dataset.Tables[0];
                for (int i = DataRowIndex; i < dt.Rows.Count; ++i)
                {
                    object[] objarray = dt.Rows[i].ItemArray;
                    T temp = new T();
                    for (int j = 0; j != objarray.Length; ++j)
                    {
                        temp.ColumnBind(j, objarray[j].ToString());
                    }
                    ret.Add(temp);
                }
            }
            catch(Exception e)
            {
                e.ToString();
            }
            finally
            {
                _Close();
            }
            return ret;
        }
        private bool _Open(string filepath)
        {
            if(_conn!=null)
            {
                return true;
            }
            _conn = new OleDbConnection();
            _conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + filepath + ";"
                + "Extended Properties=\"Excel 8.0;HDR=No;\"";
            try
            {
                _conn.Open();
            }
            catch(Exception e)
            {
                e.ToString();
                LastError = "Excel文件\""+ filepath +"\"连接失败";
                return false;
            }
            return true;
            
        }
        /// <summary>
        /// 关闭与Excel文件的连接
        /// </summary>
        private void _Close()
        {
            if(_conn!=null)
            {
                _conn.Close();
                _conn = null;
            }
        }
        private bool _GetDataSet(string sheetname)
        {
            bool ret = true;
            try
            {
                string sql = "select * from [" + sheetname + "$]";
                OleDbCommand cmd = new OleDbCommand(sql, _conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                if (adapter.Fill(_dataset) == 0)
                {
                    LastError = "表单信息为空";
                    ret = false;
                }
            }
            catch (Exception e)
            {
                e.ToString();
                LastError = "不存在的sheet名称\"" + sheetname + "\"";
                ret = false;
            }
            finally
            {
                _conn.Close();
            }
            return ret;
        }
        OleDbConnection _conn = null;
        private DataSet _dataset = new DataSet();
        //public ExcelDataCtrl()
        //{
        //    app = new Excel.ApplicationClass();
        //    app.DisplayAlerts = false;
        //    app.AlertBeforeOverwriting = false;
        //}
        ////打开文件，检查文件类型
        //private bool Open(string filepath)
        //{
        //    try
        //    {
        //        wb = app.Workbooks.Add(filepath);
        //        openfilepath = filepath;
        //    }
        //    catch (System.Exception e)
        //    {
        //        e.ToString();
        //        LastError = "打开文件\""+ filepath +"\"失败";
        //        return false;
        //    }
        //    return true;
        //}
        ////设置当前sheet
        //private bool SetWorkSheet(string sheetName)
        //{
        //    ws = (Excel.Worksheet)wb.Worksheets[sheetName];
        //    return ws != null;
        //}
        //private Excel.ApplicationClass app;
        //private Excel.Workbook wb;
        //private Excel.Worksheet ws;
        //private string openfilepath;

        ////Configure 
        //protected int iInputStartIndex;
        //protected int iInputCount;
        //protected int iExpectOutputStartIndex;
        //protected int iOutputCount;
        //protected int iActualOutputIndex;

        private string _lasterror;
        private int errorcount = 0;
        public string LastError
        {
            get 
            {
                string ret = _lasterror;
                _lasterror = "";
                errorcount = 0;
                return ret; 
            }
            set 
            {
                ++errorcount;
                if(1!=errorcount)
                {
                    _lasterror += "\n";
                }
                _lasterror+=errorcount.ToString()+". " + value; 
            }
        }
    }
}
