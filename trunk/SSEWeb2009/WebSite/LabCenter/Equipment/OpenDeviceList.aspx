<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpenDeviceList.aspx.cs" Inherits="LabCenter_Equipment_OpenDeviceList" %>

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
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="DeviceId" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5"
        OnRowDataBound="GridView1_RowDataBound" Width="600px"
        >
        <Columns>
             
              <asp:TemplateField>
                  <ItemTemplate><asp:CheckBox ID="checkdel" runat="server" /> </ItemTemplate>  
                      <HeaderTemplate>
                             <asp:CheckBox ID="check_all" runat="server" Text="全选"  onclick="javascript:SelectAll(this);"  />
                        </HeaderTemplate>
              </asp:TemplateField>
            <asp:CommandField ShowSelectButton="True" />
       <asp:BoundField DataField="DeviceID" HeaderText="设备名称" />
      
        <asp:BoundField DataField="Remark" HeaderText="备注"/>
        </Columns>
        </asp:GridView>
        <asp:Button ID="btndel" runat="server" Text="删除" OnClick="btndel_Click" />
        <asp:DetailsView ID="DetailsView1" runat="server"   AutoGenerateRows="false" OnModeChanging="DetailsView1_ModeChanging" OnItemInserting="DetailsView1_ItemInserting" OnItemUpdating="DetailsView1_ItemUpdating" ReadOnly="True" Width="600px" >
        <HeaderTemplate>可领用设备表</HeaderTemplate>
        <fields>
        <asp:BoundField DataField="DeviceID" HeaderText="设备名称" />
      
        <asp:BoundField DataField="Remark" HeaderText="备注"/>
        
        <asp:CommandField ShowInsertButton="True" />  <asp:CommandField ShowEditButton="True" />
        
        </fields>
        <HeaderStyle BackColor="#E0F2FF" Font-Bold="True" ForeColor="Teal" />
        </asp:DetailsView>
    </div>
    </form>
</body>
</html>
