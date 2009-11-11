<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeachingEvaluationManagement.aspx.cs" Inherits="Engineering_AdminBakMag_TeachingEvaluationManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<%@ Register src="../Control/Terms.ascx" tagname="Terms" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理教学评测信息--工程硕士中心</title>
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />
    <script type ="text/javascript" language = "javascript">
    function OpenOvertimeDlog(ID,width,height) 
   {       
     var me; 
     // 把父页面窗口对象当作参数传递到对话框中，以便对话框操纵父页自动刷新。 
     me = "ViewTeachingEvaluationRes.aspx?id="+ID+""; 
     // 显示对话框。
     window.showModalDialog(me,null,'dialogWidth='+width +'px;dialogHeight='+height+'px;help:no;status:no') 
   } 
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        管理教学评测信息
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True" EnableScriptLocalization="True">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
            Width="100%" CssClass="AjaxTabStrip" Visible="true">
            <cc1:TabPanel runat="server" HeaderText="查询测评结果" ID="TabPanel1">
                <HeaderTemplate>
                    查询测评结果
                
                
            
                
                
            
            </HeaderTemplate>
                

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
                                                TypeName="Department.Engineering.StudentManage">
                                            </asp:ObjectDataSource>
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
                                            <asp:AsyncPostBackTrigger ControlID="ddlGrade1" 
                                        EventName="SelectedIndexChanged" >
                                    
                                            </asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>


                                </td>
                                <td width="52" align="left" valign="middle">
                                    <span style="font-size: 15px">学期：</span>

                                </td>
                                <td width="120" align="left" valign="middle">
                                    <asp:DropDownList ID="ddlTerm" runat="server" DataSourceID="ObjectDataSource3" DataTextField="key"
                                        DataValueField="value" Width="120px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                        SelectMethod="GetTermsWithStartYear" 
                                        TypeName="Department.Engineering.TermsManage"></asp:ObjectDataSource>
                                </td>
                                <td width="118" align="center" valign="middle">
                                    <asp:Button ID="btQuery" runat="server" Height="31px" Text="查询" Width="90px" OnClick="btQuery_Click"
                                        BackColor="#3333FF" ForeColor="White" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                        <asp:GridView ID="gvEvaluaionRes" runat="server" Width="700px" AutoGenerateColumns="False"
                            CellPadding="4" DataKeyNames="CourseID" OnRowDataBound="gvEvaluaionRes_RowDataBound"
                            AllowPaging="True" ForeColor="#333333" GridLines="None" PageSize="20" 
                            BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="CourseName" HeaderText="课程名称">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="开课学期">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTerm" runat="server" Text='<%#GetCourseTime(Eval("CourseTime").ToString())%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="任课教师">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Grade" HeaderText="年级">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="评测时间">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEvaluationTime" runat="server" ForeColor="Red" Text='<%#GetEvaluationTime(Convert.ToDateTime(Eval("StartTime")), Convert.ToDateTime(Eval("EndTime"))) %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="测评结果">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbResult" runat="server">查看</asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        
                                </asp:GridView>
                        
                        
                        </ContentTemplate>
</asp:UpdatePanel>


                    </div>
                
                
            
                
                
            
            </ContentTemplate>
            

</cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="设置评教日程">
                <ContentTemplate>
                    <div>
                        <table width="600">
                            <tr>
                                <td width="60" height="31" align="left" valign="middle">
                                    <span style="font-size: 15px">学期：</span>
                                </td>
                                <td width="130" align="left" valign="middle">
                                    <asp:DropDownList ID="ddlTerm2" runat="server" Width="120px" DataSourceID="ObjectDataSource9"
                                        DataTextField="Key" DataValueField="Value"></asp:DropDownList>

                                    <asp:ObjectDataSource ID="ObjectDataSource9" runat="server" SelectMethod="GetTerms"
                                        TypeName="Department.Engineering.TermsManage"></asp:ObjectDataSource>


                                </td>
                                <td width="60" align="left" valign="middle">
                                    <span style="font-size: 15px">年级：</span>
                                </td>
                                <td width="130" align="left" valign="middle">
                                    <asp:DropDownList ID="ddlGrade2" runat="server" Width="120px" DataSourceID="ObjectDataSource8"
                                        DataTextField="Grade" DataValueField="Grade"><asp:ListItem>--请选择年级--</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" SelectMethod="GetGrade"
                                        TypeName="Department.Engineering.StudentManage"></asp:ObjectDataSource>


                                </td>
                                <td align="center" valign="middle">
                                    <asp:Button ID="btConfirm" runat="server" Height="31px" Text="确定" Width="60px" OnClick="btConfirm_Click"
                                        BackColor="#3333FF" ForeColor="White" />

                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                        <asp:GridView ID="gvTSchoolCourse" runat="server" Width="700px" AutoGenerateColumns="False"
                            CellPadding="4" ForeColor="#333333" GridLines="None" 
                            onrowcancelingedit="gvTSchoolCourse_RowCancelingEdit" 
                            onrowediting="gvTSchoolCourse_RowEditing" 
                            onrowupdating="gvTSchoolCourse_RowUpdating" DataKeyNames="TeaSchoolID" 
                            AllowPaging="True" PageSize="20">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="学期">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTerms" runat="server" Text='<%#GetCourseTime(Eval("CourseTime").ToString())%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="教学点">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTeaSchoolNames" runat="server" Text='<%#Eval("TeaSchoolName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="年级">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrades" runat="server" Text='<%#Eval("Grade")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="查看(开课数)">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblViewCourse" runat="server">查看</asp:LinkButton>
                                        (<asp:Label ID="lblCourseNum" runat="server" Text='<%#Eval("num") %>'></asp:Label>
                                        )
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="评教开始时间">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbStartTimes" runat="server" Width="100px" Text='<%#Eval("StartTime")==System.DBNull.Value?"":Convert.ToDateTime(Eval("StartTime")).ToString("yyyy-MM-dd") %>'></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="tbStartTimes">
                                        </cc1:CalendarExtender>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartTimes" runat="server" Text='<%#Eval("StartTime")==System.DBNull.Value?"":Convert.ToDateTime(Eval("StartTime")).ToString("yyyy-MM-dd") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="评教结束时间">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbEndTimes" runat="server" Width="100px" Text='<%#Eval("EndTime")==System.DBNull.Value?"":Convert.ToDateTime(Eval("EndTime")).ToString("yyyy-MM-dd") %>'></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy-MM-dd" TargetControlID="tbEndTimes">
                                        </cc1:CalendarExtender>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndTimes" runat="server" Text='<%#Eval("EndTime")==System.DBNull.Value?"":Convert.ToDateTime(Eval("EndTime")).ToString("yyyy-MM-dd") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:CommandField EditText="设置评教时间" ShowEditButton="True">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:CommandField>
                            </Columns>
                            <EditRowStyle BackColor="#D1DDF1" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        
                                </asp:GridView>
                        
                        
                        </ContentTemplate>
</asp:UpdatePanel>


                    </div>
                
                
            
                
                
            
            </ContentTemplate>
            

</cc1:TabPanel>
        </cc1:TabContainer>
    </div>
    </form>
</body>
</html>
