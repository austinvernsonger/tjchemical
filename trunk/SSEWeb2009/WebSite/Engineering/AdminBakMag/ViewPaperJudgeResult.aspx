<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewPaperJudgeResult.aspx.cs" Inherits="Engineering_AdminBakMag_ViewPaperJudgeResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
     <script type="text/javascript" language="javascript">
    function OpenOvertimeDlog(ID,width,height) 
   {       
     var me; 
     // 把父页面窗口对象当作参数传递到对话框中，以便对话框操纵父页自动刷新。 
     me = "PaperJudgeDetails.aspx?id="+ID+""; 
     // 显示对话框。
     window.showModalDialog(me,null,'dialogWidth='+width +'px;dialogHeight='+height+'px;help:no;status:no') 
   } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        查看论文评审结果
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <table width="670">
            <tr>
                <td width="60" height="31" align="left" valign="middle">
                    <span style="font-size: 15px">年级：</span>
                </td>
                <td width="120" align="left" valign="middle">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlGrade" runat="server" Width="115px" AutoPostBack="True"
                                DataSourceID="ObjectDataSource1" DataTextField="Grade" DataValueField="Grade"
                                OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
                                <asp:ListItem>--请选择年级--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetGrade"
                                TypeName="Department.Engineering.StudentManage"></asp:ObjectDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td width="80" align="left" valign="middle">
                    <span style="font-size: 15px">教学点：</span>
                </td>
                <td width="120" align="left" valign="middle">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlSchool" runat="server" Width="115px" DataSourceID="ObjectDataSource2"
                                DataTextField="TeaSchoolName" DataValueField="TeaSchoolID">
                                <asp:ListItem>--请选择教学点--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetTeaSchool"
                                TypeName="Department.Engineering.TeachingSchool">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlGrade" Name="selValue" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlGrade" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td width="102" align="left" valign="middle">
                    <span style="font-size: 15px">评审状态：</span>
                </td>
                <td width="70" align="left" valign="middle">
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Value="0">--请选择--</asp:ListItem>
                        <asp:ListItem Value="1">尚未评审</asp:ListItem>
                        <asp:ListItem Value="2">已达到标准</asp:ListItem>
                        <asp:ListItem Value="3">未达到标准</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td width="118" align="center" valign="middle">
                    <asp:Button ID="btQuery" runat="server" Height="31px" Text="查询" Width="60px" OnClick="btQuery_Click"
                        BackColor="#3333FF" ForeColor="White" />
                </td>
            </tr>
        </table>  
    </div>
    <br />
    <div>
        <asp:GridView ID="gvPaperJudgeRes" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" PageSize="25" Width="700px" DataKeyNames="StudentID" 
            onrowdatabound="gvPaperJudgeRes_RowDataBound" >
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField HeaderText="姓名" DataField="Name">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="学号" DataField="StudentID">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="BlindReviewNo" HeaderText="盲审号">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="年级" DataField="Grade">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="教学点" DataField="TeaSchoolName">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="评审结果">
                    <ItemTemplate>
                        <asp:Label ID="lblJudgeResult" runat="server" Text='<%#GetJudgeRes(Eval("JudgeStatue"),Eval("IsCriterion"))%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="查看详细">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnbView" runat="server">查看详细</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
