<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutPaperSubmitingRecorder.aspx.cs" Inherits="Engineering_TeacherBackMag_AboutPaperSubmitingRecorder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生论文相关评论信息--工程硕士中心</title>
    <script type="text/javascript">
       function SelectAll(tempControl)
       {
            var theBox=tempControl;
             xState=theBox.checked;    

            elem=theBox.form.elements;
            for(i=0;i<elem.length;i++)
            if(elem[i].type=="checkbox" && elem[i].id!=theBox.id)
             {
                  if(elem[i].checked!=xState)
                        elem[i].click();
            }
        }   
    
        function expand(obj)
        {
             var div = document.getElementById(obj);
             if(div.style.display == "block")
             {
                div.style.display="none";
             }
             else
             {
                div.style.display = "block";
             }
        }
       </script>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        所带学生的论文提交信息
    </div>
    <hr />
    <br />
    <div>
        <div style="float:left">
         类型：
        <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlStatus_SelectedIndexChanged">
            <asp:ListItem Value="0">请选择</asp:ListItem>
            <asp:ListItem Value="1">开题</asp:ListItem>
            <asp:ListItem Value="3">中期</asp:ListItem>
            <asp:ListItem Value="2">校导</asp:ListItem>
            <asp:ListItem Value="4">论文</asp:ListItem>
        </asp:DropDownList>
        </div>
        <div style="float:left; margin-left:30px">
            学号：<asp:TextBox ID="tbStuID" runat="server"></asp:TextBox>
        </div>
        <div style="float:left; margin-left:10px">
            <asp:Button ID="btQuery" runat="server" Text="查询" onclick="btQuery_Click" />
        </div>
        <br />
        <br />
        <div>
        <asp:GridView ID="gvRecorder" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" BorderColor="#666666" BorderStyle="Solid" 
            DataKeyNames="ItemID" ForeColor="#666666" 
            onrowdatabound="gvRecorder_RowDataBound" GridLines="Horizontal" 
            BorderWidth="1px" Width="700px" AllowPaging="True" PageSize="20">
            <Columns>
                <asp:TemplateField HeaderText="提交人">
                    <HeaderStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                    <ItemTemplate>
                        <%#Eval("Name").ToString()+"("+Eval("StudentID").ToString()+")" %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="150px" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="主题">
                    <HeaderStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Left" Width="280px" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                    <ItemTemplate>
                        <asp:HyperLink ID="hlTitle" runat="server" Text='<%#Eval("Title") %>' ForeColor="#666666"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="类型">
                    <HeaderStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" Width="50px" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                    <ItemTemplate>
                        <%#GetCategory(Convert.ToInt32(Eval("Category")))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="时间">
                    <HeaderStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" Width="120px" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                    <ItemTemplate>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="评论">
                    <HeaderStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" Width="80px" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px" />
                    <ItemTemplate>
                        评论(<%#Eval("ChildCount")%>)
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#CCCCCC" />
        </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
