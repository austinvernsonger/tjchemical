using System;
using System.Collections.Generic;
using System.Text;

namespace LabCenter.Authority
{
    class ManagerInfo
    {
        private string memberID;
        private string name;
        private bool isSuper;
        public string MemberID
        {
            get { return memberID;  }
            set { memberID = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public bool IsSuper
        {
            get { return isSuper; }
            set { isSuper = value; }
        }
    }
}
