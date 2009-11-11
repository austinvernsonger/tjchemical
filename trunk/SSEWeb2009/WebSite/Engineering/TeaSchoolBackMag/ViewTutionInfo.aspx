<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewTutionInfo.aspx.cs" Inherits="Engineering_TeaSchoolBackMag_ViewTutionInfo" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <uc1:sitmap ID="sitmap1" runat="server" />    
    </div>
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
            Height="400px" Width="600px">
            <cc1:TabPanel runat="server" HeaderText="查看班级学费" ID="TabPanel1">
            <ContentTemplate>
                       
    <div> 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="请选择年级："></asp:Label>


        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="dplGrade" runat="server" Height="21px" Width="199px" 
            DataSourceID="ObjectDataSource1" DataTextField="Grade" DataValueField="Grade"></asp:DropDownList>


        &#160;&#160;&#160;<br />
&#160;&#160; &#160;
        <asp:Label ID="Label3" runat="server" Text="缴费情况："></asp:Label>


        &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
        <asp:DropDownList ID="dplPayStatus" runat="server" Height="21px" Width="199px">
            <asp:ListItem>--请选择--</asp:ListItem>
            <asp:ListItem Value="1">拖欠学费的学生</asp:ListItem>
            <asp:ListItem Value="2">未拖欠学费学生</asp:ListItem>
        </asp:DropDownList>


        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_SearchGrade" runat="server" Text="查询" 
            onclick="btn_SearchGrade_Click" />


        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblResult2" runat="server"></asp:Label>


        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvGradeTutionInfo" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="StuID" HeaderText="学号" />
                <asp:BoundField DataField="Name" HeaderText="姓名" />
                <asp:BoundField DataField="Grade" HeaderText="年级" />
                <asp:TemplateField HeaderText="缴费学期">
                <ItemTemplate>
                <%# GetCourseTime(Eval("PaymentTerm").ToString())%>
                </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="缴费时间">
                <ItemTemplate>
                <%# Convert.ToDateTime(Eval("PaymentTime")).ToString("yyyy年MM月dd日")%>               
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MustMoney" HeaderText="需要学费" />
                <asp:BoundField DataField="ActualMoney" HeaderText="已缴学费" />
                <asp:BoundField DataField="Remark" HeaderText="备注" />
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


    </div>

            

            
            

            

            
            
            

            

            
            

            

            
            
            
            

            

            
            

            

            
            
            

            

            
            

            

            
            
            
            
            

            

            
            

            

            
            
            

            

            
            

            

            
            
            
            

            

            
            

            

            
            
            

            

            
            

            

            
            
            
            
            
            </ContentTemplate>
            




</cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="查看学生学费">
            <ContentTemplate>
            
    <div> 

        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="请输入学号："></asp:Label>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbStudentID" runat="server" Width="182px"></asp:TextBox>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Query" runat="server" Text="查询" onclick="btn_Query_Click" ></asp:Button>


        <br />
        <br />&#160;&#160;&#160;&#160;
        <asp:Label ID="lblResult1" runat="server"></asp:Label>

        <br />
        <asp:GridView ID="gvStudentTution" runat="server" AutoGenerateColumns="False"><Columns>
<asp:BoundField DataField="StuID" HeaderText="学号" />
<asp:BoundField DataField="Name" HeaderText="姓名" />
<asp:BoundField DataField="Grade" HeaderText="年级" />
<asp:TemplateField HeaderText="缴费学期">
    <ItemTemplate>
                <%# GetCourseTime(Eval("PaymentTerm").ToString())%>
                
            </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="缴费时间">
    <ItemTemplate>
                <%# Convert.ToDateTime(Eval("PaymentTime")).ToString("yyyy年MM月dd日")%>               
                
            </ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="MustMoney" HeaderText="需要学费" />
<asp:BoundField DataField="ActualMoney" HeaderText="已缴学费" />
<asp:BoundField DataField="Remark" HeaderText="备注" />
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
