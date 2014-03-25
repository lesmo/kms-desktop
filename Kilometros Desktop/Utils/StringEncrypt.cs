using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace KMS.Desktop.Utils {
    static class StringEncrypt {
        public static string Encrypt(string input, string password) {
            byte[] passwordBytes
                = Convert.FromBase64String(password);
            DESCryptoServiceProvider cryptoProvider
                    = new DESCryptoServiceProvider();
            MemoryStream memoryStream
                = new MemoryStream();
            CryptoStream cryptoStream
                = new CryptoStream(
                    memoryStream,
                    cryptoProvider.CreateEncryptor(
                        passwordBytes,
                        passwordBytes
                    ), 
                    CryptoStreamMode.Write
                );
            StreamWriter writer
                = new StreamWriter(cryptoStream);

            writer.Write(input);
            writer.Flush();

            cryptoStream.FlushFinalBlock();
            writer.Flush();

            return Convert.ToBase64String(
                memoryStream.GetBuffer(),
                0,
                (int)memoryStream.Length
            );
        }

        public static string Decrypt(string input, string password) {
            byte[] passwordBytes
                = Convert.FromBase64String(password);
            DESCryptoServiceProvider cryptoProvider
                = new DESCryptoServiceProvider();
            MemoryStream memoryStream
                = new MemoryStream(
                    Convert.FromBase64String(input)
                );
            CryptoStream cryptoStream
                = new CryptoStream(
                    memoryStream,
                    cryptoProvider.CreateDecryptor(
                        passwordBytes,
                        passwordBytes
                    ),
                    CryptoStreamMode.Read
                );
            StreamReader reader
                = new StreamReader(cryptoStream);

            return reader.ReadToEnd();
        }
    }
}
