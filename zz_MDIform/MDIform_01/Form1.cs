using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDIform_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool isFind = false;
            textBox1.Text = "";
            foreach (Form form in this.MdiChildren)
            {
                textBox1.Text += form.Name+"\r\n";
                if (form.Name == "Form11")
                {
                    isFind = true;
                    form.MdiParent = this;
                    form.Focus();
                }
            }
            if (isFind == false)
            {
                Form11 childForm = new Form11();
                childForm.MdiParent = this;
                //childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();
                //childForm.WindowState = FormWindowState.Maximized;
            }

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            bool isFind = false;
            textBox1.Text = "";
            foreach (Form form in this.MdiChildren)
            {
                textBox1.Text += form.Name + "\r\n";
                if (form.Name == "Form33")
                {
                    isFind = true;
                    form.MdiParent = this;
                    form.Focus();
                }
            }
            if (isFind == false)
            {
                Form33 childForm = new Form33();
                childForm.MdiParent = this;
                //childForm.WindowState = FormWindowState.Maximized;
                childForm.Show();
                //childForm.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
