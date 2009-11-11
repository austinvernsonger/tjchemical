<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnusRecord/MasterPage.master" AutoEventWireup="true" CodeFile="alumnusDetails.aspx.cs" Inherits="alumnusDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="GreenBar">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
        <asp:LinkButton ID="LinkButton5" runat="server" 
            PostBackUrl="~/AlumnusRecord/alumnusCenter.aspx">����Ժ������</asp:LinkButton>
    
    </div>
    
    
    <div>

        <table class="style1">
            <tr>
            <td class="style4">
            </td>
                <td class="style2">
                    <asp:Image ID="Image1" runat="server" Height="160px" Width="120px" />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButtonChange" runat="server" 
                        onclick="LinkButtonChange_Click" style="text-align: center">����ͷ��</asp:LinkButton>
                    <br />
                    <asp:FileUpload ID="FileUploadImg" runat="server" Height="22px" 
                        Visible="false" Width="134px" />
                    <br />
                    <br />
                    <asp:Button ID="ButtonUpload" runat="server" onclick="ButtonUpload_Click" 
                        Text="�ϴ�" Visible="false" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonCancel" runat="server" Text="ȡ��" Visible="false" />
                </td>
                <td class="style3">
                    <asp:FormView ID="FormView1" runat="server" 
                        onitemupdated="FormView1_ItemUpdated" onitemupdating="FormView1_ItemUpdating" 
                        onmodechanging="FormView1_ModeChanging">
                        <EditItemTemplate>
                            ������&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <%#Eval("Name") %>
                            <br />
                            <br />
                            ѧ�ţ�&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <%#Eval("StudentID") %>
                            <br />
                            <br />
                            ѧ����&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <%#Eval("Degree") %><br />
                            <br />
                            ���᣺&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxOrigin" runat="server" Text='<%#Eval("Origin") %>'></asp:TextBox>
                            <br />
                            <br />
                            ��ѧ�㣺&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxTeachPoint" runat="server" 
                                Text='<%#Eval("TeachingPoint") %>'></asp:TextBox>
                            <br />
                            <br />
                            ��ҵ��ݣ�&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <%#Eval("GraduateYear") %>��<br />
                            <br />
                            ������λ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxWorkPlace" runat="server" 
                                Text='<%#Eval("WorkPlace") %>'></asp:TextBox>
                            <br />
                            <br />
                            ��ַ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxAddress" runat="server" 
                                Text='<%#Eval("WorkAddress") %>'></asp:TextBox>
                            <br />
                            <br />
                            �绰��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:TextBox>
                            <br />
                            <br />
                            ���䣺&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxEmail" runat="server" Text='<%#Eval("Email") %>'></asp:TextBox>
                            <br />
                            <br />
                            ��Ϣ�Ƿ񹫿���&nbsp;&nbsp;
                            <asp:DropDownList ID="DropDownListPub" runat="server">
                                <asp:ListItem Text="����" Value="1" />
                                <asp:ListItem Text="������" Value="0" />
                            </asp:DropDownList>
                            <br />
                            <br />
                            ��ҵ��� &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxSummary" runat="server" Columns="4" Height="86px" 
                                Text='<%#Eval("Summary") %>' TextMode="MultiLine" Width="182px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update">�ύ</asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel">ȡ��</asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            ������&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("Name") %><br />
                            <br />
                            ѧ�ţ�&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("StudentID") %><br />
                            <br />
                            ѧ����&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("Degree").ToString().Trim() == "0" ? "����" : "˶ʿ" %> 
                            <br />
                            <br />
                            ���᣺&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("Origin") %><br />
                            <br />
                            ��ѧ�㣺&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("TeachingPoint") %><br />
                            <br />
                            ��ҵ��ݣ�&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("GraduateYear") %>��<br />
                            <br />
                            ������λ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("WorkPlace") %><br />
                            <br />
                            ��ַ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("WorkAddress") %><br />
                            <br />
                            �绰��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("Phone") %><br />
                            <br />
                            ���䣺&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("Email") %><br />
                            <br />
                            ��Ϣ�Ƿ񹫿���&nbsp;&nbsp; <%#Eval("Publicity").ToString().Trim() == "1" ? "����" : "������" %><br />
                            <br />
                            ��ҵ���&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("Summary") %>
                            <br />
                            <br />
                            <br />
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">������Ϣ</asp:LinkButton>
                        </ItemTemplate>
                    </asp:FormView>
                </td>
            </tr>
        </table>

    </div>
    
    
    <%--<div class="BlueBlock" style="width:;">
        <div id="BarTitle"><span>����xxxx���ҵ��</span></div>
        <div style="width:100%;">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <a href='alumnusDetails.aspx?id=<%#Eval("StudentID") %>'><%#Eval("name") %></a><br />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>--%>       
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 314px;
            height: 412px;
        }
        .style3
        {
            height: 412px;
        }
        .style4
        {
            width: 153px;
        }
    </style>

</asp:Content>


