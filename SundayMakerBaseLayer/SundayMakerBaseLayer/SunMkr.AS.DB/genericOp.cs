using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SunMkr.AS
{
    class genericOp : DBOp
    {
        bool m_hasReturnValue = false;
        string m_producer = string.Empty;
        object m_returnValue = null;
        object[] m_parameters = null;

        /// <summary>
        /// Return Value.
        /// </summary>
        public object ReturnValue
        {
            get { return m_returnValue; }
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="ProviderName"></param>
        public genericOp(string ProviderName)
            : base(ProviderName)
        {
        }

        /// <summary>
        /// The process under control of CC.
        /// </summary>
        public override void processUnderControl()
        {
            //throw new NotImplementedException();
            if (m_hasReturnValue)
                m_returnData = myProc.Producer(m_producer, out m_returnValue, m_parameters);
            else
                m_returnData = myProc.Producer(m_producer, m_parameters);
        }

        /// <summary>
        /// Set the variables.
        /// </summary>
        /// <param name="ProducerName"></param>
        /// <param name="HasReturnValue"></param>
        /// <param name="Parameters"></param>
        public void SetParameter(string ProducerName, bool HasReturnValue, params object[] Parameters)
        {
            this.m_producer = ProducerName;
            this.m_hasReturnValue = HasReturnValue;
            this.m_parameters = Parameters;
        }
    }
}
