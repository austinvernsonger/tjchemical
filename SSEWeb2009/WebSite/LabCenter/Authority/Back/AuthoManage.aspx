<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuthoManage.aspx.cs" Inherits="_AuthoManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    
    <form id="form1" runat="server">
    
    <div>
        <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 37px; position: absolute;
            top: 55px" Text="帐号："></asp:Label>
        <asp:Label ID="IDLabel" runat="server" Style="z-index: 101; left: 92px; position: absolute;
            top: 52px; bottom: 536px;" Text="IDLabel"></asp:Label>
        <asp:Label ID="Label6" runat="server" Style="z-index: 105; left: 22px; position: absolute;
            top: 95px" Text="管理权限"></asp:Label>
        <asp:Label ID="EquipLabel" runat="server" Style="z-index: 106; left: 311px; position: absolute;
            top: 163px" Text="设备管理"></asp:Label>
         <asp:CheckBox ID="CheckBox7_1" runat="server" Enabled="False" Style="z-index: 107;
            left: 401px; position: absolute; top: 161px; right: 123px;" 
            Text="设备信息管理" />
        <asp:CheckBox ID="CheckBox7_2" runat="server" Enabled="False" Style="z-index: 109;
            left: 393px; position: absolute; top: 212px; height: 20px;" 
            Text="设备借用批准" />
        <asp:Label ID="ExpeLabel" runat="server" Style="z-index: 113; left: 314px; position: absolute;
            top: 378px" Text="实验管理"></asp:Label>
        <asp:Button ID="AuthoChange" runat="server" OnClick="AuthoChange_Click" Style="z-index: 118;
            left: 80px; position: absolute; top: 670px" Text="修改权限" />
   
        <asp:Button ID="SuperTransfer" runat="server" Style="z-index: 119; left: 267px; position: absolute;
            top: 669px" Text="移交超级管理员权限" OnClick="SuperTransfer_Click" />
        <asp:Button ID="GetReturn" runat="server" OnClick="GetReturn_Click" Style="z-index: 120;
            left: 469px; position: absolute; top: 668px" Text="返回" />
        <asp:CheckBox ID="CheckBox1_1" runat="server" Enabled="False" Style="z-index: 122;
            left: 139px; position: absolute; top: 128px" Text="编辑实验中心介绍" />
        <asp:Label ID="NoticeLabel" runat="server" Style="z-index: 123; left: 28px; position: absolute;
            top: 163px" Text="通知管理"></asp:Label>
        <asp:CheckBox ID="CheckBox2_1" runat="server" Enabled="False" Style="z-index: 124;
            left: 139px; position: absolute; top: 163px" Text="添加通知" />
        <asp:CheckBox ID="CheckBox2_3" runat="server" Enabled="False" Style="z-index: 126;
            left: 137px; position: absolute; top: 221px; height: 20px;" Text="删除通知" />
        <asp:CheckBox ID="CheckBox3_1" runat="server" Enabled="False" Style="z-index: 128;
            left: 136px; position: absolute; top: 258px" Text="添加新闻" />
        <asp:CheckBox ID="CheckBox3_2" runat="server" Enabled="False" Style="z-index: 129;
            left: 134px; position: absolute; top: 288px; height: 20px;" Text="修改新闻" />
        <asp:CheckBox ID="CheckBox3_3" runat="server" Enabled="False" Style="z-index: 130;
            left: 132px; position: absolute; top: 320px" Text="删除新闻" />
        <asp:Label ID="LawLabel1" runat="server" Style="z-index: 131; left: 27px; position: absolute;
            top: 369px" Text="规章制度"></asp:Label>
        <asp:CheckBox ID="CheckBox4_1" runat="server" Enabled="False" Style="z-index: 132;
            left: 129px; position: absolute; top: 365px" Text="添加规章制度" />
        <asp:CheckBox ID="CheckBox4_2" runat="server" Enabled="False" Style="z-index: 133;
            left: 129px; position: absolute; top: 395px" Text="修改规章制度" />
        <asp:CheckBox ID="CheckBox4_3" runat="server" Enabled="False" Style="z-index: 134;
            left: 125px; position: absolute; top: 430px" Text="删除规章制度" />
    
    
    
        <asp:CheckBox ID="CheckBox2_2" runat="server" Enabled="False" Style="z-index: 125;
            left: 138px; position: absolute; top: 194px; height: 17px;" Text="修改通知" />
        
        <asp:Label ID="IntroLabel" runat="server" Style="z-index: 121; left: 27px; position: absolute;
            top: 130px; height: 17px;" Text="实验中心介绍"></asp:Label>
        
        <asp:Label ID="Label5" runat="server" Style="z-index: 104; left: 25px; position: absolute;
            top: 20px">账户信息</asp:Label>
        
    
   
        <asp:Label ID="NewsLabel" runat="server" Style="z-index: 127; left: 30px; position: absolute;
            top: 259px; height: 16px; width: 64px;" Text="新闻管理"></asp:Label>
        
    <asp:Button ID="Reverse" runat="server" onclick="Reverse_Click" 
        style="z-index: 1; left: 173px; top: 669px; position: absolute" 
        Text="取消修改" Enabled="False" />
    
        
    
    <asp:Label ID="AchieveLabel" runat="server" Style="z-index: 140; left: 31px; position: absolute;
            top: 478px; height: 17px; width: 64px; margin-bottom: 4px;" Text="成果展示"></asp:Label>
    
    
        <asp:Label ID="NameLabel" runat="server" Style="z-index: 103; left: 263px; position: absolute;
            top: 53px; right: 307px;">NameLabel</asp:Label>
        <asp:Label ID="Label3" runat="server" Style="z-index: 102; left: 195px; position: absolute;
            top: 53px; height: 20px;" Text="姓名："></asp:Label>
           <asp:CheckBox ID="CheckBox6_3" runat="server" 
            Style="z-index: 102; position: absolute; top: 626px; left: 129px;" 
            Text="删除技术资料" Enabled="False"/>
            <asp:CheckBox ID="CheckBox6_1" runat="server" 
            Style="z-index: 102; position: absolute; top: 569px; left: 126px;" 
            Text="添加技术资料" Enabled="False"/>
            <asp:CheckBox ID="CheckBox9_1" runat="server" 
            Style="z-index: 102; position: absolute; top: 575px; left: 400px; height: 20px;" 
            Text="查看报修记录" Enabled="False"/>
            <asp:CheckBox ID="CheckBox6_2" runat="server" 
            Style="z-index: 102; position: absolute; top: 596px; left: 127px;" 
            Text="修改技术资料" Enabled="False"/>
            <asp:CheckBox ID="CheckBox5_3" runat="server" 
            Style="z-index: 102; position: absolute; top: 533px; left: 130px;" 
            Text="成果展示" Enabled="False"/>
            <asp:CheckBox ID="CheckBox9_2" runat="server" 
            Style="z-index: 102; position: absolute; top: 575px; left: 539px;" 
            Text="确认报修记录" Enabled="False"/>
            <asp:CheckBox ID="CheckBox5_1" runat="server" 
            Style="z-index: 102; position: absolute; top: 470px; left: 128px;" 
            Text="添加成果展示" Enabled="False"/>
            <asp:CheckBox ID="CheckBox5_2" runat="server" 
            Style="z-index: 102; position: absolute; top: 503px; left: 130px;" 
            Text="修改成果展示" Enabled="False"/>
            <asp:CheckBox ID="CheckBox9_3" runat="server"    
            Style="z-index: 102; position: absolute; top: 611px; left: 394px; " 
            Text="取消报修记录" Enabled="False"/>
    
    <asp:Label ID="techLabel" runat="server" Text="技术资料" 
        Style="z-index: 102; position: absolute; top: 573px; left: 35px;"></asp:Label>
    
    <asp:Label ID="repairLabel" runat="server" Text="设备保修"  
        Style="z-index: 102; position: absolute; top: 572px; left: 316px;"></asp:Label>
        </div>
    <p>
        <asp:CheckBox ID="CheckBox8_1" runat="server" Enabled="False" Style="z-index: 109;
            left: 407px; position: absolute; top: 377px" Text="设备借用批准" />
        </p>
    </form>
    
</body>
</html>
