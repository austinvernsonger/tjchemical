using System.IO;
using System.Xml.Serialization;
using Report.Adapter;
using System.Web.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Report.Descriptor
{
    /// <summary>
    /// Base Class of Descriptors which Describe an Item or Report
    /// provide basic members which are essential to identify the Item
    /// @author:Wolfhead
    /// @Date:5-20
    /// </summary>
    public abstract class AbstractDescriptor
    {
        
        /// <summary>
        /// Name of an Item or Report.
        /// the any two Items in the same report should not
        /// have the same Name.
        /// Name will be used in Result Generation ,Sort and Display
        /// </summary>
        protected string m_Name;
        public string Name
        {
            set
            {
                m_Name = value;
            }
            get
            {
                return m_Name;
            }
        }

        /// <summary>
        /// the full name of the item
        /// which will be like  "parentName.parentName.SelfName"
        /// </summary>
        [XmlIgnore]
        public string FullName
        {
            get
            {
                AbstractDescriptor item = this;
                string strPrefix = "";
                while (item.Parent != null)
                {
                    item = item.Parent;
                    strPrefix = item.Name + "." + strPrefix;
                }
                return strPrefix + this.Name;
            }
        }

        /// <summary>
        /// Type of an Item or Report.
        /// </summary>
        protected ItemType m_Type;
        public ItemType Type
        {
            set
            {
                m_Type = value;
            }
            get
            {
                return m_Type;
            }
        }

        /// <summary>
        /// 好吧，我写中文
        /// 控件适配器，用于显示，取得结果
        /// </summary>
        protected IControlAdapter m_Adapter;
        [XmlIgnore]
        public IControlAdapter ControlAdapter
        {
            get
            {
                if (null == m_Adapter)
                {
                    m_Adapter = AdapterFactory.Instance.GetAdapter(Type);
                    m_Adapter.SetDescriptor(this);
                }
                return m_Adapter;
            }
            set
            {
                m_Adapter = value;
            }
        }

        /// <summary>
        /// the index of the item in the report which contains it
        /// if you set the index it  means that you want to move the item to that index
        /// this operation will also refresh the view of the control
        /// </summary>
        protected int m_Index;
        [XmlIgnore]
        public int Index
        {
            get
            {
                if (Parent != null)
                {
                    return Parent.Items.IndexOf(this);//get the index in the report
                }
                else return 0;
            }
            set
            {
                if (Parent != null)
                {
                    if (value >= 0 && value < Parent.Items.Count && value != Index)
                    {
                        //move the items between value and index
                        if (Index < value)
                        {
                            for (int i = Index + 1; i <= value; ++i )
                            {
                                Parent.Items[i - 1] = Parent.Items[i];
                            }
                            Parent.Items[value] = this;
                        }
                        if (Index > value)
                        {
                            for (int i = Index - 1; i >= value; --i)
                            {
                                Parent.Items[i + 1] = Parent.Items[i];
                            }
                            Parent.Items[value] = this;
                        }
                        //refresh the view if has any
                        Parent.ControlAdapter.RefreshControl();
                    }
                }

            }
        }

        /// <summary>
        /// Stores the validation information
        /// </summary>
        protected ValidationDescriptor m_validationDesc;
        public ValidationDescriptor ValidationDescriptor
        {
            get//Lazy evaluate
            {
                if (m_validationDesc == null)
                {
                    m_validationDesc = new ValidationDescriptor();
                }
                return m_validationDesc;
            }
            set
            {
                m_validationDesc = value;
            }
        }

        /// <summary>
        /// Stores the display information
        /// </summary>
        protected DisplayDescriptor m_DisplayDescriptor;
        public DisplayDescriptor DisplayDescriptor
        {
            get//Lazy evaluate
            {
                if (m_DisplayDescriptor == null)
                {
                    m_DisplayDescriptor = new DisplayDescriptor();
                }
                return m_DisplayDescriptor;
            }
            set
            {
                m_DisplayDescriptor = value;
            }
        }

        /// <summary>
        /// Store the Result information.
        /// About How the result will be displayed and
        /// will the result be manipulated
        /// </summary>
        protected ResultDescriptor m_ResultDescrptor;
        public ResultDescriptor ResultDescriptor
        {
            get//Lazy evaluate
            {
                if (m_ResultDescrptor == null)
                {
                    m_ResultDescrptor = new ResultDescriptor();
                }
                return m_ResultDescrptor;
            }
            set
            {
                m_ResultDescrptor = value;
            }
        }

        /// <summary>
        /// Store the reference to the report which contains this item.
        /// this reference is manually maintained
        /// </summary>
        protected ReportDescriptor m_Parent;
        [XmlIgnore]
        public ReportDescriptor Parent
        {
            get
            {
                return m_Parent;
            }
            set
            {
                m_Parent = value;
            }
        }

        protected Boolean m_Editable;
        public Boolean Editable
        {
            get
            {
                return ((this.ResultDescriptor.ResultEditMode == ResultEditMode.Both) 
                    ||(this.ResultDescriptor.ResultEditMode == ResultEditMode.OnlyBack && DisplayDescriptor.DisplayMode == DisplayMode.DisplayBack)
                    || (this.ResultDescriptor.ResultEditMode == ResultEditMode.OnlyFront && this.DisplayDescriptor.DisplayMode == DisplayMode.DisplayFront))
                    && !(this.ResultDescriptor.IsKey && this.ResultDescriptor.LastResult != "");
            }
        }

        /// <summary>
        /// remove this item from its parent report
        /// this operation will also refresh the view of the control
        /// </summary>
        /// <returns></returns>
        public Boolean Delete()
        {
            if (Parent == null)
            {
                return false; ;
            }
            else
            {
                Parent.Items.Remove(this);//Remove from parent
                Parent.ControlAdapter.RefreshControl();//Refresh the view if has any
                return true;
            }
        }

        /// <summary>
        /// recursive validation check
        /// </summary>
        /// <param name="validator"></param>
        /// <returns></returns>
        public abstract Boolean Validate(Report.Validator.IValidator validator);
        /// <summary>
        /// Set the sub-item's parent to this 
        /// </summary>
        public abstract void RefreshParentReference();
        /// <summary>
        /// get result list from the descriptor
        /// </summary>
        /// <returns>an ArrayList of Pair<string,string></returns>
        public abstract List<KeyValuePair<string, string>> GetResult();

        public abstract AbstractDescriptor GetKeyDescriptor();

        public abstract AbstractDescriptor FindDescriptorByFullName(string fullName);

        public abstract void SetDisplayMode(DisplayMode mode);
    }

    



}
