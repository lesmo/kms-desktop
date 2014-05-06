using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace KMS.Desktop.Utils {
    static class StringEncrypt {
        public static string Encrypt(string input, string password) {
            // TODO: Rehabilitar cifrado de entrada. Se deshabilitó durante Alpha-Testing because reasons.

            var stringBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(stringBytes);
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
