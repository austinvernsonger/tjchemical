using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

public partial class Education_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        if (!this.IsPostBack)
        {
            TreeView view = (TreeView)FindControlEx(this.Page,"authTree");
            System.Windows.Forms.MessageBox.Show("try");
            if (view != null)
            {
                TreeNode node = new TreeNode();
                node.Text = "test";
                view.Nodes.Add(node);
                System.Windows.Forms.MessageBox.Show("find");
            }
        }
       */
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
        bool bf = Page.FindControl("ctl00") != null;
        System.Windows.Forms.MessageBox.Show("try"); 
        if (bf)
        {
            System.Windows.Forms.MessageBox.Show("find");
        }
        string t = "";
        Label lable = new Label();
       
        display(Page.Controls, ref t);
        lable.Text = t;
        Page.Controls.Add(lable);
        */
    }
    private Control FindControlEx(Control controls, string id)
    {
        Control rs = null;
        if (controls == null)
        {
            return rs;
        }
        else
        {
            if ((rs = controls.FindControl(id)) == null)
            {
                foreach (Control control in controls.Controls)
                {
                    rs = FindControlEx(control, id);
                    if (rs != null)
                    {
                        return rs;
                    }
                }
            }
            return rs;
        }
    }
    private void display(ControlCollection controls, ref string text)
    {
       foreach ( Control control in controls)
       {
           text += controls.GetType().ToString() + "- <b>" + control.ID + "</b><br />";
           if (control.Controls != null)
           {
               display(control.Controls, ref text);
           }
       }
    }
}
