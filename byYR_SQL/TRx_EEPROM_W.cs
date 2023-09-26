using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace byYR_FOE_SQL
{
    public class TRx_EEPROM_W
    {
        string connstr = "uid = sa; pwd = dsc; database = FormericaOE; server = dataserver";

        public List<string> select_return_list()
        {
            string selectstr = "select top 1 * from TRx_EEPROM_W";
            return select_return_list(connstr, selectstr);
        }

        public List<string> select_return_list(string connstr, string selectstr)
        {

            using (SqlConnection openCon = new SqlConnection(connstr))
            using (SqlCommand cmd = new SqlCommand(selectstr, openCon))
            {
                openCon.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();//建立DataSet例項  
                da.Fill(dt);//使用DataAdapter的Fill方法(填充)，呼叫SELECT命令 

                List<string> mylist = new List<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    mylist.Add(dt.Rows[i][0].ToString());
                }

                return mylist;
            }
        }

        public DataTable select_return_dt()
        {
            
            string selectstr = "select top 10 * from TRx_EEPROM_W";
            return select_return_dt(connstr, selectstr);
        }

        public DataTable select_return_dt(string connstr, string selectstr)
        {
            using (SqlConnection openCon = new SqlConnection(connstr))
            using (SqlCommand cmd = new SqlCommand(selectstr, openCon))
            {
                openCon.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();//建立DataSet例項  
                da.Fill(dt);//使用DataAdapter的Fill方法(填充)，呼叫SELECT命令                 

                return dt;
            }
        }

        public Tuple<bool, DataTable> TRx_EEPROM_W_Qexist()
        {
            string Model_No = "TSD-S1KH1-A1G";
            string TRx_SN = "0000FR1923";

            return TRx_EEPROM_W_Qexist(Model_No, TRx_SN);
        }

        public Tuple<bool, DataTable> TRx_EEPROM_W_Qexist(string Model_No, string TRx_SN)
        {
            Model_No = "'" + Model_No + "'";
            TRx_SN = "'" + TRx_SN + "'";

            
            string selectstr = $"select * from TRx_EEPROM_W where TRx_SN = {TRx_SN} and Model_No = {Model_No}";

            using (SqlConnection openCon = new SqlConnection(connstr))
            using (SqlCommand cmd = new SqlCommand(selectstr, openCon))
            {
                openCon.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();//建立DataSet例項  
                da.Fill(dt);//使用DataAdapter的Fill方法(填充)，呼叫SELECT命令                 

                if (dt == null || dt.Rows.Count == 0)
                {
                    return Tuple.Create(false, dt);
                }
                else
                {
                    return Tuple.Create(true, dt);
                }
            }


        }

        public void TRx_EEPROM_W_Insert()
        {
            string LotNo = "5120-yyyymmddxxx";
            string TRx_SN = "nick666";
            string Model_No = "123";
            string TRx_Code = "FFFFFF";
            string Spec_Ver = "GG";
            string Pro_Ver = "V.2.0.2";
            string OP = "1090704";

            TRx_EEPROM_W_Insert(LotNo, TRx_SN, Model_No, TRx_Code, Spec_Ver, Pro_Ver, OP);
        }

        public void TRx_EEPROM_W_Insert(string LotNo, string TRx_SN, string Model_No, string TRx_Code, string Spec_Ver, string Pro_Ver, string OP)
        {
            string Test_Date = System.DateTime.Now.ToString("yyyy-MM-dd");
            string Test_Time = System.DateTime.Now.ToString("HHmmss");

            string insertQuery = "INSERT into [dbo].[TRx_EEPROM_W] ";
            insertQuery = insertQuery + "(LotNo, TRx_SN, Model_No,TRx_Code,Spec_Ver,Pro_Ver,OP,PF,Test_Date,Test_Time) VALUES ";
            insertQuery = insertQuery + "(@LotNo, @TRx_SN, @Model_No, @TRx_Code,@Spec_Ver,@Pro_Ver,@OP,@PF,@Test_Date,@Test_Time)";

            using (SqlConnection connection = new SqlConnection(connstr))
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@LotNo", LotNo);
                command.Parameters.AddWithValue("@TRx_SN", TRx_SN);
                command.Parameters.AddWithValue("@Model_No", Model_No);
                command.Parameters.AddWithValue("@TRx_Code", TRx_Code);
                command.Parameters.AddWithValue("@Spec_Ver", Spec_Ver);
                command.Parameters.AddWithValue("@Pro_Ver", Pro_Ver);
                command.Parameters.AddWithValue("@OP", OP);
                command.Parameters.AddWithValue("@PF", "PASS");
                command.Parameters.AddWithValue("@Test_Date", Test_Date);
                command.Parameters.AddWithValue("@Test_Time", Test_Time);

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



        public void TRx_EEPROM_W_Update(string TRx_Code)
        {
            string LotNo = "5120-yyyymmddxxx";
            string TRx_SN = "nick666";
            string Model_No = "123";
            //string TRx_Code = "FFFFFF";
            string Spec_Ver = "GG";
            string Pro_Ver = "V.2.0.2";
            string OP = "1090704";

            TRx_EEPROM_W_Update(LotNo, TRx_SN, Model_No, TRx_Code, Spec_Ver, Pro_Ver, OP);
        }
        public void TRx_EEPROM_W_Update(string LotNo, string TRx_SN, string Model_No, string TRx_Code, string Spec_Ver, string Pro_Ver, string OP)
        {

            string PF = "PASS";
            string Test_Date = System.DateTime.Now.ToString("yyyy-MM-dd");
            string Test_Time = System.DateTime.Now.ToString("HHmmss");

            string Query = "UPDATE [dbo].[TRx_EEPROM_W] set ";
            Query = Query + "LotNo=@LotNo, ";
            Query = Query + "TRx_Code=@TRx_Code, ";
            Query = Query + "Spec_Ver=@Spec_Ver, ";
            Query = Query + "Pro_Ver=@Pro_Ver, ";
            Query = Query + "OP=@OP, ";
            Query = Query + "PF=@PF, ";
            Query = Query + "Test_Date=@Test_Date, ";
            Query = Query + "Test_Time=@Test_Time ";

            Query = Query + " WHERE TRx_SN=@TRx_SN and Model_No=@Model_No";

            using (SqlConnection connection = new SqlConnection(connstr))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@LotNo", LotNo);
                command.Parameters.AddWithValue("@TRx_Code", TRx_Code);
                command.Parameters.AddWithValue("@Spec_Ver", Spec_Ver);
                command.Parameters.AddWithValue("@Pro_Ver", Pro_Ver);
                command.Parameters.AddWithValue("@OP", OP);
                command.Parameters.AddWithValue("@PF", PF);
                command.Parameters.AddWithValue("@Test_Date", Test_Date);
                command.Parameters.AddWithValue("@Test_Time", Test_Time);

                command.Parameters.AddWithValue("@TRx_SN", TRx_SN);
                command.Parameters.AddWithValue("@Model_No", Model_No);

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


    }
}
