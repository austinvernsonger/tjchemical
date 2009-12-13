using System;
using System.Collections.Generic;
using System.Text;
using SunMkr.Proc;
using System.Data;

namespace SunMkr.AS
{
    /// <summary>
    /// The Abstarct class of Database Operation
    /// </summary>
    public class DBOp : absOperation<IDBProvider>
    {
        /// <summary>
        /// The DataSet to be returned.
        /// </summary>
        protected DataSet m_returnData = null;
        /// <summary>
        /// Gets the return data.
        /// </summary>
        public DataSet Result
        {
            get { return m_returnData; }
        }

        /// <summary>
        /// Construction
        /// </summary>
        public DBOp( )
        {
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="BindString"></param>
        public DBOp( string BindString )
            : base(BindString)
        {
        }

        #region IOperation<IDBProvider> Members

        /// <summary>
        /// Process Under Control
        /// </summary>
        public override void processUnderControl()
        {
            throw new NotImplementedException("In DBOp's processUnderControl.");
        }

        /// <summary>
        /// AS name.
        /// </summary>
        override public string ASName
        {
            get { return "DBControl"; }
        }

        #endregion
    }
}
