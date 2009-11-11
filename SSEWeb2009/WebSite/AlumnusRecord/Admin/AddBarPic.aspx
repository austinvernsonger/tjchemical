<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnusRecord/Admin/MasterPageBack.master" AutoEventWireup="true" CodeFile="AddBarPic.aspx.cs" Inherits="AlumnusRecord_Admin_AddBarPic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="varContent" Runat="Server">




    <table style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="左边栏第一幅："></asp:Label>
              <asp:FileUpload ID="FileUpload1" runat="server" />
              
                 <asp:Label ID="Label5" runat="server" ForeColor="Red" ></asp:Label>
              </td>
             
        </tr>
        <tr>
            <td>
             <asp:Label ID="Label1" runat="server" Text="左边栏第二幅："></asp:Label>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:Label ID="Label6" runat="server" ForeColor="Red" ></asp:Label>
                </td>
                  
        </tr>
        <tr>
            <td>
             <asp:Label ID="Label3" runat="server" Text="右边栏第一幅："></asp:Label>
              <asp:FileUpload ID="FileUpload3" runat="server" />
              
              <asp:Label ID="Label7" runat="server" ForeColor="Red" ></asp:Label>
              </td>
                
        </tr>
        <tr>
            <td>
             <asp:Label ID="Label4" runat="server" Text="右边栏第二幅："></asp:Label>
              <asp:FileUpload ID="FileUpload4" runat="server" />
               <asp:Label ID="Label8" runat="server" ForeColor="Red" ></asp:Label>
              </td>
               
        </tr>
    </table>


    <asp:Button ID="Button1" runat="server" Text="提交" onclick="Button1_Click" />

    

   
    
</asp:Content>

