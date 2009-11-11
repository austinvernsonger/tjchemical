<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditIntroduction.aspx.cs" Inherits="LabCenter_Introduction_Back_EditIntroduction" %>
<%@ Register Src="~/UserControl/EditMMT.ascx" TagName="EditMMT" TagPrefix="ucl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>实验中心介绍</title>
</head>
<body>
   <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
       实验中心介绍
       <br />
        <div style="width: 75%"><ucl:EditMMT ID="editMMT" runat="server" Mode="passage" NewPost="false" MMTID="LABCENTER_INTRODUCTION"/></div>
      
        
    </div>
    </form>
</body>
</html>

