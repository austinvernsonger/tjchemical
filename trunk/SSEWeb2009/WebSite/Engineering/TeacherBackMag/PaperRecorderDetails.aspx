<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaperRecorderDetails.aspx.cs" Inherits="Engineering_TeacherBackMag_PaperRecorderDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生论文相关评论详细--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
        <table width="700">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style=" font-size:25px">学生论文提交详细信息</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:LinkButton ID="lbBack" runat="server" Text="<<返回上一页" 
                        PostBackUrl="~/Engineering/TeacherBackMag/AboutPaperSubmitingRecorder.aspx"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <br />
    <div>
        <asp:Label ID="lblTitle" runat="server" Font-Size="Medium"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCreatedTime" runat="server" Font-Size="Medium"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblName" runat="server" Font-Size="Small"></asp:Label>
        
        (<asp:Label ID="lblGrade" runat="server" Font-Size="Small"></asp:Label>)&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblStuID" runat="server" Font-Size="Small"></asp:Label>
    </div>
    <br />
    <div>
        <table width="500" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="88" height="31" align="right" valign="middle">
                    <asp:Label ID="Label1" runat="server" Text="我要留言:" Font-Bold="True"></asp:Label>
                </td>
                <td width="412" rowspan="2" align="left" valign="middle">
                    <asp:TextBox ID="tbComment" runat="server" Height="128px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="99" valign="top">
                    &nbsp;
                </td>
            </tr>
        </table>
        <p style="text-align: right; width: 487px;">
            <asp:Button ID="btComment" runat="server" Height="26px" Text="发表" Width="50px" BackColor="#3333FF"
                ForeColor="White" CommandName="comment" 
                CommandArgument='<%#Eval("ItemID") %>' onclick="btComment_Click" /></p>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="主题附件：" Font-Size="Medium"></asp:Label>
        &nbsp;<asp:LinkButton ID="lbDownload" runat="server" ForeColor="Blue" 
            onclick="lbDownload_Click">下载</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="附件最近更新时间：" Font-Size="Medium"></asp:Label>
        <asp:Label ID="lblTime" runat="server" Font-Size="Medium"></asp:Label>
    </div>
    <br />
    <div>
        <asp:DataList ID="dlChildMessage" runat="server" BackColor="White" BorderColor="#CCCCCC"
            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" GridLines="Both" Width="510px">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <ItemStyle BackColor="White" ForeColor="#330099" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <ItemTemplate>
                <table width="500">
                    <tr>
                        <td align="left" height="20" valign="middle" width="340">
                            <asp:Label ID="lblSpeaker" runat="server" Font-Size="Small" Text='<%# GetSpeaker(Eval("Communicators").ToString()) %>'
                                ForeColor="#666666"></asp:Label>
                        </td>
                        <td align="right" valign="middle" width="160">
                            <asp:Label ID="lblCommentTime" runat="server" Font-Size="Small" Text='<%# Convert.ToDateTime(Eval("CreatedDate")).ToString("yyyy-MM-dd HH:mm") %>'
                                ForeColor="#666666"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:Label ID="lblChildComment" runat="server" Font-Size="Small" Width="340px" Text='<%# Eval("Body") %>'
                        ForeColor="Black"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
    </form>
</body>
</html>
