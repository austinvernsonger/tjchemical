using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SunMkr.Com.Xml
{
    /// <summary>
    /// Xml Elements Structure.
    /// </summary>
    public class XmlElement : ICloneable
    {
        string m_Name = string.Empty;
        Dictionary<string, XmlAttribute> m_Attributes = new Dictionary<string, XmlAttribute>( );
        Dictionary<string, XmlElement> m_ChildElements = new Dictionary<string, XmlElement>( );
        string m_InnerText = string.Empty;
        XmlNode m_Node;

        /// <summary>
        /// Collection Of Element
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public XmlElement this [string Name]
        {
            get
            {
                if ( m_ChildElements.ContainsKey( Name ) )
                    return m_ChildElements [Name];
                return null;
            }
            set
            {
                if ( m_ChildElements.ContainsKey( Name ) )
                    m_ChildElements [Name] = value;
                else
                {
                    m_ChildElements.Add( Name, value );
                    m_Node.AppendChild( value.Node );
                }
            }
        }

        /// <summary>
        /// XmlNode in this element.
        /// </summary>
        public XmlNode Node
        {
            get { return m_Node; }
        }

        /// <summary>
        /// Attributes
        /// </summary>
        public Dictionary<string, XmlAttribute> Attributes
        {
            get
            {
                return m_Attributes;
            }
        }
        /// <summary>
        /// Node's Name.
        /// </summary>
        public string Name
        {
            get { return m_Name.Clone( ) as string; }
        }

        /// <summary>
        /// Inner Text in the Element.
        /// </summary>
        public string InnerText
        {
            get { return m_InnerText.Clone( ) as string; }
            set { m_InnerText = value.Clone( ) as string; m_Node.InnerText = m_InnerText; }
        }

        /// <summary>
        /// Default Construction.
        /// </summary>
        public XmlElement( )
        {
        }

        /// <summary>
        /// Xml Element Node Construction 
        /// </summary>
        /// <param name="ElementName"></param>
        public XmlElement( string ElementName )
        {
            m_Name = (string)ElementName.Clone( );
        }

        /// <summary>
        /// Xml Element Node Construction with Input Node
        /// </summary>
        /// <param name="Node"></param>
        public XmlElement( XmlNode Node )
        {
            m_Node = Node;
            m_Name = (string)Node.Name.Clone( );
            foreach ( System.Xml.XmlAttribute xmlAttr in Node.Attributes )
            {
                XmlAttribute attr = new XmlAttribute( xmlAttr.Name, xmlAttr.Value );
                m_Attributes.Add( attr.Name, attr );
            }
            foreach ( System.Xml.XmlNode xmlNode in Node.ChildNodes )
            {
                XmlElement element = new XmlElement( xmlNode );
                m_ChildElements.Add( element.m_Name, element );
            }

            m_InnerText = Node.InnerText.Clone( ) as string;
        }

        /// <summary>
        /// Add Attribute
        /// </summary>
        /// <param name="Attribute"></param>
        public void AddAttribute( XmlAttribute Attribute )
        {
            if ( m_Attributes.ContainsKey( Attribute.Name ) )
                m_Attributes [Attribute.Name] = Attribute.Clone( ) as XmlAttribute;
            else m_Attributes.Add( Attribute.Name, Attribute.Clone( ) as XmlAttribute );
        }

        /// <summary>
        /// Add Attribute
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Value"></param>
        public void AddAttribute( string Name, string Value )
        {
            XmlAttribute tmpAttr = new XmlAttribute( Name, Value );
            AddAttribute( tmpAttr );
        }

        /// <summary>
        /// Add new Child Node.
        /// </summary>
        /// <param name="Element"></param>
        public void AddChildNode( XmlElement Element )
        {
            this [Element.Name] = Element;
        }

        #region ICloneable Members

        /// <summary>
        /// Clone current Xml Element Node
        /// </summary>
        /// <returns></returns>
        public object Clone( )
        {
            XmlElement newObj = new XmlElement( );
            newObj.m_Name = this.Name;
            foreach ( XmlElement elem in this.m_ChildElements.Values )
            {
                newObj.m_ChildElements.Add( 
                    elem.Name.Clone( ) as string, elem.Clone( ) as XmlElement );
            }
            foreach ( XmlAttribute attr in this.m_Attributes.Values )
            {
                newObj.m_Attributes.Add( 
                    attr.Name.Clone( ) as string, attr.Clone( ) as XmlAttribute );
            }

            return newObj;
            //throw new NotImplementedException( );
        }

        #endregion
    }
}
