<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetAdmin.aspx.cs" Inherits="SysMgr_SetAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设定管理员</title>
    <style type="text/css">
         .spanstyle
         {
         	font-family: 宋体, Arial, Helvetica, sans-serif; 
         	font-size: small;
         	color: #333333
         }
    </style>
</head>
<body>
    <form id="formMain" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="updatePanel" runat="server">
            <ContentTemplate>
                <div style="float: left">
                     &nbsp;&nbsp;<span class="spanstyle">部门列表</span>
                    <br />
                <asp:ListBox ID="lbDepartment" runat="server" Font-Size="Small" 
                    ForeColor="#333333" Height="111px"></asp:ListBox>
                </div>
                <div style="float: left; margin-left: 10px;">
                     &nbsp;&nbsp;<span class="spanstyle">教师列表</span>
                     <br />
                    <asp:ListBox ID="lbTeacher" runat="server" Height="111px"></asp:ListBox>
                </div>
                <div style="clear:both"></div>
                <br/>
                <asp:Button ID="btnSave" runat="server" Text="保存" BorderColor="Silver" 
                    BorderStyle="Solid" BorderWidth="1px" onclick="btnSave_Click" Width="54px" />  
                    &nbsp;&nbsp;
                <asp:Label ID="lbNotice" runat="server" Text="Label" Font-Size="Small" 
                    ForeColor="Red" Visible="False"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
