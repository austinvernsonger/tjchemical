using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for WebSiteRegister
/// </summary>
public class WebSiteRegister
{
    public WebSiteRegister()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Register you department here!
    /// </summary>
    /// <returns></returns>
    public static Boolean RegisterDepartment()
    {
        //Department.Interface.DepartmentList.Register(Myname, myInterface);
        //Department.Interface.DepartmentList.Register("工程硕士中心", new Department.Engineering.EngineerLogRegister());
      //  Department.Interface.DepartmentList.Register("教学部", new Teaching.TeachingMngRegister());
       
        //Department.Interface.DepartmentList.Register("教务处", new Education.src.EducationAuthRegister());
       // Department.Interface.DepartmentList.Register("院友之家", new AlumnusRecord.AlumnusRegister());

      //  Department.Interface.DepartmentList.Register("院友会", new AlumusRecordsrc.EducationAuthRegister());
        
        
        // Revised On 17/8/09 
        // Register The Recruitment Department  
        //Department.Interface.DepartmentList.Register("招生部", new Admission.AdmissionRegister());

        return true;
    }
}
