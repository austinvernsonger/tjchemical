using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Report.Descriptor;

namespace Report.Validator
{
    public class NameDuplicateValidator:AbstractValidator
    {
        public NameDuplicateValidator(AbstractValidator next):base(next){}

        protected override bool CheckValidation(AbstractDescriptor Desc)
        {
            if (Desc.Parent != null)
            {
                int NameDuplication = 0;
                foreach (AbstractDescriptor Ad in Desc.Parent.Items)
                {
                    if (Desc.Name.Equals(Ad.Name))
                    {
                        ++NameDuplication;
                    }
                }
                if (NameDuplication > 1)
                {
                    return false;
                }
            }
            return true;
            
        }

        protected override string ErrorMessage()
        {
            return "项目名称重复\n";
        }
    }
}
