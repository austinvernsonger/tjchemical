<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="RecruitmentNew_Admin" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #top {
            width: 955px;
            margin: 0 auto;
            background-image: url("./img/logo.jpg");
            height: 150px;
        }
        #top_left {
            float: left;
        }
        #top_right {
            float: right;
            width: 150px;
            padding-top: 3px;
        }
        #top_right a {
            color: #ff00ff;
            margin-left: 40px;
        }
        #top_right a:hover {
            text-decoration: underline;
        }
        #body {
            width: 955px;
            margin-left: auto;
            margin-right: auto;
        }
        #view {
            width: 955px;
            margin: 0 auto;
        }
        #bottom {
            width: 955px;
            margin: 0 auto;
            background-image:url("./img/bottom.jpg");
            color:Lime;
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="top">
        <div id="top_left">
        </div>
        <div id="top_right">
            <a href="#">主站</a> <a href="#">首页</a>
        </div>
    </div>
    <div id="view">
       
        <asp:Label ID="Label1" runat="server" Text="请输入您要指定的管理员 编号（工号或学号）"></asp:Label>
        <br />
        <asp:TextBox ID="TxtAdminID" runat="server" Height="20px" Width="187px"></asp:TextBox>
       
      
       
       
    </div>
    <div id="bottom" align="center">
        同济大学软件学院 2009 &copy
    </div>
    </form>
</body>
</html>
