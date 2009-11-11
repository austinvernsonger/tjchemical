<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StatisticsControl.ascx.cs" Inherits="Report_Control_ResultControl_StatisticsControl" %>
<%@ Register src="../Displayer.ascx" tagname="Displayer" tagprefix="uc1" %>
<p>
    
        &nbsp;</p>
<p>
    
        <asp:Label ID="Hidden_DescriptorFilePAth" runat="server" Visible="False"></asp:Label>
    
    <asp:Label ID="Hidden_ResultFilePAth" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="Hidden_Key" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="Hidden_Value" runat="server" Visible="False"></asp:Label>
</p>
<p>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <asp:Button ID="Button_Output" runat="server" onclick="Button_Output_Click" 
        Text="导出" />
    <asp:Button ID="Button_Refresh" runat="server" onclick="Button_Refresh_Click" 
        Text="刷新" />
</p>
<table>  
                          <tr>  
                                  <td>   
                                      <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="700px">
                                          <asp:GridView ID="GridView1" runat="server" 
    AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" 
    GridLines="None" 
    onselectedindexchanged="GridView1_SelectedIndexChanged">
                                              <RowStyle BackColor="#EFF3FB" />
                                              <Columns>
                                                  <asp:TemplateField></asp:TemplateField>
                                              </Columns>
                                              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                              <EditRowStyle BackColor="#2461BF" />
                                              <AlternatingRowStyle BackColor="White" />
                                          </asp:GridView>
                                      </asp:Panel>
</td>
</tr>
</table>
<p>
    &nbsp;</p>
<uc1:Displayer ID="Displayer1" runat="server" />
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
    EnableViewState="False" Interval="1">
</asp:Timer>


