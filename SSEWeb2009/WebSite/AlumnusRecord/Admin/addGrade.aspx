<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnusRecord/Admin/MasterPageBack.master" AutoEventWireup="true" CodeFile="addGrade.aspx.cs" Inherits="addGrade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="varContent" Runat="Server">
    <div><table style="width:100%;">
        <tr>
            <td>
                毕业年份：</td>
            <td>
                <asp:DropDownList runat="server" ID="DropDownListGradYear">
                    <asp:ListItem>2000</asp:ListItem>
                    <asp:ListItem>2001</asp:ListItem>
                    <asp:ListItem>2002</asp:ListItem>
                    <asp:ListItem>2003</asp:ListItem>
                    <asp:ListItem>2004</asp:ListItem>
                    <asp:ListItem>2005</asp:ListItem>
                    <asp:ListItem>2006</asp:ListItem>
                    <asp:ListItem>2007</asp:ListItem>
                    <asp:ListItem>2008</asp:ListItem>
                    <asp:ListItem>2009</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                </asp:DropDownList>
                
                </td>
        </tr>
        <tr>
            <td>
                毕业生类型：</td>
            <td>
                <asp:dropdownlist runat="server" ID="DropdownlistDegree">
                    <asp:ListItem Selected="True" Value="0">本科</asp:ListItem>
                    <asp:ListItem Value="1">硕士</asp:ListItem>
                </asp:dropdownlist>
                <%--<select><option>本科</option><option>硕士</option></select>--%></td>
        </tr>
        <tr>
            <td>
                毕业照位置：</td>
            <td>
                
                <asp:FileUpload runat="server" ID="FileUploadImage"></asp:FileUpload>
                </td>            
        </tr>
        <tr>
            <td><br /></td>
            <td>
                <asp:Label ID="LabelResult" runat="server"></asp:Label>
                <br /></td>        
        </tr>
        <tr align="center">
            <td colspan="2">
            <asp:Button runat="server" Text="添加" ID="ButtonAdd" onclick="Add_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" Text="放弃" ID="ButtonCancel"></asp:Button></td>
        </tr>
    </table></div>
</asp:Content>

