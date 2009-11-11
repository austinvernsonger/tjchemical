<%@ Page Title="" Language="C#"  MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true"
    CodeFile="StudentTrainingPlan.aspx.cs" Inherits="Teaching_StudentTrainingPlan" %>

<%@ Register Src="~/UserControl/Calendar.ascx" TagName="Calendar" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/ViewMMT.ascx" TagName="ViewMMT" TagPrefix="uc2" %>
<%@ Register Src="../LinkListEx.ascx" TagName="LinkListEx" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../CssClass/TeachingFront.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" runat="Server">
    <div style="width: 902px; margin-left: auto; margin-right: auto; background-image: url(../../Resources/Images/mid_body_up.jpg);
        border: 0; padding: 0;">
    </div>
    <div style="width: 902px; margin-left: auto; margin-right: auto; background-image: url(../../Resources/Images/mid_body_mid.jpg);
        border: 0; padding: 0;">
        <div style="width: 422px; margin-left: auto; margin-right: auto; border: 0; padding: 0;">
            <div>
                <div style="padding-top: 3px; float: left; height: 16px;">
                    学年：</div>
                <div>
                    <asp:DropDownList ID="DDLYear" runat="server" Height="28px" Width="219px" OnSelectedIndexChanged="DDLYear_SelectedIndexChanged"
                        AutoPostBack="True" DataSourceID="ODSTerm" DataTextField="Term" OnDataBound="AfterDDLYearDataBind"
                        Style="margin-top: 0px">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div style="display: none; visibility: hidden;">
                    <asp:ObjectDataSource ID="ODSTerm" runat="server" SelectMethod="GetTerm" TypeName="Teaching.TeachingODS"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="Type" QueryStringField="Type" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <uc3:LinkListEx ID="LinkListEx" runat="server" IfSort="True" />
        </div>
    </div>
    <div style="width: 902px; margin-left: auto; margin-right: auto; background-image: url(../../Resources/Images/mid_body_down.jpg);
        border: 0; padding: 0;">
    </div>
</asp:Content>
