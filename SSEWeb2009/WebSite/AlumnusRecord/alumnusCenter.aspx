<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/AlumnusRecord/MasterPage.master" CodeFile="alumnusCenter.aspx.cs" Inherits="Pages_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
         <!--本科生毕业年级信息-->
        <div class="GreenBar">本科生</div>
        <div style="border: solid 1px;">
            <marquee behavior="scroll" direction="left" loop="infinite" scrollamount="3" onmouseover='this.stop()' onmouseout='this.start()'>                                    
                <asp:DataList ID="dl1" runat="server" DataSourceID="xmlds1" Height="120" HorizontalAlign="Left" RepeatDirection="Horizontal">                     
                     <ItemTemplate>
                         <span style="width: 100%">                                    
                            <a href='alumniList.aspx?year=<%#Eval("graduatingYear") %>&degree=0' style="text-align: center;"><asp:Image runat="server" ImageUrl='<%#Eval("graduatingImage") %>' width="100" height="75" /><br />&nbsp;&nbsp;本科生<%#Eval("graduatingYear")%>级&nbsp;&nbsp;</a>    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;                                                                    
                         </span>
                     </ItemTemplate>
                 </asp:DataList></marquee>
             <p style="text-align: right"><a href="gradeList.aspx?type=underGraduate">更多>></a></p> 
         </div>                              
         <hr />
         <!--研究生毕业年级信息-->
         <div class="GreenBar">研究生</div>
         <div style="border: solid 1px;">
            <marquee behavior="scroll" direction="left" loop="infinite" scrollamount="3" onmouseover='this.stop()' onmouseout='this.start()'>                                    
                <asp:DataList ID="DataList2" runat="server" DataSourceID="xmlds2" Height="120" HorizontalAlign="Left" RepeatDirection="Horizontal">                     
                     <ItemTemplate>
                         <span style="width: 100%">                                    
                            <a href='alumniList.aspx?year=<%#Eval("graduatingYear") %>&degree=1' style="text-align: center;"><asp:Image runat="server" ImageUrl='<%#Eval("graduatingImage") %>' width="100" height="75" /><br />&nbsp;&nbsp;研究生<%#Eval("graduatingYear")%>级&nbsp;&nbsp;</a>  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                                                                  
                         </span>
                     </ItemTemplate>
                 </asp:DataList></marquee>
                <p style="text-align: right"><a href="gradeList.aspx?type=postGraduate">更多>></a></p>                                                                 
         </div>         
        <asp:XmlDataSource ID="xmlds1" runat="server" DataFile="~/AlumnusRecord/Resources/GraduatingPhotographs/gradeinfo.xml" 
             XPath="/grades/grade[@graduatingType='本科']"/>    
        <asp:XmlDataSource ID="xmlds2" runat="server" DataFile="~/AlumnusRecord/Resources/GraduatingPhotographs/gradeinfo.xml" 
             XPath="/grades/grade[@graduatingType='硕士']"/>   
         
    </div>
</asp:Content>