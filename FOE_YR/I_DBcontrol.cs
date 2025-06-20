using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FOE_YR
{
    interface I_DBcontrol
    {
    }

    public class FOE_DB
    {
        public DataTable get_DataTable(string database, string sSQLstr)
        {
            string connstr = $"uid = sa; pwd = dsc; database = {database}; server = dataserver";
            //string sSQLstr = $"SELECT distinct {distinct_col} FROM {FromDBtable}";

            using (SqlConnection connection = new SqlConnection(connstr)) // 第一個 using: 建立並管理資料庫連線   //結束時，SqlConnection 會自動關閉和釋放
            using (SqlCommand command = new SqlCommand(sSQLstr, connection))  // 第二個 using: 建立並管理 SQL 指令物件   //using 區塊結束時，SqlCommand 會被釋放資源
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable vDT = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(vDT);

                    return vDT;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }

        public DataTable get_DataTable(string db, SqlCommand cmd)
        {
            string connstr = $"uid = sa; pwd = dsc; database = {db}; server = dataserver";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                cmd.Connection = conn;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void getModelList(ComboBox cbo, string database, string tablename, string where_str, string DISTINCT_col)
        {
            //用法
            //string database = "FormericaOE";
            //string tablename = "IQC_forEEPROM";
            //string where_str = "[Identifier] = 'CMIS'";
            //string DISTINCT_col = "Model";
            //getModelList(cbo_model, database, tablename, where_str, DISTINCT_col);

            string sql = $"Select DISTINCT {DISTINCT_col} from {tablename} where {where_str}";

            try
            {
                cbo.Items.Clear();

                FOE_DB FOE_DB = new FOE_DB();
                DataTable dt = FOE_DB.get_DataTable(database, sql);

                foreach (DataRow row in dt.Rows)
                {
                    cbo.Items.Add(row[DISTINCT_col].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading module list: " + ex.Message);
            }
        }
    }
}
