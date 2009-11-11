<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnusRecord/MasterPage.master" AutoEventWireup="true" CodeFile="gradeList.aspx.cs" Inherits="gradeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div class="GreenBar">所有毕业年级</div>   
    <asp:DataList ID="DataList1" runat="server" DataSourceID="XmlDs1" 
    Width="100%" CellPadding="4" ForeColor="#333333">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#E3EAEB" />
        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
            <a href='alumniList.aspx?year=<%#Eval("graduatingYear") %>&degree=<%#Eval("graduatingType").ToString().Trim() == "本科" ? "0":"1" %>'>     
                <asp:Image ID="Image1" runat="server" 
                ImageUrl='<%# Eval("graduatingImage") %>' Width="300px" Height="200px" />      <%# Eval("graduatingType")%>毕业生<%#Eval("graduatingYear") %>级</a>
        </ItemTemplate>
    </asp:DataList>
    <asp:XmlDataSource ID="XmlDs1" runat="server" 
        DataFile="~/AlumnusRecord/Resources/GraduatingPhotographs/gradeinfo.xml"></asp:XmlDataSource>
    <br />
    <p><a href="alumnusCenter.aspx">&lt&lt返回</a></p>
</asp:Content>

