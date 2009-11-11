using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LabCenter.Reservation
{
    public class LoginIPCheck
    {
        static Regex _s_r;
        static string _s_regex;
        static LoginIPCheck()
        {
            //初始化
            _s_regex = BasicConfig.IPCheckRegex;
            //rx
            _s_r = new Regex(_s_regex);
        }

        public static bool Check(string orginString)
        {
            if (_s_r != null)
            {
                return _s_r.IsMatch(orginString);
            }
            else
                return false;
        }
    }
}
