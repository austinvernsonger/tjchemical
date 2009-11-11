<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test1.aspx.cs" Inherits="Login_test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>

    <script type="text/javascript" src="<%= ConstValue.PureURL%>JavaScript/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="<%= ConstValue.PureURL%>JavaScript/jcarousellite_1.0.1.pack.js"></script>

    <script type="text/javascript" src="<%= ConstValue.PureURL%>JavaScript/YlMarquee.js"></script>

    <script type="text/javascript">
$(document).ready(function(){
    $(".scrollable_demo").jMarquee({
     visible:3,
     step:1,
     direction:"left"
   });
});
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--  外部div使用相对定位，里面的div使用绝对定位 -->
        <div id="sclDiv" runat="server" style="position: absolute; width: 500px; left: 0px;" class="scrollable_demo">
            <ul>
                <li><a href="../Files/Upload/2009Y/06M/Picture1.JPG" rel="clearbox" title="同济大学软件学院"><img src="http://localhost:4456/WebSite/Files/Upload/2009Y/06M/t_Picture1.JPG" width="85" height="71" border="0" class="pic"/></a></li>
                <li><a href="../Files/Upload/2009Y/06M/SI851401.JPG" rel="clearbox" title="同济大学软件学院"><img src="http://localhost:4456/WebSite/Files/Upload/2009Y/06M/t_SI851401.JPG" width="85" height="71" border="0" class="pic"/></a></li>
                <li><a href="../Files/Upload/2009Y/06M/Picture1.JPG" rel="clearbox" title="同济大学软件学院"><img src="http://localhost:4456/WebSite/Files/Upload/2009Y/06M/t_Picture1.JPG" width="85" height="71" border="0" class="pic"/></a></li>
                <li><a href="../Files/Upload/2009Y/06M/SI851401.JPG" rel="clearbox" title="同济大学软件学院"><img src="http://localhost:4456/WebSite/Files/Upload/2009Y/06M/t_SI851401.JPG" width="85" height="71" border="0" class="pic"/></a></li>
                <li><a href="../Files/Upload/2009Y/06M/Picture1.JPG" rel="clearbox" title="同济大学软件学院"><img src="http://localhost:4456/WebSite/Files/Upload/2009Y/06M/t_Picture1.JPG" width="85" height="71" border="0" class="pic"/></a></li>
                <li><a href="../Files/Upload/2009Y/06M/SI851401.JPG" rel="clearbox" title="同济大学软件学院"><img src="http://localhost:4456/WebSite/Files/Upload/2009Y/06M/t_SI851401.JPG" width="85" height="71" border="0" class="pic"/></a></li>
            </ul>
        </div>
        <!-- "prev page" link -->
    </div>
    </form>
</body>
</html>
