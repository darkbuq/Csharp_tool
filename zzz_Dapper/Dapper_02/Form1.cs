using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; //這個命名空間裡，有許多用來操作設定檔（如 app.config 或 web.config）的類別
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Dapper;

namespace Dapper_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private class Pam4FinalTestRecord//目前只示範 key塞入  忽略過多欄位
        {
            //以下為key
            public string Lot { get; set; }
            public string SN { get; set; }
            public int Channel { get; set; }
            public DateTime TestTime { get; set; }

            //以下為測試 數值填入
            public float? DDMVolt { get; set; }//float? 就是沒賦值時  會自動null
            public float? DDMTemp { get; set; }
        }

        public static string GenerateInsertSQL<T>(string tableName)
        {
            var props = typeof(T).GetProperties();  // 取得類別 T 的所有 public 屬性

            var columns = string.Join(", ", props.Select(p => p.Name));
            // ↑ 把所有屬性名稱，用逗號+空格 ", " 串接起來
            //   例如屬性有 Lot, SN, Channel，結果就是 "Lot, SN, Channel"

            var values = string.Join(", ", props.Select(p => "@" + p.Name));
            // ↑ 每個屬性前加上 @ 符號，變成 SQL 用的參數名稱
            //   結果會是 "@Lot, @SN, @Channel"

            return $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
            // ↑ 組成完整的 INSERT 指令
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            //string connStr = "uid=sa;pwd=dsc;database=FormericaOE;server=dataserver";
            string connStr = ConfigurationManager.ConnectionStrings["FormericaDb"].ConnectionString;

            var data = new Pam4FinalTestRecord
            {
                //以下為key
                Lot = txt_lot.Text,
                SN = txt_sn.Text,
                Channel = int.Parse(txt_ch.Text),
                TestTime = DateTime.Now,

                //以下為測試 數值填入
                DDMVolt = (float)3.6,
                //DDMTemp = 25
            };

            string sql = GenerateInsertSQL<Pam4FinalTestRecord>("PAM4_FinalTest");

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql, data);    //這是dapper功能
                MessageBox.Show("Insert 成功");
            }
        }

        private class DatabaseHelper
        {
            public static string GetConnectionString()
            {
                return ConfigurationManager.ConnectionStrings["FormericaDb"].ConnectionString;
            }
        }
    }
}
