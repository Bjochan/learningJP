using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LearningJapanese.LogicClass
{
    class clsLogin
    {
        public string EncryptString(string Message)
        {
            string Passphrase = "maianh";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1: using MD5

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create new object TripleDESCryptoServiceProvider 
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setting Encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert string (Message) to  byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. String encoding
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }

            finally
            {
                // Delete all info related to Triple DES and HashProvider 
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. return string encoded  by  Base64
            return Convert.ToBase64String(Results);
        }

        public string DecryptString(string Message)
        {
            string Passphrase = "maianh";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. Using  MD5

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create new object TripleDESCryptoServiceProvider 
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setting Encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert string (Message) to  byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. String encoding
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Delete all info related to Triple DES and HashProvider 
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. return result by UTF8
            return UTF8.GetString(Results);
        }

    }
}
