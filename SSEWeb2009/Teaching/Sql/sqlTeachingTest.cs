using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Teaching.Sql
{
    /// <summary>
    /// Interface to delete an MMT.
    /// </summary>
    class sqlTeachingTest : ISql
    {
        int myId;
        String myName;

        public sqlTeachingTest(int Id,String name)
        {
            myId = Id;
            myName = name;
        }

        /// <summary>
        /// Get Sql Sentence
        /// </summary>
        /// <returns></returns>
        #region ISql Members

        public string GetSql()
        {
            return "INSERT into TeachingTest Values(" + myId + ",'" + myName + "')";
        }

        #endregion
    }
}
