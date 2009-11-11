<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditMMT.ascx.cs" Inherits="UserControl_EditMMT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/UserControl/Calendar.ascx" TagPrefix="ucl" TagName="Calendar" %>
<%@ Register Src="~/UserControl/TagListControl.ascx" TagPrefix="ucl" TagName="TagList" %>

<div style="width: 100%; border: none;">
    <table width="100%" cellpadding="0px" cellspacing="0px"><tr>
        <td style="width: 50px; vertical-align: middle;">标题：</td>
        <td style="vertical-align: middle;">
            <asp:TextBox ID="title_txt" runat="server" Width="90%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requidTitle" runat="server" 
                ErrorMessage="*" ControlToValidate="title_txt">
            </asp:RequiredFieldValidator>
        </td>
    </tr></table>
</div>

<asp:Panel ID="label_pnl" runat="server" Width="100%">
    <ucl:TagList ID="tag_lst" runat="server" Width="100%" />
</asp:Panel>

<div id="Time_Location_Div" runat="server" style="width: 100%;">
    <table width="100%">
        <tr>
            <td style="width: 10%;" align="right" valign="middle">开始时间</td>
            <td style="width: 30%;"><ucl:Calendar ID="startTime" runat="server" /></td>
            <td style="width: 10%;" align="right" valign="middle">结束时间</td>
            <td style="width: 30%;"><ucl:Calendar ID="endTime" runat="server" /></td>
            <td style="width: 5%;" align="right" valign="middle">地点</td>
            <td style="width: 15%;"><asp:TextBox ID="location_txt" runat="server"></asp:TextBox></td>
        </tr>
    </table>
</div>

<%
if (this.AllowAttachment){
%>
<iframe id="ifrm_upload" width="100%" scrolling="no" frameborder='0'
    src='<% Response.Write(ConstValue.PureURL + "UserControl/tool_uploadattachment.aspx"); %>'
    onload="javascript:this.height=0;"></iframe>
<script type="text/javascript">
    function reinitIframe(){
        var iframe = document.getElementById("ifrm_upload");
        try{
            var bHeight = iframe.contentWindow.document.body.scrollHeight;
            var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
            var height = Math.max(bHeight, dHeight);
            iframe.height = height;
        } catch (ex) { }
    }
    window.setInterval("reinitIframe()", 200);
</script>
<% } %>

<div id="error_layer" runat="server" style="width: 100%; height: 15px; vertical-align: text-top; text-align: center;">
    <asp:Label ID="lb_error" runat="server" Text="" Font-Bold="True" Font-Size="0.8em" ForeColor="Red"></asp:Label>
</div>

<FCKeditorV2:FCKeditor id="default_editor" runat ="server" basePath="~/fckeditor/"
    DefaultLanguage="zh" Width="100%" ToolbarStartExpanded="true" >
</FCKeditorV2:FCKeditor>

<div id="div_registration" runat="server" style="width: 100%;">
    <iframe id="ifrm_reg" width="100%" scrolling="no" frameborder='0' runat="server"></iframe>
    <script type="text/javascript">
        function reinitReg(){
            var iframe = document.getElementById("<%=ifrm_reg.ClientID%>");
            try{
                var bHeight = iframe.contentWindow.document.body.scrollHeight;
                var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                var height = Math.max(bHeight, dHeight);
                iframe.height = height;
            } catch (ex) { }
        }
        window.setInterval("reinitReg()", 200);
    </script>
</div>

<div id="div_post_btn" style="text-align: center;" runat="server">
    <asp:Button ID="post_btn" runat="server" Text="发布" onclick="post_btn_Click" />
</div>

<div id="div_update_btn" style="text-align: center;" runat="server">
    <asp:Button ID="update_btn" runat="server" Text="更新" 
        onclick="update_btn_Click" />
</div>

<asp:Label ID="ReportFormID" runat="server" Visible="false" ></asp:Label>
<asp:Label ID="ReportDataID" runat="server" Visible="false" ></asp:Label>