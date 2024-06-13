using System;
using System.Security.Cryptography;
using System.Text;

namespace bookHubServer.Tool
{
	public class pwdEncryptTool
	{
        public static string Encrypt(string plainText)
        {
            string encryptedText;

            string SecretKey = "hdubookhub123456";

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(SecretKey);
                aesAlg.IV = new byte[16];

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encryptedText = Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
            return encryptedText;
        }



    }
}

