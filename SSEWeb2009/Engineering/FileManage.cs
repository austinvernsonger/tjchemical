using System;
using System.Collections.Generic;
using System.Text;
//using Interop.Excel;
using System.Reflection;
using System.Data;
using System.IO;
using System.Web;
using System.Data.OleDb;

namespace Department.Engineering
{
    public class FileManage
    {
        /// <summary>
        /// 从服务器下载文件
        /// </summary>
        /// <param name="file"></param>
        public static void DownLoadFile(FileInfo file)
        {
            if (file.Exists == true)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(file.Name, System.Text.Encoding.UTF8));
                HttpContext.Current.Response.AppendHeader("Content-Length", file.Length.ToString());
                HttpContext.Current.Response.WriteFile(file.FullName);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('文件不存在')</script>");
            }
        } 
    }
}
