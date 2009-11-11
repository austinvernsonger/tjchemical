<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Initialize.aspx.cs" Inherits="实验预约_Initialize" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:Label ID="lblcurterm" runat="server" Text="当前学年学期:" AssociatedControlID="tbcurterm"></asp:Label>
       <asp:TextBox ID="tbcurterm" runat="server" onclick="this.value=''"></asp:TextBox>
       <asp:CustomValidator ID="cvcurterm" runat="server" ControlToValidate="tbcurterm" Text="(Invalid)" ValidateEmptyText="true" OnServerValidate="val_ServerValidate">
       </asp:CustomValidator>
       <br /><br />
       
       <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>
       <cc1:CalendarExtender ID="cld1" runat="server" TargetControlID="tbBeginDay" Format="yyyy-MM-dd">
        </cc1:CalendarExtender>
       <asp:Label ID="ldlcurweek" runat="server" Text="开学日期:" AssociatedControlID="tbBeginDay"></asp:Label>
       <asp:TextBox ID="tbBeginDay" runat="server"></asp:TextBox>
       
       <asp:CustomValidator ID="cvcurweek" runat="server" ControlToValidate="tbBeginDay" Text="(Invalid)" ValidateEmptyText="true" OnServerValidate="val_ServerValidate2">
       </asp:CustomValidator>
       今天是第<asp:Label ID="lblCurWeek" runat="server" Text="?"></asp:Label>周
       <br /><br />
       <asp:Label ID="lbldevicecount" runat="server" Text="初始实验设备数量:" AssociatedControlID="tbdevicecount"></asp:Label>
       <asp:TextBox ID="tbdevicecount" runat="server" onclick="this.value=''"></asp:TextBox>台
       <asp:CustomValidator ID="cvdevicecount" runat="server" ControlToValidate="tbdevicecount" Text="(Invalid)" ValidateEmptyText="true" OnServerValidate="val_ServerValidate">
       </asp:CustomValidator>
       <br /><br />
       <asp:Label ID="lbltime1" runat="server" Text="实验开始前多长时间停止预约:" AssociatedControlID="tbtime1"></asp:Label>
       <asp:TextBox ID="tbtime1" runat="server" onclick="this.value=''"></asp:TextBox>分钟
       <asp:CustomValidator ID="cvtime1" runat="server" ControlToValidate="tbtime1" Text="(Invalid)" ValidateEmptyText="true" OnServerValidate="val_ServerValidate">
       </asp:CustomValidator>
       <br /><br />
       <asp:Label ID="lbltime2" runat="server" Text="已预约的学生在实验开始多长时间以后登记,算作不良记录:" AssociatedControlID="tbtime2"></asp:Label>
       <asp:TextBox ID="tbtime2" runat="server" onclick="this.value=''"></asp:TextBox>分钟
       <asp:CustomValidator ID="cvtime2" runat="server" ControlToValidate="tbtime2" Text="(Invalid)" ValidateEmptyText="true" OnServerValidate="val_ServerValidate">
       </asp:CustomValidator>
       <br /><br />
       <asp:Label ID="lbltime3" runat="server" Text="实验结束多长时间以后未登出,算作不良记录:" AssociatedControlID="tbtime3"></asp:Label>
       <asp:TextBox ID="tbtime3" runat="server" onclick="this.value=''"></asp:TextBox>分钟
       <asp:CustomValidator ID="cvtime3" runat="server" ControlToValidate="tbtime3" Text="(Invalid)" ValidateEmptyText="true" OnServerValidate="val_ServerValidate">
       </asp:CustomValidator>
       <br /><br />
       <asp:Label ID="lbltime4" runat="server" Text="未预约的学生在本实验时间段开始多久以后,如果要在本时间段继续做实验,需要考虑下一时间段的预约情况:" AssociatedControlID="tbtime4"></asp:Label>
       <asp:TextBox ID="tbtime4" runat="server" onclick="this.value=''"></asp:TextBox>分钟
       <asp:CustomValidator ID="cvtime4" runat="server" ControlToValidate="tbtime4" Text="(Invalid)" ValidateEmptyText="true" OnServerValidate="val_ServerValidate">
       </asp:CustomValidator>
       <br /><br />
       <asp:Label ID="lblstate" runat="server" Text="当前预约开启或关闭的状态(勾中表示开启):" AssociatedControlID="chkstate"></asp:Label>
       <asp:CheckBox ID="chkstate" runat="server" />
       <br /><br />
       <asp:Label ID="lblIPCheckRegex" runat="server" Text="IP绑定正则表达式"></asp:Label>
       <asp:TextBox ID="tbIPCheckRegex" runat="server"></asp:TextBox>
       <br /><br />
       <asp:Button ID="btnsave" runat="server" Text="保存修改" OnClick="btnsave_Click" />
       &nbsp;&nbsp;
       <asp:Button ID="btnrefreshBadRecord" runat="server" Text="整体刷不良记录" 
            onclick="btnrefreshBadRecord_Click" />
       <br />
       <asp:Label ID="lblsave" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
