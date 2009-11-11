<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StartChoosingStudents.aspx.cs" Inherits="Engineering_TeacherBackMag_StartChoosingStudents" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择我的学生--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style=" font-size:25px">选择学生详细信息</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:LinkButton ID="lbBack" runat="server" 
                        PostBackUrl="~/Engineering/TeacherBackMag/ChooseMyStudents.aspx">&lt;&lt;返回上一页</asp:LinkButton>
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
                    <asp:Label ID="Label1" runat="server" Text="年级："></asp:Label>
                    <asp:Label ID="lblGrade" runat="server"></asp:Label>
                </td>
                <td width="350" align="center" valign="middle">
                    <asp:Label ID="Label3" runat="server" Text="教学点："></asp:Label>
                    <asp:Label ID="lblSchool" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:GridView ID="gvChoosingStu" runat="server" Width="700px" 
                AutoGenerateColumns="False" CellPadding="4" BorderColor="#999999" 
                onrowdatabound="gvChoosingStu_RowDataBound" DataKeyNames="StudentID" 
                BorderStyle="Solid" BorderWidth="1px" 
                onselectedindexchanged="gvChoosingStu_SelectedIndexChanged" 
                    ondatabound="gvChoosingStu_DataBound">
                <Columns>
                    <asp:BoundField DataField="StudentID" HeaderText="学号" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="姓名" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="性别">
                        <ItemTemplate>
                            <%# Convert.ToBoolean(Eval("Gender"))?"女":"男" %>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Degree" HeaderText="学位类别" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="志愿（你是他的）">
                        <ItemTemplate>
                            <%# GetStuWill(Eval("Will").ToString()) %>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="选定">
                        <ItemTemplate>
                            <asp:CheckBox ID="cbSelect" runat="server" 
                                Checked='<%# Convert.ToBoolean(Eval("TeaWill"))?true:false %>' 
                                AutoPostBack="True" oncheckedchanged="cbSelect_CheckedChanged"/>
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
    <br />
    <br />
    <div>
        <asp:Button ID="btSave" runat="server" Text="保存选择" Height="31px" Width="90px" 
            onclick="btSave_Click" BackColor="#3333FF" ForeColor="White" />
        <asp:Button ID="btModify" runat="server" Text="更改选择" Height="31px" 
            Width="90px" onclick="btModify_Click" BackColor="#3333FF" 
            ForeColor="White" />
         &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btBack" runat="server" BackColor="#3333FF" ForeColor="White" 
            Height="31px" Text="返回" Width="90px" 
            PostBackUrl="~/Engineering/TeacherBackMag/ChooseMyStudents.aspx" />
    </div>
    </form>
</body>
</html>
