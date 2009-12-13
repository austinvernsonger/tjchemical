using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SunMkr.Kernel.CfgElem
{
    /// <summary>
    /// Configure Element.
    /// </summary>
    public interface ICfgElem
    {
        /// <summary>
        /// Return a XmlNode of current Configure Element.
        /// </summary>
        /// <returns></returns>
        XmlNode ToXmlNode( );

        /// <summary>
        /// Generate a configure element from a XmlNode
        /// </summary>
        /// <param name="node"></param>
        void FromXmlNode( XmlNode node );

        /// <summary>
        /// The KeyWord to identify an element
        /// </summary>
        string KeyWord { get; }
    }
}
