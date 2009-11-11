<%@ Page Language="C#" MasterPageFile="MasterPages/HomeMaster.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="LabCenter_Default" %>

<%@ Register src="../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <div id="MainPic">
            <div style="position:relative; left:295px; top:21px; width: 395px; height: 105px; color:#666; font-size:12px;">
                实验中心……</div>
           </div>
           <div id="announce">
	          <h2>实验室通知</h2>
	              <uc1:MMTList ID="MMTList2" runat="server" AllowPaging="false" DepartmentId="3" 
                        Management="false" Mode="Notice" ShowClickCount="True" 
                        ShowTime="True" InternalOnly="true" 
                        ShowURL="~/LabCenter/Notice/Show.aspx"  />
	              <a href="Notice/List.aspx" class="link_more">更多</a>    
	       </div>
		   <div id="news">
			  <h2>实验室新闻</h2>
			      <uc1:MMTList ID="MMTList1" runat="server" AllowPaging="false" DepartmentId="3" 
                        Management="false" Mode="news" ShowClickCount="True" 
                        ShowTime="True" InternalOnly="true" 
                        ShowURL="~/LabCenter/News/Show.aspx"  />
			      <a href="News/List.aspx" class="link_more">更多</a>
		   </div>
</asp:Content>