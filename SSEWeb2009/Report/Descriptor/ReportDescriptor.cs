using System.Xml.Serialization;
using Report.Descriptor.Collection;
using System.Collections;
using System.Collections.Generic;

namespace Report.Descriptor
{
    /// <summary>
    /// ReportDescriptor is used to describe an report.
    /// subclass from AbstractDescriptor
    /// Act as a Proxy to ReportDescriptorContent.
    /// control the access and modify of its member
    /// author : Wolfhead
    /// Date : 5-12
    /// </summary>
    public class ReportDescriptor:AbstractDescriptor
    {
        public ReportDescriptor()
        {
            Name = "未命名问卷";
            Type = ItemType.REPORT;
        }

        protected ItemList m_ItemList;
        [XmlArray("Items")]
        [XmlArrayItem(ElementName = "Item")]
        public ItemList Items
        {
            get//Lazy evaluate
            {
                if (null == m_ItemList)
                {
                    m_ItemList = new ItemList();
                }
                return m_ItemList;
            }
            set
            {
                m_ItemList = value;
            }
        }

        public override void RefreshParentReference()
        {
            foreach (AbstractDescriptor Ad in Items)
            {
                Ad.Parent = this;
                Ad.RefreshParentReference();
            }
        }

        public override bool Validate(Report.Validator.IValidator validator)
        {
            bool validation = validator.Validate(this);
            if (!validation)
            {
                this.ControlAdapter.SetMessage(validator.Message());
            }
            foreach (AbstractDescriptor Ad in Items)
            {
                validation &= Ad.Validate(validator);
            }
            return validation;
        }


        public override List<KeyValuePair<string, string>> GetResult()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            foreach(AbstractDescriptor Ad in Items)
            {
                list.AddRange(Ad.GetResult());
            }
            return list;
        }

        public override AbstractDescriptor GetKeyDescriptor()
        {
            AbstractDescriptor Key;
            foreach(AbstractDescriptor Ad in Items)
            {
                if (null != (Key = Ad.GetKeyDescriptor()))
                {
                    return Key;
                }
            }
            return null;
        }

        public override AbstractDescriptor FindDescriptorByFullName(string fullName)
        {
            //get the first name before dot
            string name = fullName;
            for (int i = 0; i != fullName.Length; ++i )
            {
                if (fullName[i] == '.')
                {
                    //there is a dot so we check all the items in this report
                    //first check if this is the report we are finding
                    name = fullName.Substring(0, i);
                    if (Name.Equals(name))
                    {
                        //then split the full name send the substring after the first dot to the items
                        foreach (AbstractDescriptor Ad in Items)
                        {
                            AbstractDescriptor target;
                            if ((target = Ad.FindDescriptorByFullName(fullName.Substring(i+1))) != null)
                            {
                                //if the return value is not null then we find it
                                return target;
                            }                           
                        }
                        //if we get here then there is no such Descriptor
                        return null;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            //if there is no dot the program goes here
            //then the full name is the name
            if (Name.Equals(fullName))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        public bool SetLastResult(List<KeyValuePair<string, string>> LastResult)
        {
            foreach (KeyValuePair<string,string> ResultPair in LastResult)
            {
                AbstractDescriptor Ad;
                if ((Ad = this.FindDescriptorByFullName(ResultPair.Key)) == null)
                {
                    return false;
                }
                else
                {
                    Ad.ResultDescriptor.LastResult = ResultPair.Value;
                }
            }
            return true;
        }

        public override void SetDisplayMode(DisplayMode mode)
        {
            this.DisplayDescriptor.DisplayMode = mode;
            foreach (AbstractDescriptor Ad in Items)
            {
                Ad.SetDisplayMode(mode);
            }
        }
    }
}
