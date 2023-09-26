using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


namespace byYR_FOE_SQL
{
    public class ATS_FinalTestData
    {
        string connstr = "uid = sa; pwd = dsc; database = FormericaOE; server = dataserver";
        string colStr = "Lot_No,SN,Part_No,TestCond_Type,TestCond_Other,TestCond,Spec_Version,Test_Number,Test_Voltage,Test_Temp,Sys_Power,Sys_Icc,Sys_Other,Channel,Total_Pass,Ber_Pass,DDM_Pass,Tx_DCA_Pass,Rx_DCA_Pass,Other_Pass,Ber_Sensitivity,Ber_Other,DDM_Temp,DDM_Voltage,DDM_TX,DDM_RX,DDM_losa,DDM_losd,DDM_losh,DDM_RX_LOW,DDM_RX_HIGH,DDM_Other,Tx_ER,Tx_Margin,Tx_AvgPower,Tx_OMA,Tx_JRMS,Tx_JPP,Tx_Cross,Tx_DCA_Other,Rx_Eheig,Rx_JRMS,Rx_JPP,Rx_Ewid,Rx_Margin,Rx_Cross,Rx_amp,Rx_DCA_Other,Rx_OMA,Tx_WL,OSA_Other,Other_Comments,Operator,Test_time,Station,Program_Ver";
        
        Dictionary<string, string> Dict_col = new Dictionary<string, string>();
        DateTime gg = System.DateTime.Now;

        
        //可以使用 Parameter Object 來組織這些參數
        public class ATS_FinalTestData_Parameters
        {
            public string Lot_No { get; set; } = "5xxx-yyyyMMddxxx";
            public string SN { get; set; } = "nick666";
            public string Part_No { get; set; } = "";
            public string TestCond_Type { get; set; } = "";
            public string TestCond_Other { get; set; } = "";
            public string TestCond { get; set; } = "";
            public string Spec_Version { get; set; } = "";
            public float Test_Number { get; set; } = 1;
            public string Test_Voltage { get; set; } = "";
            public string Test_Temp { get; set; } = "";
            public string Sys_Power { get; set; } = "";
            public string Sys_Icc { get; set; } = "";
            public string Sys_Other { get; set; } = "";
            public float Channel { get; set; } = 1;
            public string Total_Pass { get; set; } = "";
            public string Ber_Pass { get; set; } = "";
            public string DDM_Pass { get; set; } = "";
            public string Tx_DCA_Pass { get; set; } = "";
            public string Rx_DCA_Pass { get; set; } = "";
            public string Other_Pass { get; set; } = "";
            public string Ber_Sensitivity { get; set; } = "";
            public string Ber_Other { get; set; } = "";
            public string DDM_Temp { get; set; } = "";
            public string DDM_Voltage { get; set; } = "";
            public string DDM_TX { get; set; } = "";
            public string DDM_RX { get; set; } = "";
            public string DDM_losa { get; set; } = "";
            public string DDM_losd { get; set; } = "";
            public string DDM_losh { get; set; } = "";
            public string DDM_RX_LOW { get; set; } = "";
            public string DDM_RX_HIGH { get; set; } = "";
            public string DDM_Other { get; set; } = "";
            public string Tx_ER { get; set; } = "";
            public string Tx_Margin { get; set; } = "";
            public string Tx_AvgPower { get; set; } = "";
            public string Tx_OMA { get; set; } = "";
            public string Tx_JRMS { get; set; } = "";
            public string Tx_JPP { get; set; } = "";
            public string Tx_Cross { get; set; } = "";
            public string Tx_DCA_Other { get; set; } = "";
            public string Rx_Eheig { get; set; } = "";
            public string Rx_JRMS { get; set; } = "";
            public string Rx_JPP { get; set; } = "";
            public string Rx_Ewid { get; set; } = "";
            public string Rx_Margin { get; set; } = "";
            public string Rx_Cross { get; set; } = "";
            public string Rx_amp { get; set; } = "";
            public string Rx_DCA_Other { get; set; } = "";
            public string Rx_OMA { get; set; } = "";
            public string Tx_WL { get; set; } = "";
            public string OSA_Other { get; set; } = "";
            public string Other_Comments { get; set; } = "";
            public string Operator { get; set; } = "1090704";
            public DateTime Test_time { get; set; } = System.DateTime.Now;
            public string Station { get; set; } = "";
            public string Program_Ver { get; set; } = "";


        }


        public void ATS_FinalTestData_Insert(ATS_FinalTestData_Parameters Parameter_Object)
        {
            string insertQuery = "INSERT into [dbo].[ATS_FinalTestData] ";
            insertQuery += $"({colStr}) VALUES (";
            for (int i = 0; i < colStr.Split(',').Length; i++)
            {
                if (i< (colStr.Split(',').Length-1))
                {
                    insertQuery += $"@{colStr.Split(',')[i]},";
                }
                else
                {
                    insertQuery += $"@{colStr.Split(',')[i]})";
                }
            }


            using (SqlConnection connection = new SqlConnection(connstr))
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.Add("@Lot_No", SqlDbType.NVarChar, 255).Value = Parameter_Object.Lot_No;
                command.Parameters.Add("@SN", SqlDbType.NVarChar, 255).Value = Parameter_Object.SN;
                command.Parameters.Add("@Part_No", SqlDbType.NVarChar, 255).Value = Parameter_Object.Part_No;
                command.Parameters.Add("@TestCond_Type", SqlDbType.NVarChar, 255).Value = Parameter_Object.TestCond_Type;
                command.Parameters.Add("@TestCond_Other", SqlDbType.NVarChar, 255).Value = Parameter_Object.TestCond_Other;
                command.Parameters.Add("@TestCond", SqlDbType.NVarChar, 255).Value = Parameter_Object.TestCond;
                command.Parameters.Add("@Spec_Version", SqlDbType.NVarChar, 255).Value = Parameter_Object.Spec_Version;
                command.Parameters.Add("@Test_Number", SqlDbType.Float).Value = Parameter_Object.Test_Number;
                command.Parameters.Add("@Test_Voltage", SqlDbType.NVarChar, 255).Value = Parameter_Object.Test_Voltage;
                command.Parameters.Add("@Test_Temp", SqlDbType.NVarChar, 255).Value = Parameter_Object.Test_Temp;
                command.Parameters.Add("@Sys_Power", SqlDbType.NVarChar, 255).Value = Parameter_Object.Sys_Power;
                command.Parameters.Add("@Sys_Icc", SqlDbType.NVarChar, 255).Value = Parameter_Object.Sys_Icc;
                command.Parameters.Add("@Sys_Other", SqlDbType.NVarChar, 255).Value = Parameter_Object.Sys_Other;
                command.Parameters.Add("@Channel", SqlDbType.Float).Value = Parameter_Object.Channel;
                command.Parameters.Add("@Total_Pass", SqlDbType.NVarChar, 255).Value = Parameter_Object.Total_Pass;
                command.Parameters.Add("@Ber_Pass", SqlDbType.NVarChar, 255).Value = Parameter_Object.Ber_Pass;
                command.Parameters.Add("@DDM_Pass", SqlDbType.NVarChar, 255).Value = Parameter_Object.DDM_Pass;
                command.Parameters.Add("@Tx_DCA_Pass", SqlDbType.NVarChar, 255).Value = Parameter_Object.Tx_DCA_Pass;
                command.Parameters.Add("@Rx_DCA_Pass", SqlDbType.NVarChar, 255).Value = Parameter_Object.Rx_DCA_Pass;
                command.Parameters.Add("@Other_Pass", SqlDbType.NVarChar, 255).Value = Parameter_Object.Other_Pass;
                command.Parameters.Add("@Ber_Sensitivity", SqlDbType.NVarChar, 255).Value = Parameter_Object.Ber_Sensitivity;
                command.Parameters.Add("@Ber_Other", SqlDbType.NVarChar, 255).Value = Parameter_Object.Ber_Other;
                command.Parameters.Add("@DDM_Temp", SqlDbType.NVarChar, 255).Value = Parameter_Object.DDM_Temp;
                command.Parameters.Add("@DDM_Voltage", SqlDbType.NVarChar, 255).Value = Parameter_Object.DDM_Voltage;
                command.Parameters.Add("@DDM_TX", SqlDbType.NVarChar, 255).Value = Parameter_Object.DDM_TX;
                command.Parameters.Add("@DDM_RX", SqlDbType.NVarChar, 255).Value = Parameter_Object.DDM_RX;
                command.Parameters.Add("@DDM_losa", SqlDbType.NVarChar, 255).Value = Parameter_Object.DDM_losa;
                command.Parameters.Add("@DDM_losd", SqlDbType.NVarChar, 255).Value = Parameter_Object.DDM_losd;
                command.Parameters.Add("@DDM_losh", SqlDbType.NVarChar, 255).Value = Parameter_Object.DDM_losh;
                command.Parameters.Add("@DDM_RX_LOW", SqlDbType.NVarChar, 255).Value = Parameter_Object.DDM_RX_LOW;
                command.Parameters.Add("@DDM_RX_HIGH", SqlDbType.NVarChar, 255).Value = Parameter_Object.DDM_RX_HIGH;
                command.Parameters.Add("@DDM_Other", SqlDbType.NVarChar, 255).Value = Parameter_Object.DDM_Other;
                command.Parameters.Add("@Tx_ER", SqlDbType.NVarChar, 255).Value = Parameter_Object.Tx_ER;
                command.Parameters.Add("@Tx_Margin", SqlDbType.NVarChar, 255).Value = Parameter_Object.Tx_Margin;
                command.Parameters.Add("@Tx_AvgPower", SqlDbType.NVarChar, 255).Value = Parameter_Object.Tx_AvgPower;
                command.Parameters.Add("@Tx_OMA", SqlDbType.NVarChar, 255).Value = Parameter_Object.Tx_OMA;
                command.Parameters.Add("@Tx_JRMS", SqlDbType.NVarChar, 255).Value = Parameter_Object.Tx_JRMS;
                command.Parameters.Add("@Tx_JPP", SqlDbType.NVarChar, 255).Value = Parameter_Object.Tx_JPP;
                command.Parameters.Add("@Tx_Cross", SqlDbType.NVarChar, 255).Value = Parameter_Object.Tx_Cross;
                command.Parameters.Add("@Tx_DCA_Other", SqlDbType.NVarChar, 255).Value = Parameter_Object.Tx_DCA_Other;
                command.Parameters.Add("@Rx_Eheig", SqlDbType.NVarChar, 255).Value = Parameter_Object.Rx_Eheig;
                command.Parameters.Add("@Rx_JRMS", SqlDbType.NVarChar, 255).Value = Parameter_Object.Rx_JRMS;
                command.Parameters.Add("@Rx_JPP", SqlDbType.NVarChar, 255).Value = Parameter_Object.Rx_JPP;
                command.Parameters.Add("@Rx_Ewid", SqlDbType.NVarChar, 255).Value = Parameter_Object.Rx_Ewid;
                command.Parameters.Add("@Rx_Margin", SqlDbType.NVarChar, 255).Value = Parameter_Object.Rx_Margin;
                command.Parameters.Add("@Rx_Cross", SqlDbType.NVarChar, 255).Value = Parameter_Object.Rx_Cross;
                command.Parameters.Add("@Rx_amp", SqlDbType.NVarChar, 255).Value = Parameter_Object.Rx_amp;
                command.Parameters.Add("@Rx_DCA_Other", SqlDbType.NVarChar, 255).Value = Parameter_Object.Rx_DCA_Other;
                command.Parameters.Add("@Rx_OMA", SqlDbType.NVarChar, 255).Value = Parameter_Object.Rx_OMA;
                command.Parameters.Add("@Tx_WL", SqlDbType.NVarChar, 255).Value = Parameter_Object.Tx_WL;
                command.Parameters.Add("@OSA_Other", SqlDbType.NVarChar, 255).Value = Parameter_Object.OSA_Other;
                command.Parameters.Add("@Other_Comments", SqlDbType.NVarChar, 255).Value = Parameter_Object.Other_Comments;
                command.Parameters.Add("@Operator", SqlDbType.NVarChar, 255).Value = Parameter_Object.Operator;
                command.Parameters.Add("@Test_time", SqlDbType.DateTime).Value = Parameter_Object.Test_time;
                command.Parameters.Add("@Station", SqlDbType.NVarChar, 255).Value = Parameter_Object.Station;
                command.Parameters.Add("@Program_Ver", SqlDbType.NVarChar, 255).Value = Parameter_Object.Program_Ver;


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


        #region - 以前的寫法 -
        public void ATS_FinalTestData_Insert()
        {
            string insertQuery = "INSERT into [dbo].[ATS_FinalTestData] ";
            insertQuery += "(" + colStr + ") VALUES (";

            for (int i = 0; i < colStr.Split(',').Length; i++)
            {
                insertQuery += "@" + colStr.Split(',')[i];
            }
            insertQuery += ")";


            using (SqlConnection connection = new SqlConnection(connstr))
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                foreach (KeyValuePair<string, string> item in Dict_col)
                {
                    if (item.Key == "Test_Number" | item.Key == "Channel")
                    {
                        command.Parameters.AddWithValue($"@{item.Key}", (float)1);
                    }
                    else
                    {
                        command.Parameters.AddWithValue($"@{item.Key}", item.Value);
                    }
                }

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

        public void ATS_FinalTestData_Insert(string Lot_No, string SN, string Part_No, int Channel, string Test_time)
        {
            string insertQuery = "INSERT into [dbo].[ATS_FinalTestData] ";
            insertQuery += "(Lot_No, SN, Part_No, Channel, Test_time) VALUES ";
            insertQuery += "(@Lot_No, @SN, @Part_No, @Channel, @Test_time)";

            using (SqlConnection connection = new SqlConnection(connstr))
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Lot_No", Lot_No);
                command.Parameters.AddWithValue("@SN", SN);
                command.Parameters.AddWithValue("@Part_No", Part_No);
                command.Parameters.AddWithValue("@Channel", Channel);
                command.Parameters.AddWithValue("@Test_time", Test_time);


                try
                {
                    connection.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
        }

        public void ATS_FinalTestData_Insert(string Lot_No, string SN, string Part_No, string TestCond_Type, string TestCond, string Test_Voltage, string Test_Temp, string Sys_Power, string Sys_Icc, int Channel, string Ber_Other, string DDM_Temp, string DDM_Voltage, string DDM_TX, string DDM_RX, string DDM_Other, string Rx_DCA_Other, string Operator, string Test_time, string Station, string Program_Ver)
        {
            string insertQuery = "INSERT into [dbo].[ATS_FinalTestData] ";
            insertQuery += "(Lot_No, SN, Part_No, TestCond_Type, TestCond, Test_Voltage, Test_Temp, Sys_Power, Sys_Icc, Channel, Ber_Other, DDM_Temp, DDM_Voltage, DDM_TX, DDM_RX, DDM_Other, Rx_DCA_Other, Operator, Test_time, Station, Program_Ver) VALUES ";
            insertQuery += "(@Lot_No, @SN, @Part_No, @TestCond_Type, @TestCond, @Test_Voltage, @Test_Temp, @Sys_Power, @Sys_Icc, @Channel, @Ber_Other, @DDM_Temp, @DDM_Voltage, @DDM_TX, @DDM_RX, @DDM_Other, @Rx_DCA_Other, @Operator, @Test_time, @Station, @Program_Ver)";

            using (SqlConnection connection = new SqlConnection(connstr))
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Lot_No", Lot_No);
                command.Parameters.AddWithValue("@SN", SN);
                command.Parameters.AddWithValue("@Part_No", Part_No);
                command.Parameters.AddWithValue("@TestCond_Type", TestCond_Type);
                command.Parameters.AddWithValue("@TestCond", TestCond);
                command.Parameters.AddWithValue("@Test_Voltage", Test_Voltage);
                command.Parameters.AddWithValue("@Test_Temp", Test_Temp);
                command.Parameters.AddWithValue("@Sys_Power", Sys_Power);
                command.Parameters.AddWithValue("@Sys_Icc", Sys_Icc);
                command.Parameters.AddWithValue("@Channel", Channel);
                command.Parameters.AddWithValue("@Ber_Other", Ber_Other);
                command.Parameters.AddWithValue("@DDM_Temp", DDM_Temp);
                command.Parameters.AddWithValue("@DDM_Voltage", DDM_Voltage);
                command.Parameters.AddWithValue("@DDM_TX", DDM_TX);
                command.Parameters.AddWithValue("@DDM_RX", DDM_RX);
                //command.Parameters.AddWithValue("@DDM_losa", DDM_losa);
                //command.Parameters.AddWithValue("@DDM_losd", DDM_losd);
                //command.Parameters.AddWithValue("@DDM_losh", DDM_losh);
                //command.Parameters.AddWithValue("@DDM_RX_LOW", DDM_RX_LOW);
                //command.Parameters.AddWithValue("@DDM_RX_HIGH", DDM_RX_HIGH);
                command.Parameters.AddWithValue("@DDM_Other", DDM_Other);
                command.Parameters.AddWithValue("@Rx_DCA_Other", Rx_DCA_Other);
                command.Parameters.AddWithValue("@Operator", Operator);
                command.Parameters.AddWithValue("@Test_time", Test_time);
                command.Parameters.AddWithValue("@Station", Station);
                command.Parameters.AddWithValue("@Program_Ver", Program_Ver);


                try
                {
                    connection.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
        }

        #endregion


    }
}
