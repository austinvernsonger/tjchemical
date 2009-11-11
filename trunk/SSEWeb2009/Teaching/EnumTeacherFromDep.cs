using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Teaching.Ops;

namespace Teaching
{
    public static class EnumTeacherFromDep
    {
        public static DataSet EnumTeacherID(String Department)
        {
            String sql = "select TeacherID from TeacherAdministrator where Department = \'" + Department + "\'";
            opsTeachingQuery opsQuery = new opsTeachingQuery(sql);
            opsQuery.Do();
            return opsQuery.mResult;
        }
    }
}
