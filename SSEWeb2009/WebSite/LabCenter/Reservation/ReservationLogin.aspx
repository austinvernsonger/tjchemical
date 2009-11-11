<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LabCenter/MasterPages/HomeMaster.master" CodeFile="ReservationLogin.aspx.cs" Inherits="实验预约_OrderLogin" %>

<script runat="server">

    protected void menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        int index = Int32.Parse(e.Item.Value);
        multiview1.ActiveViewIndex = index;
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
        <asp:Label ID="lblrecord" runat="server"></asp:Label>
        <asp:HiddenField ID="dateindex" runat="server" Visible="false" />
        <br />
        
        <div id="detailsdiv" runat="server">
        <asp:Menu ID="menu1" runat="server" Orientation="Horizontal"
         StaticMenuItemStyle-CssClass="tab"
         StaticSelectedStyle-CssClass="selectedTab"
         CssClass="tabs"   
        OnMenuItemClick="menu1_MenuItemClick">
        <Items>
        <asp:MenuItem Text="实验信息" Value="0" Selected="true"/>
        <asp:MenuItem Text="登入&登出" Value="1" />
        </Items>
        </asp:Menu>
        
        <div class="tabContents">
        <asp:MultiView ID="multiview1" ActiveViewIndex="0" runat="server">
        <asp:View ID="view1" runat="server">
        <div>
        <fieldset>
        <legend>基本信息</legend>
        <asp:Label ID="lblexpname" runat="server" Text="实验名称:"></asp:Label>
        <br />
        <asp:Label ID="lblstarttime" runat="server" Text="实验开始时间:"></asp:Label>
        <br />
        <asp:Label ID="lblendtime" runat="server" Text="实验结束时间:"></asp:Label>
        </fieldset>
        </div>
        <div>
        <fieldset>
        <legend>多人实验</legend>
        <div style="float:left; width:200px;">
        <asp:Label ID="lblmulti" runat="server" Text="多人实验学号列表："></asp:Label>
        <br />
        <asp:ListBox ID="list1" runat="server">
        </asp:ListBox>
            <br />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnremove" runat="server" Text="移除" onclick="btnremove_Click"/>
        </div>
        <div style=" float:left; width:auto;">
        <asp:Label ID="lblnextStuNo" runat="server" Text="输入学号:"></asp:Label>
        <br />
        <asp:TextBox ID="txtStuNo" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="cvStuNo" runat="server" ControlToValidate="txtStuNo" ValidateEmptyText="true" OnServerValidate="val_StuNoValidate" ValidationGroup="stuno">
        </asp:CustomValidator>
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnadd" runat="server" Text="添加" 
                ValidationGroup="stuno" onclick="btnadd_Click"/>
            <br />
            <asp:Label ID="lbladdremrlt" runat="server"></asp:Label>
        </div>
        </fieldset>
        </div>
        </asp:View>
        <asp:View ID="view2" runat="server">
        <div>
        <fieldset>
        <legend>登入</legend>
        <asp:Label ID="lbldevice" runat="server" Text="设备编号:" AssociatedControlID="txtdevice"></asp:Label>
        <asp:TextBox ID="txtdevice" runat="server" />
        <asp:CustomValidator ID="cvdevice" runat="server" ControlToValidate="txtdevice" ValidateEmptyText="true" OnServerValidate="val_ServerValidate" ValidationGroup="device">
        </asp:CustomValidator>
        <br />
        <asp:Button ID="btnlogin" runat="server" Text="登入" onclick="btnlogin_Click" ValidationGroup="device"/>
        <br />
        <asp:Label ID="lbllogin" runat="server" Text="登入时间:"></asp:Label>
        </fieldset>
        </div>
        <div>
        <fieldset>
        <legend>登出</legend>
        <asp:Button ID="btnlogout" runat="server" Text="登出" onclick="btnlogout_Click" Enabled="false"/>
        <br />
        <asp:Label ID="lbllogout" runat="server" Text="登出时间:"></asp:Label>
        <br /><br />
        <asp:Button ID="btnbacktohome" runat="server" Text="回到主页" 
                PostBackUrl="~/LabCenter/Default.aspx" />
                </fieldset>
                </div>
                </asp:View>
                </asp:MultiView>
                </div>
        </div>
    </div>
</asp:Content>
