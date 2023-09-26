using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace byYR_FOE_SQL
{
    public class TRx_A2Table
    {
        string connstr = "uid = sa; pwd = dsc; database = FormericaOE; server = dataserver";
        public void TRx_A2Table_Insert(string TRx_Code)
        {
            string LotNo = "5xxx-yyyyMMddxxx";
            string TRx_SN = "nick666";
            string Model_No = "QQ";
            //string TRx_Code = "FFF";
            string Spec_Ver = "A";
            string Pro_Ver = "0.27.0.27";
            string OP = "1090704";
            string PF = "PASS";
            string Test_Date = System.DateTime.Now.ToString("yyyy-MM-dd");
            string Test_Time = System.DateTime.Now.ToString("HHmmss");
            string Note = "";
            string Save_counter = "";
            int SerialNo = 10;

            TRx_A2Table_Insert(LotNo, TRx_SN, Model_No, TRx_Code, Spec_Ver, Pro_Ver, OP, PF, Note, Save_counter);
        }

        public void TRx_A2Table_Insert(string LotNo, string TRx_SN, string Model_No, string TRx_Code, string Spec_Ver, string Pro_Ver, string OP, string PF, string Note, string Save_counter)
        {
            string Test_Date = System.DateTime.Now.ToString("yyyy-MM-dd");
            string Test_Time = System.DateTime.Now.ToString("HHmmss");

            string insertQuery = "INSERT into [dbo].[TRx_A2Table] ";
            insertQuery = insertQuery + "(LotNo,TRx_SN,Model_No,TRx_Code,Spec_Ver,Pro_Ver,OP,PF,Test_Date,Test_Time,Note,Save_counter) VALUES ";
            insertQuery = insertQuery + "(@LotNo,@TRx_SN,@Model_No,@TRx_Code,@Spec_Ver,@Pro_Ver,@OP,@PF,@Test_Date,@Test_Time,@Note,@Save_counter)";

            using (SqlConnection connection = new SqlConnection(connstr))
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                //command.Parameters.Add("@name", SqlDbType.NVarChar, 30).Value = "nick666";
                command.Parameters.AddWithValue("@LotNo", LotNo);
                command.Parameters.AddWithValue("@TRx_SN", TRx_SN);
                command.Parameters.AddWithValue("@Model_No", Model_No);
                command.Parameters.AddWithValue("@TRx_Code", TRx_Code);
                command.Parameters.AddWithValue("@Spec_Ver", Spec_Ver);
                command.Parameters.AddWithValue("@Pro_Ver", Pro_Ver);
                command.Parameters.AddWithValue("@OP", OP);
                command.Parameters.AddWithValue("@PF", PF);
                command.Parameters.AddWithValue("@Test_Date", Test_Date);
                command.Parameters.AddWithValue("@Test_Time", Test_Time);
                command.Parameters.AddWithValue("@Note", Note);
                command.Parameters.AddWithValue("@Save_counter", Save_counter);
                //command.Parameters.AddWithValue("@SerialNo", SerialNo); //SQL系統會自動給值

                try
                {
                    connection.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                    // error here
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        //System.Data.SqlClient.SqlException: 當 IDENTITY_INSERT 設為 OFF 時，無法將外顯值插入資料表'xxx'的識別欄位中
        //在MSSQL資料庫中，有設定   識別規格   為    "是"
        //設定了之後，資料庫會自動將Insert的資料編號
        //因此，在寫入資料的時候，就不需要再給該欄位   "值"

        //public void TRx_A2Table_Update(string LotNo, string TRx_SN, string Model_No, string TRx_Code, string Spec_Ver, string Pro_Ver, string OP, string PF, string Note, string Save_counter)
        //{

        //    string Test_Date = System.DateTime.Now.ToString("yyyy-MM-dd");
        //    string Test_Time = System.DateTime.Now.ToString("HHmmss");

        //    string Query = "UPDATE [dbo].[TRx_A2Table] set ";
        //    Query = Query + "LotNo=@LotNo, ";
        //    Query = Query + "TRx_SN=@TRx_SN, ";
        //    Query = Query + "Model_No=@Model_No, ";
        //    Query = Query + "TRx_Code=@TRx_Code, ";
        //    Query = Query + "Spec_Ver=@Spec_Ver, ";
        //    Query = Query + "Pro_Ver=@Pro_Ver, ";
        //    Query = Query + "OP=@OP, ";
        //    Query = Query + "PF=@PF, ";

        //    Query = Query + "Test_Date=@Test_Date, ";
        //    Query = Query + "Test_Time=@Test_Time, ";

        //    Query = Query + "Note=@Note, ";
        //    Query = Query + "Save_counter=@Save_counter, ";

        //    Query = Query + " WHERE TRx_SN=@TRx_SN and Model_No=@Model_No";

        //    using (SqlConnection connection = new SqlConnection(connstr))
        //    using (SqlCommand command = new SqlCommand(Query, connection))
        //    {
        //        command.Parameters.AddWithValue("@LotNo", LotNo);
        //        command.Parameters.AddWithValue("@TRx_SN", TRx_SN);
        //        command.Parameters.AddWithValue("@Model_No", Model_No);
        //        command.Parameters.AddWithValue("@TRx_Code", TRx_Code);
        //        command.Parameters.AddWithValue("@Spec_Ver", Spec_Ver);
        //        command.Parameters.AddWithValue("@Pro_Ver", Pro_Ver);
        //        command.Parameters.AddWithValue("@OP", OP);
        //        command.Parameters.AddWithValue("@PF", PF);

        //        command.Parameters.AddWithValue("@Test_Date", Test_Date);
        //        command.Parameters.AddWithValue("@Test_Time", Test_Time);

        //        command.Parameters.AddWithValue("@Note", Note);
        //        command.Parameters.AddWithValue("@Save_counter", Save_counter);
        //    }
        //}

    }
}
