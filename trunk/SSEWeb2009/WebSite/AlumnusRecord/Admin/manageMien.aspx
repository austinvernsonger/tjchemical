<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnusRecord/Admin/MasterPageBack.master"
    AutoEventWireup="true" CodeFile="manageMien.aspx.cs" Inherits="AlumnusRecord_Admin_manageMien" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="varContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ScriptManager1" />
    <div class="demoarea">
        <link href="../Resources/css/StyleSheetMien.css" rel="stylesheet" type="text/css" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="ReorderList1" /> 
        </Triggers>
            <ContentTemplate> 
                <div class="reorderListDemo">
                    <ajaxToolkit:ReorderList ID="ReorderList1" runat="server" PostBackOnReorder="false"
                        DataSourceID="ObjectDataSource1" CallbackCssStyle="callbackStyle" DragHandleAlignment="Left"
                        ItemInsertLocation="End" DataKeyField="ItemID" SortOrderField="Order" >
                        <ItemTemplate>
                            <div class="itemArea">
                                <asp:Label ID="Label2" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Name", " 姓名: {0}   -   预览图: "))) %>' />
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Src", "~/AlumnusRecord/{0}") %>'
                                    Height="25" Width="18" ImageAlign="Middle" />
                                <asp:LinkButton ID="EditLinkButton" runat="server" Text="编辑" CommandName="Edit" />
                                <asp:LinkButton ID="DeleteLinkButton" runat="server" Text="删除" CommandName="Delete" />
                            </div>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div class="itemArea">
                                <asp:Label ID="Label5" runat="server" Text="姓名:" />
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Src") %>' ValidationGroup="edit"
                                    Visible="False" />
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Name") %>' ValidationGroup="edit" />
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Order") %>' ValidationGroup="edit"
                                    Visible="False" />
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Src", "~/AlumnusRecord/{0}") %>'
                                    Height="25" Width="18" ImageAlign="Middle" />
                                <asp:LinkButton ID="SaveLinkButton" runat="Server" Text="保存" CommandName="Update" />
                                <asp:LinkButton ID="CancelLinkButton" runat="Server" Text="取消" CommandName="Cancel" />
                            </div>
                        </EditItemTemplate>
                        <ReorderTemplate>
                            <asp:Panel ID="Panel2" runat="server" CssClass="reorderCue" />
                        </ReorderTemplate>
                        <DragHandleTemplate>
                            <div class="dragHandle"></div>
                        </DragHandleTemplate>
                        <InsertItemTemplate>
                            <div style="padding-left: 25px; border-bottom: thin solid transparent;">
                                <asp:Panel ID="panel1" runat="server" DefaultButton="ButtonAdd" >
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <asp:Button ID="Button1" runat="server"
                                        Text="上传" CausesValidation="False" onclick="Button1_Click" />
                                        <br>
                                    <asp:Label ID="Label1" runat="server" Text="位置:" />
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Src") %>' ValidationGroup="add" />
                                    <asp:Label ID="Label5" runat="server" Text="姓名:" />
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Name") %>' ValidationGroup="add" />
                                    <asp:LinkButton ID="ButtonAdd" runat="server" CommandName="Insert" Text="添加" ValidationGroup="add" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="add"
                                        ErrorMessage="Please enter some text" ControlToValidate="TextBox1" />
                                </asp:Panel>
                            </div>
                        </InsertItemTemplate>
                    </ajaxToolkit:ReorderList>
                    
                    </div>
                    
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        DeleteMethod="Delete" InsertMethod="Insert" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="Select" 
                        TypeName="FileMienXmlDataObject" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_ItemID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="Original_ItemID" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Src" Type="String" />
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="Order" Type="Int32" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
