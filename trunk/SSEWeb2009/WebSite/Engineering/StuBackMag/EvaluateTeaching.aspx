<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EvaluateTeaching.aspx.cs" Inherits="Engineering_StuBackMag_EvaluateTeaching" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 教学评估--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 25px">   
        教学评估
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <asp:Label ID="lblResult" runat="server" ForeColor="#999999"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:GridView ID="gvEvaluating" runat="server" Width="700px" 
                AutoGenerateColumns="False" DataKeyNames="CourseID" 
                onrowdatabound="gvEvaluating_RowDataBound" BorderColor="#666666" 
                BorderStyle="Solid" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:TemplateField HeaderText="学季">
                        <ItemTemplate>
                            <%# GetCourseTime(Eval("CourseTime").ToString())%>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="CourseName" HeaderText="课程名称" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Credit" HeaderText="学分" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="任课教师" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="课程类别">
                        <ItemTemplate>
                            <%# sCategory[Convert.ToInt32(Eval("Category"))]%>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="课程性质">
                        <ItemTemplate>
                            <%# sProperty[Convert.ToInt32(Eval("Property"))]%>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="进行评估">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server">进行评估</asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
