<%@ Page Language="C#" MasterPageFile="~/Engineering/MseHomePage.master" AutoEventWireup="true"
    CodeFile="MseHomePage.aspx.cs" Inherits="Engineering_MseHomePage" Title="�ޱ���ҳ" %>

<%@ Register Src="../UserControl/MMTList.ascx" TagName="MMTList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ͬ�ô�ѧ���ѧԺ����˶ʿ</title>
    <link href="../CssClass/EngineeringHomepage.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContentPlace">
    <div id="NewsContainer">
        <div id="MainPic"></div>
        <div id="News">
            <h1>˶ʿ����</h1>
            <div style="padding:0 10px">
                <uc1:MMTList ID="MMTNewsList" runat="server" DepartmentId="4" AllowPaging="false" 
                Mode="News" Management="false" PageSize="10" ShowURL="../Engineering/Details.aspx"  InternalOnly="true"
                TitleMaxLength="15" ShowClickCount="false" ShowTime="true" EmptyString="��ǰû������" Target="_blank"/>
            </div>
        </div>
    </div>
    <div id="BlockBar"></div>
    <div id="BlockContainer">
        <div id="Block1">
            <div class="EngBtn">
		        <asp:HyperLink ID="lkAdmission" runat="server" 
                    ImageUrl="~/Engineering/Resources/images/btn_Admission.jpg" 
                    NavigateUrl="~/Engineering/zs/regulation.aspx" ToolTip="��������"></asp:HyperLink></div>
            <div class="EngBtn"><asp:HyperLink ID="lkProcess" runat="server" 
                ImageUrl="~/Engineering/Resources/images/btn_Process.jpg" 
                    NavigateUrl="~/Engineering/zs/process.aspx" ToolTip="��������"></asp:HyperLink></div>
            <div class="EngBtn"><asp:HyperLink ID="lkFAQ" runat="server" 
                ImageUrl="~/Engineering/Resources/images/btn_FAQ.jpg" 
                    NavigateUrl="~/Engineering/zs/FAQ.aspx" ToolTip="��������"></asp:HyperLink></div>
            <div class="EngBtn"><asp:HyperLink ID="lkShow" runat="server" 
                ImageUrl="~/Engineering/Resources/images/btn_Show.jpg" 
                    NavigateUrl="~/Engineering/zs/showhistory.aspx" ToolTip="�ɹ�չʾ"></asp:HyperLink></div>
        </div>
        <div id="Block2">
                <uc1:MMTList ID="MMTNoticeList" runat ="server" DepartmentId="4" AllowPaging="false" 
                Mode="Notice" Management="false" PageSize="10" ShowURL="../Engineering/Details.aspx"  InternalOnly="true"
                TitleMaxLength="18" ShowClickCount="false" ShowTime="true" EmptyString="��ǰû��֪ͨ" Target="_blank"/>
            </div>
        <div id="Block3">
            <ul>
                <li><a href="#">��ѧ�ɼ���ѯ</a></li>
                <li><a href="#">�γ̳ɼ���ѯ</a></li>
                <li><a href="#">�ѽ�ѧ�Ѳ�ѯ</a></li>
                <li><a href="#">��ʦ��Ϣ��ѯ</a></li>
            </ul>
        </div>
        <div style="clear:both;"></div>
    </div>
</asp:Content>
