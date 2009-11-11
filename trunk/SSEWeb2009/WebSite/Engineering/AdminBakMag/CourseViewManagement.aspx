<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="CourseViewManagement.aspx.cs" Inherits="Engineering_AdminBakMag_CourseViewManagemen" %>

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
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />
    <script language="javascript" type="text/javascript">
            $(document).ready(function() {
                $( "DIV.ContainerPanel > DIV.collapsePanelHeader").toggle(
                function() {
                    $(this).next("div.Content").show("slow");
                    $(this).children(".ArrowExpand").attr("class", "ArrowClose");
                    $(this).children(".HeaderContent").html("该学生所属年级教学点的开课信息（隐藏开课信息......）");
                },
                function() {                   
                    $(this).next("div.Content").hide("slow");
                    $(this).children(".ArrowClose").attr("class", "ArrowExpand");
                    $(this).children(".HeaderContent").html("该学生所属年级教学点的开课信息（显示开课信息......）");
                });             
            });           
   </script>
    <script type ="text/javascript" language = "javascript">
    function OpenOvertimeDlog(ID,width,height) 
   {       
     var me; 
     // 把父页面窗口对象当作参数传递到对话框中，以便对话框操纵父页自动刷新。 
     me = "CourseChoosingDetails.aspx?id="+ID+""; 
     // 显示对话框。
     window.showModalDialog(me,null,'dialogWidth='+width +'px;dialogHeight='+height+'px;help:no;status:no') ;
   } 
   function startProgress()
   {
        document.getElementById("progress").style.display = "block";
   }
   function endProgress()
   {
        document.getElementById("progress").style.display = "none";
   }
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 25px">
        管理选课信息
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True" EnableScriptLocalization="True">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%"
                    CssClass="AjaxTabStrip" AutoPostBack="True" 
                    OnActiveTabChanged="TabContainer1_ActiveTabChanged">
                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="处理选课结果">
                        <ContentTemplate>
                            <asp:Label ID="lblMes" runat="server" ForeColor="#999999">当前没有选课结果需要你处理:-)</asp:Label>
                            <asp:GridView ID="gvCourseResult" runat="server" AutoGenerateColumns="False" Width="700px"
                                CellPadding="4" AllowPaging="True" ForeColor="#333333" GridLines="None" PageSize="20"
                                OnPageIndexChanging="gvCourseResult_PageIndexChanging">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:BoundField DataField="Grade" HeaderText="年级">
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点">
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="所属学期">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTerm" runat="server" Text='<%#GetCourseTime(Eval("Term").ToString()) %>'></asp:Label></ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="状态">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text="选课已经完成"></asp:Label></ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="完成时间" DataField="eTime" DataFormatString="{0:yyyy-MM-dd}">
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlOperation" runat="server" NavigateUrl='<%# "~/Engineering/AdminBakMag/DisposeCourseAgenda.aspx?id="+Eval("TeaMagID") %>'
                                                ForeColor="Red">处理选课结果</asp:HyperLink></ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="查看选课日程" ID="TabPanel2">
                        <ContentTemplate>
                            <asp:Label ID="lblAgendaMsg" runat="server" ForeColor="#999999"></asp:Label>
                            <div id="div_Agenda" runat="server">
                            <asp:GridView ID="gvCourseAgenda" runat="server" AutoGenerateColumns="False" 
                                CellPadding="3" ForeColor="#333333" GridLines="None" Width="700px" 
                                AllowPaging="True" PageSize="20" DataKeyNames="TeaMagID" 
                                onrowdatabound="gvCourseAgenda_RowDataBound" 
                                onrowediting="gvCourseAgenda_RowEditing" 
                                onselectedindexchanged="gvCourseAgenda_SelectedIndexChanged" 
                                onrowcancelingedit="gvCourseAgenda_RowCancelingEdit" 
                                onrowupdating="gvCourseAgenda_RowUpdating" 
                                onrowcommand="gvCourseAgenda_RowCommand">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:TemplateField HeaderText="年级">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGradeAgen" runat="server" Text='<%#Eval("Grade") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="教学点">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSchoolAgen" runat="server" Text='<%#Eval("TeaSchoolName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="选课开始时间">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStartTime" runat="server" Text='<%#Convert.ToDateTime(Eval("StartTime")).ToString("yyyy-MM-dd")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbStartTime" runat="server" Width="100px" Text='<%#Convert.ToDateTime(Eval("StartTime")).ToString("yyyy-MM-dd")%>'></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbStartTime" Format="yyyy-MM-dd">
                                            </cc1:CalendarExtender>
                                        </EditItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="选课结束时间">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEndTime" runat="server" Text='<%#Convert.ToDateTime(Eval("EndTime")).ToString("yyyy-MM-dd") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbEndTime" runat="server" Width="100px" Text='<%#Convert.ToDateTime(Eval("EndTime")).ToString("yyyy-MM-dd") %>'></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="tbEndTime" Format="yyyy-MM-dd">
                                            </cc1:CalendarExtender>
                                        </EditItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="状态">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%#GetStatus(Eval("StartTime"), Eval("EndTime")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:CommandField EditText="修改" HeaderText="修改时间" ShowEditButton="True">
                                        <ControlStyle ForeColor="Blue" />
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="变更操作">
                                        <ItemTemplate>
                                            <asp:Button ID="btNotChooseCourse" runat="server" Width="100px" Text="改成非网上选课" CommandName="cmdModify" CommandArgument='<%#Eval("TeaMagID") %>' />
                                        </ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" Width="110px" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                            <br />
                            <div>
                                //选课时间在选课开始后就不能修改<br />
                                //改成非网上选课是指将当前的网上选课课程改为非网上选课课程<br />
                                //改成非网上选课的操作在选课开始后将不能修改
                            </div>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="年级选课情况" ID="TabPanel3">
                        <ContentTemplate>
                            <div>
                                <table width="670">
                                    <tr>
                                        <td width="60" height="31" align="left" valign="middle">
                                            <span style="font-size: 15px">年级：</span>
                                        </td>
                                        <td width="120" align="left" valign="middle">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlGrade1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                                        DataTextField="Grade" DataValueField="Grade" OnSelectedIndexChanged="ddlGrade1_SelectedIndexChanged"
                                                        Width="120px">
                                                        <asp:ListItem>--请选择年级--</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetGrade"
                                                        TypeName="Department.Engineering.StudentManage"></asp:ObjectDataSource>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td width="80" align="left" valign="middle">
                                            <span style="font-size: 15px">教学点：</span>
                                        </td>
                                        <td width="120" align="left" valign="middle">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlSchool1" runat="server" DataSourceID="ObjectDataSource2"
                                                        DataTextField="TeaSchoolName" DataValueField="TeaSchoolID" Width="120px">
                                                        <asp:ListItem>--请选择教学点--</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetTeaSchool"
                                                        TypeName="Department.Engineering.TeachingSchool">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="ddlGrade1" Name="selValue" PropertyName="SelectedValue"
                                                                Type="String" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlGrade1" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td width="52" align="left" valign="middle">
                                            <span style="font-size: 15px">学期：</span>
                                        </td>
                                        <td width="120" align="left" valign="middle">
                                            <asp:DropDownList ID="ddlTerm1" runat="server" DataSourceID="ObjectDataSource3" DataTextField="Key"
                                                DataValueField="Value" Width="120px">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetTermsWithStartYear"
                                                TypeName="Department.Engineering.TermsManage" 
                                                OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                                        </td>
                                        <td width="118" align="center" valign="middle">
                                            <asp:Button ID="btQuery1" runat="server" Height="31px" Text="查询" Width="90px" OnClick="btQuery1_Click"
                                                BackColor="#3333FF" ForeColor="White" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            <div id="progress" style="display:none">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Engineering/Resources/images/progress32x32.gif"/>
                            </div>
                            <div>
                                <asp:GridView ID="gvGradeCourse" runat="server" Width="700px" AutoGenerateColumns="False"
                                    CellPadding="4" DataKeyNames="CourseID" OnRowDataBound="gvGradeCourse_RowDataBound"
                                    AllowPaging="True" ForeColor="#333333" GridLines="None" PageSize="25" OnSelectedIndexChanged="gvGradeCourse_SelectedIndexChanged">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="学期">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTerms" runat="server" Text='<%#GetCourseTime(Eval("CourseTime").ToString())%>'></asp:Label></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CourseName" HeaderText="课程名称">
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Grade" HeaderText="年级">
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点">
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="课程类别">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategorys" runat="server" Text='<%#sCategory[Convert.ToInt32(Eval("Category"))] %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="课程性质">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProperty" runat="server" Text='<%#sProperty[Convert.ToInt32(Eval("Property"))]%>'></asp:Label></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="选课人数">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCourseNum" runat="server">0</asp:Label></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="选课学生信息">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbStuInfo" runat="server">查看详情</asp:LinkButton></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="学生选课情况">
                        <ContentTemplate>
                            学号：<asp:TextBox ID="tbStudentID" runat="server" Width="130px" ValidationGroup="queryStuID"></asp:TextBox>
                            &nbsp;
                            <asp:Button ID="btQuery2" runat="server" Height="31px" Text="查询" Width="60px" OnClick="btQuery2_Click"
                                BackColor="#3333FF" ForeColor="White" ValidationGroup="queryStuID" 
                                oninit="btQuery2_Init" /><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请输入学号" ControlToValidate="tbStudentID"
                                Display="Dynamic" Font-Names="Verdana" Font-Size="10pt" ValidationGroup="queryStuID"></asp:RequiredFieldValidator><br />
                            <br />
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                            <div id="div_studCourse" runat="server" visible="False">
                                <asp:Label ID="lblNameAndID" runat="server"></asp:Label><asp:Label ID="lblGradeAndSchool"
                                    runat="server"></asp:Label><br />
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:GridView ID="gvStuCourse" runat="server" Width="700px"
                                        AutoGenerateColumns="False" CellPadding="4" PageSize="15" DataKeyNames="CourseID"
                                        OnRowDataBound="gvStuCourse_RowDataBound" ForeColor="#333333" GridLines="None"
                                        OnRowCommand="gvStuCourse_RowCommand">
                                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                        <Columns>
                                            <asp:BoundField DataField="CourseName" HeaderText="课程名称">
                                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="开课学期">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTerm" runat="server" Text='<%#GetCourseTime(Eval("CourseTime").ToString()) %>'></asp:Label></ItemTemplate>
                                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="课程类别">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#sCategory[Convert.ToInt32(Eval("Category"))] %>'></asp:Label></ItemTemplate>
                                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="课程性质">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProperty" runat="server" Text='<%#sProperty[Convert.ToInt32(Eval("Property"))]%>'></asp:Label></ItemTemplate>
                                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Credit" HeaderText="学分">
                                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CreditHour" HeaderText="学时">
                                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="操作">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbDelete" runat="server" ForeColor="Red" CommandArgument='<%#Eval("CourseID") %>'
                                                        CommandName="cmdDelete">退选</asp:LinkButton></ItemTemplate>
                                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                <br />
                                <asp:Panel ID="Panel1" runat="server" Width="700px" Font-Bold="True"
                                    onmouseover="this.style.cursor='hand'" onmouseout="this.style.cursor='normal'">
                                    <asp:Image ID="ImgExpand" runat="server" ImageUrl="~/Engineering/Resources/images/expand.jpg">
                                    </asp:Image>&#160;&#160;&#160;
                                    <asp:Label ID="Label3" runat="server" Text=" 该学生所属年级教学点的开课信息（显示开课信息......）" ForeColor="#0033CC"></asp:Label>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server">
                                    <br />
                                    开课学期：<asp:DropDownList ID="ddlTerm" runat="server" Width="120px" DataSourceID="ObjectDataSource4"
                                            DataTextField="Key" DataValueField="Value" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged" oninit="ddlTerm_Init">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetTerms"
                                            TypeName="Department.Engineering.TermsManage"></asp:ObjectDataSource>
                                        <br />
                                        <br />
                                        <asp:Label ID="lblCourseMsg" runat="server" ForeColor="Red">无开课信息</asp:Label>
                                        <asp:GridView ID="gvAllCourse" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            Width="700px" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" DataKeyNames="CourseID"
                                            OnRowCommand="gvAllCourse_RowCommand" OnRowDataBound="gvAllCourse_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="CourseName" HeaderText="课程名称">
                                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center">
                                                    </ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="课程类别">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsCategory" runat="server" Text='<%#sCategory[Convert.ToInt32(Eval("Category"))]%>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center">
                                                    </ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="课程性质">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsProperty" runat="server" Text='<%#sProperty[Convert.ToInt32(Eval("Property"))]%>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center">
                                                    </ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Credit" HeaderText="学分">
                                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center">
                                                    </ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CreditHour" HeaderText="学时">
                                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center">
                                                    </ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="选课">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btSelect" runat="server" Text="选定" CommandArgument='<%#Eval("CourseID") %>'
                                                            CommandName="cmdSelect" /></ItemTemplate>
                                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center">
                                                    </ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                </asp:Panel>
                                <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" CollapseControlID="Panel1"
                                    ExpandControlID="Panel1" TargetControlID="Panel2" ImageControlID="ImgExpand"
                                    TextLabelID="Label3" CollapsedImage="~/Engineering/Resources/images/expand.jpg"
                                    ExpandedImage="~/Engineering/Resources/images/collapse.jpg" ExpandedText="该学生所属年级教学点的开课信息（隐藏开课信息......）"
                                    CollapsedText="该学生所属年级教学点的开课信息（显示开课信息......）" Collapsed="True" 
                                    Enabled="True">
                                </cc1:CollapsiblePanelExtender>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
