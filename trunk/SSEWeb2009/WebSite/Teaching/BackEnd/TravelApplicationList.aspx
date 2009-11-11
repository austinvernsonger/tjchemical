<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TravelApplicationList.aspx.cs" Inherits="Teaching_BackEnd_TravelApplicationList" %>

<%@ Register src="../LinkListEx.ascx" tagname="LinkListEx" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        出差申请记录<br />
        <br />
        <uc1:LinkListEx ID="LinkListEx" runat="server" 
           TargetPage="/Teaching/BackEnd/TravelApplicationLabel.aspx" 
           TargetPageSE="~/Teaching/BackEnd/TravelSummary.aspx" />

    
    </div>
    
     <p>
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/Resources/Images/newrecord.PNG" 
            PostBackUrl="~/Teaching/BackEnd/TravelApplication.aspx" />
    </p>
    </form>
</body>
</html>
