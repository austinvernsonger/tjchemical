using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Report.Controls;
using Report.Descriptor;

namespace Report.Adapter
{
    public abstract class AbstractControlAdapter:IControlAdapter
    {

        protected Report.Descriptor.AbstractDescriptor Desc;
        protected IItemControl itemControl;

        #region IControlAdapter 成员

        public abstract IControlAdapter Clone();

        public string GetResult()
        {
            if (null == itemControl)
            {
                return "";
            }
            return itemControl.GetResult();
        }
        
        public IItemControl CreateControl(TemplateControl Parent)
        {
            if (null == Desc)
            {
                return null;
            }

            if (!DisplayableInMode(Desc.DisplayDescriptor.DisplayMode))
            {
                return null;
            }
            else
            {
                switch (Desc.DisplayDescriptor.DisplayMode)
                {
                    case DisplayMode.DisplayFront:
                    case DisplayMode.DisplayBack:
                        itemControl = CreateDisplayControl(Parent);
                        break;
                    case DisplayMode.Edit:
                        itemControl = CreateEditControl(Parent);
                        break;
                }
                itemControl.SetDescriptor(Desc);
            }

            itemControl.SetEditable(EditableInMode(Desc.DisplayDescriptor.DisplayMode));

            return itemControl;
        }
        

        public void SetDescriptor(Report.Descriptor.AbstractDescriptor Desc)
        {
            this.Desc = Desc;
        }

        public void SetMessage(System.Collections.ArrayList StringArray)
        {
            if (null != itemControl)
            {
                itemControl.SetMessage(StringArray);
            }
        }
        public void RefreshControl()
        {
            if (null != itemControl)
            {
                itemControl.RefreshControl();
            }
        }
        #endregion

        //FactoryMethod
        protected abstract IItemControl CreateDisplayControl(TemplateControl target);
        protected abstract IItemControl CreateEditControl(TemplateControl target);


        protected Boolean DisplayableInMode(DisplayMode mode)
        {
            return true;
        }

        protected Boolean EditableInMode(DisplayMode mode)
        {
            return Desc.Editable;
        }
    }
}
