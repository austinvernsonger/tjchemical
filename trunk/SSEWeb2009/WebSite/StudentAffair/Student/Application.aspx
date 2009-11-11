<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAffair/Student/MasterPage.master"
    AutoEventWireup="true" CodeFile="Application.aspx.cs" Inherits="StudentAffair_Student_Application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="border: 5px solid #0000FF; width: 320px; float: left; height: 200px;">
        <h2>
            可申请项(圆角)</h2>
        <ol>
            <li><a href="">xxx奖学金申请通知</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <a href="">查看</a></li>
            <li><a href="">xxx奖学金申请通知</a></li>
            <li><a href="">xxx奖学金申请通知</a></li>
        </ol>        
        <a href="">更早的</a>
    </div>
    <div style="border: 5px solid #0000FF; width: 320px; float: right; height: 200px;">
        <h2>
            审核中的申请</h2><!--绑定到gridview上去-->
                <ol>
            <li><a href="">xxx奖学金</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="">取消</a></li>
            <li><a href="">xxx奖学金</a></li>
            <li><a href="">xxx奖学金</a></li>
        </ol>        
        <a href="">更早的</a>
    </div>
    <div style="clear: both;">
        <br />
    </div>
    <div style="border: 5px solid #0000FF; width: 320px; float: left; height: 200px;">
        <h2>
            申请记录</h2>
         <ol>
            <li><a href="">xxx奖学金</a> 通过 2008-12-12&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <a href="">查看</a></li>
            <li><a href="">xxx奖学金</a> 通过 2008-12-12&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </li>
            <li><a href="">xxx奖学金</a> 通过 2008-12-12</li>
        </ol>        
        <a href="">更多</a>
    </div>
    <div style="border: 5px solid #0000FF; width: 320px; float: right; height: 200px;">
        <h2>
            获奖记录管理</h2>
        <ol>
            <li><a href="">xxx科技竞赛一奖</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <a href="">查看</a></li>
            <li><a href="">xxx社会活动一等奖</a></li>
            <li><a href="">xxx程序设计大赛三等奖</a></li>
        </ol>        
        <a href="">查看更多</a><br />
        <a href="">添加记录</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="">更新记录</a>
    </div>
    <br style="clear: both;" />
</asp:Content>
