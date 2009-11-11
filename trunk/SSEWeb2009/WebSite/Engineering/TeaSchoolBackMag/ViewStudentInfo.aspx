<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewStudentInfo.aspx.cs" Inherits="Engineering_TeaSchoolBackMag_ViewStudentInfo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
<form id="form1" runat="server">
    <div> 
    </div>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
            Width="600px" Height="400px">
            <cc1:TabPanel runat="server" HeaderText="查看学生" ID="TabPanel1">
            <ContentTemplate>
            
    <div> 

        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="请输入学号："></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbStudentID" runat="server" Width="182px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Query" runat="server" Text="查询" onclick="btn_Query_Click" />

        <br />
        <br />&#160;&#160;&#160;&#160;
        <asp:Label ID="lblResult1" runat="server"></asp:Label>
        <br />
        <asp:DetailsView ID="dvStudentInfo" runat="server" Height="50px" Width="364px" 
            AutoGenerateRows="False">
            <Fields>
                <asp:BoundField DataField="StudentID" HeaderText="学号" />
                <asp:BoundField DataField="sName" HeaderText="姓名" />
                <asp:BoundField DataField="sGender" HeaderText="性别" />
                <asp:BoundField DataField="Degree" HeaderText="学位类别" />
                <asp:BoundField DataField="Grade" HeaderText="年级" />
                <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点" />
                <asp:BoundField DataField="tName" HeaderText="导师" />
            </Fields>
            
        </asp:DetailsView>

    </div>

            

            
            </ContentTemplate>
            
</cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="查看班级">
            <ContentTemplate>
            
    <div> 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="请选择年级："></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="dplGrade" runat="server" Height="21px" Width="199px" 
            DataSourceID="ObjectDataSource1" DataTextField="Grade" DataValueField="Grade">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblResult2" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvStudInfoList" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="学号" />
                <asp:BoundField DataField="sName" HeaderText="姓名" />
                <asp:BoundField DataField="sGender" HeaderText="性别" />
                <asp:BoundField DataField="Degree" HeaderText="学位类别" />
                <asp:BoundField DataField="Grade" HeaderText="年级" />
                <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点" />
                <asp:BoundField DataField="tName" HeaderText="导师" />
                <asp:HyperLinkField Text="查看详情" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetGradeListOfTschool" 
            TypeName="Department.Engineering.TeachingSchool" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="34" Name="teaSchoolID" 
                    QueryStringField="teaSchoolID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>

            
            
            </ContentTemplate>
            
</cc1:TabPanel>
        </cc1:TabContainer>
    </div>
</form>
</body>
</html>
