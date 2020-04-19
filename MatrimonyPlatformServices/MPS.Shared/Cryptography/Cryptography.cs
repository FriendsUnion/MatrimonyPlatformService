using MPS.Shared.CustomAttributes;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace MPS.Shared.Cryptography
{
    public static class Cryptography
    {
        public static byte[] IV = new byte[] { 0x01, 0x07, 0x02, 0x09, 0x03, 0x04, 0x08, 0x08, 0x07, 0x03, 0x02, 0x02, 0x02, 0x01, 0x07, 0x08 };

        public static string Encrypt(string raw, string key)
        {
            if (string.IsNullOrWhiteSpace(raw) || string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException($"{nameof(raw)}/{nameof(key)} cannot be null or empty for encrypting the data");

            return Encrypt(raw, Encoding.UTF8.GetBytes(key));
        }

        public static T Encrypt<T>(T t, string key)
        {
            if (t == null || string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException($"{nameof(t)}/{nameof(key)} cannot be null or empty for encrypting the data");

            var properties = t.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    if (attr is EncryptAttribute)
                    {
                        var encryptAttribute = attr as EncryptAttribute;
                        if (encryptAttribute.NeedsEncryption)
                        {
                            var plainText = prop.GetValue(t, null)?.ToString();
                            var encryptedData = Encrypt(plainText, Encoding.UTF8.GetBytes(key));
                            prop.SetValue(t, encryptedData);
                        }
                    }
                }
            }

            return t;
        }

        public static string Decrypt(string base64Text, string key)
        {
            if (base64Text == null || string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException($"{nameof(base64Text)}/{nameof(key)} cannot be null or empty for decrypting the data");

            return Decrypt(Convert.FromBase64String(base64Text), Encoding.UTF8.GetBytes(key));
        }

        public static T Decrypt<T>(T t, string key)
        {
            if (t == null || string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException($"{nameof(t)}/{nameof(key)} cannot be null or empty for decrypting the data");

            var properties = t.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    if (attr is EncryptAttribute)
                    {
                        var encryptAttribute = attr as EncryptAttribute;
                        if (encryptAttribute.NeedsEncryption)
                        {
                            var encryptedData = Convert.FromBase64String(prop.GetValue(t, null)?.ToString());
                            if (encryptedData.GetType().Name.Equals("Byte[]", StringComparison.OrdinalIgnoreCase))
                            {
                                var plainText = Decrypt((byte[])encryptedData, Encoding.UTF8.GetBytes(key));
                                prop.SetValue(t, plainText);
                            }
                        }
                    }
                }
            }

            return t;
        }

        #region Private methods

        private static string Encrypt(string plainText, byte[] Key)
        {
            byte[] encrypted;
            using (AesManaged aes = new AesManaged())
            {
                aes.Padding = PaddingMode.Zeros;
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        private static string Decrypt(byte[] cipherText, byte[] Key)
        {
            string plaintext = null;
            using (AesManaged aes = new AesManaged())
            {
                aes.Padding = PaddingMode.Zeros;
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(cipherText, 0, cipherText.Length);
                        plaintext = Encoding.UTF8.GetString(ms.ToArray());
                        plaintext = plaintext.TrimEnd('\0');
                    }
                }
            }
            return plaintext;
        }

        #endregion
    }
}
