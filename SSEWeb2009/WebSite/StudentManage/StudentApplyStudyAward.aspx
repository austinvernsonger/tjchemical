﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentApplyStudyAward.aspx.cs" Inherits="StudentManage_StudentApplyStudyAward"  MasterPageFile="~/StudentManage/MasterPage/Student_NoNested.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="homeContent" runat="server">

    <asp:SqlDataSource ID="SDS_StudentScholarship" runat="server"  
        ConnectionString="Data Source=10.60.43.9;Initial Catalog=SSE;User ID=sse_basicinfo;Password=abcd" 
        ProviderName="System.Data.SqlClient" >
    </asp:SqlDataSource>
    
    社会活动自评(150字左右):<br />
    <asp:TextBox ID="TxtSASE" runat="server" TextMode="MultiLine" Height="100px" 
        Width="500px" ></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="提交" onclick="Button1_Click" 
        style="height: 26px" />
    <br/>
    <br/>
    <br/>
    课外竞赛:
    
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SDS_ContestStudent"  AutoGenerateDeleteButton="true" 
        DataKeyNames="ID,StudentID" onrowdeleting="GridView1_RowDeleting" 
        AllowPaging="true" PageSize="5" 
        onpageindexchanging="GridView1_PageIndexChanging" >
        <Columns>
           <asp:BoundField DataField="ID" HeaderText="竞赛编号"  />
           <asp:TemplateField HeaderText="竞赛名称" >
               <ItemTemplate>
                    <asp:Label runat="server" ID="ContestNameLb" Text='<%# GetName(Eval("ID")) %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
            <asp:TemplateField HeaderText="获奖等级" >
               <ItemTemplate>
                    <asp:Label runat="server" ID="RankLb" Text='<%# GetRank(Eval("Rank")) %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
            <asp:TemplateField HeaderText="审核状态" >
               <ItemTemplate>
                    <asp:Label runat="server" ID="StatusLb" Text='<%# GetStatus(Eval("Status")) %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
            <asp:BoundField DataField="StudentID" HeaderText="学号"  />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SDS_ContestStudent" runat="server" 
        ConnectionString="Data Source=10.60.43.9;Initial Catalog=SSE;User ID=sse_basicinfo;Password=abcd" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT * FROM [ContestStudent] WHERE ([StudentID] = @StudentID)"
        InsertCommand="INSERT INTO [ContestStudent] ([ID],[StudentID], [Rank]) VALUES (@ID, @StudentID, @Rank)" 
        DeleteCommand="DELETE FROM  [ContestStudent] WHERE ([ID]=@ID AND [StudentID] = @StudentID)">
        <SelectParameters>
            <asp:SessionParameter  Name="StudentID" SessionField="IdentifyNumber" 
                Type="String" />
        </SelectParameters>
         <InsertParameters>
            <asp:ControlParameter Name="ID" ControlID="DDLContestName" PropertyName="SelectedValue"  />
            <asp:SessionParameter  Name="StudentID" SessionField="IdentifyNumber" Type="String"  />
            <asp:ControlParameter Name="Rank" ControlID="DDLContestRank" PropertyName="SelectedValue"  />
            
        </InsertParameters>
        <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
        <asp:Parameter Name="StudentID" Type="String" />
        </DeleteParameters>
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SDS_Contest_ID_Name" runat="server" 
        ConnectionString="Data Source=10.60.43.9;Initial Catalog=SSE;User ID=sse_basicinfo;Password=abcd" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT [Name] FROM [Contest] WHERE ([ID] = @ID)">
        <SelectParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    
    竞赛&nbsp&nbsp&nbsp&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 等级<br />
&nbsp;
    <asp:DropDownList ID="DDLContestName" runat="server" 
        DataSourceID="SDS_Contest" DataTextField="Name" DataValueField="ID">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SDS_Contest" runat="server" 
        ConnectionString="Data Source=10.60.43.9;Initial Catalog=SSE;User ID=sse_basicinfo;Password=abcd" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT [ID], [Name], [Year] FROM [Contest]">
    </asp:SqlDataSource>
    &nbsp&nbsp&nbsp&nbsp
    <asp:DropDownList ID="DDLContestRank" runat="server">
        <asp:ListItem Value="3">一等奖</asp:ListItem>
        <asp:ListItem Value="2">二等奖</asp:ListItem>
        <asp:ListItem Value="1">三等奖</asp:ListItem>
        <asp:ListItem Value="0">入围奖</asp:ListItem>
    </asp:DropDownList>
     &nbsp&nbsp&nbsp&nbsp
     <asp:Button ID="ButtonAdd" Text="添加"  runat="server" 
        onclick="ButtonAdd_Click"/>
    <br />
   
</asp:Content>