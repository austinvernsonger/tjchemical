<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadPics.aspx.cs" Inherits="SysMgr_UploadPics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        <div>
            <div style="margin-bottom: 3px"><asp:FileUpload ID="picUpload" runat="server" 
                    BackColor="#ECECFF" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" 
                    ForeColor="#3366FF" />&nbsp;
            <asp:Button ID="btnOK" runat="server" Text="上传" onclick="btnOK_Click" 
                    BackColor="#ECECFF" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" 
                    ForeColor="#3366FF" /><br />
            </div>
            <div style="margin-bottom: 3px">
            <asp:Label ID="lbW" runat="server" Text="图片宽度：" Font-Size="Small" 
                ForeColor="#333333"></asp:Label>
                <asp:TextBox ID="tbWidth" runat="server" 
                BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" ReadOnly="True" 
                Width="45px" Font-Size="Small" BackColor="#EAEAEA"></asp:TextBox>&nbsp;
            <asp:Label ID="lbH" runat="server" Text="图片高度：" ForeColor="#333333" Font-Size="Small"></asp:Label>
            <asp:TextBox ID="tbHeight" runat="server" BorderColor="#666666" 
                BorderStyle="Solid" BorderWidth="1px" ReadOnly="True" Width="45px" 
                Font-Size="Small" BackColor="#EAEAEA"></asp:TextBox> </div>
             <asp:Label ID="lbErr" runat="server" Text="就绪" Font-Size="Small" 
                ForeColor="Red"></asp:Label>
            <div align="left" style="width: 95%"><hr size="0" noshade="noshade" color="#999999" style="width: 100%;"></div>
            <div align="center">
                <div style="width:145px;border: 1px solid #C0C0C0; padding: 2px;">
                    <asp:Image ID="ImageShow" runat="server" 
                        ImageUrl="~/Resources/Images/default.png" />
                </div>
            </div>
         </div>
    </form>
</body>
</html>
