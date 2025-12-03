using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Windows.Forms;

namespace FOE_YR
{
    interface I_Encryption
    {

    }

    public class ReleaseSigner
    {
        // 將 key 補齊到 32 byte (AES-256) 這種需要32長度的key
        private static byte[] GetAesKey(string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            if (keyBytes.Length < 32)
            {
                Array.Resize(ref keyBytes, 32);
            }
            return keyBytes;
        }

        public string Encrypt(string plainText, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = GetAesKey(key);
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor();
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                return Convert.ToBase64String(cipherBytes);
            }
        }

        public string Encrypt()
        {
            return Encrypt($"{1090704}-{System.DateTime.Now.ToString("yyyyMMddHHmm")}", "22623536");
        }

        public string Decrypt(string cipherText, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = GetAesKey(key);
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor();
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

                return Encoding.UTF8.GetString(plainBytes);
            }
        }

        public string Decrypt(string cipherText)
        {
            return Decrypt(cipherText, "22623536");
        }

        public void SetupContextMenu(Form targetForm) //提供右鍵可以複製介面標題到剪貼薄
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem copyItem = new ToolStripMenuItem("複製標題");
            copyItem.Click += (s, e) => Clipboard.SetText(targetForm.Text);
            menu.Items.Add(copyItem);
            targetForm.ContextMenuStrip = menu;
        }
    }
}
