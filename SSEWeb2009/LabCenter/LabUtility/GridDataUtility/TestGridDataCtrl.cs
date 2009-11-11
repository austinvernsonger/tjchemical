using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.GridDataUtility
{
    public class TestGridDataCtrl<T>: GridDataCtrl<T>
        where T:IInputable,new()
    {
        public override bool SqlToFile(string sql,string datasource,string tofilepath)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override List<T> FileToClass(string filepath) 
        {
            List<T> ret = new List<T>();
            int remain = 5;
            while (0 != --remain)
            {
                //getrow
                T temp = new T();
                temp.ColumnBind(0, "1234");
                temp.ColumnBind(1, "zhoucongma");
                ret.Add(temp);
            }
            return ret;
        }
    }
}
