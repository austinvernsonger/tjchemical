<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default_menu.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="RecruitmentNew_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 {
            width: 100%;
        }
        .style2 {
            height: 30px;
            font-family: 隶书;
            font-size: xx-large;
            letter-spacing: 5px;
            color:#0ffff0;
        }
        .styleLink {
            font-family: 宋体;
            font-size: large;
            font-style:italic;
            color:yellow;
            color:#00ffaa;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" runat="Server">
    <cc1:RoundedCornersExtender ID="rndcnrex_first_day" TargetControlID="Panel1" runat="server"
        BorderColor="#00ffaa" Corners="Bottom" Radius="5" Color="#00fff0">
    </cc1:RoundedCornersExtender>
    <asp:Panel ID="Panel1" runat="server" Width="78%" Style="margin-left: 11%; margin-bottom: 10px">
        <table id="table1" class="style1" style="height: 300px; margin-right: 10%" width="80%">
            <tr>
                <td>
                    <table id="table2" class="style1" style="background-image: url('./img/test.jpg');
                        height: 300px;">
                        <tr>
                            <td class="style2">
                                高考生
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Admission/ViewStu.aspx?type=HghStu_Booklet"
                                    CssClass="styleLink">招生简章</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Admission/ViewStu.aspx?type=HghStu_Policy"
                                    CssClass="styleLink">招生政策</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/Admission/ViewStu.aspx?type=HghStu_Question"
                                    CssClass="styleLink">招生问答</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table id="table3" class="style1" style="background-image: url('./img/test.jpg');
                        height: 300px;">
                        <tr>
                            <td class="style2">
                            工程硕士
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/RecruitmentNew/View.aspx?type=EngMaster_Booklet"
                                    CssClass="styleLink">招生简章</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/RecruitmentNew/View.aspx?type=EngMaster_Policy"
                                    CssClass="styleLink">招生政策</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/RecruitmentNew/View.aspx?type=EngMaster_Question"
                                    CssClass="styleLink">招生问答</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table id="table4" class="style1" style="background-image: url('./img/test.jpg')"
                        style="height: 300px;">
                        <tr>
                            <td class="style2">
                                工学硕士
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton7" runat="server" PostBackUrl="~/RecruitmentNew/View.aspx?type=IndMaster_Booklet"
                                    CssClass="styleLink">招生简章</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton8" runat="server" PostBackUrl="~/RecruitmentNew/View.aspx?type=IndMaster_Policy"
                                    CssClass="styleLink">招生政策</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="~/RecruitmentNew/View.aspx?type=IndMaster_Question"
                                    CssClass="styleLink">招生问答</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table id="table5" class="style1" style="background-image: url('./img/test.jpg')"
                        style="height: 300px;">
                        <tr>
                            <td class="style2">
                                专业学位
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton10" runat="server" PostBackUrl="~/RecruitmentNew/View.aspx?type=ProDegree_Booklet"
                                    CssClass="styleLink">招生简章</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton11" runat="server" PostBackUrl="~/RecruitmentNew/View.aspx?type=ProDegree_Policy"
                                    CssClass="styleLink">招生政策</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButton12" runat="server" PostBackUrl="~/RecruitmentNew/View.aspx?type=ProDegree_Question"
                                    CssClass="styleLink">招生问答</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
