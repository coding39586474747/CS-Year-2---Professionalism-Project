using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class Encryption
{
    private readonly byte[] key;
    private readonly byte[] iv;

    public Encryption(string keyString, string ivString)
    {
        if (string.IsNullOrEmpty(keyString))
            throw new ArgumentNullException(nameof(keyString));
        if (string.IsNullOrEmpty(ivString))
            throw new ArgumentNullException(nameof(ivString));

        key = Encoding.UTF8.GetBytes(keyString);
        iv = Encoding.UTF8.GetBytes(ivString);
    }

    public string Encrypt(string input)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputBytes, 0, inputBytes.Length);
                    cs.FlushFinalBlock();
                }

                byte[] encryptedBytes = ms.ToArray();
                return Convert.ToBase64String(encryptedBytes);
            }
        }
    }

    public string Decrypt(string encryptedInput)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedInput);

        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;

            using (MemoryStream ms = new MemoryStream(encryptedBytes))
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
