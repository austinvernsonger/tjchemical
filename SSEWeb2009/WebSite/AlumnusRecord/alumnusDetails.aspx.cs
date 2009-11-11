using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlumnusRecord;
using System.Data;
using System.IO;

public partial class alumnusDetails : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {

        Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (!Page.IsPostBack)
        {
            try
            {
                FormInit();                
            }
            catch
            {
 
            }
        }       
    }

    protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
    {

        string id = Request.QueryString["id"];
        string user = Session["IdentifyNumber"] == null ? null : Session["IdentifyNumber"].ToString();

        if ((user != null && id == null) || (user != null && id != null && id == user))
        {
            this.FormView1.ChangeMode(e.NewMode);

            FormInit(); 
        }        
        
    }
    protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        
        try
        {
            string origin1 = ((TextBox)((FormView)sender).FindControl("TextBoxOrigin")).Text;
            string origin = ((TextBox)this.FormView1.FindControl("TextBoxOrigin")).Text;
            string teachingPoint = ((TextBox)this.FormView1.FindControl("TextBoxTeachPoint")).Text;
            string workPlace = ((TextBox)this.FormView1.FindControl("TextBoxWorkPlace")).Text;
            string address = ((TextBox)this.FormView1.FindControl("TextBoxAddress")).Text;
            string phone = ((TextBox)this.FormView1.FindControl("TextBoxPhone")).Text;
            string email = ((TextBox)this.FormView1.FindControl("TextBoxEmail")).Text;
            string publicity = ((DropDownList)this.FormView1.FindControl("DropDownListPub")).SelectedValue;
            string summary = ((TextBox)this.FormView1.FindControl("TextBoxSummary")).Text;

            Alumnus al = new Alumnus();
            al.StdNumber = /*Request.QueryString["id"]*/Session["IdentifyNumber"] == null ? null : Session["IdentifyNumber"].ToString(); 
            al.BirthPlace = origin;
            al.Email = email;
            al.GradPlace = teachingPoint;
            al.Intro = summary;
            al.Openstatus = Convert.ToInt32(publicity);
            al.Tel = phone;
            al.WorkPlace = address;
            al.WorkUnit = workPlace;

            al.UpdateAlumnus();

            FormInit();

        }
        catch
        {

        }

        this.FormView1.ChangeMode(FormViewMode.ReadOnly);

        FormInit();
    }

  
    private void FormInit()
    {        
        string id = Request.QueryString["id"];
         string user = Session["IdentifyNumber"] == null ? null : Session["IdentifyNumber"].ToString();

        if (id == null && user == null)
        {
            this.LinkButtonChange.Visible = false;
            this.Image1.Visible = false;
            return;
        }
        else if (id == null)
        {
            id = user;
        }

        Alumnus al = new Alumnus();        
        
        DataSet ds = al.GetAlumnus(id);

        int publicity;

        try
        {
            publicity = Convert.ToInt32(ds.Tables[0].Rows[0]["Publicity"]);
            String grade = Convert.ToString(ds.Tables[0].Rows[0]["GraduateYear"]);
            String name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
            this.Label1.Text = grade + "届毕业生 " + name;
        }
        catch
        {
            publicity = 1; 
        }

        if (user == null)
        {
            if (publicity == 0)
            {
                this.LinkButtonChange.Visible = false;
                this.Image1.Visible = false;
                return;
            }
            else
            {
                this.LinkButtonChange.Visible = false;
                this.FormView1.DataSource = ds;
                this.FormView1.DataBind();
                ShowImg(id);
                
            }
        }
        else
        {
            if (user == id)
            {
                this.FormView1.DataSource = ds;
                this.FormView1.DataBind();
                ShowImg(id);
            }
            else
            {
                if (publicity == 0)
                {
                    this.LinkButtonChange.Visible = false;
                    this.Image1.Visible = false;
                    return;
                }
                else
                {
                    this.LinkButtonChange.Visible = false;                  
                    this.FormView1.DataSource = ds;
                    this.FormView1.DataBind();
                    ShowImg(id);                   
                } 
            }
           

             
        }


        
    }
    protected void FormView1_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        int i = e.AffectedRows;
        
        try
        {
            string origin = ((TextBox)this.FormView1.FindControl("TextBoxOrigin")).Text;
            string teachingPoint = ((TextBox)this.FormView1.FindControl("TextBoxTeachPoint")).Text;
            string workPlace = ((TextBox)this.FormView1.FindControl("TextBoxWorkPlace")).Text;
            string address = ((TextBox)this.FormView1.FindControl("TextBoxAddress")).Text;
            string phone = ((TextBox)this.FormView1.FindControl("TextBoxPhone")).Text;
            string email = ((TextBox)this.FormView1.FindControl("TextBoxEmail")).Text;
            string publicity = ((DropDownList)this.FormView1.FindControl("DropDownListPub")).SelectedValue;
            string summary = ((TextBox)this.FormView1.FindControl("TextBoxSummary")).Text;

            Alumnus al = new Alumnus();
            al.StdNumber = /*Request.QueryString["id"]*/Session["IdentifyNumber"] == null ? null : Session["IdentifyNumber"].ToString();
            al.BirthPlace = origin;
            al.Email = email;
            al.GradPlace = teachingPoint;
            al.Intro = summary;
            al.Openstatus = Convert.ToInt32(publicity);
            al.Tel = phone;
            al.WorkPlace = address;
            al.WorkUnit = workPlace;

            al.UpdateAlumnus();

            FormInit();


        }
        catch
        {

        }

        this.FormView1.ChangeMode(FormViewMode.ReadOnly);

        FormInit();

    }
    protected void LinkButtonChange_Click(object sender, EventArgs e)
    {
        this.ButtonUpload.Visible = true;
        this.FileUploadImg.Visible = true;
        this.ButtonCancel.Visible = true;
        this.LinkButtonChange.Visible = false;
    }
    protected void ButtonUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string str = Session["IdentifyNumber"].ToString();            

            string fileName = @"~/AlumnusRecord/Resources/tempHeaderImgs/" + str + Path.GetExtension(this.FileUploadImg.FileName);

            if (File.Exists(Server.MapPath(fileName)))
            {
                File.Delete(Server.MapPath(fileName));
            }

            this.FileUploadImg.SaveAs(Server.MapPath(fileName));

            FileStream fs = File.OpenRead(Server.MapPath(fileName));
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, (int)fs.Length);
            fs.Close();

            Alumnus al = new Alumnus();
            if (al.UpdateAluImg(str, buffer))
            {
                this.Image1.ImageUrl = fileName;
            }
            else
            {
 
            }

 //           ShowImg(str);

            this.ButtonUpload.Visible = false;
            this.FileUploadImg.Visible = false;
            this.ButtonCancel.Visible = false;
            this.LinkButtonChange.Visible = true;            
        }
        catch
        {
 
        }
    }

    private void ShowImg(string id)
    {
        try
        {
            string str = id + ".bmp";

            string fileName = @"~/AlumnusRecord/Resources/tempHeaderImgs/" + str;

            byte[] contents = new Alumnus().GetAluImg(id);


            if (File.Exists(Server.MapPath(fileName)))
            {
                File.Delete(Server.MapPath(fileName));
            }            

            FileInfo fi = new FileInfo(Server.MapPath(fileName));
            FileStream fs = fi.OpenWrite();
            fs.Write(contents, 0, contents.Length);
            fs.Close();

            Random rInt = new Random();
            int tmpInt = rInt.Next();
            this.Image1.ImageUrl = fileName+"?tmpid="+tmpInt.ToString();
        }
        catch
        {
 
        }
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        this.RegisterClientScriptBlock("e", "<script language=javascript>history.go(-2);</script>");

    }
}
