<%@ Page Title="" Language="C#" MasterPageFile="~/Admission/Admin/MasterPage.master"
    AutoEventWireup="true" CodeFile="AdminRev.aspx.cs" Inherits="RecruitmentNew_Admin_AdminRev" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="table2" style="width: 100%">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="BtCommit" Font-Italic="True"
        Font-Bold="True">
        <asp:Label ID="Label1" runat="server" Text="��������Ҫɾ���Ĺ���ԱID�����Ż�ѧ�ţ�"></asp:Label>
        <br />
        <asp:TextBox ID="TbAmdinId" runat="server" Width="228px"></asp:TextBox>
       <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetCompletionList"
            UseContextKey="True" TargetControlID="TbAdminId">
        </cc1:AutoCompleteExtender>
        
        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="TbAmdinId"
            WatermarkText="����ԱID" WatermarkCssClass="watermarked">
        </cc1:TextBoxWatermarkExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="������ID"
            ControlToValidate="TbAmdinId" Display="Static">������ID</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="��ʽ����"
            Display="Static" ControlToValidate="TbAmdinId">��ʽ����</asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="BtCommit" runat="server" Text="ѡ��" OnClick="BtCommit_Click" Style="height: 26px" />
        <cc1:PopupControlExtender ID="RevisePage" runat="server" PopupControlID="Panel2"
            TargetControlID="BtCommit">
        </cc1:PopupControlExtender>
        <br />
        <asp:Panel ID="Panel2" runat="server">
            <table id="table3" style="width: 100%">
                <tr style="width: 50%">
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="ԭ����Ա��Ϣ" Font-Bold="True" 
                            Font-Italic="False" Font-Names="MS Reference Sans Serif" Font-Size="Large" 
                            ForeColor="#CC66FF"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="LbId" runat="server" Text="����ԱID��  " ForeColor="#9966FF"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="LbPwd" runat="server" Text="����Ա���룺  " ForeColor="#9966FF"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="LbAuthorrity" runat="server" Text="����ԱȨ�ޣ�  " ForeColor="#9966FF"></asp:Label>
          
                    </td>
                    <td>
                        <table id="table4" style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="���û���Ϣ"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="�¹��Ż�ѧ��"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TbNewId" runat="server"  Width="192px"></asp:TextBox>
                                    <!--
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="TbNewId"
                                        WatermarkText="�¹���ԱID" WatermarkCssClass="watermarked">
                                    </cc1:TextBoxWatermarkExtender>
                                    -->
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="������ID"
                                        ControlToValidate="TbNewId" Display="Static">������ID</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="�����ʽ����"
                                        Display="Static" ControlToValidate="TbNewId">�����ʽ����</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="������"></asp:Label>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="����������">����������</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TbNewPwd" runat="server" Width="188px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label6" runat="server" Text="��ѡ���������еĹ���Ȩ��" ForeColor="Lime"></asp:Label>
                                    <br />
                                    <br />
                                    <div id="chckbxStyle">
                                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="78px" Width="107px">
                                            <asp:ListItem>�߿���</asp:ListItem>
                                            <asp:ListItem>��ѧ˶ʿ</asp:ListItem>
                                            <asp:ListItem>����˶ʿ</asp:ListItem>
                                            <asp:ListItem>רҵѧλ</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="�ύ" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
