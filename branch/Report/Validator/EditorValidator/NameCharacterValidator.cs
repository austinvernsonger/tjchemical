using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



namespace Report.Validator
{
    public class NameCharacterValidator:AbstractValidator
    {
        protected Char[] ExceptionCharacters = { '.' };

        public NameCharacterValidator(AbstractValidator next):base(next)
        {

        }

        public NameCharacterValidator(AbstractValidator next,Char [] ExceptionCharacters):base(next)
        {
            this.ExceptionCharacters = ExceptionCharacters;
        }

        protected override bool CheckValidation(Report.Descriptor.AbstractDescriptor Desc)
        {
            foreach (Char ch in ExceptionCharacters)
            {
                if (Desc.Name.Contains(ch.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        protected override string ErrorMessage()
        {
            string str = "项目名称中不可包含字符：";
            foreach (Char ch in ExceptionCharacters)
            {
                str += "'"+ch+"' ";
            }
            return str;
        }
    }
}
