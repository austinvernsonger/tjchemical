<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewCourseArrange.aspx.cs" Inherits="Engineering_TeaSchoolBackMag_ViewCourseArrange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label3" runat="server" Text="查询课程安排"></asp:Label>
        <br />
        <br />
    
    </div>
    <div>     
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label2" runat="server" Text="请选择年级："></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlGrade" runat="server" Height="21px" Width="199px" 
            DataSourceID="ObjectDataSource1" DataTextField="Grade" DataValueField="Grade">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="请选择学期："></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSmaster" runat="server" Height="21px" Width="199px" 
            DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="id">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnQuery" runat="server" Text="查询" onclick="btnQuery_Click" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblResult2" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvCourseArrange" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="CourseID" onrowdatabound="gvCourseArrange_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="开课学期">
                <ItemTemplate>
                <%#GetCourseTime(Eval("CourseTime").ToString())%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CourseName" HeaderText="课程名称" />
                <asp:TemplateField HeaderText="课程类别">
                <ItemTemplate>
                <%#sCategory[Convert.ToInt32(Eval("Category"))] %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="课程性质">
                <ItemTemplate>
                <%#sProperty[Convert.ToInt32(Eval("Property"))] %>                
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ClassPeriod" HeaderText="上课时间" />
                <asp:BoundField DataField="Place" HeaderText="上课地点" />
                <asp:TemplateField HeaderText="任课教师"></asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetGradeListOfTschool" 
            TypeName="Department.Engineering.TeachingSchool">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="34" Name="teaSchoolID" 
                    QueryStringField="teaSchoolID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
            DataFile="~/Engineering/Resources/Xml/Terms.xml" XPath="/Terms/Term">
        </asp:XmlDataSource>
    </div>
    </form>
</body>
</html>
