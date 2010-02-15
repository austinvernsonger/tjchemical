using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Report.Validator.ResultValidator;

namespace Report.Validator
{
    public class MacroResultValidator:AbstractValidator
    {
        public MacroResultValidator()
            : base(new MustNotEmptyValidator(new MaxSizeValidator(new HasBeenCheckedValidation(null))))
        {

        }

        protected override bool CheckValidation(Report.Descriptor.AbstractDescriptor Desc)
        {
            return true;
        }

        protected override string ErrorMessage()
        {
            return "";
        }
    }
}
