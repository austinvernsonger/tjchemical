<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisposeCourseAgenda.aspx.cs" Inherits="Engineering_AdminBakMag_DisposeCourseAgenda" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>处理选课结果--工程硕士中心</title>
    <script type ="text/javascript" language = "javascript">
    function OpenOvertimeDlog(ID,width,height) 
   {       
     var me; 
     // 把父页面窗口对象当作参数传递到对话框中，以便对话框操纵父页自动刷新。 
     me = "StudentChoosingCourseDetails.aspx?courseid="+ID+""; 
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
                    <span style=" font-size:25px">处理选课结果</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:LinkButton ID="lbBack" runat="server" 
                        PostBackUrl="~/Engineering/AdminBakMag/CourseViewManagement.aspx">&lt;&lt;返回上一页</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <br />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <asp:GridView ID="gvCourseInfo" runat="server" AutoGenerateColumns="False" 
            BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="4" Width="700px" DataKeyNames="CourseID" 
            onrowdatabound="gvCourseInfo_RowDataBound">
            <Columns>
                <asp:BoundField DataField="CourseName" HeaderText="课程名称">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="任课教师" NullDisplayText="null">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField DataField="StudentNumber" HeaderText="选课人数">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="选课学生">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbViewStudent" runat="server">查看</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否开设该课程">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbOpen" runat="server" AutoPostBack="True" Checked="True" 
                            Font-Size="Small" ForeColor="Red" Text="开设" 
                            oncheckedchanged="cbOpen_CheckedChanged" />
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <div>
        <asp:Button ID="btConfirm" runat="server" Text="确认并发布" Height="31px" 
            onclick="btConfirm_Click" Width="90px" BackColor="#3333FF" 
            ForeColor="White" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btBack" runat="server" Height="31px" 
            PostBackUrl="~/Engineering/AdminBakMag/CourseViewManagement.aspx" Text="稍后处理" 
            Width="90px" BackColor="#3333FF" ForeColor="White" />
    </div>
    <br />
    <div>
        <asp:Label ID="lblResult" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    </form>
</body>
</html>
