using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SunMkr.Com.Literal
{
    /// <summary>
    /// String Validate.
    /// </summary>
    public static class Validate
    {
        static Regex x_FilePath;
        /// <summary>
        /// Get a regex of File Path
        /// </summary>
        public static Regex XFilePath
        {
            get { return x_FilePath; }
        }
        static Regex x_MailAddress;
        /// <summary>
        /// Get a regex of MailAddress
        /// </summary>
        public static Regex XMailAddress
        {
            get { return x_MailAddress; }
        }
        static Regex x_Integer;
        /// <summary>
        /// Get a regex of Integer
        /// </summary>
        public static Regex XInteger
        {
            get { return x_Integer; }
        }
        static Regex x_NotNavigateInt;
        /// <summary>
        /// Get a regex of Not-Navigate-Integer
        /// </summary>
        public static Regex XNotNavigateInt
        {
            get { return x_NotNavigateInt; }
        }
        static Regex x_PositiveInt;
        /// <summary>
        /// Get a regex of Positive Integer
        /// </summary>
        public static Regex XPositiveInt
        {
            get { return x_PositiveInt; }
        }
        static Regex x_NotPositiveInt;
        /// <summary>
        /// Get a regex of Not-Positive Integer
        /// </summary>
        public static Regex XNotPositiveInt
        {
            get { return x_NotPositiveInt; }
        }
        static Regex x_NavigateInt;
        /// <summary>
        /// Get a regex of Navigate Integer
        /// </summary>
        public static Regex XNavigateInt
        {
            get { return x_NavigateInt; }
        }
        static Regex x_NotNavigateFloat;
        /// <summary>
        /// Get a regex of Not-Navigaet Float
        /// </summary>
        public static Regex XNotNavigateFloat
        {
            get { return x_NotNavigateFloat; }
        }
        static Regex x_PositiveFloat;
        /// <summary>
        /// Get a regex of Positive Float
        /// </summary>
        public static Regex XPositiveFloat
        {
            get { return x_PositiveFloat; }
        }
        static Regex x_NotPositiveFloat;
        /// <summary>
        /// Get a regex of Not-Positive Float
        /// </summary>
        public static Regex XNotPositiveFloat
        {
            get { return x_NotPositiveFloat; }
        }
        static Regex x_NavigateFloat;
        /// <summary>
        /// Get a regex of Navigate Float
        /// </summary>
        public static Regex XNavigateFloat
        {
            get { return x_NavigateFloat; }
        }
        static Regex x_Float;
        /// <summary>
        /// Get a regex of Float
        /// </summary>
        public static Regex XFloat
        {
            get { return x_Float; }
        }
        static Regex x_UpperString;
        /// <summary>
        /// Get a regex of Upper-Case String
        /// </summary>
        public static Regex XUpper
        {
            get { return x_UpperString; }
        }
        static Regex x_LowerString;
        /// <summary>
        /// Get a regex of Lower-Case String
        /// </summary>
        public static Regex XLower
        {
            get { return x_LowerString; }
        }
        static Regex x_LetterString;
        /// <summary>
        /// Get a regex of All-Letter String
        /// </summary>
        public static Regex XLetters
        {
            get { return x_LetterString; }
        }
        static Regex x_StringWithNumber;
        /// <summary>
        /// Get a regex of a string maybe with number
        /// </summary>
        public static Regex XStringNumber
        {
            get { return x_StringWithNumber; }
        }
        static Regex x_String_Number;
        /// <summary>
        /// Get a regex of a string may contain number and available characters. (like '_')
        /// </summary>
        public static Regex XFormatString
        {
            get { return x_String_Number; }
        }
        static Regex x_Url;
        /// <summary>
        /// Get a regex of URL
        /// </summary>
        public static Regex XUrl
        {
            get { return x_Url; }
        }
        static Regex x_Tel;
        /// <summary>
        /// Get a regex of Telphone number.
        /// </summary>
        public static Regex XTel
        {
            get { return x_Tel; }
        }
        static Regex x_IP;
        /// <summary>
        /// Get a regex of IP Address.
        /// </summary>
        public static Regex XIP
        {
            get { return x_IP; }
        }
        static Regex x_Chinese;
        /// <summary>
        /// Get a regex of Chinese words.
        /// </summary>
        public static Regex XChinese
        {
            get { return x_Chinese; }
        }
        static Regex x_EmptyLine;
        /// <summary>
        /// Get a regex of Empty Line.
        /// </summary>
        public static Regex XEmptyLine
        {
            get { return x_EmptyLine; }
        }
        static Regex x_Html;
        /// <summary>
        /// Get a regex of html marks.
        /// </summary>
        public static Regex XHtml
        {
            get { return x_Html; }
        }

        static Validate( )
        {
            x_FilePath = new Regex( "([a-zA-Z]\\:)(\\\\[^\\\\/:*?<>\"|]*)*(\\.[a-zA-Z_0-9]{2,6})" );
            x_MailAddress = new Regex( @"[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" );
            x_Integer = new Regex( @"^-?\d+$" );
            x_NotNavigateInt = new Regex( @"^\d+$" );
            x_PositiveInt = new Regex( @"^[0-9]*[1-9][0-9]*$" );
            x_NotPositiveInt = new Regex( @"^((-\d+)|(0+))$" );
            x_NavigateInt = new Regex( @"^-[0-9]*[1-9][0-9]*$" );
            x_NotNavigateFloat = new Regex( @"^\d+(\.\d+)?$" );
            x_PositiveFloat = new Regex( @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$" );
            x_NotPositiveFloat = new Regex( @"^((-\d+(\.\d+)?)|(0+(\.0+)?))$" );
            x_NavigateFloat = new Regex( @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$" );
            x_Float = new Regex( @"^(-?\d+)(\.\d+)?$" );
            x_UpperString = new Regex( @"^[A-Z]+$" );
            x_LowerString = new Regex( @"^[a-z]+$" );
            x_LetterString = new Regex( @"^[A-Za-z]+$" );
            x_StringWithNumber = new Regex( @"^[A-Za-z0-9]+$" );
            x_String_Number = new Regex( @"^\w+$" );
            x_Url = new Regex( @"^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$" );
            x_Tel = new Regex( @"(d+-)?(d{4}-?d{7}|d{3}-?d{8}|^d{7,8})(-d+)?" );
            x_IP = new Regex( @"^(d{1,2}|1dd|2[0-4]d|25[0-5]).(d{1,2}|1dd|2[0-4]d|25[0-5]).(d{1,2}|1dd|2[0-4]d|25[0-5]).(d{1,2}|1dd|2[0-4]d|25[0-5])$" );
            x_Chinese = new Regex( @"\u4e00-\u9fa5" );
            x_EmptyLine = new Regex( @"\n[\s| ]*\r" );
            x_Html = new Regex( @"<(.*)>.*<\/\1>|<(.*) \/>" );
        }

        /// <summary>
        /// Validate if the input string is a file path.
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static bool IsFileSysPath( string FilePath )
        {
            return x_FilePath.IsMatch( FilePath );
        }

        /// <summary>
        /// Validate if the input string is a mail address.
        /// </summary>
        /// <param name="MailAddress"></param>
        /// <returns></returns>
        public static bool IsMailAddress( string MailAddress )
        {
            return x_MailAddress.IsMatch( MailAddress );
        }

        /// <summary>
        /// Check if the input string in the format of the regular expression.
        /// </summary>
        /// <param name="RegExpress"></param>
        /// <param name="InputString"></param>
        /// <returns></returns>
        public static bool IsInFormat(string RegExpress, string InputString)
        {
            Regex x = new Regex(RegExpress);
            return x.IsMatch(InputString);
        }
    }
}
