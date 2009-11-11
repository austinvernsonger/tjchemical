<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyOpenSpeech.aspx.cs" Inherits="Engineering_StuBackMag_MyOpenSpeech" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的开题报告--工程硕士中心</title>
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />
     <script src="../Resources/JavaScript/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Resources/JavaScript/jquery.cookie.js" type="text/javascript"></script>
    <style type="text/css">
        .watermarked
        {
            border: 1px solid #BEBEBE;
            background-color: #F0F8FF;
            color: gray;
        }
    </style>
    <script type="text/javascript">
        $(function(){
            $("#leaveMessage").toggle(
                function() {
                    $("#divmessage").css("display","block");
                    $.cookie('status', 'collapsed');
                },
                function() {                   
                    $("#divmessage").css("display","none");
                    $.cookie('status', 'expand');
                });    
                var status =$.cookie('status'); 
                if(status == 'collapsed'){
                    $("#divmessage").css("display","block");
                };
        })
    </script>
    <script type="text/javascript" language="javascript">
    function Browse()
    {
        var ifUpload;
        var confirmUpload;
        ifUpload = ifu.document.form1; 
        res = ifUpload.myFile.click();
        ifUpload.btnSubmit.click();
        document.getElementById("divprocess").style.display = "block";   
    }    
    function CallBackMsg(msg)
    {
            document.getElementById("divprocess").style.display = "none";
            if(msg != 'nil')
            {
                 window.form1.submit();
                 alert(msg);
                 
            }
    } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 25px"> 
        我的开题报告
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="600px"
            Width="100%" CssClass="AjaxTabStrip">
            <cc1:TabPanel runat="server" HeaderText="我的开题报告" ID="TabPanel1">
                <ContentTemplate>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="#999999">你还没有提交过开题报告 :-(</asp:Label>
                    <div id="div_list" runat="server">
                        <asp:GridView ID="gvRecordList" runat="server" ShowHeader="False" Width="600px" AutoGenerateColumns="False"
                            CellPadding="5" AllowPaging="True" GridLines="None" CellSpacing="2" OnPageIndexChanging="gvRecordList_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div>
                                            <asp:Label ID="lblName" runat="server" Text='<%#GetSpeaker(Eval("Communicators").ToString()) %>'
                                                ForeColor="#006666"></asp:Label>&#160;&#160;&#160;
                                            <asp:Label ID="lblTime" runat="server" Text='<%#Eval("CreatedDate") %>' ForeColor="#999999"></asp:Label></div>
                                        <br />
                                        <div>
                                            <asp:Label ID="lblRecord" runat="server" Width="550px" Text='<%#Eval("Body") %>'></asp:Label></div>
                                        <br />
                                    </ItemTemplate>
                                    <ItemStyle Height="80px" BackColor="#EAEAEA" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <div style="float: left">
                            <a href="#" id="leaveMessage">我要留言</a>
                        </div>
                        <div style="margin-left: 15px; float: left">
                            <asp:LinkButton ID="lbnDownload" runat="server" OnClick="lbnDownload_Click">开题报告下载</asp:LinkButton>
                        </div>
                        <br />
                        <br />
                        <div id="divmessage" style="display: none">
                            <asp:Label ID="Label1" runat="server" Text="留言：" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:TextBox ID="tbMessage" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                            <br />
                            <div style="float: left; width: 260px" id="myNewFile">
                                <a href="#" onclick="javascript:Browse();">更新开题报告</a>
                                <iframe src="../uploadFile.aspx?id=1&stuid=<%=studentID %>" frameborder="0" id="ifu" name="ifu"
                                    style="display: none"></iframe>
                            </div>
                            <div style="float: left">
                                <asp:Button ID="btComment" runat="server" Text="回复" BackColor="#3333FF" ForeColor="White"
                                    OnClick="btComment_Click" />
                            </div>
                            <br />
                            <div id="divprocess" style="display: none">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Engineering/Resources/images/Progress.gif" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="提交开题报告">
                <ContentTemplate>
                    <div>
                        <table style="width: 594px">
                            <tr>
                                <td align="left" height="31" valign="middle" width="130">
                                    开题报告名称：
                                </td>
                                <td align="left" valign="middle" width="394">
                                    <asp:TextBox ID="tbOpeningSpeach" runat="server" Width="190px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" height="31" valign="middle">
                                    开题报告文档：
                                </td>
                                <td align="left" valign="middle">
                                    <asp:FileUpload ID="fuOpeningSpeach" runat="server" Width="270px" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div>
                        <asp:Button ID="btOpenSpeach" runat="server" Height="31px" Text="提交报告" Width="90px"
                            OnClick="btOpenSpeach_Click" BackColor="#3333FF" ForeColor="White" /></div>
                     <br />
                    <div>
                        //文件的大小不能超过2M<br />
                        <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label></div>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
    </form>
</body>
</html>
