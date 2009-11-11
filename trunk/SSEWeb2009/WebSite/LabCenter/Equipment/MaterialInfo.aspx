<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaterialInfo.aspx.cs" Inherits="LabCenter_Equipment_MaterialInfo" %>

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
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="MaterialName" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5"
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
           <asp:BoundField DataField="MaterialName" HeaderText="耗材名称" />
           <asp:BoundField DataField="Account" HeaderText="数量" />
           <asp:BoundField DataField="Unit" HeaderText="单位" />
           <asp:BoundField DataField="Status" HeaderText="是否开放领用" />
           <asp:BoundField DataField="Remark" HeaderText="备注" />
           
        </Columns>
        </asp:GridView>
         <asp:Button ID="AddButton" runat="server" Text="添加" OnClick="AddButton_Click" />
        <asp:Button ID="btndel" runat="server" Text="删除" OnClick="btndel_Click" />
        <asp:Button ID="Button1" runat="server" Text="导出"  OnClick="Button1_Click"/>
        <asp:DetailsView ID="DetailsView1" runat="server"   AutoGenerateRows="False" 
            OnModeChanging="DetailsView1_ModeChanging" 
            OnItemInserting="DetailsView1_ItemInserting" 
            OnItemUpdating="DetailsView1_ItemUpdating" ReadOnly="True">
        <HeaderTemplate>耗材的详细信息</HeaderTemplate>
        <fields>
         <asp:BoundField DataField="MaterialName" HeaderText="耗材名称" />
           <asp:BoundField DataField="Account" HeaderText="数量" />
           <asp:BoundField DataField="Unit" HeaderText="单位" />
           <asp:BoundField DataField="Status" HeaderText="是否开放领用" />
           <asp:BoundField DataField="Remark" HeaderText="备注" />
        
        <asp:CommandField ShowInsertButton="true" NewText="" />  <asp:CommandField ShowEditButton="true" />
        
        </fields>
        <HeaderStyle BackColor="#E0F2FF" Font-Bold="true" ForeColor="teal" />
        </asp:DetailsView>
    </div>
    </form>
</body>
</html>
