using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using FOE_YR;

namespace FOE_SW_Platform
{
    public partial class Form_FOE_SW_Platform : Form
    {
        Color _resetC = Color.Silver;
        Color _runC = Color.Gold;
        Color _finishC = Color.Lime;
        Color _passC = Color.Lime;
        Color _failC = Color.Red;

        public Form_FOE_SW_Platform()
        {
            InitializeComponent();

            //#region -- 加密 --
            //ReleaseSigner signer = new ReleaseSigner();

            //// 產生今天的加密特徵碼
            //string signature = signer.Encrypt();

            //this.Text = $"{this.Text}  |  {signature}";

            //signer.SetupContextMenu(this);
            //#endregion
        }

        private void btn_pwd_Click(object sender, EventArgs e)
        {
            if (txt_pwd.Text == $"SW{DateTime.Now.ToString("yyyyMMdd")}")
            {
                cbo_Program_type.Enabled = true;
                btn_release.Enabled = true;
                btn_path.Enabled = true;

                btn_release.Enabled = true;
            }
        }

        private void btn_path_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "請選擇上架目錄";
                fbd.ShowNewFolderButton = true;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txt_path.Text = fbd.SelectedPath;
                }
            }
        }



        private void btn_release_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txt_path.Text))
            {
                MessageBox.Show("目錄不存在");
                return;
            }

            if (cbo_Program_type.SelectedIndex == -1)
            {
                MessageBox.Show("choose Program_type");
                return;
            }


            #region -- 定義檔案順序 這會影響特徵碼 --
            var files = Directory.GetFiles(txt_path.Text, "*.*", SearchOption.AllDirectories)
                             .Select(f => GetRelativePath(txt_path.Text, f)) // 相對路徑
                             .OrderBy(f => f, StringComparer.OrdinalIgnoreCase)
                             .ToList();


            // 先用來確認順序是不是你要的
            StringBuilder sb = new StringBuilder();
            foreach (var file in files)
            {
                sb.AppendLine(file);
            }

            //MessageBox.Show(sb.ToString(), "檔案順序（相對路徑）"); 
            #endregion


            //需要對整個目錄  算特徵碼
            string dirHash = ComputeDirectoryHash(txt_path.Text, files);
            txt_Program_Fingerprint.Text = dirHash;



            #region -- 把指定目錄 完整複制 到網路磁碟某位置  且目錄名稱追加yyyyMMdd_lot --
            //\\egoserver\共同區\共用-技術中心\FOE_Program\EXE\已驗證程式區\SFF_Utility\Bin20260122\SFF_Utility.exe
            string networkRoot = @"\\egoserver\共同區\共用-技術中心\FOE_Program\EXE\已驗證程式區";
            string Program_type = cbo_Program_type.Text;
            networkRoot = Path.Combine(networkRoot, Program_type);

            string sourceDir = txt_path.Text;
            string sourceName = new DirectoryInfo(sourceDir).Name;
            string lot = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string targetDirName = sourceName + "_" + lot;
            string targetFullPath = Path.Combine(networkRoot, targetDirName);

            if (Directory.Exists(targetFullPath))
            {
                MessageBox.Show("目標目錄已存在，請確認是否重複上架");
                return;
            }

            CopyDirectory(sourceDir, targetFullPath);

            //after relocation 特徵碼  加  比對
            string dirHash2 = ComputeDirectoryHash(txt_path.Text, files);
            txt_Program_Fingerprint2.Text = dirHash2;

            if (dirHash == dirHash2)
            {
                lbl_Compare_Fingerprint.BackColor = _passC;
            }
            else
            {
                lbl_Compare_Fingerprint.BackColor = _failC;
            }


            MessageBox.Show("上架完成！\r\n" + targetFullPath);
            #endregion



            #region -- 在目標目錄產生 release.txt --
            //在目標目錄產生 release.txt 
            WriteReleaseInfo(targetFullPath, cbo_Program_type.Text, dirHash);
            #endregion


        }

        private string GetRelativePath(string rootPath, string fullPath)//取得相對路徑
        {
            if (string.IsNullOrEmpty(rootPath))
                throw new ArgumentNullException("rootPath");

            if (string.IsNullOrEmpty(fullPath))
                throw new ArgumentNullException("fullPath");

            if (!rootPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                rootPath += Path.DirectorySeparatorChar;

            Uri rootUri = new Uri(rootPath);
            Uri fileUri = new Uri(fullPath);

            return Uri.UnescapeDataString(
                rootUri.MakeRelativeUri(fileUri)
                       .ToString()
                       .Replace('/', Path.DirectorySeparatorChar)
            );
        }

        private byte[] ComputeFileHash(string filePath)//單個檔案 SHA256
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            using (var stream = File.OpenRead(filePath))
            {
                return sha256.ComputeHash(stream);
            }
        }

        private string ComputeDirectoryHash(string rootPath, List<string> orderedFiles)//整個目錄特徵碼
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                foreach (var relativeFile in orderedFiles)
                {
                    string fullPath = Path.Combine(rootPath, relativeFile);

                    // 1️⃣ 將檔案相對路徑也算進 Hash
                    byte[] pathBytes = System.Text.Encoding.UTF8.GetBytes(relativeFile);
                    sha256.TransformBlock(pathBytes, 0, pathBytes.Length, null, 0);

                    // 2️⃣ 將檔案內容算進 Hash
                    byte[] contentBytes = File.ReadAllBytes(fullPath);
                    sha256.TransformBlock(contentBytes, 0, contentBytes.Length, null, 0);
                }

                // 結束 Hash
                sha256.TransformFinalBlock(new byte[0], 0, 0);

                return BitConverter.ToString(sha256.Hash).Replace("-", ""); // 十六進位字串
            }
        }

        private void CopyDirectory(string sourceDir, string targetDir)
        {
            // 建立目標目錄
            if (!Directory.Exists(targetDir))
                Directory.CreateDirectory(targetDir);

            // 複製檔案
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                string targetFilePath = Path.Combine(targetDir, fileName);
                File.Copy(file, targetFilePath, true); // true = 覆蓋
            }

            // 遞迴複製子目錄
            foreach (string directory in Directory.GetDirectories(sourceDir))
            {
                string dirName = Path.GetFileName(directory);
                string targetSubDir = Path.Combine(targetDir, dirName);
                CopyDirectory(directory, targetSubDir);
            }
        }

        private void WriteReleaseInfo(string targetDir, string programType,string dirHash)
        {
            string releaseFile = Path.Combine(targetDir, "release.txt");

            var sb = new StringBuilder();
            sb.AppendLine("ProgramType=" + programType);
            sb.AppendLine("ReleaseDate=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine("DirHash=" + dirHash);

            File.WriteAllText(releaseFile, sb.ToString(), Encoding.UTF8);
        }
    }
}
