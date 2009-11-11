<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChooseMyStudents.aspx.cs" Inherits="Engineering_TeacherBackMag_ChooseMyStudents" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择我的学生-工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 25px">      
        选择我的学生
    </div>
    <hr />
    <br />
    <asp:Label ID="lblRes" runat="server" Text="占时还没有选学生信息:-)" ForeColor="#999999" 
            Visible="False"></asp:Label>
    <div id="div_choseStu" runat="server" visible ="false">
        <div>
            状态：<asp:DropDownList ID="ddlSelect" runat="server" Width="100px" 
                AutoPostBack="True" 
                onselectedindexchanged="ddlSelect_SelectedIndexChanged">
                <asp:ListItem>全部</asp:ListItem>
                <asp:ListItem>已选择</asp:ListItem>
                <asp:ListItem>未选择</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        
        <asp:GridView ID="gvChoosingStu" runat="server" Width="700px" 
            AutoGenerateColumns="False" DataKeyNames="TeaMagID" 
            BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="4" onrowdatabound="gvChoosingStu_RowDataBound" AllowPaging="True" 
                PageSize="20">
            <Columns>
                <asp:BoundField HeaderText="年级" DataField="Grade" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="教学点" DataField="TeaSchoolName" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="结束时间">
                    <ItemTemplate>
                        <%# GetSpanTime(Eval("EndTime").ToString())%>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="当前状态">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="选择我的学生">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlStartChoosing" runat="server" ForeColor="Blue" 
                            NavigateUrl='<%# "~/Engineering/TeacherBackMag/StartChoosingStudents.aspx?id="+Eval("TeaMagID") %>'>开始选择</asp:HyperLink>
                        <asp:Label ID="lblNul" runat="server" Text="没有" Visible="False"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
