using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemError : System.Web.UI.Page
{
    /// <summary>
    /// This parameter is used to define the debug mode.
    /// Set it to false when the website is to be published.
    /// </summary>
    const Boolean BeOnDebug = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["err"] != null && BeOnDebug)
        {
            Int64 eid = Convert.ToInt64(Request.Params["err"]);
            if (ConstValue._errorSession[eid] == null)
            {
                // Message set the error system's message
                lb_message.Text = SMBL.Core.ErrorSystem.GetError(Convert.ToInt64(eid));
                Message_d.Visible = true;
                lb_message.Visible = true;
            }
            else
            {
                Exception myException = (Exception)ConstValue._errorSession[eid];

                lb_message.Text = myException.Message;
                lb_method.Text = myException.TargetSite.ToString();
                lb_Source.Text = myException.Source;
                lb_exptype.Text = myException.GetType().ToString();

                String tmpStackTrace = myException.StackTrace.Trim();
                string myDevideWord = (tmpStackTrace.StartsWith("at ")) ? "at " : "在 ";
                ArrayList myStackTraces = new ArrayList();
                for (int indexWord = 1; indexWord > 0; ++indexWord)
                {
                    int StartPoint = indexWord - 1;
                    indexWord = tmpStackTrace.IndexOf(myDevideWord, indexWord);
                    if (indexWord > 0)
                    {
                        myStackTraces.Add(tmpStackTrace.Substring(StartPoint, indexWord - StartPoint));
                    }
                }
                for (int i = 0; i < myStackTraces.Count; ++i)
                {
                    lb_stacktrace.Text += myStackTraces[i].ToString();
                    lb_stacktrace.Text += "<br /><br />";
                }

                // Show the messages
                Message_d.Visible = true;
                lb_message.Visible = true;
                Method_d.Visible = true;
                lb_method.Visible = true;
                Source_d.Visible = true;
                lb_Source.Visible = true;
                ExpType_d.Visible = true;
                lb_exptype.Visible = true;
                StackTrace_d.Visible = true;
                lb_stacktrace.Visible = true;

                ConstValue._errorSession.Remove(eid);
            }
        }
    }
}
