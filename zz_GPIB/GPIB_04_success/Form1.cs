﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GPIB_04_success
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
        Ivi.Visa.Interop.FormattedIO488 ioobj = new Ivi.Visa.Interop.FormattedIO488();
        private void button1_Click(object sender, EventArgs e)
        {
            object[] idnItems;

            ioobj.IO = (Ivi.Visa.Interop.IMessage)rm.Open("GPIB0::10::INSTR",Ivi.Visa.Interop.AccessMode.NO_LOCK, 0, "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ioobj.WriteString("*IDN?", true);

            object[] idnItems = (object[])ioobj.ReadList(Ivi.Visa.Interop.IEEEASCIIType.ASCIIType_Any, ",");

            foreach (object idnItem in idnItems)
            {
                textBox1.Text += idnItem+"\r\n";
            }
        }

        private void btn_sand_Click(object sender, EventArgs e)
        {
            ioobj.WriteString(textBox2.Text, true);

            object[] idnItems = (object[])ioobj.ReadList(Ivi.Visa.Interop.IEEEASCIIType.ASCIIType_Any, ",");

            foreach (object idnItem in idnItems)
            {
                textBox1.Text += idnItem + "\r\n";
            }
        }
    }
}