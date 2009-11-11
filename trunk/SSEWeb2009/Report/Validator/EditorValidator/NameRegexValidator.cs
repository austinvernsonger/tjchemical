using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Text.RegularExpressions;

namespace Report.Validator
{
    public class NameRegexValidator:AbstractValidator
    {
        public NameRegexValidator(AbstractValidator next)
            : base(next)
        {

        }

        protected override bool CheckValidation(Report.Descriptor.AbstractDescriptor Desc)
        {
            Regex regex = new Regex("^[a-zA-Z0-9-\u4e00-\u9fa5]+$");
            Match match = regex.Match(Desc.Name);
            return match.Success;
        }

        protected override string ErrorMessage()
        {
            return "名称只能包括中英文或数字";
        }
    }
}
