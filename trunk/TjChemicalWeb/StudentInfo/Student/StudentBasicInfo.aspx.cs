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
    protected Int32 iDepartment;
    protected Int32 iWorkUnit;
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
        CheckID();
        if (!IsPostBack)
        {
            ControlInitalize();
            BasicInfoInitialize();
        }

    }
    protected void CheckID()
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        if (Session["Authority"].ToString() != "Student")
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        strStudentID = Session["IdentifyNumber"].ToString();
    }
    protected void ControlInitalize()
    {
        DataSet dtDepartmentName = DepartmentInfoEx.SelectAllDepartName();
        
        
        for (int i = 0; i != dtDepartmentName.Tables[0].Rows.Count;i++ )
        {
            ListItem ItemDepartmentName = new ListItem();
            ItemDepartmentName.Value = dtDepartmentName.Tables[0].Rows[i][0].ToString();
            ItemDepartmentName.Text = dtDepartmentName.Tables[0].Rows[i][1].ToString();
            DropDownListDepartment.Items.Add(ItemDepartmentName);
        }

        DataSet dtWorkUnitName = WorkUnitInfoEx.SelectAllWorkUnitName();
        
        for (int i = 0; i != dtWorkUnitName.Tables[0].Rows.Count;i++ )
        {
            ListItem ItemWorkUntiName = new ListItem();
            ItemWorkUntiName.Value = dtWorkUnitName.Tables[0].Rows[i][0].ToString();
            ItemWorkUntiName.Text = dtWorkUnitName.Tables[0].Rows[i][1].ToString();
            DropDownListWorkUnit.Items.Add(ItemWorkUntiName);
        }
        
    }
    protected String CheckContent(object TableContent)
    {
        if (TableContent == null)
        {
            return "";
        }
        return TableContent.ToString();
    }
    protected String DateStringFomate(String DateString)
    {
        if (DateString.Length > 11)
        {
            String[] splitDate = DateString.Split('/');
            String[] dateString = splitDate[2].Split(' ');
            String year = splitDate[0];
            String month = splitDate[1];
            String date = dateString[0];
            String Result = year + "/" + month + "/" + date;
            return Result;
        }
        return "";
    }
    protected String CheckDropDownListView(DropDownList Dp,Object a)
    {
        String content = a.ToString();
        ListItem Checkitem = Dp.Items.FindByValue(content);
        if (Checkitem == null)
        {
            return "-1";
        }
        return content;
    }
    protected void BasicInfoInitialize()
    {
        DataSet QueryRs =StudentBasicInfoEx.SelectBasicInfo(strStudentID);
        ImgPersonalPhoto.ImageUrl = CheckContent(QueryRs.Tables[0].Rows[0][0]);
        txtCollege.Text = CheckContent(QueryRs.Tables[0].Rows[0][1]);
        DropDownListDepartment.SelectedValue = CheckDropDownListView(DropDownListDepartment, QueryRs.Tables[0].Rows[0][2]);
        DropDownListWorkUnit.SelectedValue = CheckDropDownListView(DropDownListWorkUnit,  QueryRs.Tables[0].Rows[0][3]);
        lbStudentID.Text = strStudentID;
        lbName.Text = CheckContent(QueryRs.Tables[0].Rows[0][5]);
        txtOriginalName.Text = CheckContent(QueryRs.Tables[0].Rows[0][6]);
        DropDownListGender.SelectedValue = CheckDropDownListView(DropDownListGender,QueryRs.Tables[0].Rows[0][7]);
        txtNativeProvince.Text = CheckContent(QueryRs.Tables[0].Rows[0][8]);
        txtBirthDay.Text = DateStringFomate(CheckContent(QueryRs.Tables[0].Rows[0][9]));
        txtNation.Text = CheckContent(QueryRs.Tables[0].Rows[0][10]);
        txtBirthPlace.Text = CheckContent(QueryRs.Tables[0].Rows[0][11]);
        txtHomeBirth.Text =  CheckContent(QueryRs.Tables[0].Rows[0][12]);
        DropDownListPoliticalStatus.SelectedValue = CheckDropDownListView(DropDownListPoliticalStatus,QueryRs.Tables[0].Rows[0][13]);
        txtPaperworktype.Text = CheckContent(QueryRs.Tables[0].Rows[0][14]);
        txtPaperworkNum.Text = CheckContent(QueryRs.Tables[0].Rows[0][15]);
        DropDownListMarriage.SelectedValue = CheckDropDownListView(DropDownListMarriage,QueryRs.Tables[0].Rows[0][16]);
        txtConsortName.Text = CheckContent(QueryRs.Tables[0].Rows[0][17]);
        txtConsortPhoneNumber.Text = CheckContent(QueryRs.Tables[0].Rows[0][18]);
        txtConsortWorkingPlace.Text = CheckContent(QueryRs.Tables[0].Rows[0][19]);
        txtEntranceYear.Text = CheckContent(QueryRs.Tables[0].Rows[0][20]);
        DropDownListEntranceSeason.SelectedValue = CheckDropDownListView(DropDownListEntranceSeason,QueryRs.Tables[0].Rows[0][21]);
        txtGrade.Text = CheckContent(QueryRs.Tables[0].Rows[0][22]);
        txtClass.Text = CheckContent(QueryRs.Tables[0].Rows[0][23]);
        txtStudyTime.Text = CheckContent(QueryRs.Tables[0].Rows[0][24]);
        txtWorkingPlaceBeforeSchool.Text = CheckContent(QueryRs.Tables[0].Rows[0][25]);
        DropDownListStudyType.SelectedValue = CheckDropDownListView(DropDownListStudyType,QueryRs.Tables[0].Rows[0][26]);
        DropDownListNowCondition.SelectedValue = CheckDropDownListView(DropDownListNowCondition,QueryRs.Tables[0].Rows[0][27]);
        DropDownListContinent.SelectedValue = CheckDropDownListView(DropDownListContinent,QueryRs.Tables[0].Rows[0][28]);
        txtCountry.Text = CheckContent(QueryRs.Tables[0].Rows[0][29]);
        txtStudentSource.Text = CheckContent(QueryRs.Tables[0].Rows[0][30]);
        DropDownListStudentType.SelectedValue = CheckDropDownListView(DropDownListStudentType,QueryRs.Tables[0].Rows[0][31]);
        DropDownListTrainType.SelectedValue = CheckDropDownListView(DropDownListTrainType,QueryRs.Tables[0].Rows[0][32]);
        DropDownListSubsidizeType.SelectedValue = CheckDropDownListView(DropDownListSubsidizeType,QueryRs.Tables[0].Rows[0][33]);
        txtField.Text = CheckContent(QueryRs.Tables[0].Rows[0][34]);
        txtFieldDirection.Text = CheckContent(QueryRs.Tables[0].Rows[0][35]);
        txtTeacher.Text = CheckContent(QueryRs.Tables[0].Rows[0][36]);
        txtHealth.Text = CheckContent(QueryRs.Tables[0].Rows[0][37]);
        txtBloodType.Text = CheckContent(QueryRs.Tables[0].Rows[0][38]);
        txtGraduation.Text = CheckContent(QueryRs.Tables[0].Rows[0][39]);
        DropDownListGraduationSeason.SelectedValue = CheckDropDownListView(DropDownListGraduationSeason,QueryRs.Tables[0].Rows[0][40]);
        txtGraduationTime.Text = CheckContent(QueryRs.Tables[0].Rows[0][41]);
        DropDownListGraduationType.SelectedValue = CheckDropDownListView(DropDownListGraduationType,QueryRs.Tables[0].Rows[0][42]);
        txtTrainArriveDestination.Text = CheckContent(QueryRs.Tables[0].Rows[0][43]);
        txtDormitoryNum.Text = CheckContent(QueryRs.Tables[0].Rows[0][44]);
        txtDormitoryRoom.Text = CheckContent(QueryRs.Tables[0].Rows[0][45]);
        txtDormitoryPhone.Text = CheckContent(QueryRs.Tables[0].Rows[0][46]);
        txtEmailAddress.Text = CheckContent(QueryRs.Tables[0].Rows[0][47]);
        txtQQ.Text = CheckContent(QueryRs.Tables[0].Rows[0][48]);
        txtMSN.Text = CheckContent(QueryRs.Tables[0].Rows[0][49]);
        txtHomePhone.Text = CheckContent(QueryRs.Tables[0].Rows[0][50]);
        txtHomeAddress.Text = CheckContent(QueryRs.Tables[0].Rows[0][51]);
        txtPostCode.Text = CheckContent(QueryRs.Tables[0].Rows[0][52]);
        txtRegisteredResidence.Text = CheckContent(QueryRs.Tables[0].Rows[0][53]);
        txtRegisteredResidenceProperty.Text = CheckContent(QueryRs.Tables[0].Rows[0][54]);
        txtFatherName.Text = CheckContent(QueryRs.Tables[0].Rows[0][55]);
        txtFatherPhone.Text = CheckContent(QueryRs.Tables[0].Rows[0][56]);
        txtFatherWorkingPlace.Text = CheckContent(QueryRs.Tables[0].Rows[0][57]);
        txtMotherName.Text = CheckContent(QueryRs.Tables[0].Rows[0][58]);
        txtMotherPhone.Text = CheckContent(QueryRs.Tables[0].Rows[0][59]);
        txtMotherWorkingPlace.Text = CheckContent(QueryRs.Tables[0].Rows[0][60]);
    }
}
