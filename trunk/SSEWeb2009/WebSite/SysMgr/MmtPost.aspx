<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/ManageSite.master"
    AutoEventWireup="true" CodeFile="MmtPost.aspx.cs" Inherits="SysMgr_MmtPost" %>

<%@ Register Src="~/UserControl/EditMMT.ascx" TagName="EditMMT" TagPrefix="uc" %>


<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript" src="../JavaScript/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../JavaScript/jquery-ui-1.7.2.custom.min.js"></script>
<script language="javascript" type="text/javascript">
      $(function(){
      $('#tabs').tabs();
      });
</script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderDefault" runat="Server">

<style type="text/css">
    .ui-tabs-nav
{
/*导航容器定义*/
}
.ui-tabs-nav li
{
/*默认标签样式*/
}
.ui-tabs-nav li.ui-tabs-selected
{
/*激活的标签样式*/
}
.ui-tabs-panel
{
/*默认的显示区域样式*/
}
.ui-tabs-hide
{
display: none;
}
.tab_style{ list-style-type:none; float:left; width:280px; line-height:30px}
.tab_style li{ float:left; position:relative; display:inline}
.tab_style li a{ padding-left:30px; padding-right:30px; background-image:url(../Resources/Images/tab_body.png)}
.tab_left{ background-image:url(../Resources/Images/tab_left.png); background-position:left top; background-repeat:no-repeat}
.tab_right{ background-image:url(../Resources/Images/tab_right.png); background-position:right top; background-repeat:no-repeat}
</style>
<div class="divstyle">
<a href="NewsEdit.aspx" target="editmmt">新闻发布</a>|
<a href="ActivityEdit.aspx" target="editmmt">活动发布</a>|
<a href="NoticeEdit.aspx" target="editmmt">通知发布</a>|
<iframe name="editmmt" allowTransparency=true height="800px" width="95%" style="border-style:none;" src="NewsEdit.aspx" frameborder="0" scrolling="no" height="100%"></iframe>
</div>
</asp:Content>
