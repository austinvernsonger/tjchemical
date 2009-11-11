using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.Authority;

namespace LabCenter.LabUtility.SuperUtility
{
    class SuperCtrl
    {
        public static bool AddSuper(string id)
        {
            AuthorityManage am=new AuthorityManage();
            if (am.HasSuper())
            {
                return false;
            }
            else
            {
                return am.AddSuper(id);
            }
        }
    }
}
