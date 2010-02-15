<%@ Page Language="C#" MasterPageFile="~/MasterPage/tjm_Sys.master" AutoEventWireup="true" CodeFile="tjm_sys.aspx.cs" Inherits="tjm_sys" Title="欢迎使用同济大学医学院网站系统" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CssClass/tjm_sys.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><%--phctnt_body--%>
<div style="width: 960px; margin-left: auto; margin-right: auto;">
        <div id="Navigation">
            <asp:Panel ID="pnl_nav" runat="server" Width="100%" BackColor="#EDEDED">
            </asp:Panel>
        </div>
        <div id="Content">
            <iframe name="ifrm_content" id="ifrm_content" scrolling="no" frameborder="0" width="738px"  height="100%"></iframe>
            <script language="javascript" type="text/javascript">
                function reInitial(){
                    var iframe = document.getElementById("ifrm_content");
                    try{
                    if(iframe.contentWindow.document.documentElement.scrollHeight>600){
                        iframe.height =  iframe.contentWindow.document.documentElement.scrollHeight;
                    }
                    else {
                        iframe.height=600;
                    }
                    }catch (ex){}
                }
                window.setInterval("reInitial()", 200);
            </script>
        </div>
    	<div style="clear"></div>
    </div>
</asp:Content>

