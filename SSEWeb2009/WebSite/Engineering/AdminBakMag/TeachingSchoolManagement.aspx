<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeachingSchoolManagement.aspx.cs" Inherits="Engineering_AdminBakMag_TeachingSchoolManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px">
        管理教学点信息
    </div>
    <hr />
    <br />
    <div>
        <asp:Label ID="lblMessage" runat="server" Text="当前还没有教学点:-)" ForeColor="#999999"></asp:Label>
        <asp:GridView ID="gvTSchool" runat="server" Width="600px" 
            AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" 
            ForeColor="#333333" GridLines="None" PageSize="20" 
            onpageindexchanging="gvTSchool_PageIndexChanging" 
            DataKeyNames="TeaSchoolID" onrowdatabound="gvTSchool_RowDataBound">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField HeaderText="教学点编号" DataField="TeaSchoolID" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="教学点名称" DataField="TeaSchoolName" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Password" HeaderText="密码">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        编辑
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="lnbRevise" runat="server" ImageUrl="~/Engineering/Resources/images/edit.gif"  />
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        删除
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="lnbDelete" runat="server" ImageUrl="~/Engineering/Resources/images/icon-delete.gif" CommandName="cmdDelete" />
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" Width="50px" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <br />
    <div>
        <asp:LinkButton ID="lbNewSchool" runat="server" 
            PostBackUrl="~/Engineering/AdminBakMag/TeaSchoolDetails.aspx" 
            onclick="lbNewSchool_Click">添加教学点</asp:LinkButton>
    </div>
    <br />
    <br />
    <div>
        操作说明：<br />
        1.教学点名称不能重复。<br />
        2.全日制教学点只能有一个，可以用一个特殊的编号标示。
    </div>
    </form>
</body>
</html>
