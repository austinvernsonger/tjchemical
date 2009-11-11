<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="SearchManager.aspx.cs" Inherits="_SearchManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head  runat="server">
    <title>无标题页</title>
</head>
<body>    
    <form id="form1" runat="server">   
    <div>

<h2>添加管理员</h2>
<br/>
<asp:Label ID="Label1" Text="请输入工号或学号" runat="server"></asp:Label>
<asp:TextBox ID="IDinput" runat="server" Width="100px"></asp:TextBox>
<asp:Button ID="AddSubmit" Text="确定" runat="server" OnClick="AddSubmit_Click" />

<br/><br/><br/><br/><br/>
<hr />
<br/><br/><br/><br/><br />

<h2>搜索管理员</h2>

<asp:Label ID="Label2" Text="请输入工号或学号" runat="server"></asp:Label>
<asp:TextBox ID="ConditionInput" runat="server" Width="100px"></asp:TextBox>
 <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
     <asp:ListItem Text="按工号/学号" value="1" Selected="True"></asp:ListItem>
     <asp:ListItem Text="按姓名" Value="2" ></asp:ListItem>
 </asp:RadioButtonList>
 <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
 <asp:UpdatePanel UpdateMode="Always" runat="server" ID="updatePanel1">
 <ContentTemplate>
<asp:Button ID="SearchSubmit" Text="搜索" runat="server" OnClick="SearchSubmit_Click" />
<asp:Button ID="GetAllSubmit" Text="查看所有管理员" runat="server" OnClick="GetAllSubmit_Click"/>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="8" DataKeyNames="帐号"
    OnRowCommand="GridView1_OnRowCommand" 
         OnPageIndexChanged="GridView1_PageIndexChanged" 
         OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4" 
         ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
     <Columns>
         <asp:TemplateField HeaderText="" ShowHeader="true">
           <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Details"
             Text="详细信息" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
           </ItemTemplate>     
         </asp:TemplateField>
          <asp:TemplateField HeaderText="" ShowHeader="true">
           <ItemTemplate>
             <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Deletes"
             Text="删除" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
           </ItemTemplate>     
         </asp:TemplateField>
      </Columns>  
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
   
    </ContentTemplate>
 <Triggers>
    <asp:AsyncPostBackTrigger ControlID="SearchSubmit" EventName="Click" />
    <asp:AsyncPostBackTrigger ControlID="GetAllSubmit" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
   


  </div>
    </form>
    
</body>
</html>