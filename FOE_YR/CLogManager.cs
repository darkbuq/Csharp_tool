using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FOE_YR
{
     public class CLogManager
    {
        private string logFileName;

        /// <summary>
        /// 初始化 LogManager 並設置日志文件名。
        /// </summary>
        /// <param name="formName">Form 的名稱</param>
        public CLogManager(string formName)
        {
            // 根據 Form 名稱生成日志文件名
            logFileName = $"{formName}_log.txt";
        }

        /// <summary>
        /// 保存日志到指定文件。如果文件存在則追加日志，如果文件不存在則創建新文件。
        /// </summary>
        /// <param name="logMessage">要寫入的日志信息</param>
        public void SaveLog(string logMessage)
        {
            try
            {
                // 獲取當前時間並格式化
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // 格式化日志內容
                string logEntry = $"[{timestamp}] {logMessage}{Environment.NewLine}";

                // 檢查文件是否存在並進行追加或創建
                File.AppendAllText(logFileName, logEntry);
            }
            catch (Exception ex)
            {
                // 異常處理
                MessageBox.Show($"無法保存日志: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
