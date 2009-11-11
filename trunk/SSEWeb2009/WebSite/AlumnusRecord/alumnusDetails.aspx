<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnusRecord/MasterPage.master" AutoEventWireup="true" CodeFile="alumnusDetails.aspx.cs" Inherits="alumnusDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="GreenBar">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
        <asp:LinkButton ID="LinkButton5" runat="server" 
            PostBackUrl="~/AlumnusRecord/alumnusCenter.aspx">返回院友中心</asp:LinkButton>
    
    </div>
    
    
    <div>

        <table class="style1">
            <tr>
            <td class="style4">
            </td>
                <td class="style2">
                    <asp:Image ID="Image1" runat="server" Height="160px" Width="120px" />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButtonChange" runat="server" 
                        onclick="LinkButtonChange_Click" style="text-align: center">更改头像</asp:LinkButton>
                    <br />
                    <asp:FileUpload ID="FileUploadImg" runat="server" Height="22px" 
                        Visible="false" Width="134px" />
                    <br />
                    <br />
                    <asp:Button ID="ButtonUpload" runat="server" onclick="ButtonUpload_Click" 
                        Text="上传" Visible="false" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonCancel" runat="server" Text="取消" Visible="false" />
                </td>
                <td class="style3">
                    <asp:FormView ID="FormView1" runat="server" 
                        onitemupdated="FormView1_ItemUpdated" onitemupdating="FormView1_ItemUpdating" 
                        onmodechanging="FormView1_ModeChanging">
                        <EditItemTemplate>
                            姓名：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <%#Eval("Name") %>
                            <br />
                            <br />
                            学号：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <%#Eval("StudentID") %>
                            <br />
                            <br />
                            学历：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <%#Eval("Degree") %><br />
                            <br />
                            籍贯：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxOrigin" runat="server" Text='<%#Eval("Origin") %>'></asp:TextBox>
                            <br />
                            <br />
                            教学点：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxTeachPoint" runat="server" 
                                Text='<%#Eval("TeachingPoint") %>'></asp:TextBox>
                            <br />
                            <br />
                            毕业年份：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <%#Eval("GraduateYear") %>年<br />
                            <br />
                            工作单位：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxWorkPlace" runat="server" 
                                Text='<%#Eval("WorkPlace") %>'></asp:TextBox>
                            <br />
                            <br />
                            地址：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxAddress" runat="server" 
                                Text='<%#Eval("WorkAddress") %>'></asp:TextBox>
                            <br />
                            <br />
                            电话：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:TextBox>
                            <br />
                            <br />
                            邮箱：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxEmail" runat="server" Text='<%#Eval("Email") %>'></asp:TextBox>
                            <br />
                            <br />
                            信息是否公开：&nbsp;&nbsp;
                            <asp:DropDownList ID="DropDownListPub" runat="server">
                                <asp:ListItem Text="公开" Value="1" />
                                <asp:ListItem Text="不公开" Value="0" />
                            </asp:DropDownList>
                            <br />
                            <br />
                            毕业寄语： &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBoxSummary" runat="server" Columns="4" Height="86px" 
                                Text='<%#Eval("Summary") %>' TextMode="MultiLine" Width="182px"></asp:TextBox>
                            <br />
                            <br />
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update">提交</asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel">取消</asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            姓名：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("Name") %><br />
                            <br />
                            学号：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("StudentID") %><br />
                            <br />
                            学历：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("Degree").ToString().Trim() == "0" ? "本科" : "硕士" %> 
                            <br />
                            <br />
                            籍贯：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("Origin") %><br />
                            <br />
                            教学点：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("TeachingPoint") %><br />
                            <br />
                            毕业年份：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("GraduateYear") %>年<br />
                            <br />
                            工作单位：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("WorkPlace") %><br />
                            <br />
                            地址：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("WorkAddress") %><br />
                            <br />
                            电话：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("Phone") %><br />
                            <br />
                            邮箱：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("Email") %><br />
                            <br />
                            信息是否公开：&nbsp;&nbsp; <%#Eval("Publicity").ToString().Trim() == "1" ? "公开" : "不公开" %><br />
                            <br />
                            毕业寄语：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#Eval("Summary") %>
                            <br />
                            <br />
                            <br />
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">更改信息</asp:LinkButton>
                        </ItemTemplate>
                    </asp:FormView>
                </td>
            </tr>
        </table>

    </div>
    
    
    <%--<div class="BlueBlock" style="width:;">
        <div id="BarTitle"><span>其他xxxx届毕业生</span></div>
        <div style="width:100%;">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <a href='alumnusDetails.aspx?id=<%#Eval("StudentID") %>'><%#Eval("name") %></a><br />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>--%>       
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 314px;
            height: 412px;
        }
        .style3
        {
            height: 412px;
        }
        .style4
        {
            width: 153px;
        }
    </style>

</asp:Content>


