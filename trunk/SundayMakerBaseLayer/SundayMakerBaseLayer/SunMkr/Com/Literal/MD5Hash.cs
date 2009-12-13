using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace SunMkr.Com.Literal
{
    /// <summary>
    /// MD5 Hash
    /// </summary>
    public static class MD5Hash
    {
        static MD5Hash( )
        {
        }
        
        /// <summary>
        /// Hash an input string and return the hash as
        /// a 32 character hexadecimal string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMD5Hash( string input )
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create( );

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash( Encoding.Default.GetBytes( input ) );

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder( );

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for ( int i = 0; i < data.Length; i++ )
            {
                sBuilder.Append( data [i].ToString( "x2" ) );
            }

            // Return the hexadecimal string.
            return sBuilder.ToString( );
        }

        /// <summary>
        /// Verify a hash against a string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool VerifyMd5Hash( string input, string hash )
        {
            // Hash the input.
            string hashOfInput = GetMD5Hash( input );

            // Create a StringComparer an comare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if ( 0 == comparer.Compare( hashOfInput, hash ) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
