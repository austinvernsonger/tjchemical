<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnusRecord/MasterPage.master" AutoEventWireup="true" CodeFile="alumniList.aspx.cs" Inherits="alumniList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div class="GreenBar"><asp:Label ID="gradeLabel" runat="server" Text=""/>&nbsp; 
        <a href="alumnusCenter.aspx" class="a2">返回院友中心</a></div>    
    <br />
    <div id="graduatingImage">
        <div id="leftBtn" style="float:left;vertical-align:middle;padding-top:15%;padding-bottom:15%;">
            <a href="#"><img src="Resources/images/LeftBtnImg.jpg" alt="上一届" /></a>
        </div>
        <div id="theImg" style="float:left">
            <asp:Image ID="ImageGraduate" runat="server" alt="毕业照" width="800" height="600"/></div>
        <div id="rightBtn" style="float:left;vertical-align:middle;padding-top:15%;padding-bottom:15%;">            
             <a href="#"><img src="Resources/images/RightBtnImg.jpg" alt="下一届" onclick="javascript:window.location='#'"/></a>
        </div>
        <div style="clear:both"></div>
    </div>       
<br />
<hr />
<br />
<br />   
<div id="graduatesList" style="text-align: left; width: 100%;">
    <div class="GreenBar">本届院友列表&nbsp;<a href="alumnusCenter.aspx" class="a2">返回院友中心</a></div>        
    
    
<%--    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>--%>
    
    
    <asp:DataList ID="DataListAlumnus" runat="server" Width=100%
        RepeatColumns="4" RepeatLayout="Flow">
        <HeaderTemplate>
           <span style="display:inline-block; width:24%; text-align:center;">学号 姓名</span>
           <span style="display:inline-block; width:24%; text-align:center;">学号 姓名</span>
           <span style="display:inline-block; width:24%; text-align:center;">学号 姓名</span>
           <span style="display:inline-block; width:24%; text-align:center;">学号 姓名</span>
        </HeaderTemplate>
        
        
        <ItemTemplate>
        <span style="display:inline-block; width:24%; border-style:  groove groove groove groove; text-align:center;">
            <a href='alumnusDetails.aspx?id=<%#Eval("StudentID") %>'>
            <asp:Label ID="stdnumberLabel" runat="server" Text='<%# Eval("StudentID") %>' /></a>
            <asp:Label ID="stdnameLabel" runat="server" Text='<%# Eval("Name") %>' />
         </span> <%--&nbsp;&nbsp;&nbsp;--%>
        
        </ItemTemplate>
    </asp:DataList>
    
    <div style="text-align:right">
        <asp:Label ID="LabelPages" runat="server" Text="Label"></asp:Label></div>
    <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetAlumnusNameID" TypeName="AlumnusRecord.Alumnus">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="degree" 
                QueryStringField="degree" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="2009" Name="gradYear" 
                QueryStringField="year" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>
    
   
</div>

    <p>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">&lt;&lt;返回</asp:LinkButton>
</p>
</asp:Content>

