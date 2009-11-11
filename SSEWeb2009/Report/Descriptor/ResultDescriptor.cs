using System.Xml.Serialization;

namespace Report.Descriptor
{
    public class ResultDescriptor
    {
        public ResultDescriptor()
        {
            IsKey = false;
            m_MustNotEmpty = false;
            MaxSize = 0;
            LastResult = "";
            ResultViewMode = ResultViewMode.View;
            ResultEditMode = ResultEditMode.Both;
        }

        protected bool m_IsKey;
        public bool IsKey
        {
            get
            {
                return m_IsKey;
            }
            set
            {
                m_IsKey = value;
            }
        }

        protected bool m_MustNotEmpty;
        public bool MustNotEmpty
        {
            get
            {
                if (IsKey)
                {
                    return true;
                }
                return m_MustNotEmpty;
            }
            set
            {
                m_MustNotEmpty = value;
            }
        }


        protected int m_MaxSize;
        public int MaxSize
        {
            get
            {
                return m_MaxSize;
            }
            set
            {
                m_MaxSize = value;
            }
        }

        protected string m_LastResult;
        [XmlIgnore]
        public string LastResult
        {
            get
            {
                return m_LastResult;
            }
            set
            {
                m_LastResult = value;
            }
        }

        protected ResultEditMode m_ResultEditMode;
        public ResultEditMode ResultEditMode
        {
            get
            {
                return m_ResultEditMode;
            }
            set
            {
                m_ResultEditMode = value;
            }
        }

        protected ResultViewMode m_ResultViewMode;
        public ResultViewMode ResultViewMode
        {
            get
            {
                if (IsKey)
                {
                    return ResultViewMode.View;
                }
                return m_ResultViewMode;
            }
            set
            {
                m_ResultViewMode = value;
            }
        }

    }

    public enum ResultEditMode
    {
        OnlyFront,
        OnlyBack,
        Both
    }

    public enum ResultViewMode
    {
        View,
        Hide
    }

}
