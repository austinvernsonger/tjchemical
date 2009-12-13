using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr.Proc
{
    /// <summary>
    /// The abstract version of Operation.
    /// The base class of all operation provider by the client.
    /// </summary>
    /// <typeparam name="Provider"></typeparam>
    public abstract class absOperation<Provider> : IOperation<Provider> where Provider : class, IProvider
    {
        /// <summary>
        /// The Processor
        /// </summary>
        protected Provider m_Provider;
        /// <summary>
        /// The Bound String.
        /// </summary>
        protected string m_bindstring;

        /// <summary>
        /// Construction
        /// </summary>
        public absOperation()
        {
        }

        /// <summary>
        /// Construction with bound string
        /// </summary>
        /// <param name="BindString"></param>
        public absOperation(string BindString)
        {
            this.m_bindstring = BindString;
        }

        #region IOperation<Provider> Members

        /// <summary>
        /// Processor
        /// </summary>
        public Provider myProc
        {
            get
            {
                return m_Provider;
            }
            set
            {
                m_Provider = value;
            }
        }

        /// <summary>
        /// Do Under Control
        /// </summary>
        virtual public void processUnderControl()
        {
            throw new NotImplementedException("In AOperation.");
        }

        /// <summary>
        /// Do the operator.
        /// </summary>
        /// <returns></returns>
        public bool Do()
        {
            if (!ControlCenter.RegOp(this))
                return false;
            bool bResult = ControlCenter.DoUnderControl(this);
            ControlCenter.ReleaseOp(this);
            return bResult;
        }

        /// <summary>
        /// Gets the bound string.
        /// </summary>
        public string BindString
        {
            get { return m_bindstring; }
        }

        /// <summary>
        /// Gets the AS's Name.
        /// </summary>
        virtual public string ASName
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Get last error.
        /// </summary>
        /// <returns></returns>
        public Exception GetLastError()
        {
            return SunMkr.Sys.ErrorSystem.GetError(m_errorId);
        }

        string m_errorId = string.Empty;

        /// <summary>
        /// Set last error id
        /// </summary>
        public string LastErrorID
        {
            set { m_errorId = value; }
        }

        #endregion
    }
}
