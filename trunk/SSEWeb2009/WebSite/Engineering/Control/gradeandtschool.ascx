<%@ Control Language="C#" AutoEventWireup="true" CodeFile="gradeandtschool.ascx.cs" Inherits="Engineering_Control_gradeandtschool" %>
<style type="text/css">
    .style1
    {
        width: 126px;
    }
    .style2
    {
        width: 82px;
    }
</style>
<table width="599" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="110" height="31" align="center" valign="middle">年级</td>
    <td align="left" valign="middle" class="style1">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="GradeDnList" runat="server" AutoPostBack="True" 
                    Height="28px" onselectedindexchanged="GradeDnList_SelectedIndexChanged">
                    <asp:ListItem>请选择年级</asp:ListItem>
                </asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>
      </td>
    <td align="center" valign="middle" class="style2">教学点</td>
    <td width="188" align="left" valign="middle">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="TSchoolDnList" runat="server" Height="28px" 
                    onselectedindexchanged="TSchoolDnList_SelectedIndexChanged" Width="112px">
                    <asp:ListItem>请选择教学点</asp:ListItem>
                </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GradeDnList" 
                    EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
            </td>
  </tr>
</table>