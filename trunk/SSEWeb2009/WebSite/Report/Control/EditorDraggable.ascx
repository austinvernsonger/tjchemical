<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditorDraggable.ascx.cs" Inherits="Report_Control_EditorDragable" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    <Scripts>
        <asp:ScriptReference Path="~/Report/Resource/Javascript/jquery-1.3.2.min.js" />
        <asp:ScriptReference Path="~/Report/Resource/Javascript/jquery-ui-1.7.2.custom.min.js" />
        <asp:ScriptReference Path="~/Report/Resource/Javascript/Draggable.js" />
        <asp:ScriptReference Path="~/Report/Resource/Javascript/SthAboutjQueryForIE.js" />
    </Scripts>
</asp:ScriptManagerProxy>

<asp:Panel ID="Panel_StartEdit" runat="server">
    <asp:Button ID="BN_EditReport" runat="server" Text="编辑问卷" 
        onclick="BN_EditReport_Click"  />
    <asp:Button ID="BN_CheckResult" runat="server" Text="查看结果" 
        onclick="BN_CheckResult_Click" />
</asp:Panel>
<asp:BulletedList ID="BulletedList_WarnningMessage" runat="server" 
    EnableViewState="False">
</asp:BulletedList>
<asp:Panel ID="Panel_Edit" runat="server" style="position:relative; display:none">
    <asp:Panel ID="Panel_EditTabs" runat="server" CssClass="EditTabsPanel">
        <ul>
            <li><a id="ctrl" href="">控件</a></li>
            <li><a id="attr" href="">属性</a></li>
        </ul>
        <asp:Panel ID="Panel_Ctrl" runat="server">
            <asp:Button ID="BN_NewReport" runat="server" Text="新建" 
                onclick="BN_NewReport_Click" />
            <br />
            <asp:Button ID="BN_LoadFile" runat="server"  Text="还原" 
                onclick="BN_LoadFile_Click" />
            <br />
            <asp:Button ID="BN_CancelEdit" runat="server" Text="取消编辑" 
                onclick="BN_CancelEdit_Click" />
            <br />
            <br />
            <asp:Panel ID="Panel_CtrlGroup" runat="server" style="display:none">
                <asp:Image ID="ImageButton_Text" runat="server" 
                    ImageUrl="~/Report/Resource/Image/blue_text.png" CssClass="ReportImgBtn" /><br />
                <asp:Image ID="ImageButton_Report" runat="server" 
                    ImageUrl="~/Report/Resource/Image/blue_report.png" CssClass="ReportImgBtn" /><br />
                <asp:Image ID="ImageButton_SingleSelect" runat="server" 
                    ImageUrl="~/Report/Resource/Image/blue_singleselect.png" CssClass="ReportImgBtn" /><br />
                <asp:Image ID="ImageButton_RichText" runat="server" 
                    ImageUrl="~/Report/Resource/Image/blue_richtext.png" CssClass="ReportImgBtn" /><br />
                <asp:Image ID="ImageButton_StudentID" runat="server" 
                    ImageUrl="~/Report/Resource/Image/blue_studentid.png" CssClass="ReportImgBtn" /><br />
                <asp:Image ID="ImageButton_Admin" runat="server" 
                    ImageUrl="~/Report/Resource/Image/blue_Admin.png" CssClass="ReportImgBtn" /><br />
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="Panel_Attr" runat="server">
            <p>属性：请在问卷中选择一个控件（双击）</p>
            <asp:Panel ID="Panel_ItemAttrReport" runat="server" CssClass="PanelItemAttr" style="display:none">
                <asp:Label ID="Label_ReportName_InEditor" runat="server" Text="问卷名："></asp:Label>
                <asp:TextBox ID="TextBox_ReportName_InEditor" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox_ReportName_InEditor_TextChanged" onkeyup="javascript:onKeyUpReportNameModify();"></asp:TextBox>
            </asp:Panel>
            
            <asp:Panel ID="Panel_ItemAttrText" runat="server" CssClass="PanelItemAttr" style="display:none">

                <asp:Label ID="Label_TextName_InEditor" runat="server" Text="文本框名："></asp:Label>
                <asp:TextBox ID="TextBox_TextName_InEditor" runat="server" AutoPostBack="True" ontextchanged="TextBox_TextName_InEditor_TextChanged"
                    onkeyup="javascript:onKeyUpTextNameModify();"></asp:TextBox>

            </asp:Panel>


            <asp:Panel ID="Panel_ItemAttrRichText" runat="server" CssClass="PanelItemAttr" style="display:none">
                <asp:Label ID="Label_RichTextName_InEditor" runat="server" Text="控件名："></asp:Label>
                <asp:TextBox ID="TextBox_RichTextName_InEditor" runat="server" 
                    AutoPostBack="True" onkeyup="javascript:onKeyUpRichTextNameModify();" ontextchanged="TextBox_RichTextName_InEditor_TextChanged"></asp:TextBox>
            </asp:Panel>
          
            <asp:Panel ID="Panel_ItemAttrSingleSelect" runat="server" CssClass="PanelItemAttr" style="display:none" onload="PanelControl_OnLoad">
            
                <asp:Label ID="Label_SingleSelectName_InEditor" runat="server" Text="控件名："></asp:Label>
                <asp:TextBox ID="TextBox_SingleSelectName_InEditor" runat="server" 
                    AutoPostBack="True" ontextchanged="TextBox_SingleSelectName_InEditor_TextChanged" onkeyup="javascript:onKeyUpSingleSelectNameModify();"></asp:TextBox>
                <br />
                <asp:Label ID="Label_Choice" runat="server" Text="选项："></asp:Label>
                <br />
               
                <asp:Button ID="Button_add" Text="添加" OnClick="btnAdd_Click" runat="server" Enabled="false" ></asp:Button>
                <asp:Button ID="Button_LoadSelect" Text="载入选项" OnClick="btnLoadSelect_Click" runat="server" ></asp:Button>
                <asp:Button ID="Button1_save_singleselect" Text="编辑完毕" OnClick="btnSave_Click" runat="server"></asp:Button>
                <br />
              
                <asp:PlaceHolder ID="PlaceHolder_SaveTextbox" runat="server">
                </asp:PlaceHolder>
            </asp:Panel>
           
            <asp:Panel ID="Panel_ItemAttrProperty" runat="server" CssClass="PanelItemAttr" style="display:none">
                <br />
                <asp:Label ID="Label_ItemAttrProperty" runat="server" Text="高级属性：" Font-Bold="True"></asp:Label>
                <br />
                <asp:CheckBox ID="CB_IsKey" runat="server" Text="设为主键" AutoPostBack="True" 
                    oncheckedchanged="CB_IsKey_CheckedChanged"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CB_MustNotEmpty" runat="server" Text="不允许为空" 
                    AutoPostBack="True" oncheckedchanged="CB_MustNotEmpty_CheckedChanged"/>
                <br />
                <asp:Label ID="Label_MaxSize" runat="server" Text="最大字数(0表示无限制)"></asp:Label>
                <asp:TextBox ID="TB_MaxSize" runat="server" AutoPostBack="True" 
                    ontextchanged="TB_MaxSize_TextChanged"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TB_MaxSize" Display="Dynamic" ErrorMessage="请填入有效数字" 
                    ValidationExpression="^[Z0-9]+$"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="Label1" runat="server" Text="可编辑"></asp:Label>
                <asp:DropDownList ID="DropDownList_ResultEditMode" runat="server" 
                    AutoPostBack="True" ontextchanged="DropDownList_ResultEditMode_TextChanged">
                    <asp:ListItem>前后台</asp:ListItem>
                    <asp:ListItem>前台</asp:ListItem>
                    <asp:ListItem>后台</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                <br />
                <asp:Label ID="Label2" runat="server" Text="结果是否显示该列"></asp:Label>
                &nbsp;<asp:DropDownList ID="DropDownList_ResultViewMode" runat="server" 
                    AutoPostBack="True" ontextchanged="DropDownList_ResultViewMode_TextChanged">
                    <asp:ListItem>显示</asp:ListItem>
                    <asp:ListItem>隐藏</asp:ListItem>
                </asp:DropDownList>
            </asp:Panel>

        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="Panel_Report" runat="server" CssClass="ReportPanel">
        <p>问卷</p>
        <div id='DropHelperDiv' style="display:none">我是来占位的……</div>
        <asp:PlaceHolder ID="PlaceHolder_Report" runat="server"></asp:PlaceHolder>
        <asp:Panel ID="Panel_SavePlace" runat="server" CssClass="SavePlacePanel">
        </asp:Panel>
        <asp:Panel ID="Panel_Save" runat="server" CssClass="SavePanelBottom" HorizontalAlign="Center">
            <asp:Button ID="Button_Save" runat="server" Text="保存" 
                onclick="Button_Save_Click" />
            <p>
                <asp:Label ID="Label_ErrorMessage" runat="server" EnableViewState="False" 
                    ForeColor="Red"></asp:Label>
            </p>
        </asp:Panel>
    </asp:Panel>
</asp:Panel>

<script language="javascript" type="text/javascript">

function initDragging() {
    //tab初始化
  //  alert("initDragging");  //test
    var ctrl = document.getElementById("ctrl");
    var attr = document.getElementById("attr");
    var url = "#"+"<%=Panel_Ctrl.ClientID %>";
    ctrl.href = url;
    url = "#"+"<%=Panel_Attr.ClientID %>";
    attr.href = url;

	$("#"+"<%=Panel_EditTabs.ClientID %>").tabs({
	    select: onTabsSelect
	}).tabs('select', TabIndex);
	    
	//拖拽控件初始化
	$(".ReportImgBtn").draggable({
	    helper: 'clone',
	    zIndex: 1000,
 	    drag: onDrag
//	    refreshPositions: true
	});
	$(".ReportDropPanel").droppable({
	    greedy: true,
	    hoverClass: 'ReportDropHover',
	    drop: onDropInReport,
	    over: onDropOverInReport,
	    out: onDropOutInReport
	});
	
	//属性tab
	//var itemtypemodify = $("input[id$='Hidden_ItemCtrlTypeModify_InEditor']").val();
	if (TabIndex == 1 && ItemTypeModified != "" && ItemModifiedID != "") {
	    var elemid = $("#"+"<%=Hidden_EventCtrl_InEditor.ClientID %>").val();
	    var itemmodify = GetItemCtrl(elemid);
	    //清空Hidden_EventCtrl_InEditor的内容
	    $("#"+"<%=Hidden_EventCtrl_InEditor.ClientID %>").attr("value", "");
	    
	    //alert(itemmodify.get(0).id);
	    
	    if (itemmodify != null) {
	        //DisplayAttrPanel(ItemTypeModified, itemmodify);
	        DisplayAttrPanelPostBack(ItemTypeModified);

            //隐藏域赋值
            $("input[id$='Hidden_ItemCtrlTypeModify_InEditor']").attr("value", ItemTypeModified);
            
            try
            {
                $("input[id$='Hidden_ParentFullName_InEditor']").attr("value", itemmodify.find("span[id$='Hidden_ParentFullName']").get(0).innerHTML);
            } catch (e)
            {
                $("input[id$='Hidden_ParentFullName_InEditor']").attr("value", "");
            }
            
            var ItemIndex = itemmodify.parent().find(".ReportHolderPanelForSelect").index(itemmodify[0]);
            if (ItemIndex != -1) {
                $("input[id$='Hidden_ItemIndexModify_InEditor']").attr("value", ItemIndex);
                /////////////////////////////////////////////
/*

                test1 = $("input[id$='Hidden_SaveIndex']").val(); //.get(0).innerHTML;
                alert("ascx:"+test1);///////////////
                if (test1 == "") {
                    $("input[id$='Hidden_SaveIndex']").attr("value", ItemIndex);


                    var test3 = $("input[id$='Hidden_SaveIndex']").val(); //.get(0).innerHTML;/////////////////////////
                    alert("ascx:"+test3);///////////////
                }
*/

                ////////////////////////////////////////////////////////
            }
	    }
    }
//	alert("event binding");//test
	//事件绑定
	//$(".ReportHolderPanelForSelect").bind("click", onClickItem);
	$(".ReportHolderPanelForSelect").unbind('dblclick');
	$(".ReportHolderPanelForSelect").dblclick(onClickItem);
}
	
	$(document).ready(function(){
	    initDragging();
	    var prm = Sys.WebForms.PageRequestManager.getInstance();
	    prm.add_endRequest(function() {    // re-bind jquery events
            initDragging();
	    });
	});
</script>

<p>
    <asp:Label ID="Hidden_HasOldResult" runat="server" Visible="False"></asp:Label>
</p>
<p>
<asp:Label ID="Hidden_DescriptorFilePath" runat="server" Visible="False"></asp:Label>
</p>
<p>
    <asp:Label ID="Hidden_ResultFilePath" runat="server" Visible="False"></asp:Label>
</p>

<asp:HiddenField ID="Hidden_ReportFullName_InEditor" runat="server" />
<asp:HiddenField ID="Hidden_ItemCtrlType_InEditor" runat="server" />
<asp:HiddenField ID="Hidden_ItemIndex_InEditor" runat="server" />

<asp:HiddenField ID="Hidden_ParentFullName_InEditor" runat="server" />
<asp:HiddenField ID="Hidden_ItemCtrlTypeModify_InEditor" runat="server" />
<asp:HiddenField ID="Hidden_ItemIndexModify_InEditor" runat="server" />

<asp:HiddenField ID="Hidden_EventCtrl_InEditor" runat="server" />

<!---->

<asp:HiddenField ID="Hidden_SaveIndex" runat="server" />

<!---->
<!--         -->

<!---->

<p>
<asp:Label ID="Label_ErrorReadFile" runat="server" EnableViewState="False" 
        ForeColor="Red"></asp:Label>
</p>
<asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
    EnableViewState="False" Interval="1">
</asp:Timer>
<cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
    ConfirmText="已有结果存在，继续并删除结果？" Enabled="False" TargetControlID="BN_EditReport">
</cc1:ConfirmButtonExtender>


