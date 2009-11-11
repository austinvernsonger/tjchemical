using System;
using System.Collections.Generic;
using System.Text;

namespace Teaching
{
    public static class FckConverter
    {
        public static String ProcessString(String oldString)
        {
            String newString = String.Copy(oldString);
            for (int i = 0; i != newString.Length; ++i)
            {
                if (newString[i] == '\'')
                {
                    newString = newString.Insert(i, "\'");
                    i += 1;
                }
            }
            newString = "\'" + newString + "\'";
            return newString;
        }
    }
}
