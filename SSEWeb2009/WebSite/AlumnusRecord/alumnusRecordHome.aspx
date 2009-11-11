<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/AlumnusRecord/MasterPage.master"
    CodeFile="alumnusRecordHome.aspx.cs" Inherits="alumnusRecordHome" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControl/EditMMT.ascx" TagName="EditMMT" TagPrefix="ucl" %>
<%@ Register Src="~/UserControl/ViewMMT.ascx" TagName="ViewMMT" TagPrefix="ucl" %>
<%@ Register Src="~/UserControl/MMTList.ascx" TagName="MMTList" TagPrefix="ucl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Container">
        <%--<div id="LoginBar"><span id="LoginBarRight">登录</span></div>--%>
        <!--院友访谈-->
        <div id="SideBarLeft">
            <div id="SideBarLeft_Title">
                <div style="text-align: right; float: right;margin:8px 40px 0 ; ">
                     <a href="alumnusInterview.aspx">More>></a>
                </div>
            </div>
            <!--院友访谈数据源-->
            <div id="interview_first"></div>
            <div id="interview_second"></div>
            
            
        </div>
        <!--院友动态-->
        <div id="SideBarRight">
            <div id="SideBarRight_Title">
            </div>
            <div id="SideBarRight_Container">
                <div id="SideBarRight_Container_Left" style="width: 480px;">
                
                   <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/AlumnusRecord/Resources/News/alumnusNews.xml" />
                    
                    <div style="text-align: right; float: right; padding-bottom: 0px;">
                        <a href="alumnusNews.aspx">More>></a>
                    </div>
                </div>
            </div>
        </div>
        <!--院友风采-->
        <div id="Gallery_Title">
        
            <a href="#pre" class="prev" id="pre">&nbsp;</a>
            <%--<button class="prev"><<</button>--%>
            
            <a href="#nex" class="next" id="nex">&nbsp;</a>
            <%--<button class="next">>></button>--%>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="Select" TypeName="FileMienXmlDataObject"></asp:ObjectDataSource>
    </div>
    <asp:ScriptManager ID="sm1" runat="server" LoadScriptsBeforeUI="true">
        <Scripts>
            <asp:ScriptReference Path="Resources/scripts/jquery-1.3.2-vsdoc2.js" />
            <asp:ScriptReference Path="Resources/scripts/jcarousellite_1.0.1.min.js" />
            <asp:ScriptReference Path="Resources/scripts/jquery.easing.1.1.js" />
        </Scripts>
    </asp:ScriptManager>
    <%--<script type="text/jscript" src="js/jquery-1.3.2.min.js" ></script>
    <script type="text/jscript" src="js/jcarousellite_1.0.1.min.js"></script>
    <script type="text/jscript" src="js/jquery.easing.1.1.js" ></script>--%>

    <script type="text/javascript">
        $(function() {
            $(".scrollDiv").jCarouselLite({
                btnNext: ".next",
                btnPrev: ".prev",
                auto: 800,
                speed: 1500,
                easing: "easein",
                visible: 9
            });
        });                 
    </script>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
