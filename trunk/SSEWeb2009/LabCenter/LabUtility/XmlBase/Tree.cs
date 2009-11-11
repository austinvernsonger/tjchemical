using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Web.UI.WebControls;
using System.Collections;

namespace LabCenter.LabUtility.XmlBase
{
    public class TreeNode
    {
        public TreeNode() { }
        public TreeNode(string linkaddress,string name)
        {
            m_linkaddress = linkaddress;
            m_name = name;
        }
        private string m_linkaddress="";
        public string LinkAddress
        {
            get { return m_linkaddress; }
            set { m_linkaddress = value; }
        }
        private string m_name="";
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        private List<TreeNode> m_nodes = new List<TreeNode>();
        public List<TreeNode> Nodes
        {
            get { return m_nodes; }
            set { m_nodes = value; }
        }
    };

    public class Tree:XmlParseBase
    {
        private TreeNode root;

        [XmlElement(Type = typeof(TreeNode), ElementName = "Node")]
        public TreeNode Root
        {
            get { return root; }
            set { root = value; }
        }

        public Tree(){}
        public Tree(String path)
            : base(path) { }

    }
}
