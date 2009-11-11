<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReservationLogin_pre.aspx.cs" Inherits="LabCenter_Reservation_ReservationLogin_pre" MasterPageFile="~/LabCenter/MasterPages/HomeMaster.master"%>


<%@ Register src="../NavUserControls/MyExperiment.ascx" tagname="MyExperiment" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
function redirect()
{
    window.location.href = '';
}
//setTimeout("redirect()", 1000);
</script>
<uc1:MyExperiment ID="MyExperiment1" runat="server" />
    <div id="InnerContainer">
    <h3>实验登记</h3>
    <asp:Label ID="lblmessage" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btntemp" runat="server" Text="临时预约" Visible="false" 
            onclick="btntemp_Click" />
     &nbsp;<asp:Button ID="btnnext" runat="server" Text="预约下个时间段" Visible="false" 
            onclick="btnnext_Click" />
            <div id="divmore" visible="false" runat="server">
            <hr />
            <br />
            <asp:Label ID="lblchoose" runat="server" AssociatedControlID="rdbtnexplist" Text="选择实验"></asp:Label>
            <br />
            <asp:RadioButtonList ID="rdbtnexplist" runat="server">
            <asp:ListItem></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Button ID="btnexp" runat="server" Text="确定" onclick="btnexp_Click" />
            </div>
    </div>
</asp:Content>
