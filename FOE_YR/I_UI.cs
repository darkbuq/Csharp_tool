using System;
using System.Collections.Generic;
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

        public void Reset_dgvValue(DataGridView dgv, int[] Uncleared_col)//第一行  是當作row name 不能清掉
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
}
