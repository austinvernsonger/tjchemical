<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/AlumnusRecord/MasterPage.master" CodeFile="alumnusCenter.aspx.cs" Inherits="Pages_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
         <!--��������ҵ�꼶��Ϣ-->
        <div class="GreenBar">������</div>
        <div style="border: solid 1px;">
            <marquee behavior="scroll" direction="left" loop="infinite" scrollamount="3" onmouseover='this.stop()' onmouseout='this.start()'>                                    
                <asp:DataList ID="dl1" runat="server" DataSourceID="xmlds1" Height="120" HorizontalAlign="Left" RepeatDirection="Horizontal">                     
                     <ItemTemplate>
                         <span style="width: 100%">                                    
                            <a href='alumniList.aspx?year=<%#Eval("graduatingYear") %>&degree=0' style="text-align: center;"><asp:Image runat="server" ImageUrl='<%#Eval("graduatingImage") %>' width="100" height="75" /><br />&nbsp;&nbsp;������<%#Eval("graduatingYear")%>��&nbsp;&nbsp;</a>    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;                                                                    
                         </span>
                     </ItemTemplate>
                 </asp:DataList></marquee>
             <p style="text-align: right"><a href="gradeList.aspx?type=underGraduate">����>></a></p> 
         </div>                              
         <hr />
         <!--�о�����ҵ�꼶��Ϣ-->
         <div class="GreenBar">�о���</div>
         <div style="border: solid 1px;">
            <marquee behavior="scroll" direction="left" loop="infinite" scrollamount="3" onmouseover='this.stop()' onmouseout='this.start()'>                                    
                <asp:DataList ID="DataList2" runat="server" DataSourceID="xmlds2" Height="120" HorizontalAlign="Left" RepeatDirection="Horizontal">                     
                     <ItemTemplate>
                         <span style="width: 100%">                                    
                            <a href='alumniList.aspx?year=<%#Eval("graduatingYear") %>&degree=1' style="text-align: center;"><asp:Image runat="server" ImageUrl='<%#Eval("graduatingImage") %>' width="100" height="75" /><br />&nbsp;&nbsp;�о���<%#Eval("graduatingYear")%>��&nbsp;&nbsp;</a>  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                                                                  
                         </span>
                     </ItemTemplate>
                 </asp:DataList></marquee>
                <p style="text-align: right"><a href="gradeList.aspx?type=postGraduate">����>></a></p>                                                                 
         </div>         
        <asp:XmlDataSource ID="xmlds1" runat="server" DataFile="~/AlumnusRecord/Resources/GraduatingPhotographs/gradeinfo.xml" 
             XPath="/grades/grade[@graduatingType='����']"/>    
        <asp:XmlDataSource ID="xmlds2" runat="server" DataFile="~/AlumnusRecord/Resources/GraduatingPhotographs/gradeinfo.xml" 
             XPath="/grades/grade[@graduatingType='˶ʿ']"/>   
         
    </div>
</asp:Content>