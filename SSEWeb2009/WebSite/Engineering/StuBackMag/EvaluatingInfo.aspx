<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EvaluatingInfo.aspx.cs" Inherits="Engineering_StuBackMag_EvaluatingInfo" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

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
                    <span style=" font-size:25px">教学评估详细</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:LinkButton ID="lbBack" runat="server" 
                    PostBackUrl="~/Engineering/StuBackMag/EvaluateTeaching.aspx">&lt;&lt;返回上一页</asp:LinkButton>
                </td>
            </tr>
        </table> 
    </div>
    <hr />
    <br />
    <div>
       同济大学软件学院课程教学情况调查表
    </div>
    <br />
    <div>
        <table width="700" border="1" cellpadding="0" cellspacing="0">
            <tr>
                <td width="350" height="31" align="center" valign="middle">
                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                </td>
                <td width="350" align="center" valign="middle">
                    <asp:Label ID="lblTeacher" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:GridView ID="gvEvaluatingInfo" runat="server" Width="700px" 
            AutoGenerateColumns="False" BorderColor="#666666" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
            onprerender="gvEvaluatingInfo_PreRender">
            <Columns>
                <asp:BoundField DataField="Item" HeaderText="评估项目" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="No" HeaderText="序号" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="element" HeaderText="项目要素" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="优">
                    <ItemTemplate>
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="pj" />
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="良">
                    <ItemTemplate>
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="pj" />
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="合格">
                    <ItemTemplate>
                        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="pj" />
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="不合格">
                    <ItemTemplate>
                        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="pj" />
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div>
        <asp:Label ID="Label1" runat="server" Text="对本课程教学的意见和建议："></asp:Label>
    </div>
    <div>
        <asp:TextBox ID="tbSuggestion" runat="server" Height="150px" 
            TextMode="MultiLine" Width="500px"></asp:TextBox>
    </div>
    <br />
    <br />
    <div>
        <asp:Button ID="btSubmit" runat="server" Text="提交" Height="28px" Width="70px" 
            onclick="btSubmit_Click" BackColor="#3333FF" ForeColor="White" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btBack" runat="server" Height="28px" Text="返回" Width="70px" 
            PostBackUrl="~/Engineering/StuBackMag/EvaluateTeaching.aspx" 
            BackColor="#3333FF" ForeColor="White" />
    </div>
    </form>
</body>
</html>
