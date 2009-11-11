<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuChoosingChangeDetails.aspx.cs" Inherits="Engineering_AdminBakMag_StuChoosingChangeDetails" %>
<%@ OutputCache Duration="1" VaryByParam="None"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; padding-top:4px">
        <div>
            <table width="480">
            <tr>
                <td width="340" height="31" align="left" valign="middle">
                    学生调剂导师详细信息</td>
                <td width="140" align="center" valign="middle">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
                </td>
            </tr>
        </table>
        </div>
            <br />
            <asp:DetailsView ID="dvStuChangeInfo" runat="server" Height="16px" Width="442px" 
                AutoGenerateRows="False" CellPadding="4" BackColor="White" 
                BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" 
                ondatabound="dvStuChangeInfo_DataBound" DataKeyNames="StudentID" 
                onmodechanging="dvStuChangeInfo_ModeChanging" 
                onitemcreated="dvStuChangeInfo_ItemCreated" 
                onitemupdating="dvStuChangeInfo_ItemUpdating">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <RowStyle ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <Fields>
                    <asp:TemplateField HeaderText="姓名：">
                        <ItemTemplate>
                            <%#Eval("sName")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="学号：">
                         <ItemTemplate>
                             <%#Eval("StudentID")%>
                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="年级：">
                        <ItemTemplate>
                            <%#Eval("Grade")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="教学点：">
                        <ItemTemplate>
                             <%#Eval("TeaSchoolName")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="第一志愿导师">
                        <ItemTemplate>
                            <asp:Label ID="lblFirstWill" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="第二志愿导师">
                        <ItemTemplate>
                            <asp:Label ID="lblSecondWill" runat="server"></asp:Label>                            
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="第三志愿导师">
                        <ItemTemplate>
                            <asp:Label ID="lblThirdWill" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="暂定导师：">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlTeacher" runat="server" Width="120px">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTeacher" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="320px" />
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" EditText="进行调剂" ButtonType="Button" >
                        <ControlStyle BackColor="#3333FF" ForeColor="White" Height="31px" 
                            Width="90px" />
                        <ItemStyle HorizontalAlign="Center" Height="80px" />
                    </asp:CommandField>
                </Fields>
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            </asp:DetailsView>
        <br />
        <br />
        <div>
        </div>
        <div>
            <asp:Label ID="lblRes" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        </div>
        <br />
        <br />
        <div>
            <table width="480">
            <tr>
                <td width="480" height="31" align="center" valign="middle">
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
                </td>
            </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>
