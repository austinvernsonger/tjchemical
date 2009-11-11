<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PicListContent.aspx.cs" Inherits="SysMgr_PicListContent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePanel" runat="server">
    <ContentTemplate>
    <div align="left" style="padding: 5px 5px 5px 10px">
        <asp:Label ID="lbHidden" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:DataGrid   runat="server" id="dg"    
          AutoGenerateColumns="False" AlternatingItemStyle-BackColor="#eeeeee"  
          HeaderStyle-BackColor="Navy" HeaderStyle-ForeColor="White"  
          HeaderStyle-Font-Size="15pt" HeaderStyle-Font-Bold="True" 
          BorderColor="#DEDFDE" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
          Font-Names="Tahoma" Font-Size="Small" onitemdatabound="dg_ItemDataBound" 
          onselectedindexchanged="dg_SelectedIndexChanged" BackColor="White" 
            ForeColor="#666666" GridLines="Both">  
            <FooterStyle BackColor="#CCCC99" />
            <SelectedItemStyle BackColor="#C1EBFF" Font-Bold="False" ForeColor="#666666" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" 
                Mode="NumericPages" />
                <AlternatingItemStyle BackColor="White" Font-Names="Tahoma" 
                Font-Size="Small">
                </AlternatingItemStyle>
            <ItemStyle BackColor="#F7F7DE" />
            <Columns>  
                 <asp:BoundColumn   DataField="Name" HeaderText="文件名"  
                        ItemStyle-HorizontalAlign="Center" DataFormatString="{0}"   >  
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>  
                <asp:BoundColumn   DataField="LastWriteTime" HeaderText="最后修改时间"  
                        ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}"   >  
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn   DataField="Length" HeaderText="文件大小"  
                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###   字节}">  
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundColumn>
                <asp:ButtonColumn CommandName="Select" HeaderText="操作" Text="预览">
                </asp:ButtonColumn>
            </Columns>  
            <HeaderStyle BackColor="#6B696B" Font-Size="Small" ForeColor="White" 
                Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
        </asp:DataGrid>  
                 <div style="margin:2px;"><asp:Label ID="lbNotice" runat="server" 
            Text="[注意]:<br/>1. 选择图片的时候若图片名字带有前缀‘_t’则表示缩略图.<br/>请尽量选择缩略图进行预览.<br/>2. 树状图中Y表示年,M表示月" Font-Size="Small" 
            ForeColor="#666666"></asp:Label> </div>
         <div align="left" style="width: 95%"><hr size="0" noshade="noshade" color="#999999" style="width: 100%;"></div>
        <div style="margin:3px"><asp:LinkButton ID="lbSelPic" runat="server" Font-Size="Small" 
            ForeColor="#666666" onclick="lbSelPic_Click" Visible="False">我要这张图片</asp:LinkButton> &nbsp;
        <asp:Label ID="lbInfo" runat="server" Text="Label" Visible="False" 
                Font-Size="Small" ForeColor="Red"></asp:Label>  </div>
        <asp:Image ID="imgPreview" runat="server" />
           </div>
            </ContentTemplate>
           </asp:UpdatePanel>
    </form>
</body>
</html>
