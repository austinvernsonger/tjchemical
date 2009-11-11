<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateReport.aspx.cs" Inherits="实验预约_UpdateReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <style type="text/css">
        .reports td,.reports th
        {
            padding:5px;
        }
    </style>
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
       <asp:Label ID="lblterm" runat="server" Text="学期" AssociatedControlID="ddlterm"></asp:Label>
       <asp:DropDownList ID="ddlterm" runat="server">
       <asp:ListItem></asp:ListItem>
       </asp:DropDownList>
       &nbsp;&nbsp;&nbsp;
       <asp:Label ID="lblname" runat="server" Text="实验" AssociatedControlID="ddlname"></asp:Label>
       <asp:DropDownList ID="ddlname" runat="server">
       <asp:ListItem></asp:ListItem>
       </asp:DropDownList>
       &nbsp;&nbsp;&nbsp;
       <asp:Label ID="lblNo" runat="server" Text="学号" AssociatedControlID="txtNo"></asp:Label>
       <asp:TextBox ID="txtNo" runat="server" Width="54px"></asp:TextBox>
       <asp:Button ID="btnselect" runat="server" Text="确定" OnClick="btnselect_Click" />
       <asp:Label ID="lblsave" runat="server"></asp:Label>
       <hr /><br />
       <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
       <asp:UpdatePanel ID="up1" runat="server">
       <ContentTemplate>
       <asp:GridView ID="grdreport" runat="server" 
                AllowPaging="true" PageSize="3"  
                CssClass="reports" DataSourceID="srcReport1" 
                AutoGenerateEditButton="true" AutoGenerateColumns="false"
                DataKeyNames="StuID,ExperimentName">
       <Columns>
       <asp:BoundField DataField="StuID" HeaderText="学号" ReadOnly="true"/>
       <asp:BoundField DataField="ExperimentName" HeaderText="实验名称" ReadOnly="true"/>
       <asp:CheckBoxField DataField="ReportState" HeaderText="实验报告提交与否" />
       </Columns>
       <EmptyDataTemplate>
       <p>无匹配记录！</p>
       </EmptyDataTemplate>
       </asp:GridView>       
       </ContentTemplate>
       </asp:UpdatePanel>  
       <!--<asp:ObjectDataSource ID="srcReport" 
            runat="server" 
            TypeName="LabCenter.Reservation.ReportRecordsDSPaging" 
            SelectMethod="GetReports"
            SelectCountMethod="GetReportCount"
            UpdateMethod="UpdateReport"
            EnablePaging="True">
            <UpdateParameters>
            <asp:Parameter Name="StuID" Type="Int32"/>
            <asp:Parameter Name="ExperimentName" />
            <asp:Parameter Name="ReportState" Type="Boolean"/>
            </UpdateParameters>
           </asp:ObjectDataSource> -->   
           <asp:ObjectDataSource ID="srcReport1"
            runat="server" SelectMethod="GetReportsDataSet"  UpdateMethod="UpdateReports" TypeName="LabCenter.Reservation.ReportUIPaging">
            <UpdateParameters>
            <asp:ControlParameter Name="StuID" ControlID="grdreport" PropertyName='SelectedDataKey("StuID")'/>
            <asp:ControlParameter Name="ExperimentName" ControlID="grdreport" PropertyName='SelectedDataKey("ExperimentName")'/>
            <asp:Parameter Name="ReportState" Type="Boolean"/>
            </UpdateParameters>
            </asp:ObjectDataSource>   
       <br /> 
       
       </div>
    </form>
</body>
</html>
