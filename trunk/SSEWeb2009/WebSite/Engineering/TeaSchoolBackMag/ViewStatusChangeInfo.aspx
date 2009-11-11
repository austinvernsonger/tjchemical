<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewStatusChangeInfo.aspx.cs" Inherits="Engineering_TeaSchoolBackMag_ViewStatusChangeInfo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
            Height="400px" Width="600px">
            <cc1:TabPanel runat="server" HeaderText="按班级查询" ID="TabPanel1">
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
        <asp:Button ID="btn_Query" runat="server" Text="查询" onclick="btn_Query_Click" />

        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblResult1" runat="server"></asp:Label>

        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvClassStatus" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="学号" />
                <asp:BoundField DataField="Name" HeaderText="姓名" />
                <asp:BoundField DataField="ApplyCategory" HeaderText="学籍状态" />
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
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="按类型查询">
            <ContentTemplate>
                       
    <div> 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="请选择学籍变动类型："></asp:Label>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="dplApplyChgType" runat="server" Height="21px" 
            Width="199px">
            <asp:ListItem>--请选择学籍变动类型--</asp:ListItem>
            <asp:ListItem>退学</asp:ListItem>
            <asp:ListItem>休学</asp:ListItem>
            <asp:ListItem>其它</asp:ListItem>
        </asp:DropDownList>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_SearchByType" runat="server" Text="查询" 
            OnClick="btn_SearchByType_Click" />

        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblResult2" runat="server"></asp:Label>

        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvChangeInfo" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="学号" DataField="StuID" />
                <asp:BoundField HeaderText="姓名" DataField="Name" />
                <asp:BoundField HeaderText="年级" DataField="Grade" />
                <asp:BoundField HeaderText="学籍状态" DataField="ApplyCategory" />
                <asp:BoundField HeaderText="申请时间" DataField="ApplyTime" />
                <asp:BoundField HeaderText="结束时间" DataField="BackTime" />
                <asp:HyperLinkField Text="查看详情" />
            </Columns>
        </asp:GridView>

    </div>

            

            
            </ContentTemplate>
            
</cc1:TabPanel>
        </cc1:TabContainer>
    </div>
    </form>
</body>
</html>
