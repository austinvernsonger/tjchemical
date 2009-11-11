<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeachingFeedBack.aspx.cs" Inherits="Engineering_TeacherBackMag_TeachingFeedBack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
     <form id="form1" runat="server">
    <div>
        <table width="700">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style=" font-size:25px">课程评估反馈信息</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                        PostBackUrl="~/Engineering/TeacherBackMag/MyCourse.aspx">返回上一页</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <br />
    <div> 
        <asp:Panel ID="Panel1" runat="server"> 
        <div>
            到目前为止，总共有&nbsp; 
            <asp:Label ID="lblSum" runat="server" Text="0" Font-Bold="True" 
                Font-Size="Large" ForeColor="Red"></asp:Label> &nbsp; 位同学对这门课进行了测评
        </div>
        <div>
            <asp:GridView ID="gvResult" runat="server" Width="700px" 
                AutoGenerateColumns="False" BorderColor="#666666" 
                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
                onprerender="gvResult_PreRender">
                <Columns>
                    <asp:BoundField DataField="Item" HeaderText="评估项目" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="No" HeaderText="序号" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="element" HeaderText="项目要素" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="excellent" HeaderText="优" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="good" HeaderText="良" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="quality" HeaderText="合格" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="bad" HeaderText="不合格" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>       
        </div>
        <br />
        <div>
            相关评论：
        </div>  
        <br />
        <div>
            <asp:GridView ID="gvSuggestion" runat="server" Width="700px" 
                AutoGenerateColumns="False" BackColor="White" 
                BorderStyle="None" CellPadding="2" ShowHeader="False" AllowPaging="True" 
                GridLines="None" onpageindexchanging="gvSuggestion_PageIndexChanging">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <RowStyle ForeColor="#000066" />
                <Columns>
                    <asp:BoundField DataField="ID">
                        <ItemStyle HorizontalAlign="Left" Width="30px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Item">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
