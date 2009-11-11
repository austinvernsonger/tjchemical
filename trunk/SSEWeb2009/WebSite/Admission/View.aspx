<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="RecruitmentNew_View" %>

<%@ Register Src="../UserControl/ViewMMT.ascx" TagName="ViewMMT" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        <uc1:ViewMMT ID="ViewMMT1" runat="server"/>
    </div>
    <div id="bottom" align="center">
           同济大学软件学院 2009 &copy
    </div>
    </form>
</body>
</html>
