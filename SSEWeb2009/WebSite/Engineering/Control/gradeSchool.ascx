<%@ Control Language="C#" AutoEventWireup="true" CodeFile="gradeSchool.ascx.cs" Inherits="Engineering_Control_gradeSchool" %>
<table width="570">
    <tr>
        <td align="left" height="31" valign="middle" width="100">
           <asp:Label ID="lbGrade" runat="server" Text="年级："></asp:Label>
        </td>
        <td align="left" valign="middle" width="190">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlGrade" runat="server" AutoPostBack="True" 
                        DataSourceID="ObjectDataSource1" DataTextField="Grade" DataValueField="Grade" 
                        onselectedindexchanged="ddlGrade_SelectedIndexChanged" Width="140px">
                        <asp:ListItem>--请选择年级--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        SelectMethod="GetGrade" TypeName="Department.Engineering.StudentManage">
                    </asp:ObjectDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td align="center" valign="middle" width="140">
            <asp:Label ID="lbSchool" runat="server" Text="教学点："></asp:Label>
        </td>
        <td align="left" valign="middle" width="140">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlSchool" runat="server" 
                        DataSourceID="ObjectDataSource2" DataTextField="TeaSchoolName" 
                        DataValueField="TeaSchoolID" Width="140px">
                        <asp:ListItem>--请选择教学点--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                        SelectMethod="GetTeaSchool" TypeName="Department.Engineering.TeachingSchool">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlGrade" Name="selValue" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlGrade" 
                        EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
