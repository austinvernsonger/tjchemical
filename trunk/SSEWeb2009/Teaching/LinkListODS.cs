using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Teaching
{
    public class LinkListODS
    {
         public DataSet GetList(String SQL)
         {
             Ops.opsTeachingQuery query = new Ops.opsTeachingQuery(SQL);
             query.Do();
             return query.mResult;
         }
         public void DeleteLine(Int32 ID, String SQL)
         {
             Ops.opsTeachingExec exec = new Ops.opsTeachingExec(SQL);
             exec.Do();
         }
    }
}
