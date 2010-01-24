using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using StundentInfoManagement;
public partial class StudentInfo_StudentBasicInfo : System.Web.UI.Page
{
    protected String strPersonalPhoto;
    protected String strCollege;
    protected String strDepartment;
    protected String strStudentID;
    protected String strName;
    protected String strOriginalName;
    protected Int32 iGender;
    protected String strNativeProvince;
    protected DateTime dt_BirthDay;
    protected String strNation;
    protected String strBirthPlace;
    protected String strHomeBirth;
    protected Int32 iPoliticalStatus;
    protected String strPaperworktype;
    protected String strPaperworkNum;
    protected Int32 iMarriage;
    protected String strConsortName;
    protected String strConsortPhoneNumber;
    protected String strConsortWorkingPlace;
    protected String strEntranceYear;
    protected Int32 iEntranceSeason;
    protected String strGrade;
    protected String strClass;
    protected String strStudyTime;
    protected String strWorkingPlaceBeforeSchool;
    protected Int32 iStudyType;
    protected Int32 iNowCondition;
    protected Int32 iContinent;
    protected String strCountry;
    protected String strStudentSource;
    protected Int32 iStudentTyp;
    protected Int32 iTrainType;
    protected Int32 iSubsidizeType;
    protected String strField;
    protected String strFieldDirection;
    protected String strTeacher;
    protected String strHealth;
    protected String strBloodtype;
    protected String strGraduation;
    protected Int32 iGraduationSeason;
    protected String strGraduationTime;
    protected Int32 iGraduationType;
    protected String strTrainArriveDestination;
    protected String strDormitoryNum;
    protected String strDormitoryRoom;
    protected String strDormitoryPhone;
    protected String strEmailAddress;
    protected String strQQ;
    protected String strMSN;
    protected String strHomePhone;
    protected String strHomeAddress;
    protected String strPostCode;
    protected String strRegisteredResidence;
    protected String strRegisteredResidenceProperty;
    protected String strFatherNam;
    protected String strFatherPhone;
    protected String strFatherWorkingPlace;
    protected String strMotherName;
    protected String strMotherPhone;
    protected String strMotherWorkingPlace;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (CheckID() && !IsPostBack)
        {
            BasicInfoInitialize();
        }

    }
    protected bool CheckID()
    {
        /*if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        String StudentID = Session["IdentifyNumber"].ToString();*/
        return true;
    }
    protected void BasicInfoInitialize()
    {
        DataSet QueryRs =StudentBasicInfoEx.SelectBasicInfo("074249"/*Session["IdentifyNumber"].ToString()*/);
        
    }
}
