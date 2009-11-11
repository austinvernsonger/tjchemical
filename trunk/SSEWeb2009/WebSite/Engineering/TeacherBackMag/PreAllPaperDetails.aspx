<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreAllPaperDetails.aspx.cs" Inherits="Engineering_TeacherBackMag_PreAllPaperDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>论文评审详细--工程硕士中心</title>
    <script type ="text/javascript" language = "javascript">
    function OpenOvertimeDlog(bNo,teacherid,width,height) 
   {       
     var me; 
     // 把父页面窗口对象当作参数传递到对话框中，以便对话框操纵父页自动刷新。 
     me = "ViewOtherMemDetails.aspx?id=" + bNo + "&&teacherid=" + teacherid+""; 
     // 显示对话框。
     window.showModalDialog(me,null,'dialogWidth='+width +'px;dialogHeight='+height+'px;help:no;status:no') ;
   } 
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>  
        <table width="700">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style=" font-size:25px">论文评审报告详细</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                        PostBackUrl="~/Engineering/TeacherBackMag/ViewAllPaper.aspx">&lt;&lt;返回上一页</asp:LinkButton>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <fieldset style="width: 700px">
            <legend>评审成员</legend>
            <div>
                <table width="700">
                    <tr>
                        <td height="31" colspan="2" align="left" valign="middle">
                            评审组长：<asp:Label ID="lblLeader" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="350" height="31" align="left" valign="middle">
                            评审成员一：<asp:Label ID="lblMember1" runat="server"></asp:Label>
                        </td>
                        <td width="350" align="left" valign="middle">
                            评审成员二：<asp:Label ID="lblMember2" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
    <br />
    <div>
        <table width="700">
            <tr>
                <td width="700" height="31" align="left" valign="middle">
                   盲审编号：
                   <asp:TextBox ID="tbBNo" runat="server" Width="120px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="31" align="left" valign="middle">
                    论文题目： 
                    <asp:TextBox ID="tbTitle" runat="server" Width="450px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        学术评语：
    </div>
    <div>    
        <asp:TextBox ID="tbRemark" runat="server" Height="298px" TextMode="MultiLine" 
            Width="700px"></asp:TextBox>    
    </div>
    <div>
        <table width="700">
            <tr>
                <td width="700" height="31" align="right" valign="middle">
                    <asp:Label ID="lblTime" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="700">
            <tr>
                <td width="80" rowspan="2" align="left" valign="middle">
                    评分：</td>
                <td width="620" height="31" align="left" valign="middle">
                    <asp:RadioButton ID="rbQualify" runat="server" Checked="True" 
                        GroupName="isqualify" Text="已经达到论文标准水平" />
                </td>
            </tr>
            <tr>
                <td height="31" align="left" valign="middle">
                    <asp:RadioButton ID="rbNoQualify" runat="server" GroupName="isqualify" 
                        Text="尚未达论文标准水平" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        论文下载：<asp:LinkButton ID="lbDownload" runat="server" 
            onclick="lbDownload_Click">下载</asp:LinkButton>
    </div>
    <br />
    <div>
        <asp:Button ID="btSave" runat="server" Text="保存" Height="31px" Width="90px" 
            onclick="btSave_Click" BackColor="#3333FF" ForeColor="White" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btSubmit" runat="server" Height="31px" Text="完成评审" Width="90px" 
            onclick="btSubmit_Click" BackColor="#3333FF" ForeColor="White" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btBack" runat="server" Height="31px" Text="返回" Width="90px" 
            PostBackUrl="~/Engineering/TeacherBackMag/ViewAllPaper.aspx" 
            BackColor="#3333FF" ForeColor="White" />
    </div>
    <br />
    <div>
        <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <br />
    <div>
        <asp:Panel ID="Panel1" runat="server" Width="700px" Visible="false" Font-Bold="True" onmouseover="this.style.cursor='hand'" onmouseout="this.style.cursor='normal'">
            <asp:Image ID="ImgExpand" runat="server" ImageUrl="~/Engineering/Resources/images/expand.jpg">
            </asp:Image>&#160;&#160;&#160;
            <asp:Label ID="Label3" runat="server" Text="查看评审成员的评审结果（显示详细信息......）" ForeColor="#0033CC"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible = "false">
            <br />
            <asp:Label ID="lblMessage" runat="server" Text="当前还没有评审结果:-)" 
                ForeColor="#999999"></asp:Label>
            <asp:DataList ID="dvOtherMemRes" runat="server" BackColor="White" BorderColor="#666666"
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            GridLines="Horizontal" onitemdatabound="dvOtherMemRes_ItemDataBound" 
            Width="700px" onselectedindexchanged="dvOtherMemRes_SelectedIndexChanged">
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <AlternatingItemStyle BackColor="#F7F7F7" />
            <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <ItemTemplate>
                <table border="0" cellpadding="0" cellspacing="0" width="700">
                    <tr>
                        <td height="31" valign="middle" width="200">
                            成员：<asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                            <asp:Label ID="lblID" runat="server" Visible="False" Text='<%#Eval("TeacherID") %>'></asp:Label>
                            <asp:Label ID="lblbNo" runat="server" Visible="false" Text='<%#Eval("BlindReviewNo") %>'></asp:Label>
                        </td>
                        <td align="center" colspan="2" valign="middle">
                            评审完成！评审结果：<asp:Label ID="lblRes" runat="server" Text='<%#  Convert.ToInt32(Eval("IsCriterion")) == 2?"不通过":"通过" %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" height="31" valign="middle">
                            完成时间：<asp:Label ID="lblTime" runat="server" Text='<%# Eval("JudgeTime") %>'></asp:Label>
                        </td>
                        <td align="center" valign="middle" width="300">
                            <asp:LinkButton ID="lbViewDetails" runat="server">查看详细</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        </asp:Panel>
        <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" CollapseControlID="Panel1"
            ExpandControlID="Panel1" TargetControlID="Panel2" ImageControlID="ImgExpand"
            TextLabelID="Label3" CollapsedImage="~/Engineering/Resources/images/expand.jpg"
            ExpandedImage="~/Engineering/Resources/images/collapse.jpg" ExpandedText="查看评审成员的评审结果（隐藏详细信息......）"
            CollapsedText="查看评审成员的评审结果（显示详细信息......）" Enabled="false" Collapsed="True">
        </cc1:CollapsiblePanelExtender>
    </div>
    </form>
</body>
</html>
