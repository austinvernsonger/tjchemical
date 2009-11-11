<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TutorChooseingDetails.aspx.cs" Inherits="Engineering_AdminBakMag_TutorChooseingDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理导师分配信息--工程硕士中心</title>
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
    <script language="javascript" type="text/javascript">
            $(document).ready(function() {
                $("DIV.ContainerPanel > DIV.collapsePanelHeader").toggle(
                function() {
                    $(this).next("div.Content").show("slow");
                    $(this).children(".ArrowExpand").attr("class", "ArrowClose");
                    $(this).children(".HeaderContent").html("所有导师在本教学点暂选学生情况(隐藏详细)");
                },
                function() {                   
                    $(this).next("div.Content").hide("slow");
                    $(this).children(".ArrowClose").attr("class", "ArrowExpand");
                    $(this).children(".HeaderContent").html("所有导师在本教学点暂选学生情况(显示详细)");
                });             
            });           
   </script>
    <script type ="text/javascript" language = "javascript">
    function OpenOvertimeDlog(ID,width,height) 
   {       
     var me; 
     // 把父页面窗口对象当作参数传递到对话框中，以便对话框操纵父页自动刷新。 
     me = "StuChoosingChangeDetails.aspx?id="+ID+""; 
     // 显示对话框。
     window.showModalDialog(me,null,'dialogWidth='+width +'px;dialogHeight='+height+'px;help:no;status:no') 
   } 
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style=" font-size:25px">导师双向选择详细信息(查看详细)</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:LinkButton ID="lbBack" runat="server" 
                    PostBackUrl="~/Engineering/AdminBakMag/TutorResultManagement.aspx">&lt;&lt;返回上一页</asp:LinkButton>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
    <table width="700" border="1" cellpadding="0" cellspacing="0">
        <tr>
            <td width="350" height="31" align="center" valign="middle">
                <asp:Label ID="lblGrade" runat="server"></asp:Label>
            </td>
            <td width="350" align="center" valign="middle">
                <asp:Label ID="lblSchool" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    <br />
    <div id="ContainerPanel" class="ContainerPanel">
        <div id="header" class="collapsePanelHeader">
            <div id="dvArrow" class="ArrowExpand"></div>
            <div id="dvHeaderText" class="HeaderContent">所有导师在本教学点暂选学生情况(显示详细)</div>
        </div>
        <div id="dvContent" class="Content" style="display: none">
            <asp:GridView ID="gvTutorsTempStdNum" runat="server" AutoGenerateColumns="False"
                OnRowDataBound="gvTutorsTempStdNum_RowDataBound" DataKeyNames="TeacherID" Width="700px"
                BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" BackColor="White" CellPadding="3"
                CellSpacing="1" GridLines="None">
                <Columns>
                    <asp:BoundField HeaderText="导师" DataField="Name" />
                    <asp:BoundField HeaderText="职称" DataField="Post" />
                    <asp:BoundField HeaderText="研究方向" DataField="ResearchAspect" />
                    <asp:TemplateField HeaderText="暂选学生数"></asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#4A3C8C"
                    Font-Bold="True" ForeColor="#E7E7FF" />
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <RowStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#DEDFDE"
                    ForeColor="Black" />
                <AlternatingRowStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
        </div>
    </div>
    <br />
    <div>
        <asp:Label ID="Label2" runat="server" Text="本教学点学生暂选导师情况："></asp:Label> 
        <asp:GridView ID="gvTutorChoosing" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Width="700px" OnRowDataBound="gvTutorChoosing_RowDataBound" DataKeyNames="StudentID"
            BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px">
            <Columns>
                <asp:TemplateField HeaderText="学号">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px">
                    </ItemStyle>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbStuNo" runat="server" Text='<%#Eval("StudentID") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学生姓名">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("sName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblChooseTutor" runat="server" Text=">>分配给&gt;&gt;"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="分配给（导师）">
                    <ItemTemplate>
                       
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px">
                    </ItemStyle>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
    <br />
    <div>
        <asp:Button ID="btSave" runat="server" Text="确认并保存最终结果" Height="31px" 
            Width="125px" onclick="btSave_Click" BackColor="#3333FF" 
            ForeColor="White" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btBack" runat="server" Height="31px" Text="返回" Width="90px" 
            PostBackUrl="~/Engineering/AdminBakMag/TutorResultManagement.aspx" 
            BackColor="#3333FF" ForeColor="White" />
    </div>
    <br />
    <div>
        <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <br />
    <br />
    <div>
        *当点击确认后，导师分配结果将向学生和导师公布<br />
        *点击学号，为学生分配导师
    </div>
    </form>
</body>
</html>
