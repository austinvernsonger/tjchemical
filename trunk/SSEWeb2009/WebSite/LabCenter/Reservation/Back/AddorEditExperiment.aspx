<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddorEditExperiment.aspx.cs" Inherits="LabCenter_Reservation_Back_AddorEditExperiment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <style type="text/css">
        html
        {
            background-color:silver;
        }
        .tabs
        {
            position:relative;
            top:1px;
            left:10px;
        }
        .tab 
        {
            border:solid 1px black;
            background-color:#eeeeee;
            padding:2px 10px;
        }
        .selectedTab
        {
            background-color:white;
            border-bottom:solid 1px white;
        }
        .tabContents
        {
            border:solid 1px black;
            padding:10px;
            background-color:white;
        }
    </style>
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Menu
        id="Menu1"
        Orientation="Horizontal"
        StaticMenuItemStyle-CssClass="tab"
        StaticSelectedStyle-CssClass="selectedTab"
        CssClass="tabs"
        OnMenuItemClick="Menu1_MenuItemClick"
        Runat="server">
        <Items>
        <asp:MenuItem Text="添加实验基本信息" Value="0" Selected="true" />
        <asp:MenuItem Text="修改实验基本信息" Value="1" />
        </Items>    
    </asp:Menu>
    
    <div class="tabContents">
    <asp:MultiView
        id="MultiView1"
        ActiveViewIndex="0"
        Runat="server">
        <asp:View ID="View1" runat="server">
            <asp:label id="labnamelbl" runat="server" Text="实验名称" AssociatedControlID="labname"></asp:label>
            <br />
            <asp:TextBox ID="labname" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqLabname" ControlToValidate="labname" Text="(Required)" runat="server">
            </asp:RequiredFieldValidator>
            <br /><br />
            <asp:Button ID="Btnadd" runat="server" Text="添加" OnClick="Btnadd_Click"/>
            <asp:Label ID="lblresult1" runat="server"></asp:Label>
        </asp:View>        
        <asp:View ID="View2" runat="server">
        <asp:Label ID="lblselectexperiment" Text="选择实验" AssociatedControlID="ddlExperiment" runat="server"></asp:Label>
            <asp:DropDownList ID="ddlExperiment" AutoPostBack="true" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlExperiment_SelectedIndexChanged">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqexperiment" runat="server" Text="(Required)" ControlToValidate="ddlExperiment" ValidationGroup="selectexperiment">
            </asp:RequiredFieldValidator>
            <hr />
            <asp:Label ID="lblname" runat="server" AssociatedControlID="txtname" 
                Text="实验名称"></asp:Label>
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lalisvalid" runat="server" AssociatedControlID="chkisvalid" 
                Text="是否有效"></asp:Label>
            <asp:CheckBox ID="chkisvalid" runat="server" />
            <br />
            <br />
            <asp:Button ID="btnsavechange" runat="server" Text="保存修改" 
                OnClick="btnsavechange_Click" Enabled="False"/>
            
            <asp:Label ID="lblresult2" runat="server"></asp:Label>
        </asp:View>      
    </asp:MultiView>
    </div>
    </div>    
    </form>
</body>
</html>
