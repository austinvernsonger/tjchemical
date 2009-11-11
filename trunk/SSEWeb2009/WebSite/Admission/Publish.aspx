<%@ Page Title="" Language="C#" MasterPageFile="~/Admission/MasterPage.master" AutoEventWireup="true" CodeFile="Publish.aspx.cs" Inherits="RecruitmentNew_Publish" %>

<%@ Register Src="../UserControl/EditMMT.ascx" TagName="EditMMT" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table id="table2">
            <tr>
                <td align="right">
                    请选择您面向的招生群体
                </td>
                <td>
                    <asp:DropDownList ID="DDGroup" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="DDGroup_SelectedIndexChanged">
                        <asp:ListItem Value="HghStu_" Selected="True">高考生</asp:ListItem>
                        <asp:ListItem Value="EngMaster_">工程硕士</asp:ListItem>
                        <asp:ListItem Value="IndMaster_">工学硕士</asp:ListItem>
                        <asp:ListItem Value="ProDegree_">专业学位</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    请选择发布的文件种类
                </td>
                <td>
                    <asp:DropDownList ID="DDKind" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="DDKind_SelectedIndexChanged">
                        <asp:ListItem Value="Question">招生问答</asp:ListItem>
                        <asp:ListItem Value="Policy">招生政策</asp:ListItem>
                        <asp:ListItem Value="Booklet" Selected="True">招生简章</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <div>
            <uc1:EditMMT id="EditMmtContent" runat="server" DepartmentId="8" Mode="passage" OnSuccessGoTo="~/Default.aspx"
                NewPost="False" />
        </div>
    
</asp:Content>

