<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceApplyTable.aspx.cs" Inherits="LabCenter_Equipment_DeviceApplyTable" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <script language="javascript">
       function SelectAll(tempControl)
       {
           //将除头模板中的其它所有的CheckBox取反 

            var theBox=tempControl;
             xState=theBox.checked;    

            elem=theBox.form.elements;
            for(i=0;i<elem.length;i++)
            if(elem[i].type=="checkbox" && elem[i].id!=theBox.id)
             {
                  if(elem[i].checked!=xState)
                        elem[i].click();
            }
  }   
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="1px" CellPadding="4"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="ApplyId" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5"
        OnRowDataBound="GridView1_RowDataBound"
        >
        <Columns>
             
              <asp:TemplateField>
                  <ItemTemplate><asp:CheckBox ID="checkdel" runat="server" /> </ItemTemplate>  
                      <HeaderTemplate>
                             <asp:CheckBox ID="check_all" runat="server" Text="全选"  onclick="javascript:SelectAll(this);"  />
                        </HeaderTemplate>
              </asp:TemplateField>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField HeaderText="申请编号">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"   Text='<%# Bind("ApplyId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ApplyId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="设备名称">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"  Text='<%# Bind("DeviceName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DeviceName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请人编号">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"   Text='<%# Bind("ApplierId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("ApplierId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="申请时间">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server"   Text='<%# Bind("Date") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请状态">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
        </asp:GridView>
        <asp:Button ID="btndel" runat="server" Text="删除" OnClick="btndel_Click" />
        <asp:DetailsView ID="DetailsView1" runat="server"   AutoGenerateRows="False" OnModeChanging="DetailsView1_ModeChanging"  OnItemUpdating="DetailsView1_ItemUpdating" ReadOnly="True">
        <HeaderTemplate>耗材的详细信息</HeaderTemplate>
        <fields>
            <asp:TemplateField HeaderText="申请编号">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" Text='<%# Bind("ApplyId") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ApplyId") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ApplyId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="设备名称">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"  ReadOnly="true" Text='<%# Bind("DeviceName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DeviceName") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DeviceName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请人编号">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true" Text='<%# Bind("ApplierId") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ApplierId") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("ApplierId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="申请时间">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" ReadOnly="true" Text='<%# Bind("Date") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否批准">
                <EditItemTemplate>
                    
                   <asp:DropDownList ID="DropDownList1" runat="server">
                    
                    <asp:ListItem Value="1">允许</asp:ListItem>
                    <asp:ListItem Value="2">拒绝</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server"  TextMode="MultiLine" Text='<%# Bind("Remark") %>'></asp:TextBox>
                    
                    
                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ControlToValidate="TextBox7" ValidationExpression="([\u4e00-\u9fa5]|[^\u4e00-\u9fa5]){0,500}" runat="server" ErrorMessage="请勿输入超过500个字！"></asp:RegularExpressionValidator>
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" ReadOnly="true" TextMode="MultiLine" Text='<%# Bind("Remark") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
        
        </fields>
        <HeaderStyle BackColor="#E0F2FF" Font-Bold="True" ForeColor="Teal" />
        </asp:DetailsView>
    </div>
    </form>
</body>
</html>

