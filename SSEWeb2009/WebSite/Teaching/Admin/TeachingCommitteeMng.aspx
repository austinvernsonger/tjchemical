<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeachingCommitteeMng.aspx.cs" Inherits="Teaching_Admin_TeachingCommitteeMng" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        教学工作委员会管理</p>
    <p>
        会议标题：<asp:TextBox ID="ArticleTitle" runat="server"></asp:TextBox>
                </p>
    <p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <p>
                    会议日期：<asp:Calendar ID="MeetingTime" runat="server" BackColor="White" 
                        BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                        ForeColor="#003399" Height="200px" Width="220px">
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                            Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    </asp:Calendar>
                </p>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
    <div>
    
        <FCKeditorV2:FCKeditor ID="TeachingCommittee" runat="server" Height="800px">
        </FCKeditorV2:FCKeditor>
        <br />
        <asp:Button ID="Submit" runat="server" Text="提交" onclick="Submit_Click" />
        <asp:Button ID="Cancel" runat="server" Text="取消" 
            PostBackUrl="~/Teaching/Admin/AdminManagement.aspx?Type=7" />
    
    </div>
    </form>
</body>
</html>
