<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CoursesManagement.aspx.cs" Inherits="Engineering_AdminBakMag_CoursesManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 管理课程信息--工程硕士中心</title>
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />
    <script src="../Resources/JavaScript/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Resources/JavaScript/jquery.cookie.js" type="text/javascript"></script>
       <script type="text/javascript">
       function SelectAll(tempControl)
       {
            var theBox=tempControl;
             xState=theBox.checked;    

            elem=theBox.form.elements;
            for(i=0;i<elem.length;i++)
            if(elem[i].type=="checkbox" && elem[i].id!=theBox.id)
             {
                  if(elem[i].checked!=xState)
                        elem[i].click();
            }
        }   
            function OpenOvertimeDlog(ID,width,height) 
           {       
             var me; 
             // 把父页面窗口对象当作参数传递到对话框中，以便对话框操纵父页自动刷新。 
             me = "EditCourseDetails.aspx?id="+ID+""; 
             // 显示对话框。
             window.showModalDialog(me,null,'dialogWidth='+width +'px;dialogHeight='+height+'px;help:no;status:no') ;
           } 
           function SetChoosingTime(object)
           {
                if(object.checked == true)
                {
                    document.getElementById("choosingTime").style.display = "block";
                }
                else
                {
                    document.getElementById("choosingTime").style.display = "none";
                }
           }
           function CollapseChoosingTime(object)
           {
                if(object.checked == true)
                {
                    document.getElementById("choosingTime").style.display = "none";
                }
           }
       </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 25px">
        管理课程信息
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"
            EnableScriptLocalization="True">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
        <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" CssClass="AjaxTabStrip"
            ActiveTabIndex="0" onprerender="TabContainer1_PreRender" AutoPostBack="True" 
                    onactivetabchanged="TabContainer1_ActiveTabChanged">
            <cc1:TabPanel runat="server" HeaderText="查看课程信息" ID="TabPanel1">
                <ContentTemplate>
                    <div>
                        <table width="670">
                            <tr>
                                <td align="left" height="31" valign="middle" width="60">
                                    <span style="font-size: 15px">年级：</span>
                                </td>
                                <td align="left" valign="middle" width="120">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlGrade2" runat="server" AutoPostBack="True" 
                                                DataSourceID="ObjectDataSource1" DataTextField="Grade" DataValueField="Grade" 
                                                OnSelectedIndexChanged="ddlGrade2_SelectedIndexChanged" Width="115px">
                                                <asp:ListItem>--请选择年级--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                                SelectMethod="GetGrade" TypeName="Department.Engineering.StudentManage">
                                            </asp:ObjectDataSource>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="left" valign="middle" width="80">
                                    <span style="font-size: 15px">教学点：</span>
                                </td>
                                <td align="left" valign="middle" width="120">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlSchool2" runat="server" 
                                                DataSourceID="ObjectDataSource2" DataTextField="TeaSchoolName" 
                                                DataValueField="TeaSchoolID" Width="115px">
                                                <asp:ListItem>--请选择教学点--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                                SelectMethod="GetTeaSchool" TypeName="Department.Engineering.TeachingSchool">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlGrade2" Name="selValue" 
                                                        PropertyName="SelectedValue" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlGrade2" 
                                                EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="left" valign="middle" width="52">
                                    <span style="font-size: 15px">学期：</span>
                                </td>
                                <td align="left" valign="middle" width="120">
                                    <asp:DropDownList ID="ddlCourseTerm" runat="server" 
                                        DataSourceID="ObjectDataSource5" DataTextField="Key" DataValueField="Value" 
                                        Width="115px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" 
                                        SelectMethod="GetTermsWithStartYear" 
                                        TypeName="Department.Engineering.TermsManage"></asp:ObjectDataSource>
                                </td>
                                <td align="center" valign="middle" width="118">
                                    <asp:Button ID="btQuery" runat="server" BackColor="#3333FF" ForeColor="White" 
                                        Height="31px" OnClick="btQuery_Click" Text="查询" Width="60px" 
                                        oninit="btQuery_Init" onprerender="btQuery_PreRender" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div>
                        <asp:Label ID="lbResult" runat="server" Font-Bold="False" ForeColor="Red" 
                            Visible="False"></asp:Label>
                        <asp:GridView ID="gvCourses" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CourseID" 
                            ForeColor="#333333" GridLines="None" 
                            OnPageIndexChanging="gvCourses_PageIndexChanging" 
                            OnRowDataBound="gvCourses_RowDataBound" OnRowDeleting="gvCourses_RowDeleting" 
                            OnRowEditing="gvCourses_RowEditing" PageSize="30" Width="700px" 
                            onrowcommand="gvCourses_RowCommand">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="开课学期">
                                    <ItemTemplate>
                                        <asp:Label ID="lbCourseTerm" runat="server" 
                                            Text='<%#GetCourseTime(Eval("CourseTime").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="课程名称">
                                    <ItemTemplate>
                                        <asp:Label ID="lbCourseName" runat="server" Text='<%#Eval("CourseName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Grade" HeaderText="年级">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="时间地点">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTextDetails" runat="server" ForeColor="Red" Text="未设置" 
                                            Visible="false"></asp:Label>
                                        <asp:LinkButton ID="lbViewDetails" runat="server" Visible="false"> 查看 
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="任课教师">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="编辑">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnbEdit" runat="server" 
                                            ImageUrl="~/Engineering/Resources/images/edit.gif" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="删除">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" runat="server" CommandName="cmdDelete"  CommandArgument='<%#Eval("CourseID") %>' ImageUrl="~/Engineering/Resources/images/icon-delete.gif" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btNewCourse" runat="server" Text="添加新课程" Height="31px" 
                            PostBackUrl="~/Engineering/AdminBakMag/AddNewCourse.aspx" />
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel runat="server" HeaderText="上传课程信息" ID="TabPanel2">
                <ContentTemplate>
                    <div>
                        请点击下载：<asp:LinkButton ID="lbCourseInfo" runat="server" 
                            OnClick="LinkButton1_Click" oninit="lbCourseInfo_Init">课程信息录入专用表</asp:LinkButton>
                    </div>
                    <br />
                    <table width="600" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" valign="middle" height="31" width="120">
                                年级
                            </td>
                            <td align="left" valign="middle" width="180">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlGrade1" runat="server" AutoPostBack="True" 
                                            DataSourceID="ObjectDataSource3" DataTextField="Grade" DataValueField="Grade" 
                                            OnSelectedIndexChanged="ddlGrade1_SelectedIndexChanged" Width="120px">
                                            <asp:ListItem>--请选择年级--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                            SelectMethod="GetGrade" TypeName="Department.Engineering.StudentManage">
                                        </asp:ObjectDataSource>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" valign="middle" width="120">
                                教学点 
                            </td>
                            <td align="left" valign="middle" width="180">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSchool1" runat="server" 
                                            DataSourceID="ObjectDataSource4" DataTextField="TeaSchoolName" 
                                            DataValueField="TeaSchoolID" Width="120px">
                                            <asp:ListItem>--请选择教学点--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" 
                                            SelectMethod="GetTeaSchool" TypeName="Department.Engineering.TeachingSchool">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlGrade1" Name="selValue" 
                                                    PropertyName="SelectedValue" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlGrade1" 
                                            EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="middle" height="31">
                                开课学期
                            </td>
                            <td align="left" valign="middle" colspan="3">
                                <asp:DropDownList ID="ddlTerm" runat="server" 
                                    DataSourceID="ObjectDataSource6" DataTextField="Key" DataValueField="Value" 
                                    OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged" Width="120px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" 
                                    SelectMethod="GetTerms" TypeName="Department.Engineering.TermsManage">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="middle" height="31">
                                课程信息表
                            </td>
                            <td align="left" valign="middle" colspan="3">
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="371px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div>
                        <asp:CheckBox ID="cbNonSelectTime" runat="server" Text="不需要进行网上选课" onclick="javascript:CollapseChoosingTime(this)" />
                        <cc1:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender1" 
                            runat="server" Enabled="True" Key="selectTime" 
                            TargetControlID="cbNonSelectTime">
                        </cc1:MutuallyExclusiveCheckBoxExtender>
                    </div>
                    <br />
                    <div>
                        <asp:CheckBox ID="cbSelectTime" runat="server" Text="要进行网上选课" onclick="javascript:SetChoosingTime(this)" />
                        (<span style="color: Red">*如果该年级该教学点需要进行网上选课，必须设置选课时间</span>)
                        <cc1:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender2" 
                            runat="server" Enabled="True" Key="selectTime" TargetControlID="cbSelectTime">
                        </cc1:MutuallyExclusiveCheckBoxExtender>
                    </div>
                    <br />
                    <div id="choosingTime" style="display: none">
                        选课起始时间： 
                        <asp:TextBox ID="tbStartTime" runat="server" Width="120px"></asp:TextBox>
                        <asp:ImageButton ID="lnbStartTime" runat="server" 
                            ImageUrl="~/Engineering/Resources/images/calendar.JPG" />
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                            Format="yyyy-MM-dd" PopupButtonID="lnbStartTime" TargetControlID="tbStartTime">
                        </cc1:CalendarExtender>
                        <br />
                        选课结束时间： 
                        <asp:TextBox ID="tbEndtTime" runat="server" Width="120px"></asp:TextBox>
                        <asp:ImageButton ID="lnbEndTime" runat="server" 
                            ImageUrl="~/Engineering/Resources/images/calendar.JPG" />
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                            Format="yyyy-MM-dd" PopupButtonID="lnbEndTime" TargetControlID="tbEndtTime">
                        </cc1:CalendarExtender>
                    </div>
                    <br />
                    <div>
                        &nbsp;<asp:Button ID="tbSubmit" runat="server" BackColor="#3333FF" 
                            ForeColor="White" Height="31px" OnClick="tbSubmit_Click" oninit="tbSubmit_Init" 
                            Text="确定" Width="90px" />
                    </div>
                    <br />
                    <div runat="server" id="div_courseInfo" visible="False">
                        <asp:Label ID="lblGrade" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
                        <br />
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#333333"></asp:Label>
                        <asp:GridView ID="gvCourseInfo" runat="server" AutoGenerateColumns="False" BorderColor="#666666"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="2" OnRowDataBound="gvCourseInfo_RowDataBound"
                            PageSize="15" Style="margin-bottom: 0px" Width="700px" OnRowDeleting="gvCourseInfo_RowDeleting"
                            OnRowEditing="gvCourseInfo_RowEditing" 
                            OnRowUpdating="gvCourseInfo_RowUpdating" 
                            onrowcancelingedit="gvCourseInfo_RowCancelingEdit">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="课程名称">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbCourseNamei" runat="server" Text='<%#Eval("courseName") %>' Width="80px"></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCourseNamev" runat="server" Text='<%#Eval("courseName") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="学分">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbCrediti" runat="server" Text='<%#Eval("credit") %>' Width="35px"></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreditv" runat="server" Text='<%#Eval("credit") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle Width="40px" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="学时">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbCreditHouri" runat="server" Text='<%#Eval("creditHour") %>' Width="35px"></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreditHourv" runat="server" Text='<%#Eval("creditHour") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle Width="40px" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="课程性质">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbPropertyi" runat="server" Text='<%#Eval("property") %>' Width="50px"></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPropertyv" runat="server" Text='<%#Eval("property") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="课程类别">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbCategoryi" runat="server" Text='<%#Eval("category")%>' Width="50px"></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategoryv" runat="server" Text='<%#Eval("category")%>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="考核方式">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbExamModei" runat="server" Text='<%#Eval("examMode") %>' Width="60px"></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExamModev" runat="server" Text='<%#Eval("examMode") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="教学方式">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbIntruModei" runat="server" Text='<%#Eval("instruMode") %>' Width="60px"></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntruModev" runat="server" Text='<%#Eval("instruMode") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="上课时间">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbClassPeriodi" runat="server" Text='<%#Eval("classPeriod") %>'
                                            Width="80px"></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblClassPeriodv" runat="server" Text='<%#Eval("classPeriod") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="上课地点">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbPlacei" runat="server" Text='<%#Eval("place") %>' Width="80px"></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlacev" runat="server" Text='<%#Eval("place") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:CommandField EditText="修改" ShowEditButton="True">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:CommandField ShowDeleteButton="True">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <div>
                            <asp:Button ID="btConfirm" runat="server" Text="确认并提交" Height="31px" OnClick="btConfirm_Click" />&#160;&#160;&#160;
                            <asp:Button ID="btCancel" runat="server" Height="31px" Text="取消并重新上传" OnClick="btCancel_Click" /></div>
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
                </cc1:TabContainer>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
