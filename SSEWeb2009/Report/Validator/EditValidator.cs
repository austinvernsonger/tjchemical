using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Report.Validator.EditorValidator;

namespace Report.Validator
{
    public class EditValidator : AbstractValidator
    {
        public EditValidator():base(new NameDuplicateValidator(new NameRegexValidator(new KeyDuplicateValidator(null))))
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
