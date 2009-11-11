<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleManagement.aspx.cs" Inherits="Engineering_AdminBakMag_RoleManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色管理--工程硕士中心</title>
     <style type="text/css">
        .ContainerPanel
        {
            width: 700px;
            border: 1px;
            border-color: #1052a0;
        }
        .collapsePanelHeader
        {
            width: 700px;
            height: 30px;
            color: #FFF;
            font-weight: bold;
        }
        .collapsePanelHeader:hover
        {
        	cursor:hand;
        }
        .HeaderContent
        {
        	margin-top:5px;
        	padding-left:10px;
            color:Blue;
            font-weight:bold;
            float:left;
        }
        .Content
        {
        	margin-top:10px;
        }
        .ArrowExpand
        {
        	float:left;
        	margin-top:9px;
        	background-image: url(../Resources/images/expand.jpg);
            width: 13px;
            height: 13px;
        }
        .ArrowClose
        {
        	float:left;
        	margin-top:9px;
        	background-image: url(../Resources/images/collapse.jpg);
            width: 13px;
            height: 13px;
        }
    </style>
    <script src="../Resources/JavaScript/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Resources/JavaScript/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function(){
            $("DIV.ContainerPanel > DIV.collapsePanelHeader").toggle(
                function() {
                    $(this).next("div.Content").show("slow");
                    $(this).children(".ArrowExpand").attr("class", "ArrowClose");
                    $(this).children(".HeaderContent").html("我要移交超级管理员权限（隐藏详细信息......）");
                    $.cookie('status', 'collapsed');
                },
                function() {                   
                    $(this).next("div.Content").hide("slow");
                    $(this).children(".ArrowClose").attr("class", "ArrowExpand");
                    $(this).children(".HeaderContent").html("我要移交超级管理员权限（显示详细信息......）");
                    $.cookie('status', 'expand');
                });    
                var status =$.cookie('status'); 
                if(status == 'collapsed'){
                    $("div.collapsePanelHeader").next("div.Content").show();
                    $("div.collapsePanelHeader").children(".ArrowExpand").attr("class", "ArrowClose");
                    $("#div.collapsePanelHeader").children(".HeaderContent").html("JQuery Cookies");
                };
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px">
        角色管理
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False" 
            CellPadding="3" ShowHeader="False" Width="227px" GridLines="None" 
            onrowediting="gvRoles_RowEditing" onrowupdating="gvRoles_RowUpdating" 
            DataKeyNames="RoleId" onrowdatabound="gvRoles_RowDataBound" 
            onselectedindexchanged="gvRoles_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Left" Width="20px" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Engineering/Resources/images/edit.gif"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="RoleName">
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div id="ContainerPanel" class="ContainerPanel">
        <div id="header" class="collapsePanelHeader">
            <div id="dvArrow" class="ArrowExpand">
            </div>
            <div id="dvHeaderText" class="HeaderContent">
                我要移交超级管理员权限（显示详细信息......）</div>
        </div>
        <div id="dvContent" class="Content" style="display: none">
            新超级管理员账号：<asp:TextBox ID="tbNewAdmin" runat="server"></asp:TextBox><br />
            <br />
            <asp:Button ID="btConfirm" runat="server" Text="移交权限" OnClick="btConfirm_Click" />
            <br />
            <br />
            <asp:Label ID="lblRes" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            <br />
            <br />
            *当你离开该部门时，请将超级管理权限移交给下一任的超级管理员<br />
            *该过程不可逆，执行该操作时，请慎重
        </div>
    </div>
    </form>
</body>
</html>
