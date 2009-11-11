<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnusRecord/Admin/MasterPageBack.master" AutoEventWireup="true" CodeFile="manageGrade.aspx.cs" Inherits="manageGrade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="varContent" Runat="Server">
    <!--div style="width:940px;"-->
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
        DataFile="~/AlumnusRecord/Resources/GraduatingPhotographs/gradeinfo.xml"></asp:XmlDataSource> 
    <br />
    <asp:GridView ID="gradeGrid" runat="server" Height="100%" Width="100%"
        DataSourceID="XmlDataSource1" HorizontalAlign="Center" 
        AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" 
        ForeColor="#333333" GridLines="None" onrowupdating="gradeGrid_RowUpdating" 
            onrowupdated="gradeGrid_RowUpdated">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <%--<asp:BoundField DataField="graduatingYear" HeaderText="毕业年份" 
                ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>

            </asp:BoundField>--%>
            <asp:TemplateField HeaderText="毕业年份" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate><asp:Label ID="Label2" runat="server" Text='<%#Eval("graduatingYear","{0}级") %> ' /></ItemTemplate>                
                <EditItemTemplate>
                    <asp:Label ID="LabelGradYear" runat="server" Text='<%#Eval("graduatingYear") %>' />
                </EditItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField> 
            
            <asp:TemplateField HeaderText="毕业生类型" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%#Eval("graduatingType") %>' /></ItemTemplate>                
                <EditItemTemplate>
                    <asp:Label ID="LabelDegree" runat="server" Text='<%#Eval("graduatingType") %>' />
                </EditItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="毕业照位置" ControlStyle-Width="100%" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate><asp:Label ID="Label3" runat="server" Text='<%#Eval("graduatingImage") %>'></asp:Label></ItemTemplate>                
                <EditItemTemplate>
                    <asp:FileUpload ID="FileUploadImage" runat="server" Width="100%"/>
                </EditItemTemplate>

<ControlStyle Width="100%"></ControlStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>          
            <asp:CommandField HeaderText="操作" ShowEditButton="True" ItemStyle-HorizontalAlign="Center" 
                ShowHeader="True" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <!--/div-->             
</asp:Content>

