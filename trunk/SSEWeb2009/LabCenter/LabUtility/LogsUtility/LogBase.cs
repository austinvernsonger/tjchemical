using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.LogUtility
{
    /// <summary>
    /// 日志基类
    /// 提供功能
    /// 1.开关日志记录
    /// 2.写日志
    /// </summary>
    public abstract class LogBase:ILog
    {
        public LogBase()
        {
            _enableLog = true;
        }

        /// <summary>
        /// 日志开关
        /// </summary>
        bool _enableLog;

        /// <summary>
        /// 日志开关de访问器
        /// </summary>
        public bool EnableLog
        {
            get
            {
                return _enableLog;
            }
            set
            {
                _enableLog = value;
            }
        }

        /// <summary>
        /// 在子类中重写将日志信息按特定方式存储
        /// </summary>
        /// <param name="msg"></param>
        public abstract void _Write(string message);

        /// <summary>
        /// 处理后的日志信息
        /// 加上日期时间等操作
        /// </summary>
        /// <param name="rawMessage">原始日志信息</param>
        /// <returns>处理后的信息</returns>
        public virtual string GetProcessedData(string rawMessage)
        {
            string processedData;
            processedData = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + rawMessage;
            return processedData;
        }

        /// <summary>
        /// 在按特定方式写入之前处理
        /// 1.考虑到txt日志功能一直开着，文件会太大，可以在这里新建日志文件
        /// </summary>
        /// <param name="message"></param>
        public virtual void Pre_Write(ref string message) { }

        /// <summary>
        /// 模版方法
        /// 1.判断是否允许日志
        /// 2.处理日志信息
        /// 3.通过特定方式存储
        /// </summary>
        /// <param name="rawMessage"></param>
        public void Write(string rawMessage)
        {
            if (!_enableLog)
                return;
            string processedData = GetProcessedData(rawMessage);
            Pre_Write(ref processedData);
            _Write(processedData);
        }

    }
}
