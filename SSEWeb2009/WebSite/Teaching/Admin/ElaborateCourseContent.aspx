<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ElaborateCourseContent.aspx.cs" Inherits="Teaching_Admin_ElaborateCourseContent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 134px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td class="style2">
                    <span lang="zh-cn">序号</span></td>
                <td>
                    <%=IDText %>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span lang="zh-cn">年度</span></td>
                <td>
                    <%=YearText %>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span lang="zh-cn">负责人</span></td>
                <td>
                    <%=ResPersonText %>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span lang="zh-cn">项目名称</span></td>
                <td>
                    <%=ProjectNameText %>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span lang="zh-cn">资助资金</span></td>
                <td>
                    <%=AsCashText %>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span lang="zh-cn">资助时间</span></td>
                <td>
                    <%=AsTimeText %>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span lang="zh-cn">起始时间</span></td>
                <td>
                    <%=StartimeText %>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span lang="zh-cn">终止时间</span></td>
                <td>
                    <%=EndtimeText %>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span lang="zh-cn">精品课程网址</span></td>
                <td>
                    <%=ElaborateNetText %>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span lang="zh-cn">相关发布信息网址</span></td>
                <td>
                    <%=SrcNetText %>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <span lang="zh-cn">备注</span></td>
                <td>
                    <%=AddText %>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
