using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.GridDataUtility
{
    /// <summary>
    /// 下面以Person为例介绍网格结构文件导入类的方法
    /// Person 一个简单的记录人的信息的实体
    /// 如果要使用Excel文件导入类的功能，对你的实体有以下要求
    /// 1.实现IInputable接口（如何实现请继续看）
    /// 2.有默认的无参构造函数
    /// </summary>
    public class Person : IInputable
    {
        public Person() { }
        public Person(int id, string name)
        {
            _id = id;
            _name = name;
        }
        private int _id;
        private string _name;
        /// <summary>
        /// ID号码
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// Inputable接口的函数绑定字段
        /// </summary>
        /// <param name="columnindex">网格文件的列索引，从0开始</param>
        /// <param name="filedata">对应列的数据的字符串形式，将他设置到类的属性上</param>
        /// <returns>如果不是你想要的列索引请返回false</returns>
        bool IInputable.ColumnBind(int columnindex, string filedata)
        {
            if (0 == columnindex)
            {
                //将第0列绑定到Person类的id属性上，如果不是string类型，请自行转换
                //如果转换失败的话可以返回false
                _id = Convert.ToInt32(filedata);
            }
            else if (1 == columnindex)
            {
                //将第1列绑定到Person类的name属性上
                _name = filedata;
            }
            else
            {
                //不是你想要的列索引，所以返回false
                return false;
            }
            //如果绑定成功返回true
            return true;
        }
    }
}
