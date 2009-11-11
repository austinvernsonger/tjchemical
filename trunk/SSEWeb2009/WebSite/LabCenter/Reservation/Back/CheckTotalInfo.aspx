<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckTotalInfo.aspx.cs" Inherits="LabCenter_Reservation_Back_CheckTotalInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">

        <div style="width:800px">
            <asp:Label ID="lblterm" runat="server" Text="选择学期:" AssociatedControlID="ddlterm"></asp:Label>
            <asp:DropDownList ID="ddlterm" runat="server" 
                onselectedindexchanged="ddlterm_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqterm" runat="server" ControlToValidate="ddlterm" Text="(Required)">
            </asp:RequiredFieldValidator>
            <br />
            
        </div>
        
        <hr />
        <div>
            
            <asp:Label ID="lbltotalinfo" Text="实验统计信息" runat="server"></asp:Label>
            <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
            <%--=DateTime.Now.ToString("T") --%>
            <br/>
            时间单位均为：(小时)
            <asp:UpdatePanel ID="up1" runat="server" >
                <ContentTemplate>
                    <asp:GridView ID="GV" AllowPaging="true" runat="server" style="width:100%;" >
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="btnexport" runat="server" Text="导出" onclick="btnexport_Click" />
        </div>

    </form>
</body>
</html>
