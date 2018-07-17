﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NancyApp.Security
{
    public class Cryptography
    {
        private static byte[] bIV =
        { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18,
        0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };
        private const string cryptoKey =
            "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";

        public static string Encrypt(string text)
        {
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    byte[] bKey = Convert.FromBase64String(cryptoKey);
                    byte[] bText = new UTF8Encoding().GetBytes(text);

                    Rijndael rijndael = new RijndaelManaged();
                    rijndael.KeySize = 256;

                    MemoryStream mStream = new MemoryStream();
                    CryptoStream encryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateEncryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    encryptor.Write(bText, 0, bText.Length);
                    encryptor.FlushFinalBlock();
                    return Convert.ToBase64String(mStream.ToArray());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao criptografar", ex);
            }
        }

        public static string Decrypt(string text)
        {
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    byte[] bKey = Convert.FromBase64String(cryptoKey);
                    byte[] bText = Convert.FromBase64String(text);

                    Rijndael rijndael = new RijndaelManaged();

                    rijndael.KeySize = 256;

                    MemoryStream mStream = new MemoryStream();

                    CryptoStream decryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateDecryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    decryptor.Write(bText, 0, bText.Length);
                    decryptor.FlushFinalBlock();
                    UTF8Encoding utf8 = new UTF8Encoding();
                    return utf8.GetString(mStream.ToArray());
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao descriptografar", ex);
            }
        }
    }
}