using System;
using System.Collections.Generic;
using System.Text;

namespace IdentifyLibrary
{
    public class Identity
    {
        public enum IdentityType
        {
            None = 0,
            Student = 1,
            Teacher = 2
        }
        IdentityType _identityType = IdentityType.None;
        #region Identity Members
        public bool isStudent
        {
            get
            {
                return _identityType == IdentityType.Student ? true : false;
            }
        }
        public bool isTeacher
        {
            get
            {
                return _identityType == IdentityType.Teacher ? true : false;
            }
        }
        public Identity (String ID)
        {
            if(BasicInfoEx.CheckStudent(ID))
            {
                _identityType = IdentityType.Student;
            }
            if(BasicInfoEx.CheckAdmin(ID))
            {
                _identityType = IdentityType.Teacher;
            }
        }
        #endregion
    }
}
