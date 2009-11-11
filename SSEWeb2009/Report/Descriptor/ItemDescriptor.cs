using System;
using System.Collections;
using Report.Descriptor.Collection;
using System.Web.UI;
using System.Collections.Generic;

namespace Report.Descriptor
{
    /// <summary>
    /// ItemDescriptor is used to describe an item.
    /// subclass from AbstractDescriptor
    /// Act as a Proxy to ItemDescriptorContent.
    /// control the access and modify of its member
    /// author : Wolfhead
    /// Date : 5-12
    /// </summary>
    public class ItemDescriptor : AbstractDescriptor
    {
        public ItemDescriptor()
        {
            Name = "未命名项";
            Type = ItemType.TEXT;
        }

        protected StringList m_StringList;
        public StringList Infos
        {
            get//Lazy evaluate
            {
                if (null == m_StringList)
                {
                    m_StringList = new StringList();
                }
                return m_StringList;
            }
            set
            {
                m_StringList = value;
            }
        }

        public override void RefreshParentReference()
        {
            return;
        }

        public override bool Validate(Report.Validator.IValidator validator)
        {
            if (!validator.Validate(this))
            {
                this.ControlAdapter.SetMessage(validator.Message());
                return false;
            }
            return true;
        }


        public override List<KeyValuePair<string, string>> GetResult()
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string,string>>();
            KeyValuePair<string, string> resultPair = new KeyValuePair<string, string>(this.FullName, this.ControlAdapter.GetResult());
            result.Add(resultPair);
            return result;
        }

        public override AbstractDescriptor GetKeyDescriptor()
        {
            if (ResultDescriptor.IsKey)
            {
                return this;
            }
            return null;
        }

        public override AbstractDescriptor FindDescriptorByFullName(string fullName)
        {
            //this is easy for itemsDescriptor
            //the full name should be it's name or not
            if (Name.Equals(fullName))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        public override void SetDisplayMode(DisplayMode mode)
        {
            this.DisplayDescriptor.DisplayMode = mode;
        }
    }
}
