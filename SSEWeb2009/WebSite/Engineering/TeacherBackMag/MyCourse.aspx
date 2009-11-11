<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyCourse.aspx.cs" Inherits="Engineering_TeacherBackMag_MyCourse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的课程--我的课程</title>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        我的课程
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="#999999"></asp:Label>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
           <asp:GridView ID="gvMyCourse" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="CourseID" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                CellPadding="4" AllowPaging="True" onrowdatabound="gvMyCourse_RowDataBound" 
                    Width="700px">
                <Columns>
                    <asp:BoundField DataField="CourseName" HeaderText="课程名称" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Grade" HeaderText="授课年级">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TeaSchoolName" HeaderText="授课对象" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ClassPeriod" HeaderText="上课时间" 
                        NullDisplayText="未定" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Place" HeaderText="上课地点" NullDisplayText="未定" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StudentNumber" HeaderText="选课人数" 
                        NullDisplayText="0" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:HyperLinkField DataNavigateUrlFields="CourseID" 
                        DataNavigateUrlFormatString="ViewCourseDetails.aspx?cid={0}" HeaderText="课程成绩" 
                        Text="查看" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:HyperLinkField>
                    <asp:TemplateField HeaderText="评教结果">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbViewDetails" runat="server">查看详细</asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView> 
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
