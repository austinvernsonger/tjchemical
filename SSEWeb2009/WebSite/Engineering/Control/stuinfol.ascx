<%@ Control Language="C#" AutoEventWireup="true" CodeFile="stuinfol.ascx.cs" Inherits="Engineering_Control_stuinfol" %>
<table width="590" border="1" cellpadding="0" cellspacing="0">
    <tr>
        <td height="22" colspan="6" valign="top">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td width="89" height="29" align="center" valign="middle">
            姓名
        </td>
        <td width="95" align="center" valign="middle">
            <%=stuInfo.StuName%>
        </td>
        <td width="98" align="center" valign="middle">
            学号
        </td>
        <td width="122" align="center" valign="middle">
            <%=stuInfo.StuID %>
        </td>
        <td colspan="2" rowspan="6" align="center" valign="middle">
            <asp:Button ID="Button1" runat="server" Text="上传照片" Width="56px" />
        </td>
    </tr>
    <tr>
        <td height="31" align="center" valign="middle">
            性别
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.Gender %>
        </td>
        <td align="center" valign="middle">
            出生日期
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.Birthday %>
        </td>
    </tr>
    <tr>
        <td height="32" align="center" valign="middle">
            身份证号
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.StuIDNumber %>
        </td>
        <td align="center" valign="middle">
            民族
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.Nation %>
        </td>
    </tr>
    <tr>
        <td height="32" align="center" valign="middle">
            政治面貌
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.PolStatus %>
        </td>
        <td align="center" valign="middle">
            籍贯
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.NativePro %>
        </td>
    </tr>
    <tr>
        <td height="31" align="center" valign="middle">
            寝室
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.Dormitory %>
        </td>
        <td align="center" valign="middle">
            婚姻状况
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.MarStatus %>
        </td>
    </tr>
    <tr>
        <td height="32" align="center" valign="middle">
            导师
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.TeacherName %>
        </td>
        <td align="center" valign="middle">
            Email
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.EmailAddress %>
        </td>
    </tr>
    <tr>
        <td height="32" align="center" valign="middle">
            入学时间
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.Grade %>
        </td>
        <td align="center" valign="middle">
            学制
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.Schooling %>
        </td>
        <td width="74" align="center" valign="middle">
            原学历
        </td>
        <td width="98" align="center" valign="middle">
            <%=stuInfo.OrigDegree %>
        </td>
    </tr>
    <tr>
        <td height="34" align="center" valign="middle">
            学院名称
        </td>
        <td align="center" valign="middle">
        </td>
        <td align="center" valign="middle">
            专业领域名称
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.Major %>
        </td>
        <td align="center" valign="middle">
            学位类别
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.Degree %>
        </td>
    </tr>
    <tr>
        <td height="32" align="center" valign="middle">
            年级
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.Grade %>
        </td>
        <td align="center" valign="middle">
            班级
        </td>
        <td align="center" valign="middle">
            <%=stuInfo.Class %>
        </td>
        <td align="center" valign="middle">
            是否毕业
        </td>
        <td align="center" valign="middle">
        </td>
    </tr>
    <tr>
        <td height="31" align="center" valign="middle">
            手机号码
        </td>
        <td colspan="2" align="center" valign="middle">
            <%=stuInfo.MobPhone %>
        </td>
        <td align="center" valign="middle">
            固定电话
        </td>
        <td colspan="2" align="center" valign="middle">
            <%=stuInfo.FixedPhone %>
        </td>
    </tr>
    <tr>
        <td height="36" align="center" valign="middle">
            通讯地址
        </td>
        <td colspan="2" align="left" valign="middle">
            <%=stuInfo.Address %>
        </td>
        <td align="center" valign="middle">
            邮政编码
        </td>
        <td colspan="2" align="center" valign="middle">
            <%=stuInfo.PostalCode %>
        </td>
    </tr>
    <tr>
        <td height="35" align="center" valign="middle">
            家庭住址
        </td>
        <td colspan="5" align="left" valign="middle">
            <%=stuInfo.HomeAddress %>
        </td>
    </tr>
    <tr>
        <td height="32" align="center" valign="middle">
            工作单位
        </td>
        <td colspan="5" align="left" valign="middle">
            <%=stuInfo.WorkPlace %>
        </td>
    </tr>
    <tr>
        <td height="32" align="center" valign="middle">
            单位地址
        </td>
        <td colspan="5" align="left" valign="middle">
            <%=stuInfo.WorkPlaceAdd %>
        </td>
    </tr>
</table>
