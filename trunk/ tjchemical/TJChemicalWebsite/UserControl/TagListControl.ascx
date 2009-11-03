<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TagListControl.ascx.cs" Inherits="UserControl_TagListControl" %>

<style type="text/css">
.tagBtnNormal
{
	margin: 5px;
	border: 1px solid #808080;
	background-color: #EAEAEA;
	font-family: Tahoma;
	font-size: small;
	color: #808080;
	height: 24px;
}

.tagBtnClicked
{
	margin: 5px;
	border: 1px solid #0066FF;
	background-color: #99CCFF;
	font-family: Tahoma;
	font-size: small;
	color: #3C3C3C;
	height: 24px;
}
</style>
<script type="text/javascript">
     function Show() {
         document.getElementById("mainDiv").style.display = "block";
     }
     
     function Hide() {
         document.getElementById("mainDiv").style.display = "none";
     }

     function ShowContent() {
         if (document.getElementById("panelDiv").style.display == "block") {
             document.getElementById("panelDiv").style.display = "none";
             document.getElementById("lbPlus").value = "+";
         }
         else {
             document.getElementById("panelDiv").style.display = "block";
             document.getElementById("lbPlus").value = "-";
         }
     }
</script>

<div style="padding: 0; margin: 0; border: solid 1px #999999; width: 100%;">
    &nbsp;
    <asp:Label ID="label" runat="server" Text="新闻/通知类型：" Font-Size="0.75em" 
        ForeColor="#333333"></asp:Label>
    <asp:RadioButtonList ID="blockRadioButtonList" runat="server" 
        RepeatLayout="Flow" RepeatDirection="Horizontal" Font-Size="0.75em" 
        ForeColor="#333333">
        <asp:ListItem Value="1" Selected="True" OnClick="Show()">全局</asp:ListItem>
        <asp:ListItem Value="2" OnClick="Hide()">部门</asp:ListItem>  
    </asp:RadioButtonList>
    &nbsp;
    <input id="lbPlus" onclick="ShowContent(); return false;" type="button" value="-" 
        style="border: none; font-family: 宋体; font-size: small; color: #333333; cursor: pointer;" />
    <div id="mainDiv" style="display: block; width: 100%;">
        <div align="left" style="width: 95%"><hr size="0" noshade="noshade" color="#999999" style="width: 100%;"></div>
        <div id="panelDiv" style="display: block;">
            <asp:Panel ID="TagPanel" runat="server">
            </asp:Panel>
        </div>
        &nbsp;
        <asp:Label ID="lbInfo" runat="server" Text="没有选择标准，默认标签为“全部”" Font-Names="Tahoma" Font-Size="Small" 
            ForeColor="#333333"></asp:Label>
    </div>
 </div>
