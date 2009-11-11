<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Home.aspx.cs" Inherits="Home"  MasterPageFile="~/StudentManage/MasterPage/Home.master"%>
<%@ Register Src="~/UserControl/MMTList.ascx" TagName="MMTList" TagPrefix="uc" %>


<asp:Content ID="Content1" ContentPlaceHolderID="homeContent" runat="server">
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />

    <div id="leftup">
        <script type="text/javascript">
            var str0='14:25 新闻0：小泉称若……</a><br>';
            var str1='14:25 新闻1：小泉称若……</a><br>';
            var str2='14:25 新闻2：小泉称若……</a><br>';
            var str3='14:25 新闻3：小泉称若……</a><br>';
            var str4='14:25 新闻4：小泉称若……</a><br>';
            var showstr=str0+str1+str2+str3+str4;
            
            document.write(' <marquee id="scrollarea" direction="up" scrolldelay="20" scrollamount="5" width="60%" height="50" onmouseover="this.stop();" onmouseout="this.start();"> '+showstr+'</marquee>');
        </script> 
    </div>
    
    <div id="leftmid">
    <uc:mmtlist id="mmtlist" runat="server" departmentid="0" showtime="true" showclickcount="true" mode="notice" management="true" emptystring="no" pagesize="3" allowpaging="true" />
    </div>
    <div id="leftdown">
    这里是学生风采
    </div>
    <div id="right">
    友情链接1<br />友情链接2<br />友情链接3<br />
    
    </div>
</asp:Content>