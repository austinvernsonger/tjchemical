<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignPaperForStus.aspx.cs" Inherits="Engineering_AdminBakMag_AssignPaperForStus" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分配预审论文--工程硕士中心</title>
    <script type ="text/javascript" language = "javascript">
    function OpenOvertimeDlog(ID,width,height,type) 
   {       
     var me; 
     // 把父页面窗口对象当作参数传递到对话框中，以便对话框操纵父页自动刷新。
     if(type == 0) 
     {
        me = "StudentInfoDetails.aspx?id="+ID+""; 
     }
     if(type ==1)
     {
        me = "AssignPaperDisagree.aspx?id="+ID;
     }
     // 显示对话框。
     window.showModalDialog(me,null,'dialogWidth='+width +'px;dialogHeight='+height+'px;help:no;status:no') ;
    // 刷新本页
     location.reload();
   } 
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px"> 
        分配预审论文
    </div>
    <hr />
    <br />
    <div>
        <asp:Label ID="lblResult" runat="server" ForeColor="#999999"></asp:Label>
        <asp:GridView ID="gvPaperInfo" runat="server" Width="700px" 
            AutoGenerateColumns="False" CellPadding="4" AllowPaging="True" 
            BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" PageSize="20" 
            onrowdatabound="gvPaperInfo_RowDataBound" 
            onrowcommand="gvPaperInfo_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="姓名">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" Width="80px" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lbName" runat="server" Text='<%#Eval("Name") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="StudentID" HeaderText="学号">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="CreateTime" 
                    DataFormatString="{0:yyyy-MM-dd}" HeaderText="提交时间">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="AttachName" HeaderText="论文题目">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="批准">
                    <ItemTemplate>
                        <asp:Button ID="btAgree" runat="server" Height="25px" Text="批准并分配"/>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="不批准">
                    <ItemTemplate>
                        <asp:Button ID="btDisagree" runat="server" Height="25px" Text="不批准" />
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" Width="80px" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>     
    </div>
    <br />
    <div runat="server" id="div_remark" visible="false">
        //点击姓名查看学生的具体情况
    </div>
    </form>
</body>
</html>
