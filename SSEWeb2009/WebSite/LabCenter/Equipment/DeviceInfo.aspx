<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceInfo.aspx.cs" Inherits="LabCenter_Equipment_DeviceInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
        <asp:GridView ID="GridView1" runat="server" BorderWidth="1px" CellPadding="4"
        
            DataKeyNames="DeviceId" AllowPaging="True" OnRowCommand="GridView1_OnRowCommand"
            OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5"
        OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False"
        >
        <Columns>
             
              <asp:TemplateField>
              
                  <ItemTemplate><asp:CheckBox ID="checkdel" runat="server" /> </ItemTemplate>  
                      <HeaderTemplate>
                             <asp:CheckBox ID="check_all" runat="server" Text="全选"  onclick="javascript:SelectAll(this);"  />
                        </HeaderTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="" ShowHeader="true">
           <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Details"
             Text="详细信息" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
           </ItemTemplate>     
         </asp:TemplateField>
           <asp:BoundField DataField="DeviceId" HeaderText="仪器编号" />
            
           <asp:BoundField DataField="DeviceName" HeaderText="设备名称" />
           <asp:BoundField DataField="Account" HeaderText="数量" />
           <asp:BoundField DataField="Status" HeaderText="现状" />
           <asp:BoundField DataField="Location" HeaderText="存放地点" />
           <asp:BoundField DataField="User" HeaderText="使用人" />
        </Columns>
        </asp:GridView>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Label ID="ImportLabel" runat="server" Text="(导入文件)"></asp:Label>
        <br />
        <asp:Button ID="ImportBtn" runat="server" Text="导入" OnClick="ImportBtn_Click" />
         <asp:Button ID="AddBtn" runat="server" Text="添加" OnClick="AddBtn_Click" />
        <asp:Button ID="btndel" runat="server" Text="删除" OnClick="btndel_Click" />
        <asp:Button ID="Button1" runat="server" Text="导出"  OnClick="Button1_Click"/>
        <asp:DetailsView ID="DetailsView1" runat="server"   AutoGenerateRows="False" 
            OnModeChanging="DetailsView1_ModeChanging" 
            OnItemInserting="DetailsView1_ItemInserting" 
            OnItemUpdating="DetailsView1_ItemUpdating" ReadOnly="True">
        <HeaderTemplate>设备的详细信息</HeaderTemplate>
        <fields>
        <asp:BoundField DataField="DeviceID" HeaderText="仪器编号" />

        <asp:BoundField DataField="DeviceName" HeaderText="设备名称"/>
        <asp:BoundField DataField="Model" HeaderText="型号"/>
        <asp:BoundField DataField="Format" HeaderText="规格"/>
        <asp:BoundField DataField="Account" HeaderText="数量"/>
        <asp:BoundField DataField="Price" HeaderText="单价"/>
        <asp:BoundField DataField="Date" HeaderText="购置日期"/>
        <asp:BoundField DataField="Factory" HeaderText="厂家"/>
        <asp:BoundField DataField="Status" HeaderText="现状"/>
        <asp:BoundField DataField="Location" HeaderText="存放地点1"/>
        <asp:BoundField DataField="Location2" HeaderText="存放地点2"/>
        <asp:BoundField DataField="User" HeaderText="使用人"/>
        <asp:BoundField DataField="Admin" HeaderText="监管人"/>
        <asp:BoundField DataField="Remark" HeaderText="备注"/>
        
            <asp:CommandField ShowEditButton="true" NewText="" ShowInsertButton="True" />
        
        </fields>
        <HeaderStyle BackColor="#E0F2FF" Font-Bold="true" ForeColor="teal" />
        </asp:DetailsView>
        
    </div>
    </form>
</body>
</html>
