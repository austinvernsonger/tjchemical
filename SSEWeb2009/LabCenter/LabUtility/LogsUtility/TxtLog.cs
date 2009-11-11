using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LabCenter.LabUtility.LogUtility
{
    /// <summary>
    /// TXT日志记录器
    /// 提供功能
    /// 1.按日子分文件存储日志
    /// 2.可指定日志文件夹路径和日志名前缀（后缀用时间区别）
    /// </summary>
    public class TxtLog:LogBase
    {
        /// <summary>
        /// ShowUse
        /// </summary>
        public static void ShowUse()
        {
            ILog Log = new TxtLog("C:", "Web");
            Log.Write("first 记录");
            Log.Write("second second second second second second second second" +
                " second second second second second second second second second" +
                " second second second second second second second second second" +
                " second second second second second second second second second" +
                " second second second second second second second second second");
        }

        #region 构造

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="folder">存储日志文件夹路径</param>
        /// <param name="filePrefix">日志名前缀</param>
        public TxtLog(string folder,string filePrefix)
        {
            _folder = folder;
            _filePrefix = filePrefix;
            EnableLog = true;
        }

        #endregion


        #region 日志文件管理

        /// <summary>
        /// txt位于文件夹路径
        /// </summary>
        string _folder;

        /// <summary>
        /// 日志文件名前缀，后面要加日期的
        /// </summary>
        string _filePrefix;

        /// <summary>
        /// 当前记录日志
        /// </summary>
        DateTime _currentDt;

        /// <summary>
        /// 组合特定日期（只用年月日）生成的日志文件全路径
        /// </summary>
        /// <returns></returns>
        string _ComposeLogFileName(DateTime dt)
        {
            string ret;
            //文件夹最后的那个'\'
            if (_folder.Length != 0)
            {
                if (_folder[_folder.Length-1]!='\\')
                {
                    _folder+='\\';
                }
            }
            ret = _folder + _filePrefix + dt.ToString("_yyyy-MM-dd") + ".log";
            return ret;
        }

        #endregion


        #region 日志记录准备

        /// <summary>
        /// 日志记录出错的异常记录
        /// </summary>
        /// <param name="log"></param>
        void LogLog(string e)
        {
            TxtLog log = new TxtLog("C:", "LogLog");
            log.Write(e.ToString());
        }


        StreamWriter _StreamWriter=null;

        /// <summary>
        /// 关闭日志记录的Stream
        /// </summary>
        void _CloseWriter()
        {
            try
            {
                if (_StreamWriter != null)
                {
                    _StreamWriter.Close();
                    _StreamWriter = null;
                }
            }
            catch(Exception e)
            {
                LogLog(e.ToString());
            }
        }

        /// <summary>
        /// 在创建文件前检查所在文件夹是否存在，不存在的话创建
        /// </summary>
        /// <param name="filepath"></param>
        void CreateFolder(string filepath)
        {
            int folderlength = filepath.LastIndexOf('\\');
            DirectoryInfo di = new DirectoryInfo(filepath.Substring(0, folderlength));
            if (!di.Exists)
            {
                di.Create();
            }
        }

        /// <summary>
        /// 创建日志记录的Stream
        /// </summary>
        /// <param name="filepath"></param>
        StreamWriter _CreateWriter(string filepath)
        {
            try
            {
                //创建文件夹
                CreateFolder(filepath);

                //创建文件
                FileInfo fileinfo = new FileInfo(filepath);

                return new StreamWriter(fileinfo.Open(FileMode.Append, FileAccess.Write, FileShare.Read));
            }
            catch (Exception e)
            {
                LogLog(e.ToString());
                return null;
            }
        }

        #endregion


        #region 日志记录管理

        /// <summary>
        /// 判断是否要新建日志文件了~
        /// </summary>
        /// <param name="message"></param>
        public override void Pre_Write(ref string message)
        {
            if (DateTime.Now.DayOfYear != _currentDt.DayOfYear || null==_StreamWriter)
            {
                _currentDt = DateTime.Now;
                _CloseWriter();
                _StreamWriter = _CreateWriter(_ComposeLogFileName(_currentDt));
            }
        }

        public override void _Write(string message)
        {
            _StreamWriter.WriteLine(message);
            _StreamWriter.Flush();
        }

        #endregion
    }
}
