using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.LogUtility
{
    public interface ILog
    {
        /// <summary>
        /// 开关日志功能
        /// </summary>
        bool EnableLog
        {
            get;
            set;
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="rawMessage">写入的信息</param>
        void Write(string rawMessage);
    }
}
