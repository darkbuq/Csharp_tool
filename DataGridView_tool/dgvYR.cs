using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGridView_tool
{
    public class dgvYR
    {
        public void dgv_initialize(DataGridView dgv)
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

        
        public void dgv_add_col(System.Windows.Forms.DataGridView dgv, string[] colname, string[] coltxt, string[] coltype, int[] colW)
        {
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
            }
        }
    }
}
