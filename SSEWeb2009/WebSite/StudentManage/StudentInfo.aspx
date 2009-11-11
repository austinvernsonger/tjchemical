<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentInfo.aspx.cs" 
    Inherits="StudentManage_Student"  MasterPageFile="~/StudentManage/MasterPage/Student_NoNested.master"%>

 <asp:Content ID="Content1" ContentPlaceHolderID="homeContent" runat="server">
      <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1"  
          DataKeyField="StudentID"  >
            <ItemTemplate>
                <p>姓名：<asp:Label ID="LabelName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                     <br />
                    学号：<asp:Label ID="LabelNum" runat="server" Text='<%# Eval("StudentID") %>'></asp:Label>
                     <br />
                     性别：<asp:Label ID="LabelSex" runat="server" Text='<%# ReturnSex(Eval("Gender")) %>' ></asp:Label>
                     <br />
                     籍贯：<asp:TextBox ID="TxtNativeProvince" runat="server"  Text='<%# Eval("NativeProvince") %>' OnTextChanged="TxtNativeProvince_Changed"></asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorNativePlace" runat="server" 
                         ControlToValidate="TxtNativeProvince" Display="Static" ErrorMessage="请输入籍贯">  </asp:RequiredFieldValidator>
                     <br />
                     年级：<asp:Label ID="LabelGrade" runat="server" Text='<%# Eval("Grade") %>'></asp:Label>
                     <br />
                     班级：<asp:Label ID="LabelClass" runat="server" Text='<%# Eval("Class") %>'></asp:Label>
                     <br />
                     寝室：<asp:TextBox ID="TxtDormitory" runat="server"  Text='<%# Eval("Dormitory")%>' OnTextChanged="TxtDormitory_Changed"></asp:TextBox>
                      &nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ControlToValidate="TxtDormitory" Display="Static" ErrorMessage="请输入寝室"></asp:RequiredFieldValidator>
                     <br />
                     班级职务：<asp:TextBox ID="TxtPosition" runat="server"  Text='<%# Eval("Position") %>' OnTextChanged="TxtPosition_Changed"></asp:TextBox>
                      &nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                         ControlToValidate="TxtPosition" Display="Static" >请输入班级职务</asp:RequiredFieldValidator>
                     <br />
                     政治面貌：<asp:Label ID="LabelPoliticalLandscape" runat="server"  Text='<%# Eval("PoliticalStatus") %>'></asp:Label>
                     <br />
                     手机：<asp:TextBox ID="TxtMobilePhone" runat="server"  Text='<%# Eval("MobilePhone") %>' OnTextChanged="TxtMobilePhone_Changed"></asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                         ControlToValidate="TxtMobilePhone" Display="Static" >请输入手机</asp:RequiredFieldValidator>
                     <br />
                     固定电话：<asp:TextBox ID="TxtFixedPhone" runat="server"  Text='<%# Eval("FixedPhone") %>' OnTextChanged="TxtFixedPhone_Changed"></asp:TextBox>
                      &nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                         ControlToValidate="TxtFixedPhone" Display="Static" >请输入固定电话</asp:RequiredFieldValidator>
                     <br /> 
                     特长爱好：<asp:TextBox ID="TxtAdvantage" runat="server"  Text='<%# Eval("Advantage") %>' OnTextChanged="TxtAdvantage_Changed"></asp:TextBox>
                      &nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                         ControlToValidate="TxtAdvantage" Display="Static" >请输入特长爱好</asp:RequiredFieldValidator>
                     <br />
                     家庭地址：<asp:TextBox ID="TxtHomeAddress" runat="server"  Text='<%# Eval("HomeAddress") %>' OnTextChanged="TxtHomeAddress_Changed"></asp:TextBox>
                      &nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                         ControlToValidate="TxtHomeAddress" Display="Static" >请输入家庭地址</asp:RequiredFieldValidator>
                     <br />
                     <asp:Button ID="ButtonOK" runat="server" Text="确定" OnClick="ButtonOK_Click" />
                     <br />
                 </p>
            </ItemTemplate>
        </asp:DataList>
     
     
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="Data Source=10.60.43.9;Initial Catalog=SSE;User ID=sse_basicinfo;Password=abcd"  >
     </asp:SqlDataSource>
     
</asp:Content>
    
