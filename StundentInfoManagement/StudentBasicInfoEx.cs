using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
using SMBL.Operation;
using StundentInfoManagement.Ops;
using System.Data;
namespace StundentInfoManagement
{
    public class StudentBasicInfoEx
    {
        public static DataSet SelectBasicInfo(String StudentID)
        {
            Sql.SqlSelectAllStudentBasicInfo QueryString = new Sql.SqlSelectAllStudentBasicInfo();
            QueryString.SetSelectId(StudentID);
            OpStudentMngQuery OpsQuery = new OpStudentMngQuery(QueryString);
            OpsQuery.Do();
            return OpsQuery.Ds;
        }
        public static bool CheckAdmin(String ID)
        {
            Sql.SqlCheckAdmin QueryString = new Sql.SqlCheckAdmin();
            QueryString.SetSelectId(ID);
            OpStudentMngQuery OpsQuery = new OpStudentMngQuery(QueryString);
            OpsQuery.Do();
            if (OpsQuery.Ds.Tables[0].Columns.Count == 0)
            {
                return false;
            }
            return true;
        }
        private static byte BoolChange(String a)
        {
            if (a == "0")
            {
                return 0;
            }
            return 1;
        }
        public static bool InsertStudentInfo(
        String strPersonalPhoto,
        String strCollege,
        String iDepartment,
        String iWorkUnit,
        String strStudentID,
        String strStudentName,
        String strOriginalName,
        String iGender,
        String strNativeProvince,
        DateTime dt_BirthDay,
        String strNation,
        String strBirthPlace,
        String strHomeBirth,
        String iPoliticalStatus,
        String strPaperworktype,
        String strPaperworkNum,
        String iMarriage,
        String strConsortName,
        String strConsortPhoneNumber,
        String strConsortWorkingPlace,
        String strEntranceYear,
        String iEntranceSeason,
        String strGrade,
        String strClass,
        String strStudyTime,
        String strWorkingPlaceBeforeSchool,
        String iStudyType,
        String iNowCondition,
        String iContinent,
        String strCountry,
        String strStudentSource,
        String iStudentTyp,
        String iTrainType,
        String iSubsidizeType,
        String strField,
        String strFieldDirection,
        String strTeacher,
        String strHealth,
        String strBloodtype,
        String strGraduation,
        String iGraduationSeason,
        String strGraduationTime,
        String iGraduationType,
        String strTrainArriveDestination,
        String strDormitoryNum,
        String strDormitoryRoom,
        String strDormitoryPhone,
        String strEmailAddress,
        String strQQ,
        String strMSN,
        String strHomePhone,
        String strHomeAddress,
        String strPostCode,
        String strRegisteredResidence,
        String strRegisteredResidenceProperty,
        String strFatherName,
        String strFatherPhone,
        String strFatherWorkingPlace,
        String strMotherName,
        String strMotherPhone,
        String strMotherWorkingPlace)
        {
            OpStudentMngProducer op = new OpStudentMngProducer("P_ADD_STUDENT",
         strPersonalPhoto,
         strCollege,
         Convert.ToInt16(iDepartment),
         Convert.ToInt16(iWorkUnit),
         strStudentID,
         strStudentName,
         strOriginalName,
         BoolChange(iGender),
         strNativeProvince,
         dt_BirthDay,
         strNation,
         strBirthPlace,
         strHomeBirth,
         Convert.ToInt16(iPoliticalStatus),
         strPaperworktype,
         strPaperworkNum,
         BoolChange(iMarriage),
         strConsortName,
         strConsortPhoneNumber,
         strConsortWorkingPlace,
         strEntranceYear,
         BoolChange(iEntranceSeason),
         strGrade,
         strClass,
         strStudyTime,
         strWorkingPlaceBeforeSchool,
         BoolChange(iStudyType),
         BoolChange(iNowCondition),
         Convert.ToInt16(iContinent),
         strCountry,
         strStudentSource,
         Convert.ToInt16(iStudentTyp),
         Convert.ToInt16(iTrainType),
         Convert.ToInt16(iSubsidizeType),
         strField,
         strFieldDirection,
         strTeacher,
         strHealth,
         strBloodtype,
         Convert.ToInt32(strGraduation),
         BoolChange(iGraduationSeason),
         strGraduationTime,
         Convert.ToInt16(iGraduationType),
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
         strMotherWorkingPlace);
            op.Do();
            if (Convert.ToBoolean(op.ExecuteResult))
            {
                return true;
            }
            return false;
		
        }
    }

}
