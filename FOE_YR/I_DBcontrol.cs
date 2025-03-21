using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

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
    }
}
