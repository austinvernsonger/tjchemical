<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyDefenseApplicant.aspx.cs" Inherits="Engineering_StuBackMag_MyDefenseApplicant" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的答辩申请--工程硕士中心</title>
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
        我的答辩申请
    </div>
    <hr />
    <br />
    <div>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
        <div>
            <table width="500" border="1" style="border-color: Black" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="40" colspan="2" align="center" valign="middle">
                        答 辩 申 请
                    </td>
                </tr>
                <tr>
                    <td width="140" height="40" align="center" valign="middle">
                        开题报告
                    </td>
                    <td width="360" align="center" valign="middle">
                        <asp:Label ID="lblOpenSpeach" runat="server" Text="尚未提交" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="40" align="center" valign="middle">
                        校外导师信息
                    </td>
                    <td align="center" valign="middle">
                        <asp:Label ID="lblOutTeacher" runat="server" Text="尚未提交" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="40" align="center" valign="middle">
                        中期考核表
                    </td>
                    <td align="center" valign="middle">
                        <asp:Label ID="lblMidForm" runat="server" Text="尚未提交" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="40" align="center" valign="middle">
                        论文初稿
                    </td>
                    <td align="center" valign="middle">
                        <asp:Label ID="lblPaper" runat="server" Text="尚未提交" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <p style="text-align: center; width: 500px;">
            <asp:Button ID="btApply" runat="server" Text="申请" Height="31px" OnClick="lblApply_Click"
                Width="90px" />
        </p>
        <div>
            <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
        </div>
        <br />
        <br />
        <div>
            *答辩申请的条件：开题报告，中期考核表，校外导师表以及论文初稿都已提交。 <br />
            *申请答辩后，将不得再提交开题报告，中期考核表，校外导师表以及论文初稿。
        </div>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="Panel2" runat="server" Visible="False">
            <div>
                申请答辩正在等待导师处理，请耐心等待......
            </div>
             <br />
            <div>
                <asp:LinkButton ID="LinkButton3" runat="server">给导师发信</asp:LinkButton>
            </div>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="Panel3" runat="server" Visible="False">
            <div id="div_tutorRes" runat="server">
                导师审批结果：<asp:Label ID="label2" runat="server" ForeColor="Red">批准</asp:Label>
            </div> 
            <br />
            <div>
                <asp:Label ID="Label4" runat="server" Text="*请提交最终的论文初稿，提交前请仔细阅读下面的注意事项" 
                    ForeColor="Red"></asp:Label>
                <table width="600">
                    <tr>
                        <td width="120" height="31" align="left" valign="middle">
                            论文题目</td>
                        <td width="480" align="left" valign="middle">
                            <asp:TextBox ID="tbPaperName" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                            论文稿件</td>
                        <td align="left" valign="middle">
                            <asp:FileUpload ID="FileUpload1" runat="server" Width="270px" />
                        </td>
                    </tr>
                    <tr>
                        <td height="50" colspan="2" align="left" valign="bottom">
                            <asp:Button ID="Button1" runat="server" Height="31px" Text="提交" Width="90px" 
                                onclick="Button1_Click" BackColor="#3333FF" ForeColor="White" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Label ID="lblFinalPaper" runat="server" Visible="False"></asp:Label>
            </div>
            <br />
            <br />
            <div>
                注意事项：1.请提交最终的论文初稿。<br />
                <span style="margin-left:80px">2.请将论文初稿封面删去（隐去姓名和指导教师），以便进行盲审。</span><br />
                <span style="margin-left:80px">3.论文中任何地方均不要出现研究生姓名、导师姓名等有关信息。</span><br />
                <span style="margin-left:80px">4.删去致谢页</span>
            </div>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="Panel4" runat="server" Visible="False">
            <div>
                导师审批结果：<asp:Label ID="Label3" runat="server" Text="不批准" ForeColor="Red"></asp:Label>
            </div>
            <br />
            <div>
                原因：<br />
                <asp:TextBox ID="tbReason" runat="server" Height="114px" TextMode="MultiLine" 
                    Width="298px" ReadOnly="True"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Button ID="btNewStart" runat="server" Text="重新申请" Height="31px" 
                    Width="90px" onclick="btNewStart_Click" BackColor="#3333FF" 
                    ForeColor="White" />
            </div>
            <div>
                <asp:Label ID="Label5" runat="server" Text="出现错误，请重试！" ForeColor="Red" 
                    Visible="False"></asp:Label>
            </div>
            <br />
            <div>
                *如有疑问请通过校内信与导师联系&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server">给导师发信</asp:LinkButton>
                &nbsp;</div>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="Panel5" runat="server" Visible="False">
            <div>
                待评审的论文提交成功，教务员审查通过后将提交给评审老师，请耐心等待评审结果......
            </div>
            <br />
            <br />
            <div>
                <asp:LinkButton ID="lbViewResult" runat="server">给管理员发信</asp:LinkButton>
            </div>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="Panel6" runat="server" Visible="False">
            <div style="color:Red">
                你的答辩申请没有通过管理员审批。
           </div>
           <br />
           <div>
            具体原因如下：
           </div> 
            <div>
                <asp:TextBox ID="tbAdmReason" runat="server" Height="115px" 
                    TextMode="MultiLine" Width="409px" ></asp:TextBox>
            </div>
            <br />
            <div> 
                <asp:Button ID="btApplyAgn" runat="server" Text="重新申请" BackColor="#3333FF" 
                    ForeColor="White" Height="31px" onclick="btApplyAgn_Click" Width="90px" />
            </div>
            <br />
            <div>
                <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <a href="#"  onclick="javascript:Browse();">重新上传预审论文</a>
                <iframe src="../uploadFile.aspx?id=5&stuid=<%=studentID %>" frameborder="0" id="ifu"
                    name="ifu" style="display: none"></iframe>
            </div>
            <div id="divprocess" style="display: none">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Engineering/Resources/images/Progress.gif" />
            </div>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="Panel7" runat="server" Visible="False">
            <div>
                你的论文已经评审结束，评审结果可查。
            </div>
            <br />
            <div>
                <asp:LinkButton ID="LinkButton2" runat="server">查看评审结果</asp:LinkButton>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
