<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMyCourses.aspx.cs" Inherits="Engineering_StuBackMag_ViewMyCourses" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的课程--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        我的课表
    </div>
    <hr />
    <br />
    <div>
        学年：<asp:DropDownList ID="ddlYear" runat="server" Width="120px" 
            AutoPostBack="True" onselectedindexchanged="ddlYear_SelectedIndexChanged">
        </asp:DropDownList>
        学期：
        <asp:DropDownList ID="ddlTerm" runat="server" Width="50px" AutoPostBack="True" 
            onselectedindexchanged="ddlTerm_SelectedIndexChanged">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
        </asp:DropDownList>
    </div>
    <br />
    <div>
        <asp:GridView ID="gvMyCourse" runat="server" AutoGenerateColumns="False" 
            CellPadding="5" 
            onrowdatabound="gvMyCourse_RowDataBound" DataKeyNames="CourseID" 
            BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" Width="700px">
            <Columns>
                <asp:BoundField DataField="CourseName" HeaderText="课程名称">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="课程类别">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                    <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%#sCategory[Convert.ToInt32(Eval("Category"))] %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="课程性质">
                    <ItemTemplate>
                        <asp:Label ID="lblProperty" runat="server" Text='<%#sProperty[Convert.ToInt32(Eval("Property"))] %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:TemplateField>
                <asp:BoundField DataField="CreditHour" HeaderText="学时">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField DataField="Credit" HeaderText="学分">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="任课教师" NullDisplayText="null">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField DataField="ClassPeriod" HeaderText="上课时间" 
                    NullDisplayText="null">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField DataField="Place" HeaderText="上课地点" NullDisplayText="null">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView> 
    </div>
    </form>
</body>
</html>
