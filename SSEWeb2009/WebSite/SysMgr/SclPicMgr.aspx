<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/ManageSite.master" AutoEventWireup="true" CodeFile="SclPicMgr.aspx.cs" Inherits="SysMgr_SclPicMgr" %>

<%@ Register src="../UserControl/SclPicInfoControl.ascx" tagname="SclPicInfoControl" tagprefix="uc" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CssClass/clearbox.css" rel="stylesheet" type="text/css" />
    <script src="../JavaScript/sysmgr_clearbox.js" type="text/javascript"></script> 
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
    <h3 class="h3style">
        学院图片管理</h3>
    <hr size="0" noshade="noshade" color="#999999"/>
    <div class="divstyle">
        <a href="PreUploadPage.aspx" rel="clearbox(375,,240,,click)" target="_blank" title="上传图片">我要上传图片</a> | 
        <a href="../SysMgr/PreViewPage.aspx" target="_blank" rel="clearbox(680,,430,,click)" title="选择图片">选择图片</a> |
        <asp:UpdatePanel ID="updatePanel" runat="server" RenderMode="Inline">
            <ContentTemplate>
        <asp:LinkButton ID="lbAdd" runat="server" onclick="lbAdd_Click">增加一张图片</asp:LinkButton> | 
        <asp:LinkButton ID="lbSave" runat="server" onclick="lbSave_Click">保存设置</asp:LinkButton>
        &nbsp;&nbsp;<asp:Label ID="lbOpInfo" runat="server" Text="Label" 
            ForeColor="Red" Visible="False"></asp:Label>
        <br/><br/>
        <asp:Label ID="lbUse" runat="server" Text="[使用方法] 选择一张图片后，在下列图片列表中选择获取图片即可"></asp:Label>
        <br/><br/>
        
        <asp:PlaceHolder ID="placeHolder" runat="server">
        </asp:PlaceHolder>

        <asp:Timer ID="timerPostBack" runat="server" Enabled="False" EnableViewState="False" Interval="1">
         </asp:Timer>
	        </ContentTemplate>
	    </asp:UpdatePanel>
		</div>
</asp:Content>

