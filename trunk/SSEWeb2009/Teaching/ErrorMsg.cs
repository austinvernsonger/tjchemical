using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Teaching
{
    public static class ErrorMsg
    {
        public static void WriteErrorMsg(HttpResponse Response, String msg)
        {
            Response.Write("<p><span class=\"Apple-style-span\" style=\"font-family: Simsun; font-size: 16px; \"> " +
            "<div style=\"background-color: rgb(255, 255, 255); padding-top: 5px; padding-right: 5px; padding-bottom: 5px; padding-left:"
            + " 5px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; font-family: Arial, Verdana, sans-serif;"
            + " font-size: 12px; \"><strong><span style=\"color: rgb(255, 0, 0); \">&nbsp;请填写"
            + msg
            + " </span></strong></div>" + "</span></p>");
        }
    }
}
