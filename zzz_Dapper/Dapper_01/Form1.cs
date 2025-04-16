using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using Dapper;

namespace Dapper_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            string connStr = "uid=sa;pwd=dsc;database=FormericaOE;server=dataserver";

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

            string sql = @"INSERT INTO PAM4_FinalTest (Lot, SN, Channel, TestTime, DDMVolt, DDMTemp) 
                   VALUES (@Lot, @SN, @Channel, @TestTime, @DDMVolt, @DDMTemp)";

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                conn.Execute(sql, data);    //這是dapper功能
                MessageBox.Show("Insert 成功");
            }
        }

        public class Pam4FinalTestRecord//目前只示範 key塞入  忽略過多欄位
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
    }


}
