<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LabCenter/MasterPages/HomeMaster.master" CodeFile="UserDeviceApplyTable.aspx.cs" Inherits="LabCenter_Equipment_UserDeviceApplyTable" %>

<%@ Register src="../NavUserControls/Equipment.ascx" tagname="Equipment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Equipment ID="Equipment1" runat="server" />
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

    <div id="InnerContainer">
    <h3>设备借用记录</h3>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="ApplyId" AllowPaging="True" 
            OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5"
        OnRowDataBound="GridView1_RowDataBound" ForeColor="#333333" GridLines="None"
        >
        
        <RowStyle BackColor="#EFF3FB" />
        
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
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:Button ID="btndel" runat="server" Text="取消申请" OnClick="btndel_Click" />
        
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="ApplyId" AllowPaging="True" 
            OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="5"
        OnRowDataBound="GridView2_RowDataBound" ForeColor="#333333" GridLines="None"
        >
        
            <RowStyle BackColor="#EFF3FB" />
        
        <Columns>
             
              <asp:TemplateField>
                  <ItemTemplate><asp:CheckBox ID="checkdel" runat="server" /> </ItemTemplate>  
                      <HeaderTemplate>
                             <asp:CheckBox ID="check_all1" runat="server" Text="全选"  onclick="javascript:SelectAll(this);"  />
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
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
</asp:Content>    
