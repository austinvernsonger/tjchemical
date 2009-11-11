<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uploadFile.aspx.cs" Inherits="Engineering_uploadFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript">
    function SubmitForm()
    {
        document.form1.submit ();
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="myFile" type="file" name="myFile" style="display:none" runat="server" />
        <input id="btnSubmit" type="button" runat="server" value="button" name="btnSubmit" onclick="javascript:SubmitForm();" style="display:none" />
        <br />
    </div>
    </form>
</body>
</html>
