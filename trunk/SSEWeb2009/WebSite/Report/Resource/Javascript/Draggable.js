//全局
//获取拖拽时drop的对象
var DropObj = null;
//待修改属性或正在修改属性的控件
var ItemModified = null;
//当前显示tab的index
var TabIndex = 0;


//var test1 = null;/////////////////////////////

//待修改属性或正在修改属性的控件的类型
var ItemTypeModified = "";
// //待修改属性或正在修改属性的控件的下标
// var ItemIndexModified = 0;
// //待修改属性或正在修改属性的控件的父问卷的全名
// var ItemParentNameModified = "";
// 
// //高级属性中5个控件的值，回发重新显示时用

//当前正在修改属性的控件id
var ItemModifiedID = "";

//点击按钮设置标志来显示属性控件：0 不显示; 3 其余控件，GeneralEditor控件
var WhichIsDisplay = 0;

//替换图片
function   ChangeImg(e, strSrc)   
{
//     var url = window.location.protocol + "//" + window.location.hostname;
//     if(window.location.port != "") 
//     {
//         url = url + ":" + window.location.port;
//     }  
//     e.src = url+strSrc;   
    e.src = strSrc;   
}

function  onDropInReport(ev, ui)  
{
    $("#DropHelperDiv").attr("style", "display:none");
    DropObj = null;

    var strID = this.id;
    //alert(strID);
    
    var report = $(this);
    var item = ui.draggable;
        
    //获取report full name
    var ReportFullname = report.find("span[id$='Hidden_ReportFullName']").get(0).innerHTML;
    $("input[id$='Hidden_ReportFullName_InEditor']").attr("value", ReportFullname);
    
    //获取拖拽的item type
    var ItemType = FindItemTypeByID(item);
    $("input[id$='Hidden_ItemCtrlType_InEditor']").attr("value", ItemType);
    
    //获取拖拽的控件的index
    var ItemIndex = report.children(".ReportSubItemPanel").children().filter(".ReportHolderPanelForSelect, #DropHelperDiv").index($("#DropHelperDiv")[0]);
    if (ItemIndex != -1) {
        $("input[id$='Hidden_ItemIndex_InEditor']").attr("value", ItemIndex);
    }
    
    //回发
    __doPostBack('UpdatePanel1','');
}

function  FindItemTypeByID($item)
{
    var itemtype = "";
    var itemid = $item.attr("id");
    if (itemid.indexOf("RichText") > -1) {
        itemtype = "RICHTEXT";
    } else if (itemid.indexOf("Report") > -1) {
        itemtype = "REPORT";
    } else if (itemid.indexOf("SingleSelect") > -1) {
        itemtype = "SINGLESELECT";
    } else if (itemid.indexOf("Text") > -1) {
        itemtype = "TEXT";
    } else if (itemid.indexOf("StudentID") > -1) {
        itemtype = "STUDENTID";
    } else if (itemid.indexOf("Admin") > -1) {
        itemtype = "ADMIN";
    }
    
    return itemtype;
}

//drop over
function onDropOverInReport(ev, ui)
{
    DropObj = $(this);
}

//drop out
function onDropOutInReport(ev, ui)
{
    $("#DropHelperDiv").attr("style", "display:none");
    DropObj = null;
}

//drag
function onDrag(ev, ui)
{
    $("#DropHelperDiv").attr("style", "display:none");

    if (DropObj == null) {
        return;
    }
    
    //report中没有item
    if (DropObj.children(".ReportSubItemPanel").children(".ReportHolderPanelForSelect").length == 0) {
        DropObj.children(".ReportSubItemPanel").prepend($("#DropHelperDiv"));
        $("#DropHelperDiv").attr("style", "display:");
        return;
    }

    var TopPos = ui.offset.top - DropObj.offset().top;
    if (TopPos < 0) {
        TopPos = 0;
    }
    
    var PanelHeight = 0;
    
    $("#DropHelperDiv").attr("style", "display:none");
    DropObj.children(".ReportSubItemPanel").children(".ReportHolderPanelForSelect").each(function(i){
        PanelHeight += $(this).outerHeight(true);
        if (PanelHeight > TopPos) {
//            $("#DropHelperDiv").attr("style", "display:none");

            if (TopPos < (PanelHeight-$(this).outerHeight(true)/2)) {
                $(this).before($("#DropHelperDiv"));
            } else {
                $(this).after($("#DropHelperDiv"));
            }
            
            $("#DropHelperDiv").attr("style", "display:");
            //跳出循环
            return false;
        }
    });
}

//双击控件事件,css待添加
function onClickItem(event)
{
    //测试
    //alert(this.id);
    
    //阻止事件冒泡
    //event.stopPropagation();
    
    ItemCtrl = $(this);

    $(".ReportHolderPanelForSelect").removeClass("ClickItemPanelToModify");
    ItemCtrl.addClass("ClickItemPanelToModify");
    
    var ItemType;
    try
    {
        ItemType = ItemCtrl.find("span[id$='Hidden_ItemTypeForAttr']").get(0).innerHTML;
    } catch (e)
    {
        ItemType = "";
    }
    
    //显示属性tab
    $("div").find("div[id$='Panel_EditTabs']").tabs('select', 1);
    TabIndex = 1;
    
    //显示相应控件的属性panel
    //DisplayAttrPanel(ItemType, ItemCtrl);////////////////////////////////////////////////////////////////
    
    //隐藏域赋值
    $("input[id$='Hidden_ItemCtrlTypeModify_InEditor']").attr("value", ItemType);

    try
    {
        $("input[id$='Hidden_ParentFullName_InEditor']").attr("value", ItemCtrl.find("span[id$='Hidden_ParentFullName']").get(0).innerHTML);
    } catch (e)
    {
        $("input[id$='Hidden_ParentFullName_InEditor']").attr("value", "");
    }
    
    var ItemIndex = ItemCtrl.parent().find(".ReportHolderPanelForSelect").index(ItemCtrl[0]);
    if (ItemIndex != -1) {
        $("input[id$='Hidden_ItemIndexModify_InEditor']").attr("value", ItemIndex);
        
        
        /////////////////////////////////////////////

/*
        test1 = $("input[id$='Hidden_SaveIndex']").val(); //.get(0).innerHTML;
        //alert("js:" + test1);
        if (test1 == "") {
            $("input[id$='Hidden_SaveIndex']").attr("value", ItemIndex);
            var test4 = $("input[id$='Hidden_SaveIndex']").val();
        //    alert("js:" + test4);
        }
*/

        ////////////////////////////////////////////////////////
    }

    ////////////////////////////////////////////////////
    var index_in_hidden = $("input[id$='Hidden_SaveIndex']").val(); //.get(0).innerHTML; //.val



    if (ItemType == "SINGLESELECT" && ItemIndex != index_in_hidden) {
      //  alert("do not show");
        $(".PanelItemAttr").attr("style", "display:none");
    }
    else {
     //   alert("show");
        DisplayAttrPanel(ItemType, ItemCtrl);
    }


    //////////////////////////////////////////////////////////////////////////
    if (ItemType == "SINGLESELECT" && index_in_hidden == "") {
        DisplayAttrPanel(ItemType, ItemCtrl);
    }
    //////////////////////////////////////////////////////
    //保存全局的修改控件
    ItemModified = ItemCtrl;
    ItemTypeModified = ItemType;
    ItemModifiedID = ItemCtrl.get(0).id;
    
    return false;
}

//显示相应控件的属性panel
function DisplayAttrPanel(ItemType, ItemCtrl)
{
    $(".PanelItemAttr").attr("style", "display:none");
    if (ItemType == "REPORT") {
        $("div").find("div[id$='Panel_ItemAttrReport']").attr("style", "display:");
        $("div").find("div[id$='Panel_ItemAttrReport']").find("input[id$='TextBox_ReportName_InEditor']").attr("value", ItemCtrl.find("span[id$='Label_ReportNameInReportCtrl']").get(0).innerHTML);
    } else if (ItemType == "TEXT") {
        $("div").find("div[id$='Panel_ItemAttrText']").attr("style", "display:");
        $("div").find("div[id$='Panel_ItemAttrProperty']").attr("style", "display:");
        $("div").find("div[id$='Panel_ItemAttrText']").find("input[id$='TextBox_TextName_InEditor']").attr("value", ItemCtrl.find("span[id$='Label_ItemName']").get(0).innerHTML);

        $("div").find("div[id$='Panel_ItemAttrProperty']").find("select[id$='DropDownList_ResultEditMode']").attr("value", ItemCtrl.find("span[id$='DropDownList_ResultEditMode']").get(0).innerHTML);
        $("div").find("div[id$='Panel_ItemAttrProperty']").find("select[id$='DropDownList_ResultViewMode']").attr("value", ItemCtrl.find("span[id$='DropDownList_ResultViewMode']").get(0).innerHTML);
        if (ItemCtrl.find("span[id$='CB_IsKey']").get(0).innerHTML == "True") {
            $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_IsKey']").attr("checked",true);
        } else {
            $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_IsKey']").attr("checked",'');
        }
        //$("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_IsKey']").attr("checked", ItemCtrl.find("span[id$='CB_IsKey']").get(0).innerHTML);
        if (ItemCtrl.find("span[id$='CB_MustNotEmpty']").get(0).innerHTML == "True") {
            $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_MustNotEmpty']").attr("checked", true);
        } else {
            $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_MustNotEmpty']").attr("checked",'');
        }
        //$("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_MustNotEmpty']").attr("checked", ItemCtrl.find("span[id$='CB_MustNotEmpty']").get(0).innerHTML);
        $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='TB_MaxSize']").attr("value", ItemCtrl.find("span[id$='TB_MaxSize']").get(0).innerHTML);
    } else if (ItemType == "RICHTEXT") {
        $("div").find("div[id$='Panel_ItemAttrRichText']").attr("style", "display:");
        $("div").find("div[id$='Panel_ItemAttrProperty']").attr("style", "display:");
        $("div").find("div[id$='Panel_ItemAttrRichText']").find("input[id$='TextBox_RichTextName_InEditor']").attr("value", ItemCtrl.find("span[id$='Label_ItemName']").get(0).innerHTML);

        $("div").find("div[id$='Panel_ItemAttrProperty']").find("select[id$='DropDownList_ResultEditMode']").attr("value", ItemCtrl.find("span[id$='DropDownList_ResultEditMode']").get(0).innerHTML);
        $("div").find("div[id$='Panel_ItemAttrProperty']").find("select[id$='DropDownList_ResultViewMode']").attr("value", ItemCtrl.find("span[id$='DropDownList_ResultViewMode']").get(0).innerHTML);
        if (ItemCtrl.find("span[id$='CB_IsKey']").get(0).innerHTML == "True") {
            $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_IsKey']").attr("checked",true);
        } else {
            $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_IsKey']").attr("checked",'');
        }
        if (ItemCtrl.find("span[id$='CB_MustNotEmpty']").get(0).innerHTML == "True") {
            $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_MustNotEmpty']").attr("checked", true);
        } else {
            $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_MustNotEmpty']").attr("checked",'');
        }
        $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='TB_MaxSize']").attr("value", ItemCtrl.find("span[id$='TB_MaxSize']").get(0).innerHTML);
    } else if (ItemType == "SINGLESELECT") {
        $("div").find("div[id$='Panel_ItemAttrSingleSelect']").attr("style", "display:");
        $("div").find("div[id$='Panel_ItemAttrProperty']").attr("style", "display:");
        $("div").find("div[id$='Panel_ItemAttrSingleSelect']").find("input[id$='TextBox_SingleSelectName_InEditor']").attr("value", ItemCtrl.find("span[id$='Label_SingleSelectionName']").get(0).innerHTML);

        $("div").find("div[id$='Panel_ItemAttrProperty']").find("select[id$='DropDownList_ResultEditMode']").attr("value", ItemCtrl.find("span[id$='DropDownList_ResultEditMode']").get(0).innerHTML);
        $("div").find("div[id$='Panel_ItemAttrProperty']").find("select[id$='DropDownList_ResultViewMode']").attr("value", ItemCtrl.find("span[id$='DropDownList_ResultViewMode']").get(0).innerHTML);
        if (ItemCtrl.find("span[id$='CB_IsKey']").get(0).innerHTML == "True") {
            $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_IsKey']").attr("checked",true);
        } else {
            $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_IsKey']").attr("checked",'');
        }
        if (ItemCtrl.find("span[id$='CB_MustNotEmpty']").get(0).innerHTML == "True") {
            $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_MustNotEmpty']").attr("checked", true);
        } else {
            $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='CB_MustNotEmpty']").attr("checked",'');
        }
        $("div").find("div[id$='Panel_ItemAttrProperty']").find("input[id$='TB_MaxSize']").attr("value", ItemCtrl.find("span[id$='TB_MaxSize']").get(0).innerHTML);
    }else {
        //其余的
        return false;
    }
}

function DisplayAttrPanelPostBack(ItemType)                            
{
    if (ItemType == "REPORT") {
        $("div").find("div[id$='Panel_ItemAttrReport']").attr("style", "display:");
    } else if (ItemType == "TEXT") {
        $("div").find("div[id$='Panel_ItemAttrText']").attr("style", "display:");
        $("div").find("div[id$='Panel_ItemAttrProperty']").attr("style", "display:");
    }  else if (ItemType == "RICHTEXT") {
        $("div").find("div[id$='Panel_ItemAttrRichText']").attr("style", "display:");
        $("div").find("div[id$='Panel_ItemAttrProperty']").attr("style", "display:");
    } else if (ItemType == "SINGLESELECT") {
        $("div").find("div[id$='Panel_ItemAttrSingleSelect']").attr("style", "display:");
        $("div").find("div[id$='Panel_ItemAttrProperty']").attr("style", "display:");
    } else {
        //其余的
        return false;
    }
}

//问卷名onkeyup事件
function onKeyUpReportNameModify()
{
    if (ItemModified == null) {
        return;
    }
    
    if (ItemModified.get(0).innerHTML == "") {
        ItemModified = $("#"+ItemModifiedID);
    }
    
    //同步
    var ReportNameModify = $("input[id$='TextBox_ReportName_InEditor']").val();
    ItemModified.find("span[id$='Label_ReportNameInReportCtrl']").get(0).innerHTML = ReportNameModify;
}


//文本框名onkeyup事件
function onKeyUpTextNameModify()
{
    if (ItemModified == null) {
        return;
    }

    if (ItemModified.get(0).innerHTML == "") {
        ItemModified = $("#"+ItemModifiedID);
    }
    
    //同步
    var TextNameModify = $("input[id$='TextBox_TextName_InEditor']").val();
    ItemModified.find("span[id$='Label_ItemName']").get(0).innerHTML = TextNameModify;
}

//tabs_select event
function onTabsSelect(ev, ui)
{
    TabIndex = ui.index;
    
    //隐藏域清空，属性tab清空
    if (ui.index == 0) {
        $("input[id$='Hidden_ItemCtrlTypeModify_InEditor']").attr("value", "");
        $("input[id$='Hidden_ParentFullName_InEditor']").attr("value", "");
        $("input[id$='Hidden_ItemIndexModify_InEditor']").attr("value", "");
        
        $(".ReportHolderPanelForSelect").removeClass("ClickItemPanelToModify");
        $(".PanelItemAttr").attr("style", "display:none");
    }
}

//RichTextbox onkeyup事件
function onKeyUpRichTextNameModify() {
    if (ItemModified == null) {
        return;
    }

    if (ItemModified.get(0).innerHTML == "") {
        ItemModified = $("#"+ItemModifiedID);
    }

    //同步
    var RichTextNameModify = $("input[id$='TextBox_RichTextName_InEditor']").val();
    ItemModified.find("span[id$='Label_ItemName']").get(0).innerHTML = RichTextNameModify;
}


function GetItemCtrl(elemid)
{
    //alert(elemid);
    
    if (elemid == "") {
        return null;
    }
    
    var itemmodify = null;

    //获得上次选中的控件
	itemmodify = $("#" + ItemModifiedID);
	    
	if (itemmodify == undefined) {
	    return null;
	}
        
    if (elemid.lastIndexOf("BN_Delete") != -1) {
        //删除按钮
        WhichIsDisplay = 0;
        return null;
    } else if (elemid.lastIndexOf("BN_MoveUP") != -1) {
        //上移按钮
        WhichIsDisplay = 0;
        return null;
    } else if (elemid.lastIndexOf("BN_MoveDown") != -1) {
        //下移按钮
        WhichIsDisplay = 0;
        return null;
    } else if (elemid.lastIndexOf("Timer_Refresh") != -1) {
        //刷新控件
        if (WhichIsDisplay == 0) {
            return null;
        } 
//         else if (WhichIsDisplay == 1) {
//             //上移
//             var itemtmp = itemmodify.prevAll(".ReportHolderPanelForSelect:last");
//             if (itemtmp.length != 0) {
//                 //不是第一个
//                 itemmodify = itemtmp;
//                 ItemModifiedID = itemmodify.get(0).id;
//             }
//         } else if (WhichIsDisplay == 2) {
//             //下移
//             var itemtmp = itemmodify.nextAll(".ReportHolderPanelForSelect:first");
//             if (itemtmp.length != 0) {
//                 //不是最后一个
//                 itemmodify = itemtmp;
//                 ItemModifiedID = itemmodify.get(0).id;
//             }
//         }
    } else {
        //其余控件
        WhichIsDisplay = 3;
    }
    
    return itemmodify;
}


//单选名onkeyup事件
function onKeyUpSingleSelectNameModify() {
    if (ItemModified == null) {
        return;
    }

    if (ItemModified.get(0).innerHTML == "") {
        ItemModified = $("#" + ItemModifiedID);
    }

    //同步
    var SingleSelectNameModify = $("input[id$='TextBox_SingleSelectName_InEditor']").val();
    ItemModified.find("span[id$='Label_SingleSelectionName']").get(0).innerHTML = SingleSelectNameModify;
}

//选项内容onkeyup事件     
function onKeyUpChoiceModify(x) {
    //alert(x); 
}
