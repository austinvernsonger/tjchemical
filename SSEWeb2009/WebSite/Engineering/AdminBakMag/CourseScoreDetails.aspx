<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseScoreDetails.aspx.cs" Inherits="Engineering_AdminBakMag_CourseScoreDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style=" font-size:25px">学科成绩详细信息</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                        PostBackUrl="~/Engineering/AdminBakMag/ScoreViewManagement.aspx">返回上一页</asp:LinkButton>
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
    <div>
        <asp:Label ID="lblCourseTime" runat="server"></asp:Label>
        <asp:Label ID="lblCourseName" runat="server" Font-Bold="True" Font-Size="Large" 
            ForeColor="Red"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="课程成绩如下："></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <asp:GridView ID="gvScoreDetails" runat="server" AutoGenerateColumns="False" 
            Width="700px" BorderColor="#666666" BorderStyle="Solid" CellPadding="4" onrowdatabound="gvScoreDetails_RowDataBound" 
            DataKeyNames="StudentID" BorderWidth="1px" ondatabound="gvScoreDetails_DataBound">
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="学号">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="姓名">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField DataField="Degree" HeaderText="学位类别">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField DataField="CourResult" HeaderText="成绩">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        确认
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbConfirm" runat="server" AutoPostBack="True" 
                            oncheckedchanged="cbConfirm_CheckedChanged" />
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" Width="60px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        有疑问
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbNoConfirm" runat="server" AutoPostBack="True" 
                            oncheckedchanged="cbNoConfirm_CheckedChanged"/>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" Width="60px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>   
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
     <asp:Button ID="btClose" runat="server" Text="确认并发布成绩" BackColor="#3333FF" 
       ForeColor="White" Height="31px" onclick="btClose_Click" />
    <br /><br />
     //确认并发布成绩后，学生将可查询该课程成绩<br>
    //确认并发布成绩后，任课教师将没有权利再修改成绩<br />
    //点击确认并发布成绩前，请先核对成绩
    </form>
</body>
</html>
