<%@ Page Title="" Language="C#" MasterPageFile="~/Admission/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Admission_Admin_test" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <!-- <div style="position:relative;float:none">
       <asp:Panel ID="Panel1" runat="server" DefaultButton="BtCommit">
           <asp:Label ID="Label1" runat="server" Text="请输入你要删除的管理员ID（工号或学号）"></asp:Label>
           <br />
           <asp:TextBox ID="TbAmdinId" runat="server" Width="228px"></asp:TextBox>
         
       
        
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入ID"
               ControlToValidate="TbAmdinId" Display="Static">请输入ID</asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="格式错误"
               Display="Static" ControlToValidate="TbAmdinId">格式错误</asp:RegularExpressionValidator>
           <br />
           <br />
           <asp:Button ID="BtCommit" runat="server" Text="选择" Style="height: 26px" />-->
        <!--
          
           <br />
           <asp:Panel ID="Panel2" runat="server">
               <table id="table3" style="width: 100%">
                   <tr style="width: 50%">
                       <td>
                           <asp:Label ID="Label2" runat="server" Text="原管理员信息" Font-Bold="True" Font-Italic="False"
                               Font-Names="MS Reference Sans Serif" Font-Size="Large" ForeColor="#CC66FF"></asp:Label>
                           <br />
                           <br />
                           <br />
                           <asp:Label ID="LbId" runat="server" Text="管理员ID：  " ForeColor="#9966FF"></asp:Label>
                           <br />
                           <br />
                           <br />
                           <asp:Label ID="LbPwd" runat="server" Text="管理员密码：  " ForeColor="#9966FF"></asp:Label>
                           <br />
                           <br />
                           <br />
                           <asp:Label ID="LbAuthorrity" runat="server" Text="管理员权限：  " ForeColor="#9966FF"></asp:Label>
                       </td>
                       <td>
                           <table id="table4" style="width: 100%">
                               <tr>
                                   <td>
                                       <asp:Label ID="Label3" runat="server" Text="新用户信息"></asp:Label>
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       <asp:Label ID="Label4" runat="server" Text="新工号或学号"></asp:Label>
                                   </td>
                                   <td>
                                       <asp:TextBox ID="TbNewId" runat="server" Width="192px"></asp:TextBox>
                                       <!--
                                    
                             
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入ID"
                                           ControlToValidate="TbNewId" Display="Static">请输入ID</asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="输入格式错误"
                                           Display="Static" ControlToValidate="TbNewId">输入格式错误</asp:RegularExpressionValidator>
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       <asp:Label ID="Label5" runat="server" Text="新密码"></asp:Label>
                                   </td>
                                   <td>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入密码">请输入密码</asp:RequiredFieldValidator>
                                       <asp:TextBox ID="TbNewPwd" runat="server" Width="188px"></asp:TextBox>
                                   </td>
                               </tr>
                               <tr>
                                   <td colspan="2">
                                       <asp:Label ID="Label6" runat="server" Text="请选择他所具有的管理权限" ForeColor="Lime"></asp:Label>
                                       <br />
                                       <br />
                                       <div id="chckbxStyle">
                                           <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="78px" Width="107px">
                                               <asp:ListItem>高考生</asp:ListItem>
                                               <asp:ListItem>工学硕士</asp:ListItem>
                                               <asp:ListItem>工程硕士</asp:ListItem>
                                               <asp:ListItem>专业学位</asp:ListItem>
                                           </asp:CheckBoxList>
                                       </div>
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       <asp:Button ID="Button1" runat="server" Text="提交" />
                                   </td>
                               </tr>
                           </table>
                       </td>
                   </tr>
               </table>
           </asp:Panel>
          
       </asp:Panel>
   </div>  -->
  
</asp:Content>

