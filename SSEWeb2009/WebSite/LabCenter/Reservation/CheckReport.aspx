<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LabCenter/MasterPages/HomeMaster.master" CodeFile="CheckReport.aspx.cs" Inherits="实验预约_CheckReport" %>

<%@ Register src="../NavUserControls/MyExperiment.ascx" tagname="MyExperiment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:MyExperiment ID="MyExperiment1" runat="server" />
    <div id="InnerContainer">
        <h3>实验报告</h3>
        <asp:GridView
         ID="ReportList"
          AutoGenerateColumns="False"
          runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <RowStyle BackColor="#EFF3FB" />
          <Columns>
          <asp:BoundField DataField="Expname" HeaderText="实验名称" 
                  ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
              </asp:BoundField>
          <asp:BoundField DataField="ReportState" HeaderText="是否提交实验报告" 
                  ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
              </asp:BoundField>
          </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
          <EmptyDataTemplate>
          <p>无相关记录!</p>
          </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/LabCenter/Default.aspx">返回</asp:LinkButton>
    
    </div>
  </asp:Content>