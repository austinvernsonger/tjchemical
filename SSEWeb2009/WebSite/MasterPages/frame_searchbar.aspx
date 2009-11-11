<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frame_searchbar.aspx.cs" Inherits="MasterPages_frame_searchbar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
    @import url(http://www.google.com/cse/api/branding.css);
    </style>
    <script type="text/javascript">
        function onBarFocus()
        {
            var str = document.getElementById("inputBox").value;
            if (str == "Google搜索")
            {
                document.getElementById("inputBox").value = "";
            }
        }
        
        function onBarBlur()
        {
            var str = document.getElementById("inputBox").value;
            if (str == "")
            {
                document.getElementById("inputBox").value = "Google搜索";
            }
        }
        
    </script>
</head>
    <body style="margin-top: 0; margin-left: 0;"> 
    <div class="cse-branding-right" style="background-color:Transparent;color:#000000">
      <div class="cse-branding-form">
        <form action="http://www.google.com/cse" id="Form1" target="_blank">
          <div>
            <input type="hidden" name="cx" value="006561871041232888483:epo3ndxltnc" />
            <input type="hidden" name="ie" value="UTF-8" />
            <input type="text" name="q" size="19" 
                style="border-style:none; height:16px; background-color:Transparent; font-family:Verdana; font-size:12px; color: #808080; width: 142px; padding:2px"
                id="inputBox" value="Google搜索" onblur="onBarBlur()" onfocus="onBarFocus()"/>
            <input type="hidden" name="sa" value="搜索" />
          </div>
        </form>
      </div>
    </div>
</body>
</html>
