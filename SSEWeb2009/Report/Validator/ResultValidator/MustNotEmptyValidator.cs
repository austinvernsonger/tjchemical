using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Report.Validator.ResultValidator
{
    public class MustNotEmptyValidator:AbstractValidator
    {
        public MustNotEmptyValidator(AbstractValidator next):base(next)
        {

        }

        protected override bool CheckValidation(Report.Descriptor.AbstractDescriptor Desc)
        {
            if (Desc.ResultDescriptor.MustNotEmpty)
            {
                if (Desc.ControlAdapter.GetResult().Length == 0)
                {
                    return false;
                }            
            }
            return true;
        }

        protected override string ErrorMessage()
        {
            return "不可以为空";
        }
    }
}
