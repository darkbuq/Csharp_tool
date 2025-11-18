using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FOE_YR;

namespace EEPROMworkflow_improvement_01
{
    public partial class Form1 : Form
    {
        Color _resetC = Color.Silver;
        Color _runC = Color.Yellow;
        Color _finishC = Color.Lime;

        Color _passC = Color.Lime;
        Color _failC = Color.Red;

        Color _comparePC = Color.Aquamarine;
        Color _compareTC = Color.Pink;
        Color _escape_compareC = Color.LightSkyBlue;

        UI_dgv UI_dgv = new UI_dgv();
        FOE_DB FOE_DB = new FOE_DB();


        #region -- dgv --

        private void Dgv_A0info_initialize(DataGridView dgv)
        {
            dgv.RowTemplate.Height = 20;


            //.Rows //.Columns
            dgv.Columns.Add("item", "item");
            dgv.Columns.Add("value", "value");

            dgv.Rows.Add("VN");
            dgv.Rows.Add("PN");
            dgv.Rows.Add("OUI");
            dgv.Rows.Add("SN");
            dgv.Rows.Add("DC");
            dgv.Rows.Add("VendorRev");
            dgv.Rows.Add("VRev_ASCII");


            dgv.RowHeadersWidth = 5;
            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgv.Columns[0].Width = 90;
            dgv.Columns[1].Width = 140;



            dgv.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
            //dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow;
            dgv.EnableHeadersVisualStyles = false;


            foreach (DataGridViewColumn column in dgv.Columns) //禁用排序
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        #endregion

        public Form1()
        {
            InitializeComponent();

            Dgv_A0info_initialize(dgv_SFF8472_info);
            Dgv_A0info_initialize(dgv_SFF8636_info);
            Dgv_A0info_initialize(dgv_CMIS_info);

            UI_dgv.Dgv_DDMI_initialize(dgv_SFF8472_DDMI, new int[] { 35, 50, 50, 50, 50 });
            UI_dgv.Dgv_DDMI_initialize(dgv_SFF8636_DDMI, new int[] { 35, 50, 50, 50, 50 });
            UI_dgv.Dgv_DDMI_initialize(dgv_CMIS_DDMI, new int[] { 35, 50, 50, 50, 50 });

        }


    }
}
