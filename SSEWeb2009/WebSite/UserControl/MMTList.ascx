<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MMTList.ascx.cs" Inherits="UserControl_MMTList" %>
<link href="<%=ConstValue.PureURL%>CssClass/MMTControlCSS.css" rel="stylesheet" type="text/css" />

<div style="display: none; visibility: hidden;">
    <asp:Label ID="lb_DepartmentId" runat="server" Text=""></asp:Label>
    <asp:Label ID="lb_KeyWord" runat="server" Text=""></asp:Label>
    <asp:Label ID="lb_InternalOnly" runat="server" Text=""></asp:Label>
    <asp:Label ID="lb_Mode" runat="server" Text=""></asp:Label>
    <asp:Label ID="lb_Label" runat="server" Text=""></asp:Label>
    <asp:Label ID="lb_MgrState" runat="server" Text=""></asp:Label>
    <asp:Label ID="lb_Date" runat="server" Text=""></asp:Label>
   
    
</div>
<asp:ObjectDataSource ID="objDS_All" runat="server" SelectMethod="GetList" 
    TypeName="SysCom.MMTStatic" UpdateMethod="MarkDelete">
    <UpdateParameters>
        <asp:Parameter Name="MMTID" Type="String" />
    </UpdateParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="lb_DepartmentId" Name="DepartmentId" 
            PropertyName="Text" Type="Int32" />
        <asp:ControlParameter ControlID="lb_Mode" Name="Mode" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="lb_KeyWord" Name="KeyWord" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="lb_MgrState" Name="MgrUse" PropertyName="Text" 
            Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="objDS_Notice_noDate" runat="server" 
    SelectMethod="GetNotice" TypeName="SysCom.MMTStatic">
    <SelectParameters>
        <asp:ControlParameter ControlID="lb_DepartmentId" Name="DepartmentId" 
            PropertyName="Text" Type="Int32" />
        <asp:ControlParameter ControlID="lb_KeyWord" Name="Keyword" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="lb_Label" Name="Label" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="lb_InternalOnly" Name="Internal" 
            PropertyName="Text" Type="Boolean" />
        <asp:ControlParameter ControlID="lb_MgrState" Name="MgrUse" PropertyName="Text" 
            Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="objDS_Notice" runat="server" SelectMethod="GetNotice" 
    TypeName="SysCom.MMTStatic">
    <SelectParameters>
        <asp:ControlParameter ControlID="lb_DepartmentId" Name="DepartmentId" 
            PropertyName="Text" Type="Int32" />
        <asp:ControlParameter ControlID="lb_KeyWord" Name="Keyword" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="lb_Label" Name="Label" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="lb_InternalOnly" Name="Internal" 
            PropertyName="Text" Type="Boolean" />
        <asp:ControlParameter ControlID="lb_Date" Name="Date" PropertyName="Text" 
            Type="DateTime" />
        <asp:ControlParameter ControlID="lb_MgrState" Name="MgrUse" PropertyName="Text" 
            Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>



<asp:GridView ID="theList" runat="server" AllowPaging="True" 
    DataSourceID="objDS_All" AutoGenerateColumns="False" 
    ShowHeader="False" BorderStyle="None" BorderWidth="0px" 
    GridLines="None" Width="100%" OnDataBound="AfterDataBound">
    <RowStyle BorderStyle="None" BorderWidth="0px"/>
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HiddenField ID="hdf_id" runat="server" Value='<%# Eval("ID") %>' />
                <div id="main_line" style="width: 100%;" runat="server" class='<%#ItemCssClass%>'>
                    <div id="main_ctnt" style="float:left; text-align:left;" runat="server">
                        <asp:LinkButton ID="lbtn_update" Text='<%# Convert.ToBoolean(Eval("State")) ? "恢复" : "删除"%>'
                            runat="server" Visible='<%#Management%>' CssClass="EditBtn" OnClick="MarkDeleteClick" ToolTip='<%# Eval("ID") %>'>
                        </asp:LinkButton>
                        <asp:LinkButton ID="lbtn_delete" Text="彻底删除" runat="server" Visible='<%#Management%>'
                            CssClass="EditBtn" OnClick="DeleteClick" ToolTip='<%# Eval("ID") %>'>
                        </asp:LinkButton>
                        <asp:HyperLink ID="lnk_title" NavigateUrl='<%#ShowURL+"?MMTID="+Eval("ID")%>' 
                            Text='<%# LimitLength(Eval("Title"))%>' runat="server" Target='<%# Target %>'></asp:HyperLink>
                        <asp:Label Text='<%#"&nbsp;[" + Eval("ClickCount") + "]"%>' runat="server" 
                            Visible='<%#ShowClickCount%>' ForeColor="#999999" Font-Size="11px"
                            Font-Names="Arial"></asp:Label>
                    </div>
                    <div id="time_div" style="float:right; text-align: right;" runat="server" visible='<%#ShowTime%>'>
                        <asp:Label Text='<%#Eval("LastModifyTime")%>' runat="server" 
                            CssClass='<%#TimeCssClass%>' ></asp:Label>
                    </div>
                    <div style="clear: both;"></div>
                    <div runat="server" id="to_expand"><asp:PlaceHolder ID="phd_expand" runat="server"></asp:PlaceHolder></div>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    
    <EmptyDataTemplate>
        <asp:Label ID="lb_empty" runat="server" Font-Bold="True" Font-Size="12px" 
            ForeColor="Red" Text="<%#EmptyString%>">
        </asp:Label>
    </EmptyDataTemplate>

    <AlternatingRowStyle BorderStyle="None" BorderWidth="0px" />

</asp:GridView>

<% if (GetRows != null) GetRows(this.theList.Rows.Count); %>
