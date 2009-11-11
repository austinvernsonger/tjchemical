<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChooseMyTutor.aspx.cs" Inherits="Engineering_ChooseMyTutor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择我的导师--工程硕士中心</title>
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
            $("#resume").hide();
            $("#cbBox").click(function(){
                var checked = this.checked;
                $("#resume").css("display",checked?"block":"none");
            });
            $("DIV.ContainerPanel > DIV.collapsePanelHeader").toggle(
                function() {
                    $(this).next("div.Content").show("slow");
                    $(this).children(".ArrowExpand").attr("class", "ArrowClose");
                    $(this).children(".HeaderContent").html("导师选择详细（隐藏详细信息......）");
                    $.cookie('status', 'collapsed');
                },
                function() {                   
                    $(this).next("div.Content").hide("slow");
                    $(this).children(".ArrowClose").attr("class", "ArrowExpand");
                    $(this).children(".HeaderContent").html("导师选择详细（显示详细信息......）");
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
    <div style="font-size: 25px">                                  
        网上选导师 
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>         
    </div>
    <hr />
    <br />
    <div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
        <br />
        <br />
        <div id="ContainerPanel" class="ContainerPanel">
            <div id="header" class="collapsePanelHeader">
                <div id="dvArrow" class="ArrowExpand">
                </div>
                <div id="dvHeaderText" class="HeaderContent">
                    导师选择详细（显示详细信息......）</div>
            </div>
            <div id="dvContent" class="Content" style="display: none">
                <asp:GridView ID="gvStuTeacherNum" runat="server" AutoGenerateColumns="False" BorderColor="#666666"
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" DataKeyNames="UserID" OnRowDataBound="gvStuTeacherNum_RowDataBound"
                    Width="600px">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="导师">
                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="第一志愿人数">
                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="第二志愿人数">
                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="第三志愿人数">
                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="总人数">
                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>          
         <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <table style="height: 104px; width: 600px">
                <tr>
                    <td width="120" height="31" align="left" valign="middle">
                        我的第一志愿
                    </td>
                    <td align="left" valign="middle">
                        <asp:DropDownList ID="ddlFirst" runat="server" Width="130px" >
                        </asp:DropDownList>
                        <asp:Label ID="lblFirst" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="31" align="left" valign="middle">
                        我的第二志愿
                    </td>
                    <td align="left" valign="middle">
                        <asp:DropDownList ID="ddlSecond" runat="server" Width="130px">
                        </asp:DropDownList>
                        <asp:Label ID="lblSecond" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label>
                    </td>                  
                </tr>
                <tr>
                    <td height="31" align="left" valign="middle">
                        我的第三志愿
                    </td>
                    <td align="left" valign="middle">
                        <asp:DropDownList ID="ddlThird" runat="server" Width="130px">
                        </asp:DropDownList>
                        <asp:Label ID="lblThird" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
            </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <p>
            <asp:Button ID="btOk" runat="server" Text="提交" Height="31px" Width="90px" 
                onclick="btOk_Click" BackColor="#3333FF" ForeColor="White" />
            <asp:Button ID="btModify" runat="server" Height="31px" Text="修改志愿" 
                Width="90px" onclick="btModify_Click" BackColor="#3333FF" 
                ForeColor="White" />
        </p>
        <div>
            <asp:Label ID="lblResult" runat="server" Visible="False" ForeColor="Red"></asp:Label>
        </div>
        <br />
        <br />
        <div>
            *三个志愿都必须选<br />
            *任何两个志愿不可以选择同一个导师<br />
            *建议上传个人简历(不是必须)
        </div>
    </div>
    </form>
</body>
</html>
