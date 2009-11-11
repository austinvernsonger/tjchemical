using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;

namespace Report.Validator
{
    public abstract class AbstractValidator:IValidator
    {
        protected ArrayList m_ErrorMessage;
        protected AbstractValidator NextValidate;

        public AbstractValidator(AbstractValidator next)
        {
            NextValidate = next;
            m_ErrorMessage = new ArrayList();
        }

        #region IValidator 成员

        public bool Validate(Report.Descriptor.AbstractDescriptor Desc)
        {
            //clear the  Message
            m_ErrorMessage.Clear();
            //check if this validate passes 
            bool Validation = CheckValidation(Desc);
            if (!Validation)
            {
                //if not pass add the specified ErrorMessage to the Message
                m_ErrorMessage.Add(ErrorMessage());
            }
            //if has a next validator to check
            if (null != NextValidate)
            {
                //check if the next validate passes
                if (!(Validation &= NextValidate.Validate(Desc)))
                {
                    //if not and the next validation's Message to this validate Message
                    m_ErrorMessage.AddRange(NextValidate.Message());
                }          
            }
            return Validation;
        }

        public ArrayList Message()
        {
            return m_ErrorMessage;
        }

        #endregion

        abstract protected bool CheckValidation(Report.Descriptor.AbstractDescriptor Desc);
        abstract protected string ErrorMessage();
    }
}
