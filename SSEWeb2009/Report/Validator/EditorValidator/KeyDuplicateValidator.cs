using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using Report.Descriptor;

namespace Report.Validator.EditorValidator
{
    public class KeyDuplicateValidator:AbstractValidator
    {
        public KeyDuplicateValidator(AbstractValidator next)
            : base(next)
        {

        }

        protected override bool CheckValidation(Report.Descriptor.AbstractDescriptor Desc)
        {
            if (Desc.ResultDescriptor.IsKey)
            {
                while (Desc.Parent != null)
                {
                    Desc = Desc.Parent;
                }
                return CountKey(Desc as ReportDescriptor) <= 1;
            }
            return true;
        }

        protected override string ErrorMessage()
        {
            return "不允许有一个以上的主键";
        }

        protected int CountKey(ReportDescriptor Desc)
        {
            int keycount = 0;
            Stack<AbstractDescriptor> stack = new Stack<AbstractDescriptor>();
            stack.Push(Desc);
            while (stack.Count != 0)
            {
                AbstractDescriptor current = stack.Pop();
                if (current is ReportDescriptor)
                {
                    foreach (AbstractDescriptor Ad in (current as ReportDescriptor).Items)
                    {
                        stack.Push(Ad);
                    }
                }
                else
                {
                    if (current.ResultDescriptor.IsKey)
                    {
                        ++keycount;
                    }
                }
            }
            return keycount;
        }
    }
}
