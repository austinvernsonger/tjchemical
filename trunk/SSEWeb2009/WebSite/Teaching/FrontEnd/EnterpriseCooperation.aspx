<%@ Page Title="" Language="C#"  MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true" CodeFile="EnterpriseCooperation.aspx.cs" Inherits="Teaching_Enterprise" %>




<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../LinkListEx.ascx" tagname="LinkListEx" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../CssClass/TeachingFront.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="selec" ContentPlaceHolderID="phctnt_body" Runat="Server">
    <div style="width:902px; margin-left:auto; margin-right:auto; background-image:url(../../Resources/Images/mid_body_up.jpg); border:0; padding:0;"></div>
    <div style="width:902px; margin-left:auto; margin-right:auto; background-image:url(../../Resources/Images/mid_body_mid.jpg); border:0; padding:0;">
        <div style="width:422px; margin-left:auto; margin-right:auto; border:0; padding:0;">
            <div>
                <div style="padding-top:3px; float:left; height:16px;">查询企业：</div>
                <div>
                    <span><asp:TextBox ID="EnterpriseName" runat="server" BorderColor="#7575FF" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox></span>
               
                    <span style="margin-left:10px;">
                    <asp:Button ID="bnSearch" runat="server" 
                        Text="搜索" onclick="bnSearch_Click" 
                     CssClass="btnSearch"/></span>
                </div>
            </div>
            <uc3:LinkListEx ID="LinkListExContent" runat="server" QuerySQL="select *,-1 as FS  from [EnterpriseCooperation]" />
        </div>
    </div>
    <div style="width:902px; margin-left:auto; margin-right:auto; background-image:url(../../Resources/Images/mid_body_down.jpg); border:0; padding:0;"></div>
</asp:Content>

