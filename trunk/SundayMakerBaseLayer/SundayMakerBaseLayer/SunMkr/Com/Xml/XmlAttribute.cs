using System;
using System.Collections.Generic;
using System.Text;

namespace SunMkr.Com.Xml
{
    /// <summary>
    /// Xml Attributes
    /// </summary>
    public class XmlAttribute : ICloneable
    {
        string m_Value = string.Empty;
        string m_Name = string.Empty;

        /// <summary>
        /// Name of the Attribute
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = (string)value.Clone( ); }
        }

        /// <summary>
        /// Value of the Attribute
        /// </summary>
        public string Value
        {
            get { return m_Value; }
            set { m_Value = (string)value.Clone( ); }
        }

        /// <summary>
        /// Default Construction.
        /// </summary>
        public XmlAttribute( )
        {
        }

        /// <summary>
        /// Copy Construction.
        /// </summary>
        /// <param name="Value"></param>
        public XmlAttribute( string Value )
        {
            m_Value = (string)Value.Clone( );
        }

        /// <summary>
        /// Create the attribute with key and value.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Value"></param>
        public XmlAttribute( string Name, string Value )
        {
            m_Name = (string)Name.Clone( );
            m_Value = (string)Value.Clone( );
        }

        /// <summary>
        /// Implicit Conversition Operator
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static implicit operator string( XmlAttribute rhs )
        {
            return (string)rhs.m_Value.Clone( );
        }

        #region ICloneable Members

        /// <summary>
        /// Return a cloned object.
        /// </summary>
        /// <returns></returns>
        public object Clone( )
        {
            //throw new NotImplementedException( );
            return new XmlAttribute( this.m_Name, this.m_Value );
        }

        #endregion
    }
}
