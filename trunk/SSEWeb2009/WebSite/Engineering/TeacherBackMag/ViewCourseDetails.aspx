<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewCourseDetails.aspx.cs" Inherits="Engineering_TeacherBackMag_ViewCourseDetails" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的课程--工程硕士中心</title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style=" font-size:25px">课程详细信息</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:LinkButton ID="lbBack" runat="server" PostBackUrl="~/Engineering/TeacherBackMag/MyCourse.aspx">&lt;&lt;返回上一页</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <br />
    <div>
        课程名称：<asp:Label ID="lblCourseName" runat="server" Font-Bold="True" Font-Size="Large" 
                        ForeColor="Red"></asp:Label>
    </div>
    <br />
    <div style="float:left">
        年级:<asp:Label ID="lblGrade" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
    </div>
    <div style="float:left ; margin-left:10px">
        教学点：<asp:Label ID="lblSchool" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue"></asp:Label>
    </div>
    <br />
    <div>
        <asp:GridView ID="gvMyCourse" runat="server" AutoGenerateColumns="False" 
            BorderColor="#666666" BorderStyle="Groove" BorderWidth="1px" CellPadding="4" 
            onrowdatabound="gvMyCourse_RowDataBound" Width="700px" 
            DataKeyNames="StudentID" ondatabound="gvMyCourse_DataBound">
            <RowStyle BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" />
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="学号">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="姓名">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                         <asp:Label ID="lblGender" runat="server" Text='<%#Convert.ToInt32(Eval("Gender"))==0?"女":"男" %>'></asp:Label>
                    </ItemTemplate>
                   
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="成绩">
                    <ItemTemplate>
                        <asp:Label ID="lblRes" runat="server" Text='<%#Eval("CourResult") %>'></asp:Label>
                        <asp:TextBox ID="tbRes" runat="server" Visible="False" Width="120px" Text='<%#Eval("CourResult") %>'></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#CCCCCC" BorderStyle="Solid" />
        </asp:GridView>
    </div>
    <br />
    <div>
        <asp:Button ID="btModify" runat="server" Text="录入成绩" Height="31px" 
            Width="90px" onclick="btModify_Click" />
        <asp:Button ID="btSave" runat="server" Height="31px" Text="保存成绩" Width="90px" 
            onclick="btSave_Click" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btBack" runat="server" Height="31px" 
            PostBackUrl="~/Engineering/TeacherBackMag/MyCourse.aspx" Text="返回" 
            Width="90px" />
    </div>
    </form>
</body>
</html>
