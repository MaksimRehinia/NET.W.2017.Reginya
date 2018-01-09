﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Service for data encryption and decryption.
    /// </summary>
    public static class CryptoService
    {
        #region Public methods
                
        /// <summary>
        /// Encrypts string with specified key using Rijndael algorithm.
        /// </summary>
        /// <param name="encryptString">Data to encrypt.</param>
        /// <param name="key">Symmetrical key.</param>
        /// <returns>Encrypted string.</returns>
        public static string RijndaelEncrypt(string encryptString, string key)
        {
            VerifyIsValidString(encryptString, nameof(encryptString));
            VerifyIsValidString(key, nameof(key));
            var cipher = new RijndaelManaged
            {               
                Key = Encoding.UTF8.GetBytes(key),
                IV = Encoding.UTF8.GetBytes(key)
            };            
            var encryptor = cipher.CreateEncryptor();            
            byte[] textInBytes = Encoding.UTF8.GetBytes(encryptString);
            byte[] result = encryptor.TransformFinalBlock(textInBytes, 0, textInBytes.Length);
            return Convert.ToBase64String(result);
        }

        /// <summary>
        /// Decrypts string with specified key using Rijndael algorithm.
        /// </summary>
        /// <param name="decryptString">Data to decrypt.</param>
        /// <param name="key">Symmetrical key.</param>
        /// <returns>Decrypted string.</returns>
        public static string RijndaelDecrypt(string decryptString, string key)
        {
            VerifyIsValidString(decryptString, nameof(decryptString));
            VerifyIsValidString(key, nameof(key));
            var cipher = new RijndaelManaged
            {                
                Key = Encoding.UTF8.GetBytes(key),
                IV = Encoding.UTF8.GetBytes(key)
            };
            var decryptor = cipher.CreateDecryptor();            
            byte[] textInBytes = Convert.FromBase64String(decryptString);
            byte[] result = decryptor.TransformFinalBlock(textInBytes, 0, textInBytes.Length);
            return Encoding.UTF8.GetString(result);
        }

        #endregion

        #region Private methods

        private static void VerifyIsValidString(string str, string paramName)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException($"{paramName} can't be null or white space.", paramName);
            }
        }

        #endregion
    }
}
