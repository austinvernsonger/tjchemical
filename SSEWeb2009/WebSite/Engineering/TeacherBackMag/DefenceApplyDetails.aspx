<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefenceApplyDetails.aspx.cs" Inherits="Engineering_TeacherBackMag_DefenceApplyDetails" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生答辩申请--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style=" font-size:25px">学生申请答辩详细信息</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:LinkButton ID="lbBack" runat="server" 
                    PostBackUrl="~/Engineering/TeacherBackMag/MyStudDefenceApply.aspx">&lt;&lt;返回上一页</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <br />
    <div>
        <asp:DetailsView ID="dvDefenceDetails" runat="server" Height="50px" Width="700px" 
            AutoGenerateRows="False" CellPadding="5" BackColor="White" 
            BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
            ondatabound="dvDefenceDetails_DataBound" DataKeyNames="StudentID">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <RowStyle ForeColor="#000066" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <Fields>
                <asp:BoundField DataField="sName" HeaderText="姓名" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle Width="450px" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField DataField="StudentID" HeaderText="学号" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <%# Convert.ToInt32(Eval("sGender")) == 0?"男":"女" %>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Grade" HeaderText="年级" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点" >
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="开题报告">
                    <ItemTemplate>
                        <asp:Label ID="lblSpeach" runat="server" Text="尚未提交" ForeColor="Red"></asp:Label>
                        <asp:LinkButton ID="lbSpeach" runat="server" Visible="False" 
                            onclick="lbSpeach_Click" ForeColor="Blue">下载</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="校外导师信息">
                    <ItemTemplate>
                        <asp:Label ID="lblOutTeacher" runat="server" Text="尚未提交" ForeColor="Red"></asp:Label>
                        <asp:LinkButton ID="lbOutTeacher" runat="server" Visible="False" 
                            OnClick="lbOutTeacher_Click" ForeColor="Blue">下载</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="中期考核表">
                    <ItemTemplate>
                        <asp:Label ID="lblMidForm" runat="server" Text="尚未提交" ForeColor="Red"></asp:Label>
                        <asp:LinkButton ID="lbMidForm" runat="server" Visible="False" 
                            OnClick="lbMidForm_Click" ForeColor="Blue">下载</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="论文初稿">
                    <ItemTemplate>
                        <asp:Label ID="lblPaper" runat="server" Text="尚未提交" ForeColor="Red"></asp:Label>
                        <asp:LinkButton ID="lbPaper" runat="server" Visible="False" 
                            OnClick="lbPaper_Click" ForeColor="Blue">下载</asp:LinkButton>                    
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
            </Fields>
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:DetailsView>
    </div>
    <br />
    <div>
        <table width="700">
            <tr>
                <td width="80" rowspan="2" align="left" valign="middle">
                    审批：</td>
                <td width="620" height="31" align="left" valign="middle">
                    <asp:RadioButton ID="rbAgree" runat="server" GroupName="defence" Text="批准答辩" 
                        Checked="True" />
                </td>
            </tr>
            <tr>
                <td height="31" align="left" valign="middle">
                    <asp:RadioButton ID="rbDisagree" runat="server" GroupName="defence" 
                        Text="不批准答辩" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        理由：（可以不写）
    </div>
    <div>
        <asp:TextBox ID="tbReason" runat="server" Height="100px" TextMode="MultiLine" 
            Width="400px"></asp:TextBox>
    </div>
    <br />
    <div>
        <asp:Button ID="tbConfirm" runat="server" Text="确定" Height="31px" 
            Width="90px" onclick="tbConfirm_Click" BackColor="#3333FF" 
            ForeColor="White" />
    </div>
    <br />
    <div>
        <asp:Label ID="lblResult" runat="server" Visible="False"></asp:Label>
    </div>
    </form>
</body>
</html>
