using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FOE_YR
{
    interface I_UI
    {
    }

    public class UI_dgv
    {
        public void Dgv_EEPROM_initialize(DataGridView dgv, string title, int row_start, int row_end)
        {
            dgv.RowTemplate.Height = 20;

            dgv.Columns.Add("_", title);
            for (int i = 0; i < 16; i++)
            {
                dgv.Columns.Add(i.ToString("X1"), "0" + i.ToString("X1"));
            }
            dgv.RowHeadersWidth = 5;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            for (int i = row_start; i < row_end; i++)
            {
                dgv.Rows.Add(i.ToString("X1") + "0");
            }

            //dgv.Rows[0].Cells[0].Style.BackColor = Color.Aqua; //cell 換色

            dgv.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;
            dgv.EnableHeadersVisualStyles = false;

            dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;//cell 置中


            foreach (DataGridViewColumn column in dgv.Columns) //禁用排序
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//文字置中
        }

        public void Dgv_DDMI_initialize(DataGridView dgv)
        {
            dgv.RowTemplate.Height = 20;


            //.Rows //.Columns
            dgv.Columns.Add("_", "#");

            dgv.Columns.Add("A_H", "A_H");
            dgv.Columns.Add("A_L", "A_L");
            dgv.Columns.Add("W_H", "W_H");
            dgv.Columns.Add("W_L", "W_L");

            dgv.Rows.Add("T");
            dgv.Rows.Add("V");
            dgv.Rows.Add("Bs");
            dgv.Rows.Add("Tx");
            dgv.Rows.Add("Rx");


            dgv.RowHeadersWidth = 5;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgv.Columns[0].Width = 20;
            dgv.Columns[1].Width = 40;
            dgv.Columns[2].Width = 40;
            dgv.Columns[3].Width = 40;
            dgv.Columns[4].Width = 40;


            dgv.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;
            dgv.EnableHeadersVisualStyles = false;


            foreach (DataGridViewColumn column in dgv.Columns) //禁用排序
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public DataTable TransposeDataTable(DataTable originalTable)//轉置
        {
            DataTable transposedTable = new DataTable();

            // 添加第一列，用於存放原始表的列名稱
            transposedTable.Columns.Add("Field");

            // 添加其他列，列數等於原始表的行數
            for (int i = 0; i < originalTable.Rows.Count; i++)
            {
                transposedTable.Columns.Add($"Row {i + 1}");
            }

            // 將原始表的每個列轉為行
            foreach (DataColumn column in originalTable.Columns)
            {
                DataRow newRow = transposedTable.NewRow();
                newRow[0] = column.ColumnName;

                for (int i = 0; i < originalTable.Rows.Count; i++)
                {
                    newRow[i + 1] = originalTable.Rows[i][column];
                }

                transposedTable.Rows.Add(newRow);
            }

            return transposedTable;
        }

        public void Reset_dgvColor(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.Empty; //換色
                }
            }
        }

        public void Reset_dgvFont(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[0].DefaultCellStyle.Font = dgv.Font;
            }
        }

        public void Reset_dgvValue(DataGridView dgv)//第一行  是當作row name 不能清掉
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 1; j < dgv.ColumnCount; j++)
                {
                    dgv.Rows[i].Cells[j].Value = string.Empty;
                }
            }
        }

        public void Reset_dgvValue(DataGridView dgv, int[] Uncleared_col)//不清掉 部分col
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    if (Uncleared_col.Contains(j))
                    {

                    }
                    else
                    {
                        dgv.Rows[i].Cells[j].Value = string.Empty;
                    }

                }
            }
        }

        public void Reset_dgvValue(DataGridView dgv, int[] cleared_col, int[] cleared_row)
        {
            for (int row = 0; row < dgv.RowCount; row++)
            {
                for (int col = 0; col < dgv.ColumnCount; col++)
                {
                    if (cleared_col.Contains(col) & cleared_row.Contains(row))
                    {
                        dgv.Rows[row].Cells[col].Value = string.Empty;
                    }
                }
            }
        }

        public void Set_EEPROM_Value_to_Dgv(DataGridView dgv, byte[] bytearr, int startAdr)
        {
            for (int i = 0; i < bytearr.Length; i++)
            {
                dgv[((startAdr + i) % 16) + 1, (i + startAdr) / 16].Value = bytearr[i].ToString("X2");
            }
        }

        public void SetUI_DgvForeColorColor(DataGridView dgv, int start_add, int length, Color color)
        {
            Reset_dgvColor(dgv);
            for (int i = 0; i < length; i++)
            {
                dgv[((i + start_add) % 16) + 1, (i + start_add) / 16].Style.BackColor = color; //換色
            }
        }


        /// <summary>
        /// dgv add col 支援 txt chk btn
        /// </summary>
        public void Add_dgv_col(System.Windows.Forms.DataGridView dgv, string[] colname, string[] coltxt, string[] coltype, int[] colW)
        {
            //string[] colname = "name,Item,H_2,H_1,L_2,L_1,page,address,value".Split(',');
            //string[] coltxt = "name,Item,H_2,H_1,L_2,L_1,page,address,value".Split(',');
            //string[] coltype = "txt,txt,chk,chk,chk,chk,txt,txt,txt".Split(',');
            //int[] colW = { 60, 80, 35, 35, 35, 35, 35, 55, 45 };

            for (int i = 0; i < colname.Length; i++)
            {
                if (coltype[i] == "txt")
                {
                    DataGridViewColumn col = new DataGridViewTextBoxColumn();
                    col.DataPropertyName = colname[i];
                    col.HeaderText = coltxt[i];
                    col.Name = colname[i];
                    col.Width = colW[i];

                    dgv.Columns.Add(col);


                }
                else if (coltype[i] == "chk")
                {
                    DataGridViewColumn col = new DataGridViewCheckBoxColumn();
                    col.DataPropertyName = colname[i];
                    col.HeaderText = coltxt[i];
                    col.Name = colname[i];
                    col.Width = colW[i];

                    dgv.Columns.Add(col);
                }
                else if (coltype[i] == "btn")
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.DataPropertyName = colname[i];
                    col.HeaderText = coltxt[i];
                    col.UseColumnTextForButtonValue = true;
                    col.Text = coltxt[i];
                    col.Name = colname[i];
                    col.Width = colW[i];

                    dgv.Columns.Add(col);
                }
                else if (coltype[i] == "cbo")
                {
                    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                    col.DataPropertyName = colname[i];
                    col.HeaderText = coltxt[i];
                    col.Name = colname[i];
                    col.Width = colW[i];

                    dgv.Columns.Add(col);
                }
            }
        }

        /// <summary>
        /// col黃色, 禁用排序, 禁止自動建立資料行
        /// </summary>
        public void Initialize_dgv(DataGridView dgv)
        {

            dgv.AllowUserToAddRows = false;

            dgv.RowTemplate.Height = 25;
            dgv.RowHeadersWidth = 10;

            //dgv.Columns[1].DefaultCellStyle.BackColor = Color.LightYellow;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;
            dgv.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn column in dgv.Columns) //禁用排序
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgv.AutoGenerateColumns = false;
        }

        public int Find_Dgv_rowIndex_byValue(DataGridView dgv, int colindex, string cellvalue)
        {
            int RowIndex = -1;

            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].Cells[colindex].Value.ToString() == cellvalue)
                {
                    RowIndex = i;
                    break;
                }
            }

            return RowIndex;
        }

        public int Find_Dgv_colIndex_byValue(DataGridView dgv, int rowindex, string cellvalue)
        {
            int ColIndex = -1;
            for (int i = 1; i < dgv.ColumnCount; i++)//第一 col 不用找
            {
                if (dgv.Rows[rowindex].Cells[i].Value.ToString() == cellvalue)
                {
                    ColIndex = i;
                    break;
                }
            }

            return ColIndex;
        }
    }

    public class UI_groupBox
    {
        public void ClearUI_groupBox_text(GroupBox grp)
        {
            foreach (Control ctrl in grp.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty; // 清空 TextBox 的文字
                    ((TextBox)ctrl).BackColor = Color.Empty;
                }
                else if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).Items.Clear();
                    ((ComboBox)ctrl).Text = string.Empty;
                }
            }
        }
    }

    public class UI_cbo
    {
        public void Populate_cbo_WithDistinctValues_forFOE(ComboBox cbo, string DB, string FromDBtable, string distinct_col)
        {
            cbo.Items.Clear();

            string connstr = $"uid = sa; pwd = dsc; database = {DB}; server = dataserver";
            string sSQLstr = $"SELECT distinct {distinct_col} FROM {FromDBtable}";

            using (SqlConnection connection = new SqlConnection(connstr)) // 第一個 using: 建立並管理資料庫連線   //結束時，SqlConnection 會自動關閉和釋放
            using (SqlCommand command = new SqlCommand(sSQLstr, connection))  // 第二個 using: 建立並管理 SQL 指令物件   //using 區塊結束時，SqlCommand 會被釋放資源
            {
                //SqlCommand command = new SqlCommand(sSQLstr, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable vDT = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(vDT);

                    foreach (DataRow row in vDT.Rows)
                    {
                        cbo.Items.Add(row[0]);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }
    }
}
