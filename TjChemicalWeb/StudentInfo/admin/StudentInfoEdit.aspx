﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="StudentInfoEdit.aspx.cs" Inherits="StudentInfo_admin_StudentInfoEdit" Title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
    <asp:Label ID="lbErrorMessage" runat="server" ></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        HeaderText="请完成纠正以下错误后再按保存键" ShowMessageBox="True" ShowSummary="False" />
<p>
    照片
   <asp:Image ID="ImgPersonalPhoto" runat="server" /> 

</p>
<p>
    学院
    <asp:TextBox ID="txtCollege" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtCollege" ErrorMessage="请输入学院！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
   系所
   <asp:DropDownList ID="DropDownListDepartment" runat="server"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="DropDownListDepartment" ErrorMessage="请选择系所！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    目前所在单位
    <asp:DropDownList ID="DropDownListWorkUnit" runat="server"></asp:DropDownList>
</p>
<p>
    学号
    <asp:Label ID="lbStudentID" runat="server"></asp:Label>
</p>
<p>
    姓名
    <asp:Label ID="lbName" runat="server"></asp:Label>
</p>
<p>
    曾用名
    <asp:TextBox ID="txtOriginalName" runat="server"></asp:TextBox>
</p>
<p>
    性别
    <asp:DropDownList ID="DropDownListGender" runat="server">
        <asp:ListItem Value="0">女</asp:ListItem>
        <asp:ListItem Value="1">男</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="DropDownListGender" ErrorMessage="请选择性别！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    籍贯
    <asp:TextBox ID="txtNativeProvince" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtNativeProvince" ErrorMessage="请输入籍贯！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    生日
    <asp:TextBox ID="txtBirthDay" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="txtBirthDay" ErrorMessage="请输入生日！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                    TargetControlID="txtBirthday" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
</p>
<p>
    民族
    <asp:TextBox ID="txtNation" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtNation" ErrorMessage="请输入民族！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    出生地
    <asp:TextBox ID="txtBirthPlace" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ControlToValidate="txtBirthPlace" ErrorMessage="请输入出生地！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    家庭出身
    <asp:TextBox ID="txtHomeBirth" runat="server"></asp:TextBox>
</p>
<p>
        政治面貌 
        <asp:DropDownList ID="DropDownListPoliticalStatus" runat="server">
            <asp:ListItem Value="0">群众</asp:ListItem>
            <asp:ListItem Value="1">团员</asp:ListItem>
            <asp:ListItem Value="2">预备党员</asp:ListItem>
            <asp:ListItem Value="3">党员</asp:ListItem>
            <asp:ListItem Value="4">民主党派</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
        ControlToValidate="DropDownListPoliticalStatus" ErrorMessage="请选择政治面貌！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    证件类型
    <asp:TextBox ID="txtPaperworktype" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
        ControlToValidate="txtPaperworktype" ErrorMessage="请输入证件类型！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    证件号码
    <asp:TextBox ID="txtPaperworkNum" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
        ControlToValidate="txtPaperworkNum" ErrorMessage="请输入证件号码！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    婚姻状况
    <asp:DropDownList ID="DropDownListMarriage" runat="server">
        <asp:ListItem Value="0">未婚</asp:ListItem>
        <asp:ListItem Value="1">已婚</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
        ControlToValidate="DropDownListMarriage" ErrorMessage="请选择婚姻状况！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    配偶姓名
    <asp:TextBox ID="txtConsortName" runat="server"></asp:TextBox>
</p>
<p>
    配偶电话
    <asp:TextBox ID="txtConsortPhoneNumber" runat="server"></asp:TextBox>
</p>
<p>
    配偶单位
    <asp:TextBox ID="txtConsortWorkingPlace" runat="server"></asp:TextBox>
</p>
<p>
    入学年份
    <asp:TextBox ID="txtEntranceYear" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
        ControlToValidate="txtEntranceYear" ErrorMessage="请输入入学年份！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    入学季度
    <asp:DropDownList ID="DropDownListEntranceSeason" runat="server">
        <asp:ListItem Value="0">秋季</asp:ListItem>
        <asp:ListItem Value="1">春季</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
        ControlToValidate="DropDownListEntranceSeason" ErrorMessage="请输入入学季度！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    年级
    <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
        ControlToValidate="txtGrade" ErrorMessage="请输入年级！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    班级
    <asp:TextBox ID="txtClass" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
        ControlToValidate="txtClass" ErrorMessage="请输入班级！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    学制
    <asp:TextBox ID="txtStudyTime" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
        ControlToValidate="txtStudyTime" ErrorMessage="请输入学制！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    入学前单位
    <asp:TextBox ID="txtWorkingPlaceBeforeSchool" runat="server"></asp:TextBox>
</p>
<p>
    就读方式
    <asp:DropDownList ID="DropDownListStudyType" runat="server">
        <asp:ListItem Value="0">住读</asp:ListItem>
        <asp:ListItem Value="1">走读</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
        ControlToValidate="DropDownListStudyType" ErrorMessage="请选择就读方式！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    目前状态
    <asp:DropDownList ID="DropDownListNowCondition" runat="server">
        <asp:ListItem Value="0">在读</asp:ListItem>
        <asp:ListItem Value="1">出国</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
        ControlToValidate="DropDownListNowCondition" ErrorMessage="请选择目前状态！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    来源洲别
    <asp:DropDownList ID="DropDownListContinent" runat="server">
        <asp:ListItem Value="0">亚洲</asp:ListItem>
        <asp:ListItem Value="1">欧洲</asp:ListItem>
        <asp:ListItem Value="2">非洲</asp:ListItem>
        <asp:ListItem Value="3">北美洲</asp:ListItem>
        <asp:ListItem Value="4">南美洲</asp:ListItem>
        <asp:ListItem Value="5">大洋洲</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
        ControlToValidate="DropDownListContinent" ErrorMessage="请选择来源洲别！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    来源国别
    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
        ControlToValidate="txtCountry" ErrorMessage="请输入来源国别！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    生源地
    <asp:TextBox ID="txtStudentSource" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
        ControlToValidate="txtStudentSource" ErrorMessage="请输入生源地！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    学生类别
    <asp:DropDownList ID="DropDownListStudentType" runat="server">
        <asp:ListItem Value="0">本科生</asp:ListItem>
        <asp:ListItem Value="1">研究生</asp:ListItem>
        <asp:ListItem Value="2">博士生</asp:ListItem>
    </asp:DropDownList>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
        ControlToValidate="DropDownListStudentType" ErrorMessage="请选择学生类别！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    培养方式
    <asp:DropDownList ID="DropDownListTrainType" runat="server">
       <asp:ListItem Value="0">国家统考</asp:ListItem>
       <asp:ListItem Value="1">在职单考</asp:ListItem>
       <asp:ListItem Value="2">定向委培</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
        ControlToValidate="DropDownListTrainType" ErrorMessage="请选择培养方式！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    资助方式
    <asp:DropDownList ID="DropDownListSubsidizeType" runat="server">
        <asp:ListItem Value="0">本科全日制</asp:ListItem>
        <asp:ListItem Value="1">全日制A</asp:ListItem>
        <asp:ListItem Value="2">全日制B</asp:ListItem>
        <asp:ListItem Value="3">定向委培</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" 
        ControlToValidate="DropDownListSubsidizeType" ErrorMessage="请选择资助方式！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    现在专业
    <asp:TextBox ID="txtField" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
        ControlToValidate="txtField" ErrorMessage="请输入现在专业！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    专业方向
    <asp:TextBox ID="txtFieldDirection" runat="server"></asp:TextBox>
</p>
<p>
    导师
    <asp:TextBox ID="txtTeacher" runat="server"></asp:TextBox>
</p>
<p>
    健康状况
    <asp:TextBox ID="txtHealth" runat="server"></asp:TextBox>
</p>
<p>
    血型
    <asp:TextBox ID="txtBloodType" runat="server"></asp:TextBox>
</p>
<p>
    预计毕业年份
    <asp:TextBox ID="txtGraduation" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" 
        ControlToValidate="txtGraduation" ErrorMessage="请输入预计毕业年份！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    预计毕业季度
    <asp:DropDownList ID="DropDownListGraduationSeason" runat="server">
        <asp:ListItem Value="0">秋季</asp:ListItem>
        <asp:ListItem Value="1">春季</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" 
        ControlToValidate="DropDownListGraduationSeason" ErrorMessage="请选择预计毕业季度！" SetFocusOnError="False">*</asp:RequiredFieldValidator>
</p>
<p>
    实际毕业时间
    <asp:TextBox ID="txtGraduationTime" runat="server"></asp:TextBox>
</p>
<p>
    毕业身份
    <asp:DropDownList ID="DropDownListGraduationType" runat="server">
        <asp:ListItem Value="0">本科生</asp:ListItem>
        <asp:ListItem Value="1">硕士</asp:ListItem>
        <asp:ListItem Value="2">博士</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
   火车乘车区间
   <asp:TextBox ID="txtTrainArriveDestination" runat="server"></asp:TextBox>
</p>
<p>
    宿舍号
    <asp:TextBox ID="txtDormitoryNum" runat="server"></asp:TextBox>
</p>
<p>
    寝室号
    <asp:TextBox ID="txtDormitoryRoom" runat="server"></asp:TextBox>
</p>
<p>
    宿舍电话
    <asp:TextBox ID="txtDormitoryPhone" runat="server"></asp:TextBox>
</p>
<p>
    常用电子邮箱
    <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
</p>
<p>
    QQ
    <asp:TextBox ID="txtQQ" runat="server"></asp:TextBox>
</p>
<p>
    MSN
    <asp:TextBox ID="txtMSN" runat="server"></asp:TextBox>
</p>
<p>
    家庭电话
    <asp:TextBox ID="txtHomePhone" runat="server"></asp:TextBox>
</p>
<p>
    家庭住址
    <asp:TextBox ID="txtHomeAddress" runat="server"></asp:TextBox>
</p>
<p>
    家庭邮编
    <asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox>
</p>
<p>
    户口所在地
    <asp:TextBox ID="txtRegisteredResidence" runat="server"></asp:TextBox>
</p>
<p>
    户口性质
    <asp:TextBox ID="txtRegisteredResidenceProperty" runat="server"></asp:TextBox>
</p>
<p>
    父亲姓名
    <asp:TextBox ID="txtFatherName" runat="server"></asp:TextBox>
</p>
<p>
    父亲电话
    <asp:TextBox ID="txtFatherPhone" runat="server"></asp:TextBox>
</p>
<p>
    父亲工作单位
    <asp:TextBox ID="txtFatherWorkingPlace" runat="server"></asp:TextBox>
</p>
<p>
    母亲姓名
    <asp:TextBox ID="txtMotherName" runat="server"></asp:TextBox>
</p>
<p>
    母亲电话
    <asp:TextBox ID="txtMotherPhone" runat="server"></asp:TextBox>
</p>
<p>
    母亲工作单位
    <asp:TextBox ID="txtMotherWorkingPlace" runat="server"></asp:TextBox>
</p>
<p>
    审核：
    <asp:DropDownList ID="DropDownListVal" runat="server">
        <asp:ListItem Value="0">未审核</asp:ListItem>
        <asp:ListItem Value="1">未通过</asp:ListItem>
        <asp:ListItem Value="2">通过</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    未通过理由：
    <br />
    <asp:TextBox ID="txtReason" runat="server" Height="150px" TextMode="MultiLine" 
        Width="433px"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btConfirm" runat="server" Text="确认提交" 
        onclick="btConfirm_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btBack" runat="server" Text="返回" onclick="btBack_Click" />
</p>
</asp:Content>

