using System;
using System.Collections.Generic;
using System.Web;
using Report.Adapter;
using Report.Controls;
using Report.Descriptor;
using Report.ReportException;

/// <summary>
///MySingleSelectionAdapter 的摘要说明
/// </summary>
public class MySingleSelectionAdapter
{
//     private ItemDescriptor itemDesc;
//     IItemControl singleSelectionControl;
//     IItemControl singleSelectionEditControl;
// 
//     public MySingleSelectionAdapter()
//     {
//         //
//         //TODO: 在此处添加构造函数逻辑
//         //
//     }
// 
//     #region IControlAdapter 成员
// 
//     public string GetResult()
//     {
//         return singleSelectionControl.GetResult();
//     }
// 
//     public void CreateDisplayControl(System.Web.UI.TemplateControl control, System.Web.UI.ControlCollection collection)
//     {
//         singleSelectionControl = control.LoadControl("~/Report/ItemControl/SingleSelectionControl.ascx") as IItemControl;
//         singleSelectionControl.SetDescriptor(itemDesc);
//         collection.Add(singleSelectionControl as System.Web.UI.Control);
//     }
// 
//     public void CreateEditControl(System.Web.UI.TemplateControl control, System.Web.UI.ControlCollection collection)
//     {
//         singleSelectionEditControl = control.LoadControl("~/Report/EditControl/SingleSelectionEditControl.ascx") as IItemControl;
//         singleSelectionEditControl.SetDescriptor(itemDesc);
//         collection.Add(singleSelectionEditControl as System.Web.UI.Control);
//     }
// 
//     public IControlAdapter Clone()
//     {
//         return new MySingleSelectionAdapter();
//     }
// 
//     public void SetDescriptor(Report.Descriptor.AbstractDescriptor Desc)
//     {
//         if (Desc.Type == ItemType.SINGLESELECT && Desc is ItemDescriptor)
//         {
//             itemDesc = Desc as ItemDescriptor;
//         }
//         else
//         {
//             throw new UnMatchedTypeException();
//         }
//     }
// 
//     #endregion
}
