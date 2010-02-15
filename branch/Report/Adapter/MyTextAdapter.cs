using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


using Report.Adapter;
using Report.Controls;
using Report.Descriptor;
using Report.ReportException;
/// <summary>
///MyTextAdapter 的摘要说明
/// </summary>
public class MyTextAdapter
{

//     private ItemDescriptor itemDesc;
//     IItemControl textControl;
//     IItemControl textEditControl;
//     public MyTextAdapter()
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
// 
//         return textControl.GetResult();
//     }
// 
//     public void CreateDisplayControl(TemplateControl control, ControlCollection collection)
//     {
// 
//         textControl = control.LoadControl("~/Report/ItemControl/TextControl.ascx") as IItemControl;
//         textControl.SetDescriptor(itemDesc);
// 
//         collection.Add(textControl as System.Web.UI.Control);
//     }
// 
//     public void CreateEditControl(TemplateControl control, ControlCollection collection)
//     {
// 
//         textEditControl = control.LoadControl("~/Report/EditControl/TextEditControl.ascx") as IItemControl;
//         textEditControl.SetDescriptor(itemDesc);
// 
//         collection.Add(textEditControl as System.Web.UI.Control);
//     }
// 
//     public IControlAdapter Clone()
//     {
//         return new MyTextAdapter();
//     }
// 
//     public void SetDescriptor(Report.Descriptor.AbstractDescriptor Desc)
//     {
//         if (Desc.Type == ItemType.TEXT && Desc is ItemDescriptor)
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
