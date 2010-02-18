<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tool_uploadattachment.aspx.cs" Inherits="UserControl_tool_uploadattachment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{ margin: 0px; font-size: 11px; font-family: Arial; }
        .ChkBox { font-size:11px; color: #222222; }
    </style>
</head>
<body>
    <form id="frm_upload" runat="server">
    <asp:ScriptManager ID="srcpmgr" runat="server">
    </asp:ScriptManager>
    <div>
    <% if ( Session ["IdentifyNumber"] == null )
       { %>
        <asp:Label ID="lb_chkuser" runat="server" Text="Please Login..." 
            Font-Size="11px" ForeColor="Red" Visible="False">
        </asp:Label>
        <%}
       else
       { %>
        <asp:Panel ID="upload_pnl" runat="server" Width="100%" Style="margin: 0">
            <asp:Panel ID="result_pnl" runat="server" Width="100%"></asp:Panel>
            <div style="width: 100%; vertical-align: middle;">
                <asp:Label ID="title_lb" runat="server" Text="上传附件"
                    ForeColor="#333333"></asp:Label>
                <asp:FileUpload ID="attachment_upload" runat="server" BorderColor="#333333" 
                    BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" />
                <asp:Button ID="upload_btn" runat="server" Text="上传" 
                    onclick="upload_btn_Click" BorderColor="#333333" BorderStyle="Solid" 
                    BorderWidth="1px" ForeColor="#333333" />
                <asp:Label ID="msg_lb" runat="server"
                    ForeColor="Red" ></asp:Label><br />
            </div>
        </asp:Panel>
        <%} %>
    </div>
    </form>
</body>
</html>
