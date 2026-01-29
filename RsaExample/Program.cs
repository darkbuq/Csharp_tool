using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO; // 為了使用 File 類別
using System.Security.Cryptography; // 為了使用 RSACryptoServiceProvider

namespace RsaExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                // true 代表包含私鑰，false 代表僅包含公鑰
                string privateKey = rsa.ToXmlString(true);
                string publicKey = rsa.ToXmlString(false);

                // 寫入檔案
                File.WriteAllText("private.key", privateKey);
                File.WriteAllText("public.key", publicKey);

                Console.WriteLine("金鑰檔案已成功產生！");
                Console.ReadLine();
            }

        }
    }
}
