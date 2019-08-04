using System;
using System.Security.Cryptography;
using System.Text;
using Loja.Common.Resources;

namespace Loja.Common.Validation
{
    public class PasswordAssertionConcern
    {
        public static void AssertIsValid(string password)
        {
            AssertionConcern.AssertArgumentNotNull(password, Errors.InvalidUserPassword);
        }

        //public static string Encrypt(string password)
        //{
        //    password += "|2d331cca-f6c0-40c0-bb43-6e32989c2881";
        //    MD5 md5 = MD5.Create();
        //    byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(password));
        //    var sbString = new StringBuilder();
        //    foreach (byte t in data)
        //        sbString.Append(t.ToString("x2"));
        //    return sbString.ToString();
        //}

        public static string Encrypt(string password)
        {
            try
            {
                var objcriptografaSenha = new TripleDESCryptoServiceProvider();
                var objcriptoMd5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = "1,2";

                byteHash = objcriptoMd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objcriptoMd5 = null;
                objcriptografaSenha.Key = byteHash;
                objcriptografaSenha.Mode = CipherMode.ECB;

                byteBuff = ASCIIEncoding.ASCII.GetBytes(password);
                return Convert.ToBase64String(objcriptografaSenha.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                return string.Format("Digite os valores Corretamente : {0}", ex.Message);
            }
        }


        public static string Decrypt(string password)
        {
            try
            {
                var objdescriptografaSenha = new TripleDESCryptoServiceProvider();
                var objcriptoMd5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = "1,2";

                byteHash = objcriptoMd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objcriptoMd5 = null;
                objdescriptografaSenha.Key = byteHash;
                objdescriptografaSenha.Mode = CipherMode.ECB;

                byteBuff = Convert.FromBase64String(password);
                string strDecrypted = ASCIIEncoding.ASCII.GetString(objdescriptografaSenha.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                objdescriptografaSenha = null;

                return strDecrypted;
            }
            catch (Exception ex)
            {
                return string.Format("Digite os valores Corretamente : {0}", ex.Message);
            }
        }

    }
}
