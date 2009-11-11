<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="StudentsManagement.aspx.cs" Inherits="Engineering_AdminBakMag_StudentsManagement" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理学生信息--工程硕士中心</title>
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />
     <script type ="text/javascript" language = "javascript">
    function OpenOvertimeDlog(ID,width,height) 
   {       
     var me; 
     // 把父页面窗口对象当作参数传递到对话框中，以便对话框操纵父页自动刷新。 
     me = "StudentInfoDetails.aspx?id="+ID+""; 
     // 显示对话框。
     window.showModalDialog(me,null,'dialogWidth='+width +'px;dialogHeight='+height+'px;help:no;status:no') 
   } 
   
   function SelectAll(tempControl)
  {
       //将除头模板中的其它所有的CheckBox取反 

       var theBox=tempControl;
       xState=theBox.checked;    

       elem=theBox.form.elements;
       for(i=0;i<elem.length;i++)
       if(elem[i].type=="checkbox" && elem[i].id!=theBox.id)
       {
            if(elem[i].checked!=xState)
                    elem[i].click();
       }
  }   
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        管理学生信息
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%"
            CssClass="AjaxTabStrip" AutoPostBack="True" 
                onactivetabchanged="TabContainer1_ActiveTabChanged">
            <cc1:TabPanel runat="server" HeaderText="查看学生信息" ID="TabPanel1">
                <ContentTemplate>
                    <div>
                        <table width="670">
                            <tr>
                                <td width="60" height="31" align="left" valign="middle">
                                    <span style="font-size: 15px">年级：</span>
                                </td>
                                <td width="120" align="left" valign="middle">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="GradeList" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                                DataTextField="Grade" DataValueField="Grade" Width="120px" OnSelectedIndexChanged="GradeList_SelectedIndexChanged">
                                                <asp:ListItem>--请选择年级--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetGrade"
                                                TypeName="Department.Engineering.StudentManage"></asp:ObjectDataSource>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td width="80" align="left" valign="middle">
                                    <span style="font-size: 15px">教学点：</span>
                                </td>
                                <td width="120" align="left" valign="middle">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="TSchoolingList" runat="server" DataSourceID="ObjectDataSource2"
                                                DataTextField="TeaSchoolName" DataValueField="TeaSchoolID" Width="120px">
                                                <asp:ListItem>--请选择教学点--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetTeaSchool"
                                                TypeName="Department.Engineering.TeachingSchool">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="GradeList" Name="selValue" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="GradeList" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td width="52" align="left" valign="middle">
                                    <span style="font-size: 15px">学号：</span>
                                </td>
                                <td width="120" align="left" valign="middle">
                                    <asp:TextBox ID="tbStuID" runat="server" Width="115px"></asp:TextBox>
                                </td>
                                <td width="118" align="center" valign="middle">
                                    <asp:Button ID="btnQuery" runat="server" Text="查询" Height="31px" Width="90px" OnClick="btnQuery_Click"
                                        BackColor="#3333FF" ForeColor="White" onprerender="btnQuery_PreRender" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div>
                        <asp:GridView ID="gvStudentsInfo" runat="server" Width="700px" AllowPaging="True"
                            AutoGenerateColumns="False" CellPadding="4" PageSize="20" DataKeyNames="StudentID"
                            OnRowDataBound="gvStudentsInfo_RowDataBound" GridLines="None" OnPageIndexChanging="gvStudentsInfo_PageIndexChanging"
                            ForeColor="#333333" onrowcommand="gvStudentsInfo_RowCommand">
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbSelectAll" runat="server" onclick="javascript:SelectAll(this);"  />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbSelect" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="StudentID" HeaderText="学号">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sName" HeaderText="姓名">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="性别">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Convert.ToInt32(Eval("sGender"))==0?"男" :"女"%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Grade" HeaderText="年级">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Degree" HeaderText="学位类别">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        查看
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnbView" AlternateText="查看" ImageUrl="~/Engineering/Resources/images/view_icon.gif"
                                            runat="server" CommandName="cmdView" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="修改">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnbModify" runat="server" AlternateText="修改" ImageUrl="~/Engineering/Resources/images/edit.gif" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        删除
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnbDelete" AlternateText="删除" ImageUrl="~/Engineering/Resources/images/icon-delete.gif"
                                            runat="server" CommandName="cmdDelete" CommandArgument='<%#Eval("StudentID") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btNewStudent" runat="server" Text="添加学生信息" Height="31px" 
                            PostBackUrl="~/Engineering/AdminBakMag/AddNewStudent.aspx" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btDeleteStudents" runat="server" Height="31px" 
                            onclick="btDeleteStudents_Click" 
                            onclientclick="return confirm('你确认要删除这些学生信息吗？')" Text="删除学生信息" />
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="上传学生信息"> 
                <HeaderTemplate>
                    上传学生信息
                </HeaderTemplate>
                <ContentTemplate>
                    <div>
                        请单击下载：<asp:LinkButton ID="lbRegistForm" runat="server" 
                            OnClick="lbRegistForm_Click" oninit="lbRegistForm_Init">学生信息登记专用表格</asp:LinkButton></div>
                    <br />
                    <div>
                        请选择年级：&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlGrade" runat="server" Width="120px">
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div>
                        请选择教学点：<asp:DropDownList ID="ddlSchool" runat="server" Width="120px" DataSourceID="ObjectDataSource3"
                            DataTextField="TeaSchoolName" DataValueField="TeaSchoolID">
                            <asp:ListItem>请选择教学点</asp:ListItem>
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetTeaSchoolList"
                            TypeName="Department.Engineering.TeachingSchool" 
                            OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                    </div>
                    <br />
                    <div>
                        请选择学生信息登记表：&nbsp;
                        <asp:FileUpload ID="fuStudentsInfo" runat="server" Width="200px" /></div>
                    <br />
                     <asp:Button ID="tbSubmit" runat="server" Text="提交" Height="31px" Width="90px" OnClick="tbSubmit_Click"
                            BackColor="#3333FF" ForeColor="White" oninit="tbSubmit_Init" />
                    <div>
                            <br />
                            <asp:Label ID="lblGrade" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lblMessage" runat="server" Font-Size="Medium"></asp:Label>
                            <asp:GridView ID="gvFileUplaodStu" runat="server" AutoGenerateColumns="False" 
                                BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                                OnRowDataBound="gvFileUplaodStu_RowDataBound" PageSize="20" 
                                Width="700px" onrowcancelingedit="gvFileUplaodStu_RowCancelingEdit" 
                                onrowediting="gvFileUplaodStu_RowEditing" 
                                onrowupdating="gvFileUplaodStu_RowUpdating" 
                                onrowdeleting="gvFileUplaodStu_RowDeleting">
                                <Columns>
                                    <asp:TemplateField>
  
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="姓名">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNamev" runat="server" Text='<%#Eval("sName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbNamei" runat="server" Text='<%#Eval("sName") %>' Width="80px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="学号">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbStuNumi" runat="server" Text='<%#Eval("sStuid") %>' 
                                                Width="80px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStuNumv" runat="server" Text='<%#Eval("sStuid") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="性别">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbGenderi" runat="server" Text='<%#Eval("sGender") %>' 
                                                Width="80px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGenderv" runat="server" Text='<%#Eval("sGender") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="学制">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbSchoolingi" runat="server" Text='<%#Eval("sSchooling") %>' 
                                                Width="80px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSchoolingv" runat="server" Text='<%#Eval("sSchooling") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="学位类别">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDegreev" runat="server" Text='<%#Eval("sDegree") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbDegreei" runat="server"  Text='<%#Eval("sDegree") %>' Width="80px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="密码">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPasswordv" runat="server" Text='<%#Eval("sPassword") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbPasswordi" runat="server" Text='<%#Eval("sPassword") %>' Width="80px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:CommandField EditText="修改" ShowEditButton="True">
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:CommandField ShowDeleteButton="True">
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                            HorizontalAlign="Center" />
                                    </asp:CommandField>
                                </Columns>
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:GridView>
                    </div>
                    <br />
                    <div id="div_stuinfo" runat="server" visible="False">
                        <br />
                        <asp:Button ID="btConfirm" runat="server" Text="确认并提交" Height="31px" OnClick="btConfirm_Click"
                            Width="90px" />&#160;&#160;&#160;&#160;&#160;
                        &nbsp;
                        <asp:Button ID="btCancel" runat="server" Text="取消并重新上传" Height="31px" OnClick="btCancel_Click"
                            Width="100px" /><br />
                  <br />
                  //蓝色表示该学号已经存在<br />
                  //黄色表示学号不合法<br />
                  //红色表示输入不合法
                  </div>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
