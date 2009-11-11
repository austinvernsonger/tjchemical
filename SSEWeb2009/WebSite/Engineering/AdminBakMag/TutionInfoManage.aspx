<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TutionInfoManage.aspx.cs" Inherits="Engineering_AdminBakMag_TutionInfoManage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理学费信息--工程硕士中心</title>
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />
    <script type="text/javascript">
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
        管理学费信息
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>    
    </div>
    <hr />
    <br />
    <div>
        <cc1:TabContainer ID="TabContainer1" runat="server" CssClass="AjaxTabStrip" ActiveTabIndex="0"
            Width="100%" OnPreRender="TabContainer1_PreRender">
            <cc1:TabPanel runat="server" HeaderText="查询学费信息" ID="TabPanel1">
                <HeaderTemplate>
                    查询学费信息
                
                
            </HeaderTemplate>
                
<ContentTemplate>
                    <table width="670">
                        <tr>
                            <td width="60" height="31" align="left" valign="middle">
                                <span style="font-size: 15px">年级：</span>
                            </td>
                            <td width="120" align="left" valign="middle">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlGrade" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                            DataTextField="Grade" DataValueField="Grade" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged"
                                            Width="110px">
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
                                        <asp:DropDownList ID="ddlSchool" runat="server" DataSourceID="ObjectDataSource2"
                                            DataTextField="TeaSchoolName" DataValueField="TeaSchoolID" Width="115px">
                                            <asp:ListItem>--请选择教学点--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetTeaSchool"
                                            TypeName="Department.Engineering.TeachingSchool">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlGrade" Name="selValue" PropertyName="SelectedValue"
                                                    Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    
                                </ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ddlGrade" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
</asp:UpdatePanel>

                            </td>
                            <td width="52" align="left" valign="middle">
                                <span style="font-size: 15px">学期：</span>
                            </td>
                            <td width="120" align="left" valign="middle">
                                <asp:DropDownList ID="ddlTerm1" runat="server" DataSourceID="ObjectDataSource4" DataTextField="Key"
                                    DataValueField="Value"></asp:DropDownList>

                                <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetTermsWithStartYear"
                                    TypeName="Department.Engineering.TermsManage" 
                                    OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>

                            </td>
                            <td width="118" align="center" valign="middle">
                                <asp:Button ID="btQuery" runat="server" Height="31px" Text="查询" Width="60px" OnClick="btQuery_Click"
                                    BackColor="#3333FF" ForeColor="White" />

                            </td>
                        </tr>
                    </table>
                    <br />
                    <div>
                        <asp:GridView ID="gvTutionInfo" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            AllowPaging="True" PageSize="25" OnRowDataBound="gvTutionInfo_RowDataBound" OnPreRender="gvTutionInfo_PreRender"
                            OnPageIndexChanging="gvTutionInfo_PageIndexChanging" OnSelectedIndexChanging="gvTutionInfo_SelectedIndexChanging"
                            DataKeyNames="TuitionID" ForeColor="#333333" GridLines="None" Width="700px" OnRowCommand="gvTutionInfo_RowCommand">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbCheckAll" runat="server" onclick="javascript:SelectAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbCheck" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" Font-Italic="False" BorderColor="#666666" BorderStyle="Solid"
                                        BorderWidth="1px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="StuID" HeaderText="学号">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Name" HeaderText="姓名">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Grade" HeaderText="年级">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="学期">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#GetCourseTime(Eval("PaymentTerm").ToString() )%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="MustMoney" HeaderText="需缴学费">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ActualMoney" HeaderText="已缴学费">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="编辑">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnbEdit" runat="server" ImageUrl="~/Engineering/Resources/images/edit.gif" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="删除">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnbDelete" runat="server" ImageUrl="~/Engineering/Resources/images/icon-delete.gif"
                                            CommandName="cmdDelete" CommandArgument='<%#Eval("TuitionID") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>

                        <br />
                        <div>
                            <asp:Button ID="btDelete" runat="server" Text="删除学费信息" Height="31px" OnClick="btDelete_Click" />
&#160;&#160;&#160;&#160;&#160;
                            <asp:Button ID="btAddNewTuition" runat="server" Text="添加学费信息" Height="31px" 
                                PostBackUrl="~/Engineering/AdminBakMag/EditTuitionDetails.aspx" />
</div>
                    </div>
                
                
            </ContentTemplate>
            
</cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="上传学费信息">
                <ContentTemplate>
                    <div>
                        请点击下载：<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">学费信息登记专用表</asp:LinkButton></div>
                    <br />
                    <div>
                        缴费学期：&#160;&#160;&#160;
                        <asp:DropDownList ID="ddlTerm" runat="server" Width="120px" DataSourceID="ObjectDataSource3"
                            DataTextField="Key" DataValueField="Value">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetTerms"
                            TypeName="Department.Engineering.TermsManage"></asp:ObjectDataSource>
                    </div>
                    <br />
                    <div>
                        学费信息表：<asp:FileUpload ID="FileUpload1" runat="server" Width="400px" /></div>
                    <br />
                    <div>
                        <asp:Button ID="btSubmit" runat="server" Text="确定" Height="31px" Width="90px" OnClick="btSubmit_Click"
                            BackColor="#3333FF" ForeColor="White" /></div>
                    <br />
                    <div id="div_tuition" runat="server" visible="False">
                        <asp:Label ID="lblResult" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvTuitionConfirm" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                    Width="700px" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" OnRowDataBound="gvTuitionConfirm_RowDataBound"
                                    OnRowEditing="gvTuitionConfirm_RowEditing" OnRowCancelingEdit="gvTuitionConfirm_RowCancelingEdit"
                                    DataKeyNames="num" OnRowUpdating="gvTuitionConfirm_RowUpdating" OnDataBound="gvTuitionConfirm_DataBound"
                                    OnRowDeleting="gvTuitionConfirm_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblNo1" runat="server" Text='<%#Eval("num") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblNo2" runat="server" Text='<%#Eval("num") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="学期">
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="学号">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStuNum1" runat="server" Text='<%#Eval("stuid") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbStuNum1" runat="server" Text='<%#Eval("stuid") %>' Width="80px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="实缴金额">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAcutualMoney1" runat="server" Text='<%#Eval("actualMoney") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbAcutualMoney1" runat="server" Text='<%#Eval("actualMoney") %>'
                                                    Width="80px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="应缴金额">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMustMoney" runat="server" Text='<%#Eval("mustMoney") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbMustMoney" runat="server" Text='<%#Eval("mustMoney") %>' Width="80px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="备注">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemark1" runat="server" Text='<%#Eval("remark") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbRemark1" runat="server" Text='<%#Eval("remark") %>' Width="100px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:CommandField EditText="修改" ShowEditButton="True">
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:CommandField ShowDeleteButton="True">
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:CommandField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <div>
                        </div>
                        <asp:Button ID="btConfirm" runat="server" Text="确认并提交" Height="31px" Width="90px"
                            OnClick="btConfirm_Click" />&#160;&#160;&#160;&#160;&#160;
                        <asp:Button ID="btCancel" runat="server" Text="取消并重新上传" Height="31px" Width="110px"
                            OnClick="btCancel_Click" /><br />
                        <br />
                        *红色表示信息有错，请更正<br />
                        *蓝色表示该账号不存在，请删除该条学费信息<br />
                        *黄色表示该账号该学期的缴费信息已存在，请删除该条学费信息
                    </div>
                
                
            </ContentTemplate>
            
</cc1:TabPanel>
        </cc1:TabContainer>
    </div>
    </form>
</body>
</html>
