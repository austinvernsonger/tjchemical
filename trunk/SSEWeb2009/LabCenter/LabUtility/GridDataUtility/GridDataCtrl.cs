using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.GridDataUtility
{
    public abstract class GridDataCtrl<T>
        where T:IInputable,new()
    {
        /// <summary>
        /// 将Sql执行结果导入文件
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>成功与否</returns>
        public abstract bool SqlToFile(string sql,string datasource,string tofilepath);
        /// <summary>
        /// 文件导入类
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns>类集合</returns>
        public abstract List<T> FileToClass(string filepath);

        int _datarowindex=1;
        /// <summary>
        /// 数据开始行的由0开始计的索引
        /// </summary>
        public int DataRowIndex
        {
            get { return _datarowindex; }
            set { _datarowindex = value; }
        }
    }
}
