<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkListEx.ascx.cs" Inherits="Teaching_LinkListEx" %>
<asp:GridView ID="LinkListView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    BorderStyle="None" GridLines="None" ShowHeader="False" Style="font-weight: 700"
    Width="422px" DataSourceID="ODSLinkList" BackColor="White" BorderColor="#E7E7FF"
    BorderWidth="1px" CellPadding="3">
    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" VerticalAlign="Top" />
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                    <table style="width: 422px; font-family: 宋体, Arial, Helvetica, sans-serif; font-size: 14px;
                        text-decoration: none; color: #262626;">
                        <tr>
                            <td align="left" style="width: 318px;">
                                <img alt="" src="../Resources/Images/tag.gif" style="width: 9px; height: 13px" />&nbsp;
                                <asp:HyperLink ID="hl_HyperLink" Font-Underline="false" ForeColor="Gray" runat="server"
                                    NavigateUrl='<%#Request.CurrentExecutionFilePath+ "?DocumentID=" + Eval("ID") + (PostParam.Text==""?"":"&"+PostParam.Text) %>'><%#Eval("Title")%></asp:HyperLink>
                            </td>
                            <td style="width: 42px;">
                                <asp:HyperLink ID="hl_HyperLinkSE" Font-Underline="false" ForeColor="Gray" runat="server"
                                    NavigateUrl='<%#strTargetPageSE +Eval("ID") %>' ToolTip='<%#TargetPageSEToolTip %>'
                                    Visible='<%#strTargetPageSE.Length!=0 %>'>总结</asp:HyperLink>
                            </td>
                            <td style="width: 42px;">
                                <asp:Label ID="FState" runat="server" Style='<%# Eval("FS").ToString()=="0"? "color:gray;": (Eval("FS").ToString() == "1" ? "color:green;" : "color:red;") %>'
                                    ToolTip="审核状态">
                            <%#Eval("FS").ToString()=="-1"? "" :(Eval("FS").ToString()=="0"? "未审批" :  (Eval("FS").ToString() == "1" ? "通过" : "未通过"))%>
                                </asp:Label>
                            </td>
                            <td style="width: 20px">
                                <asp:ImageButton ID="ImageButton" runat="server" Visible='<%#DeleteString.Length!=0 %>'
                                    ImageUrl="../Resources/Images/delete.GIF" PostBackUrl='<%#Request.CurrentExecutionFilePath+ "?DeleteID=" + Eval("ID") + (PostParam.Text==""?"":"&"+PostParam.Text) %>'
                                    ToolTip="删除" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" 
        VerticalAlign="Top" />
    <EmptyDataTemplate>
        没有数据...
    </EmptyDataTemplate>
    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
    <AlternatingRowStyle BackColor="White" VerticalAlign="Top" Wrap="True" />
</asp:GridView>




<div style="display: none; visibility: hidden;">

    <asp:ObjectDataSource ID="ODSLinkList" runat="server" SelectMethod="GetList" 
        TypeName="Teaching.LinkListODS" DeleteMethod="DeleteLine">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="SQL" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="SQLstr" Name="SQL" PropertyName="Text" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:TextBox ID="SQLstr" runat="server"></asp:TextBox>
    <asp:TextBox ID="PostParam" runat="server"></asp:TextBox>
</div>




