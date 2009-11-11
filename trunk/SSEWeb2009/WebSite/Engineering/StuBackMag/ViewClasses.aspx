<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewClasses.aspx.cs" Inherits="Engineering_StuBackMag_ViewClasses" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看所有课程--工程硕士中心</title>
    <script type ="text/javascript" language = "javascript">
    function OpenOvertimeDlog(ID,width,height) 
   {       
     var me; 
     // 把父页面窗口对象当作参数传递到对话框中，以便对话框操纵父页自动刷新。 
     me = "CourseDetails.aspx?courseId="+ID+""; 
     // 显示对话框。
     window.showModalDialog(me,null,'dialogWidth='+width +'px;dialogHeight='+height+'px;help:no;status:no') 
   } 
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        查看所有课程
    </div>
    <hr />
    <br />
    <div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="#999999"></asp:Label>
    </div>
    <asp:GridView ID="gvCourseInfo" runat="server" AutoGenerateColumns="False" 
        BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="4" Width="700px" onrowdatabound="gvCourseInfo_RowDataBound" 
        AllowPaging="True" PageSize="15" DataKeyNames="CourseID" >
        <Columns>
            <asp:BoundField DataField="CourseName" HeaderText="课程名称">
                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                    BorderWidth="1px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="课程性质">
                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                    BorderWidth="1px" />
                <ItemTemplate>
                    <%#sProperty[Convert.ToInt32(Eval("Property"))] %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="课程类别">
                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                    BorderWidth="1px" />
                <ItemTemplate>
                    <%#sCategory[Convert.ToInt32(Eval("Category"))] %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Credit" HeaderText="学分">
                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                    BorderWidth="1px" />
            </asp:BoundField>
            <asp:BoundField DataField="CreditHour" HeaderText="学时">
                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                    BorderWidth="1px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="查看详细">
                <ItemTemplate>
                    <asp:LinkButton ID="lbViewDetails" runat="server">查看</asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                    BorderWidth="1px" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="备注" >
                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                    HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView> 
    </form>
</body>
</html>
