<%@ Page Language="C#" MasterPageFile="~/Engineering/MseHomePage.master" AutoEventWireup="true"
    CodeFile="MseHomePage.aspx.cs" Inherits="Engineering_MseHomePage" Title="无标题页" %>

<%@ Register Src="../UserControl/MMTList.ascx" TagName="MMTList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>同济大学软件学院工程硕士</title>
    <link href="../CssClass/EngineeringHomepage.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContentPlace">
    <div id="NewsContainer">
        <div id="MainPic"></div>
        <div id="News">
            <h1>硕士新闻</h1>
            <div style="padding:0 10px">
                <uc1:MMTList ID="MMTNewsList" runat="server" DepartmentId="4" AllowPaging="false" 
                Mode="News" Management="false" PageSize="10" ShowURL="../Engineering/Details.aspx"  InternalOnly="true"
                TitleMaxLength="15" ShowClickCount="false" ShowTime="true" EmptyString="当前没有新闻" Target="_blank"/>
            </div>
        </div>
    </div>
    <div id="BlockBar"></div>
    <div id="BlockContainer">
        <div id="Block1">
            <div class="EngBtn">
		        <asp:HyperLink ID="lkAdmission" runat="server" 
                    ImageUrl="~/Engineering/Resources/images/btn_Admission.jpg" 
                    NavigateUrl="~/Engineering/zs/regulation.aspx" ToolTip="招生简章"></asp:HyperLink></div>
            <div class="EngBtn"><asp:HyperLink ID="lkProcess" runat="server" 
                ImageUrl="~/Engineering/Resources/images/btn_Process.jpg" 
                    NavigateUrl="~/Engineering/zs/process.aspx" ToolTip="招生流程"></asp:HyperLink></div>
            <div class="EngBtn"><asp:HyperLink ID="lkFAQ" runat="server" 
                ImageUrl="~/Engineering/Resources/images/btn_FAQ.jpg" 
                    NavigateUrl="~/Engineering/zs/FAQ.aspx" ToolTip="常见问题"></asp:HyperLink></div>
            <div class="EngBtn"><asp:HyperLink ID="lkShow" runat="server" 
                ImageUrl="~/Engineering/Resources/images/btn_Show.jpg" 
                    NavigateUrl="~/Engineering/zs/showhistory.aspx" ToolTip="成果展示"></asp:HyperLink></div>
        </div>
        <div id="Block2">
                <uc1:MMTList ID="MMTNoticeList" runat ="server" DepartmentId="4" AllowPaging="false" 
                Mode="Notice" Management="false" PageSize="10" ShowURL="../Engineering/Details.aspx"  InternalOnly="true"
                TitleMaxLength="18" ShowClickCount="false" ShowTime="true" EmptyString="当前没有通知" Target="_blank"/>
            </div>
        <div id="Block3">
            <ul>
                <li><a href="#">入学成绩查询</a></li>
                <li><a href="#">课程成绩查询</a></li>
                <li><a href="#">已缴学费查询</a></li>
                <li><a href="#">导师信息查询</a></li>
            </ul>
        </div>
        <div style="clear:both;"></div>
    </div>
</asp:Content>
