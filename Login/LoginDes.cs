using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
namespace SysCom
{
    ///<summary>
    /// 功能类：LoginDes - 用于加密和解密路径 
    /// 作者：Sunwell
    /// 最近一次修改时间：2009-7-9
    ///</summary>
    public class LoginDes
    {
       /// <summary>
       /// 密钥
       /// </summary>
       private static Byte[] Iv64 = { 11, 22, 33, 44, 55, 66, 77, 85 };
       private static Byte[] byKey64 = { 10, 20, 30, 40, 50, 60, 70, 80 };

       //路径加密
        static public string Encrypt(string strText)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey64, Iv64), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

       //路径解密
       static public string Decrypt(string strText)
       {
           Byte[] inputByteArray = new byte[strText.Length];
           try
           {
               DESCryptoServiceProvider des = new DESCryptoServiceProvider();
               inputByteArray = Convert.FromBase64String(strText);
               MemoryStream ms = new MemoryStream();
               CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey64, Iv64), CryptoStreamMode.Write);
               cs.Write(inputByteArray, 0, inputByteArray.Length);
               cs.FlushFinalBlock();
               System.Text.Encoding encoding = System.Text.Encoding.UTF8;
               return encoding.GetString(ms.ToArray());
           }
           catch (Exception ex)
           {
               return ex.Message;
           }
       }
    }
}
