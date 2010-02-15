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
    protected String strStudentID;
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
        Int16 ivalidate = Convert.ToInt16(QueryRs.Tables[0].Rows[0][62]);
        switch (ivalidate)
        {
            case 0:
                btConfirm.Visible = true;
                btConfirm.Enabled = true;
                lbErrorMessage.Text = "状态：未审核";
        	    break;
            case 1:
                btConfirm.Visible = true;
                btConfirm.Enabled = true;
                lbErrorMessage.Text = "状态：未通过审核\r\n";
                lbErrorMessage.Text += "原因：\r\n" + CheckContent(QueryRs.Tables[0].Rows[0][61]);
                break;
            case 2:
                btConfirm.Visible = false;
                btConfirm.Enabled = false;
                lbErrorMessage.Text = "状态：通过审核";
                break;
            default:
                lbErrorMessage.Text = "网络或数据原因状态读取错误！请与管理员联系！";
                break;
        }
    }

    protected void btConfirm_Click(object sender, EventArgs e)
    {
        String strPersonalPhoto = ImgPersonalPhoto.ImageUrl;
        String strCollege = txtCollege.Text.Trim();
        String iDepartment = DropDownListDepartment.SelectedValue;
        String iWorkUnit = DropDownListWorkUnit.SelectedValue;
        String strStudentName = lbName.Text.Trim();
        String strOriginalName = txtOriginalName.Text.Trim();
        String iGender = DropDownListGender.SelectedValue;
        String strNativeProvince = txtNativeProvince.Text.Trim();
        DateTime dt_BirthDay = Convert.ToDateTime(txtBirthDay.Text.Trim());
        String strNation = txtNation.Text.Trim();
        String strBirthPlace = txtBirthPlace.Text.Trim();
        String strHomeBirth = txtHomeBirth.Text.Trim();
        String iPoliticalStatus = DropDownListPoliticalStatus.Text.Trim();
        String strPaperworktype = txtPaperworktype.Text.Trim();
        String strPaperworkNum = txtPaperworkNum.Text.Trim();
        String iMarriage = DropDownListMarriage.SelectedValue;
        String strConsortName = txtConsortName.Text.Trim();
        String strConsortPhoneNumber = txtConsortPhoneNumber.Text.Trim();
        String strConsortWorkingPlace = txtConsortWorkingPlace.Text.Trim();
        String strEntranceYear = txtEntranceYear.Text.Trim();
        String iEntranceSeason = DropDownListEntranceSeason.SelectedValue;
        String strGrade = txtGrade.Text.Trim();
        String strClass = txtClass.Text.Trim();
        String strStudyTime = txtStudyTime.Text.Trim();
        String strWorkingPlaceBeforeSchool = txtWorkingPlaceBeforeSchool.Text.Trim();
        String iStudyType = DropDownListStudyType.SelectedValue;
        String iNowCondition = DropDownListNowCondition.SelectedValue;
        String iContinent = DropDownListContinent.SelectedValue;
        String strCountry = txtCountry.Text.Trim();
        String strStudentSource = txtStudentSource.Text.Trim();
        String iStudentTyp = DropDownListStudentType.SelectedValue;
        String iTrainType = DropDownListTrainType.SelectedValue;
        String iSubsidizeType = DropDownListSubsidizeType.SelectedValue;
        String strField = txtField.Text.Trim();
        String strFieldDirection = txtFieldDirection.Text.Trim();
        String strTeacher = txtTeacher.Text.Trim();
        String strHealth = txtHealth.Text.Trim();
        String strBloodtype = txtBloodType.Text.Trim();
        String strGraduation = txtGraduation.Text.Trim();
        String iGraduationSeason = DropDownListGraduationSeason.SelectedValue;
        String strGraduationTime = txtGraduationTime.Text.Trim();
        String iGraduationType = DropDownListGraduationType.SelectedValue;
        String strTrainArriveDestination = txtTrainArriveDestination.Text.Trim();
        String strDormitoryNum = txtDormitoryNum.Text.Trim();
        String strDormitoryRoom = txtDormitoryRoom.Text.Trim();
        String strDormitoryPhone = txtDormitoryPhone.Text.Trim();
        String strEmailAddress = txtEmailAddress.Text.Trim();
        String strQQ = txtQQ.Text.Trim();
        String strMSN = txtMSN.Text.Trim();
        String strHomePhone = txtHomePhone.Text.Trim();
        String strHomeAddress = txtHomeAddress.Text.Trim();
        String strPostCode = txtPostCode.Text.Trim();
        String strRegisteredResidence = txtRegisteredResidence.Text.Trim();
        String strRegisteredResidenceProperty = txtRegisteredResidenceProperty.Text.Trim();
        String strFatherName = txtFatherName.Text.Trim();
        String strFatherPhone = txtFatherPhone.Text.Trim();
        String strFatherWorkingPlace = txtFatherWorkingPlace.Text.Trim();
        String strMotherName = txtMotherName.Text.Trim();
        String strMotherPhone = txtMotherPhone.Text.Trim();
        String strMotherWorkingPlace = txtMotherWorkingPlace.Text.Trim();
        if(!StudentBasicInfoEx.InsertStudentInfo(strPersonalPhoto,
         strCollege,
         iDepartment,
         iWorkUnit,
         strStudentID,
         strStudentName,
         strOriginalName,
         iGender,
         strNativeProvince,
         dt_BirthDay,
         strNation,
         strBirthPlace,
         strHomeBirth,
         iPoliticalStatus,
         strPaperworktype,
         strPaperworkNum,
         iMarriage,
         strConsortName,
         strConsortPhoneNumber,
         strConsortWorkingPlace,
         strEntranceYear,
         iEntranceSeason,
         strGrade,
         strClass,
         strStudyTime,
         strWorkingPlaceBeforeSchool,
         iStudyType,
         iNowCondition,
         iContinent,
         strCountry,
         strStudentSource,
         iStudentTyp,
         iTrainType,
         iSubsidizeType,
         strField,
         strFieldDirection,
         strTeacher,
         strHealth,
         strBloodtype,
         strGraduation,
         iGraduationSeason,
         strGraduationTime,
         iGraduationType,
         strTrainArriveDestination,
         strDormitoryNum,
         strDormitoryRoom,
         strDormitoryPhone,
         strEmailAddress,
         strQQ,
         strMSN,
         strHomePhone,
         strHomeAddress,
         strPostCode,
         strRegisteredResidence,
         strRegisteredResidenceProperty,
         strFatherName,
         strFatherPhone,
         strFatherWorkingPlace,
         strMotherName,
         strMotherPhone,
         strMotherWorkingPlace))
        {
            lbErrorMessage.Text = "数据插入失败！";
            return;
        }
        lbErrorMessage.Text = "数据插入成功！";
    }
}
