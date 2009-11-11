<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignPaperDetails.aspx.cs" Inherits="Engineering_AdminBakMag_AssignPaperDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
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
                    $(this).children(".HeaderContent").html("上传匿名论文（隐藏详细信息......）");
                    $.cookie('status', 'collapsed');
                },
                function() {                   
                    $(this).next("div.Content").hide("slow");
                    $(this).children(".ArrowClose").attr("class", "ArrowExpand");
                    $(this).children(".HeaderContent").html("上传匿名论文（显示详细信息......）");
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
    <div>     
        <table width="700">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style=" font-size:25px">预审论文分配详细信息</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                        PostBackUrl="~/Engineering/AdminBakMag/AssignPaperForStus.aspx">&lt;&lt;返回上一页</asp:LinkButton>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div> 
        <asp:DetailsView ID="dvPrejudication" runat="server" AutoGenerateRows="False" 
            CellPadding="5" Height="50px" Width="700px" BackColor="White" 
            BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <Fields>
                <asp:BoundField HeaderText="姓名" DataField="sName" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="学号" DataField="StudentID" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle Width="500px" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <%# Convert.ToInt32(Eval("Gender")) == 0?"男":"女" %>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="年级" DataField="Grade" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="教学点" DataField="TeaSchoolName" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="指导老师" DataField="tName" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="论文题目">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("AttachName") %>'></asp:Label>
                        <asp:LinkButton ID="lbSpeach" runat="server" ForeColor="Red" 
                            onclick="lbSpeach_Click">下载</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
            </Fields>
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <EditRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        </asp:DetailsView>  
    </div>
    <br />
    <div style="font-weight:bold">
        预审分配
    </div>
    <br />
    <div>
        <table width="700">
            <tr>
                <td align="left" height="31" valign="middle" width="150">
                    盲审代码：</td>
                <td align="left" valign="middle" width="550">
                    <asp:TextBox ID="tbNum" runat="server" Width="145px" ReadOnly="True"></asp:TextBox>
                    <asp:Button ID="btGenerateCode" runat="server" Text="生成盲审代码" 
                        onclick="btGenerateCode_Click" />
                </td>
            </tr>
            <tr>
                <td align="left" height="31" valign="middle">
                    预审组长：</td>
                <td align="left" valign="middle">
                    <asp:DropDownList ID="ddlLeader" runat="server" Width="150px" 
                        DataSourceID="ObjectDataSource1" DataTextField="UserName" 
                        DataValueField="UserID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" height="31" valign="middle">
                    预审组员一：</td>
                <td align="left" valign="middle">
                    <asp:DropDownList ID="ddlMember1" runat="server" Width="150px" 
                        DataSourceID="ObjectDataSource1" DataTextField="UserName" 
                        DataValueField="UserID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" height="31" valign="middle">
                    预审组员二：</td>
                <td align="left" valign="middle">
                    <asp:DropDownList ID="ddlMember2" runat="server" Width="150px" 
                        DataSourceID="ObjectDataSource1" DataTextField="UserName" 
                        DataValueField="UserID">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>  
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetAllTutorInfoList" 
            TypeName="Department.Engineering.TeacherManage" 
            OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
    </div>
    <br />
    <div>
        <asp:Button ID="btSubmit" runat="server" Text="完成分配" Height="31px" Width="90px" 
            onclick="btSubmit_Click" BackColor="#3333FF" ForeColor="White" />
    &nbsp;&nbsp;
        <asp:Button ID="btBack" runat="server" BackColor="#3333FF" ForeColor="White" 
            Height="31px" PostBackUrl="~/Engineering/AdminBakMag/AssignPaperForStus.aspx" 
            Text="返回" Width="90px" />
    </div>
    <br />
    <div id="ContainerPanel" class="ContainerPanel">
        <div id="header" class="collapsePanelHeader">
            <div id="dvArrow" class="ArrowExpand">
            </div>
            <div id="dvHeaderText" class="HeaderContent">
                上传匿名论文（显示详细信息......）</div>
        </div>
        <div id="dvContent" class="Content" style="display: none">
            论文文档：<asp:FileUpload ID="FileUpload1" runat="server" Width="200px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="上传" OnClick="Button3_Click" Style="height: 26px" /><br />
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
