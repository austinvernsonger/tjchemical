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
    public class HasBeenCheckedValidation:AbstractValidator
    {
        public HasBeenCheckedValidation(AbstractValidator next):base(next)
        {

        }


        protected override bool CheckValidation(Report.Descriptor.AbstractDescriptor Desc)
        {
            if (Desc.Type == Report.Descriptor.ItemType.ADMINCHECK &&
                Desc.DisplayDescriptor.DisplayMode == Report.Descriptor.DisplayMode.DisplayFront)
            {
                if (Desc.ControlAdapter.GetResult().Equals("已审核"))
                {
                    return false;
                }
            }
            return true;
        }

        protected override string ErrorMessage()
        {
            return "内容已被审核不能继续提交";
        }
    }
}
