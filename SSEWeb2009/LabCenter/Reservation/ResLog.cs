using System;
using System.Collections.Generic;
using System.Text;
using LabCenter.LabUtility.LogUtility;

namespace LabCenter.Reservation
{
    public class ResLog
    {
        static ILog _log = new TxtLog(@"C:\Logs\LabCenter", "Reservation.Log");

        public static bool EnableLog
        {
            get
            {
                return _log.EnableLog;
            }
            set
            {
                _log.EnableLog = value;
            }
        }

        public static void Write(string rawMessage)
        {
            _log.Write(rawMessage);
        }

    }
}
