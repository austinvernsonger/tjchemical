<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LabCenter/MasterPages/HomeMaster.master" CodeFile="LabReservation.aspx.cs" Inherits="实验预约_LabOrder" %>

<%@ Register src="../NavUserControls/MyExperiment.ascx" tagname="MyExperiment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:MyExperiment ID="MyExperiment1" runat="server" />
    <div id="InnerContainer" style="float:left;">
    <h3>实验预约</h3>
        <asp:Calendar ID="Calendar1" runat="server" 
            OnSelectionChanged="Calendar1_SelectionChanged" 
            OnDayRender="Calendar1_DayRender" SelectionMode="None"></asp:Calendar>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        
        </div>
        <div style="float:left;">
            <br /><br />&nbsp;
        <asp:Label ID="Label1" runat="server" Text="时间段:" AssociatedControlID="DropDownList1"></asp:Label>&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Enabled="False" 
                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="167px">
        </asp:DropDownList>&nbsp;
        <!--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=localhost;Initial Catalog=LabCenter;Persist Security Info=True;User ID=sa;Password=sa"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT convert(varchar(8),[beginTime],8) as begintime, convert(varchar(8),[endTime],8) as endtime, [endDayOfWeek] FROM [TimeInfo] ORDER BY [beginTime]">
            </asp:SqlDataSource>-->
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1"
            ErrorMessage="RequiredFieldValidator" ValidationGroup="TimeSpan">Required</asp:RequiredFieldValidator>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton3" runat="server" Enabled="False" OnClick="LinkButton3_Click" 
                ValidationGroup="TimeSpan">确定</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="剩余实验设备数:"></asp:Label>
        <asp:Label ID="Label6" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="实验名:"></asp:Label>
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Visible="False">
            <asp:ListItem></asp:ListItem>
        </asp:RadioButtonList>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" 
                OnClick="LinkButton1_Click" ValidationGroup="TimeSpan">预约</asp:LinkButton>&nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server" 
                PostBackUrl="~/LabCenter/Default.aspx">返回</asp:LinkButton>
            &nbsp;<br />
        <hr />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server"></asp:Label>
            &nbsp;
    </div>
</asp:Content>
