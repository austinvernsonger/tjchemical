<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frame_btmbar.aspx.cs" Inherits="MasterPages_frame_btmbar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Frame Bottom Bar</title>

 <link href="../CssClass/Bright.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-left: 0; margin-top: 0;">
    <form id="frm_btmbar" runat="server">
    <asp:ScriptManager ID="scrptmgr_btm" runat="server">
    </asp:ScriptManager>
    <div style="width: 100%;">
    <!--Bottom Panel-->         
    <asp:Panel id="bottom_bar" runat="server" CssClass="bottom_bar">
	    <table border="0" cellpadding="0" id="bottom_table">
          <tr>
            <td>上海市嘉定区曹安公路4800号&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;邮政编码：201804</td>
            <td style="text-align:right;">CopyRight 2009 SSE,TJU</td>
          </tr>
          <tr>
            <td>电话：69589585 | 传真：69589332 | E-mail：<a href="mailto:sse@tongji.edu.cn">tjsseinfoa@tongji.edu.cn</a></td>
            <td style="text-align:right;">
                <asp:HyperLink ID="lnk_dev" runat="server" NavigateUrl="#">Developer Team</asp:HyperLink>
            </td>
          </tr>
        </table>
    </asp:Panel> 
    </div>
    </form>
</body>
</html>
