using System;
using System.Collections.Generic;
using System.Text;
using NExcel;
using System.Data;

namespace Department.Engineering
{
    public class ExcelEngine
    {
        // stuInfo当前上传的是学生信息
        // courseInfo当前上传的是课程信息
        public enum Mode { stuInfo, courseInfo }  
                                                
        private Mode _infoMode;
        public Mode InfoMode
        {
            get { return _infoMode; }
            set { _infoMode = value; }
        }

        //将学生信息写入Dataset
        public DataSet WriteToDataset(string fileName)
        {
            if (fileName == null) return null;
            Workbook workbook = null;
            try
            {
                workbook = Workbook.getWorkbook(fileName);
                Sheet sheet = workbook.Sheets[0];
                string[] col = { "num","sStuid", "sName", "sGender", "sSchooling", "sDegree", "sPassword" };
                DataSet ds = new DataSet();
                System.Data.DataTable dt = new DataTable();
                ds.Tables.Add(dt);
                for (int k = 0; k < col.Length; k++)
                {
                    dt.Columns.Add(col[k],typeof(string));
                }
                for (int irow = 2; irow < sheet.Rows; irow++)
                {
                    DataRow dr = dt.NewRow();
                    for (int icol = 0; icol < col.Length; icol++)
                    {
                        if (icol == 0)
                        {
                            dr[icol] = (irow - 1).ToString();
                        }
                        else
                        {
                            Cell cell = sheet.getCell(icol-1, irow);
                            object val = cell.Value;
                            string strVal = (val != null) ? val.ToString() : "";
                            dr[icol] = strVal;
                        }
                    }
                 
                    dt.Rows.Add(dr);
                   
                }
                if (workbook != null)
                {
                    workbook.close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //将课程信息写入Dataset
        public DataSet WriteCourseInfoToDataset(string fileName)
        {
            if (fileName == null) return null;
            Workbook workbook = null;
            try
            {
                workbook = Workbook.getWorkbook(fileName);
                Sheet sheet = workbook.Sheets[0];
                string[] col = { "num","courseName", "credit", "creditHour", "property", "category", "examMode", "instruMode", "classPeriod","place" };
                DataSet ds = new DataSet();
                System.Data.DataTable dt = new DataTable();
                ds.Tables.Add(dt);
                for (int k = 0; k < col.Length; k++)
                {
                    dt.Columns.Add(col[k], typeof(string));
                }
                for (int irow = 6; irow < sheet.Rows; irow++)
                {
                    DataRow dr = dt.NewRow();
                    for (int icol = 0; icol < col.Length; icol++)
                    {
                        if (icol == 0)
                        {
                            dr[icol] = (irow - 5).ToString();
                        }
                        else
                        {
                            Cell cell = sheet.getCell(icol-1, irow);
                            object val = cell.Value;
                            string strVal = (val != null) ? val.ToString() : "";
                            dr[icol] = strVal;
                        }
                    }

                    dt.Rows.Add(dr);

                }
                if (workbook != null)
                {
                    workbook.close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //将学生成绩写入Dataset
        public DataSet WriteScoreToDataset(string fileName)
        {
            if (fileName == null) return null;
            Workbook workbook = null;
            try
            {
                workbook = Workbook.getWorkbook(fileName);
                Sheet sheet = workbook.Sheets[0];
                string[] col = { "id", "score" };
                DataSet ds = new DataSet();
                System.Data.DataTable dt = new DataTable();
                ds.Tables.Add(dt);
                for (int k = 0; k < col.Length; k++)
                {
                    dt.Columns.Add(col[k], typeof(string));
                }
                for (int irow = 2; irow < sheet.Rows; irow++)
                {
                    DataRow dr = dt.NewRow();
                    for (int icol = 0; icol < col.Length; icol++)
                    {
                        Cell cell = sheet.getCell(icol, irow);
                        object val = cell.Value;
                        string strVal = (val != null) ? val.ToString().Trim() : "";
                        dr[icol] = strVal;
                    }

                    dt.Rows.Add(dr);

                }
                if (workbook != null)
                {
                    workbook.close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //将学费信息写入Dataset
        public DataSet WriteTutionToDataset(string fileName)
        {
            if (fileName == null) return null;
            Workbook workbook = null;
            try
            {
                workbook = Workbook.getWorkbook(fileName);
                Sheet sheet = workbook.Sheets[0];
                string[] col = { "num","stuid", "actualMoney","mustMoney","remark" };// num 为学费信息的编号
                DataSet ds = new DataSet();
                System.Data.DataTable dt = new DataTable();
                ds.Tables.Add(dt);
                for (int k = 0; k < col.Length; k++)
                {
                    dt.Columns.Add(col[k], typeof(string));
                }
                for (int irow = 2; irow < sheet.Rows; irow++)
                {
                    DataRow dr = dt.NewRow();
                    for(int icol = 0; icol < col.Length; icol++)
                    {
                        if (icol == 0)
                        {
                            dr[icol] = (irow - 1).ToString();
                        }
                        else
                        {
                            Cell cell = sheet.getCell(icol-1, irow);
                            object val = cell.Value;
                            string strVal = (val != null) ? val.ToString() : "";
                            dr[icol] = strVal;
                        }
                    }
                    dt.Rows.Add(dr);
                }
                if (workbook != null)
                {
                    workbook.close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                if (workbook != null)
                {
                    workbook.close();
                }
                throw ex;
            }
        }
    }
}
