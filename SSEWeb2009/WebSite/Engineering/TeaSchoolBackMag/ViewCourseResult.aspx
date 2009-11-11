<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewCourseResult.aspx.cs" Inherits="Engineering_TeaSchoolBackMag_ViewCourseResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label3" runat="server" Text="查询课程成绩"></asp:Label>
        <br />
        <br />
    
    </div>
    <div>     
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="请选择年级："></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlGrade" runat="server" Height="21px" Width="199px" 
            DataSourceID="ObjectDataSource1" DataTextField="Grade" DataValueField="Grade">
        </asp:DropDownList>
        <br />
         &nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="Label1" runat="server" Text="请选择学期："></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSmaster" runat="server" Height="21px" Width="199px" 
            DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="id">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Query" runat="server" Text="查询" onclick="btn_Query_Click" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblResult2" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvCourseList" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="CourID" onrowdatabound="gvCourseList_RowDataBound">
            <Columns>
                <asp:BoundField DataField="CourseName" HeaderText="课程名称" />
                <asp:TemplateField HeaderText="开课学期">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <%#GetCourseTime(Eval("CourseTime").ToString())%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="任课教师">
                <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="StudentNumber" HeaderText="选课人数" />
                <asp:HyperLinkField HeaderText="查看课程成绩" Text="点击查看" 
                    DataNavigateUrlFields="CourID" 
                    DataNavigateUrlFormatString="CourseScoreList.aspx?id={0}" />
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
