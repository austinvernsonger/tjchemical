<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllPaper.aspx.cs" Inherits="Engineering_TeacherBackMag_ViewAllPaper" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>待评审的论文--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">  
    <div  style=" font-size:25px">
        待评审的论文
    </div>
    <hr />
    <br />
    <div>
        <asp:Label ID="lblResult" runat="server" ForeColor="#999999"></asp:Label>
        <asp:GridView ID="gvAllPrePaper" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" PageSize="15" Width="700px" 
            onrowdatabound="gvAllPrePaper_RowDataBound" 
            BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px">
            <Columns>
                <asp:BoundField DataField="BlindReviewNo" HeaderText="盲审号">
                    <FooterStyle HorizontalAlign="Left" />
                    <HeaderStyle BackColor="Silver" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="论文题目（点击进入评审页面）">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlPaper" runat="server" Text='<%# Eval("AttachName") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle BackColor="Silver" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%# Convert.ToInt32(Eval("JudgeStatue")) == 0 ?"未评审":"已评审"%>
                    </ItemTemplate>
                    <HeaderStyle BackColor="Silver" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                    <ItemStyle Width="80px" HorizontalAlign="Center" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="评审组长">
                    <HeaderStyle BackColor="Silver" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                    <ItemStyle Width="80px" HorizontalAlign="Center" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
