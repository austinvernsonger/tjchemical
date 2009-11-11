<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyStudDefenceApply.aspx.cs" Inherits="Engineering_TeacherBackMag_MyStudDefenceApply" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生答辩申请--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">  
        学生答辩申请
    </div>
     <hr />
     <br />
    <div>  
        <div>
            <asp:Label ID="lblResult" runat="server" ForeColor="#999999"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="gvDefenceApply" runat="server" Width="700px" 
                AutoGenerateColumns="False" CellPadding="4" BorderColor="#666666" 
                BorderStyle="Solid" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="申请人">
                        <HeaderStyle BackColor="#CCCCCC" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                            HorizontalAlign="Center" Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CreatedTime" 
                        DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="申请时间">
                        <HeaderStyle BackColor="#CCCCCC" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                            HorizontalAlign="Center" Width="300px" />
                    </asp:BoundField>
                    <asp:HyperLinkField DataNavigateUrlFields="StudentID" 
                        DataNavigateUrlFormatString="DefenceApplyDetails.aspx?id={0}" Text="查看详细">
                        <ControlStyle ForeColor="Blue" />
                        <HeaderStyle BackColor="#CCCCCC" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                            HorizontalAlign="Center" />
                    </asp:HyperLinkField>
                </Columns>
            </asp:GridView>
        </div>  
    </div>
    </form>
</body>
</html>
