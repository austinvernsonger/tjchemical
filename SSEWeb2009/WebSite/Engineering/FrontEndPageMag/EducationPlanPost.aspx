<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EducationPlanPost.aspx.cs" Inherits="Engineering_FrontEndPageMag_EducationPlanPost" %>

<%@ Register src="../../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px">
        更新培养方案
    </div>
    <hr />
    <br />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:EditMMT ID="EditMMT1" runat="server"  DepartmentId="4" Mode="Passage"  MMTID="EDUCATION_PLAN"
        AllowAttachment="false" EditHeight="800" NewPost="false" onsuccessgoto="EducationPlanMag.aspx" ToolbarStartExpanded="true" /> 
    </div>
    </form>
</body>
</html>
