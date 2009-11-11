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
    public class MaxSizeValidator:AbstractValidator
    {
        int MaxSize = 0;

        public MaxSizeValidator(AbstractValidator next):base(next)
        {

        }

        protected override bool CheckValidation(Report.Descriptor.AbstractDescriptor Desc)
        {
            if (Desc.ResultDescriptor.MaxSize > 0)
            {
                if (Desc.ControlAdapter.GetResult().Length > Desc.ResultDescriptor.MaxSize)
                {
                    this.MaxSize = Desc.ResultDescriptor.MaxSize;
                    return false;
                }
            }
            return true;
        }

        protected override string ErrorMessage()
        {
            return "长度不可超过" + MaxSize.ToString();
        }
    }
}
