using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.IO;

namespace Teaching
{
    public static class StatusCheck
    {
        public static void Connect(String username, String password)
        {
            String cmdString = "net use \\\\10.60.40.2 /user:" + username + " " + password;
            Console.WriteLine(cmdString);
            ManagementClass processClass = new ManagementClass("Win32_Process");
            object[] methodArgs = { cmdString, null, null, 0 };
            object result = processClass.InvokeMethod("Create", methodArgs);
        }

        public static Boolean Check(String filename, String username, String password)
        {
            Connect(username, password);
            //String filename = "\\\\10.60.40.2\\Public_files\\精品课程申请\\双语";
            return Directory.Exists(filename);
        }
    }
}
