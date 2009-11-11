using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.LabUtility.GridDataUtility
{
    public interface IInputable
    {
        bool ColumnBind(int columnindex,string filedata);
    }
}
