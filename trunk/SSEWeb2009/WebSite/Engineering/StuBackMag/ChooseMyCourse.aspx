<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChooseMyCourse.aspx.cs" Inherits="Engineering_StuBackMag_ChooseMyCourse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网上选课--工程硕士中心</title>
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
                    $(this).children(".HeaderContent").html("我要选修的课程(隐藏详细)");
                },
                function() {                   
                    $(this).next("div.Content").hide("slow");
                    $(this).children(".ArrowClose").attr("class", "ArrowExpand");
                    $(this).children(".HeaderContent").html("我要选修的课程(显示详细)");
                });             
            });           
   </script>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        网上选课
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
     <hr />
     <br />
     <div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="#999999"></asp:Label>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvCourseInfo" runat="server" AutoGenerateColumns="False" BorderColor="#666666"
                BorderStyle="Solid" BorderWidth="1px" CellPadding="3" Width="700px" OnRowDataBound="gvCourseInfo_RowDataBound"
                AllowPaging="True" PageSize="15" DataKeyNames="CourseID" OnRowCommand="gvCourseInfo_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CourseName" HeaderText="课程名称">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="课程性质">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemTemplate>
                            <%#sProperty[Convert.ToInt32(Eval("Property"))] %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="课程类别">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemTemplate>
                            <%#sCategory[Convert.ToInt32(Eval("Category"))] %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Credit" HeaderText="学分">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CreditHour" HeaderText="学时">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="任课教师">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StudentNumber" HeaderText="已选人数">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="选课">
                        <ItemTemplate>
                            <asp:Button ID="btSelect" runat="server" CommandArgument='<%#Eval("CourseID") %>'
                                CommandName="xuanding" Text="选定" />
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <div id="ContainerPanel" class="ContainerPanel">
        <div id="header" class="collapsePanelHeader">
            <div id="dvArrow" class="ArrowExpand"></div>
            <div id="dvHeaderText" class="HeaderContent">我要选修的课程(显示详细)</div>
        </div>
        <div id="dvContent" class="Content" style="display:none">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:GridView ID="gvMyCourse" runat="server" AutoGenerateColumns="False" BorderColor="#666666"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="CourseID"
                        OnRowDeleting="gvMyCourse_RowDeleting" OnSelectedIndexChanged="gvMyCourse_SelectedIndexChanged"
                        Width="700px" OnRowDataBound="gvMyCourse_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="CourseName" HeaderText="课程名称">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="课程性质">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%# sProperty[Convert.ToInt32(Eval("Property"))] %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="课程类别">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%#sCategory[Convert.ToInt32(Eval("Category"))] %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Credit" HeaderText="学分">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreditHour" HeaderText="学时">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="任课教师" NullDisplayText="null">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:CommandField DeleteText="退选" ShowDeleteButton="True">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" ForeColor="Red"
                                    HorizontalAlign="Center" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
