using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace LabCenter.Reservation
{
    public class CurrentStudentUIPaging
    {
        private static int _currentterm;
        private static int _currentweek;

        public DataSet GetCurrentStudent()
        {
            return BackManager.GetCurrentStudentDS(_currentterm,_currentweek);
        }

        static CurrentStudentUIPaging()
        {
            if (HttpContext.Current.Cache["currentterm"] != null)
            {
                _currentterm = (int)HttpContext.Current.Cache["currentterm"];
                _currentweek = (int)HttpContext.Current.Cache["currentweek"];
            }
        }
    }
}
