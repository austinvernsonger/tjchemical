using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SunMkr.Com.Literal
{
    /// <summary>
    /// String Format.
    /// </summary>
    public static class FormatString
    {
        /// <summary>
        /// Format the input filepath to X:/Folder/File.EXT style
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public static string AppFormat( string FileName )
        {
            string rtnFilePah = AppDomain.CurrentDomain.BaseDirectory;
            if ( Validate.IsFileSysPath( FileName ) )
            {
                if ( FileName.StartsWith( rtnFilePah ) )
                {
                    return FileName.Clone( ) as string;
                }
                else throw new FormatException( 
                    string.Format( "\"{0}\" not in current application's directory.", FileName ) );
            }

            // Join the app path with the file name.
            rtnFilePah += ( @"\" + FileName.TrimStart( '\\', '/' ) );
            return rtnFilePah;
        }

        /// <summary>
        /// Get current date time in format.
        /// </summary>
        /// <param name="Format"></param>
        /// <returns></returns>
        public static string GetFormatedDate( string Format )
        {
            return DateTime.Now.ToString( Format );
        }

        /// <summary>
        /// Convert the source date string to a formated type.
        /// </summary>
        /// <param name="SourceDate"></param>
        /// <param name="Format"></param>
        /// <returns></returns>
        public static string GetFormatedDate( string SourceDate, string Format )
        {
            return Convert.ToDateTime( SourceDate ).ToString( Format );
        }

        /// <summary>
        /// Convert the source date to formated type.
        /// </summary>
        /// <param name="SourceDate"></param>
        /// <param name="Format"></param>
        /// <returns></returns>
        public static string GetFormatedDate( DateTime SourceDate, string Format )
        {
            return SourceDate.ToString( Format );
        }
    }
}
