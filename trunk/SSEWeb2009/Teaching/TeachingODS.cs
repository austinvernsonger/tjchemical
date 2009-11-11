using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Teaching
{
    class TeachingODS
    {
        public DataSet GetList(String SQL)
        {
            Ops.opsTeachingQuery query = new Ops.opsTeachingQuery(SQL);
            query.Do();
            return query.mResult;
        }
        public DataSet GetTerm(String Type)
        {
            return GetList("select distinct [Term] from [EducationSchema] where Type ="+Type);
        }
    }
}
