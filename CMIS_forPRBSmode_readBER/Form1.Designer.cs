
namespace CMIS_forPRBSmode_readBER
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_result = new System.Windows.Forms.TextBox();
            this.btn_read = new System.Windows.Forms.Button();
            this.btn_write = new System.Windows.Forms.Button();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_EEPROM = new System.Windows.Forms.DataGridView();
            this.btn_read_256byte = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.txt_baudRate = new System.Windows.Forms.TextBox();
            this.btn_new_SerialPort = new System.Windows.Forms.Button();
            this.dgv_BER_result = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Host = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_Media = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_script = new System.Windows.Forms.TextBox();
            this.btn_script_set = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_Host_Media = new System.Windows.Forms.ComboBox();
            this.btn_read_once = new System.Windows.Forms.Button();
            this.btn_I2C_cmd = new System.Windows.Forms.Button();
            this.txt_cmd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_RealTime_ON = new System.Windows.Forms.Button();
            this.btn_RealTime_OFF = new System.Windows.Forms.Button();
            this.cbo_Host_pattern = new System.Windows.Forms.ComboBox();
            this.cbo_Media_pattern = new System.Windows.Forms.ComboBox();
            this.btn_Host_pattern = new System.Windows.Forms.Button();
            this.btn_Media_pattern = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbo_Host_Media_2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_RealTime_OFF2 = new System.Windows.Forms.Button();
            this.btn_RealTime_ON2 = new System.Windows.Forms.Button();
            this.dgv_DDMI2 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv_DDMI = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EEPROM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BER_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Host)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Media)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DDMI2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DDMI)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_result
            // 
            this.txt_result.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_result.Location = new System.Drawing.Point(526, 463);
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(573, 27);
            this.txt_result.TabIndex = 0;
            // 
            // btn_read
            // 
            this.btn_read.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_read.ForeColor = System.Drawing.Color.Blue;
            this.btn_read.Location = new System.Drawing.Point(899, 396);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(63, 27);
            this.btn_read.TabIndex = 2;
            this.btn_read.Text = "read";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // btn_write
            // 
            this.btn_write.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_write.ForeColor = System.Drawing.Color.Blue;
            this.btn_write.Location = new System.Drawing.Point(822, 397);
            this.btn_write.Name = "btn_write";
            this.btn_write.Size = new System.Drawing.Size(71, 27);
            this.btn_write.TabIndex = 2;
            this.btn_write.Text = "write";
            this.btn_write.UseVisualStyleBackColor = true;
            this.btn_write.Click += new System.EventHandler(this.btn_write_Click);
            // 
            // txt_value
            // 
            this.txt_value.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_value.ForeColor = System.Drawing.Color.Blue;
            this.txt_value.Location = new System.Drawing.Point(684, 397);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(132, 27);
            this.txt_value.TabIndex = 3;
            this.txt_value.Text = "778899";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "BER";
            // 
            // dgv_EEPROM
            // 
            this.dgv_EEPROM.AllowUserToAddRows = false;
            this.dgv_EEPROM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EEPROM.Location = new System.Drawing.Point(525, 48);
            this.dgv_EEPROM.Name = "dgv_EEPROM";
            this.dgv_EEPROM.ReadOnly = true;
            this.dgv_EEPROM.RowHeadersVisible = false;
            this.dgv_EEPROM.RowHeadersWidth = 51;
            this.dgv_EEPROM.Size = new System.Drawing.Size(573, 343);
            this.dgv_EEPROM.TabIndex = 4;
            // 
            // btn_read_256byte
            // 
            this.btn_read_256byte.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_read_256byte.ForeColor = System.Drawing.Color.Blue;
            this.btn_read_256byte.Location = new System.Drawing.Point(1011, 397);
            this.btn_read_256byte.Name = "btn_read_256byte";
            this.btn_read_256byte.Size = new System.Drawing.Size(87, 27);
            this.btn_read_256byte.TabIndex = 2;
            this.btn_read_256byte.Text = "read all";
            this.btn_read_256byte.UseVisualStyleBackColor = true;
            this.btn_read_256byte.Click += new System.EventHandler(this.btn_read_256byte_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(525, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "address";
            // 
            // txt_address
            // 
            this.txt_address.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_address.ForeColor = System.Drawing.Color.Blue;
            this.txt_address.Location = new System.Drawing.Point(591, 397);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(39, 27);
            this.txt_address.TabIndex = 3;
            this.txt_address.Text = "30";
            // 
            // txt_port
            // 
            this.txt_port.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_port.Location = new System.Drawing.Point(652, 15);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(54, 27);
            this.txt_port.TabIndex = 3;
            this.txt_port.Text = "COM3";
            // 
            // txt_baudRate
            // 
            this.txt_baudRate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_baudRate.Location = new System.Drawing.Point(712, 15);
            this.txt_baudRate.Name = "txt_baudRate";
            this.txt_baudRate.Size = new System.Drawing.Size(65, 27);
            this.txt_baudRate.TabIndex = 3;
            this.txt_baudRate.Text = "115200";
            // 
            // btn_new_SerialPort
            // 
            this.btn_new_SerialPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_SerialPort.Location = new System.Drawing.Point(525, 15);
            this.btn_new_SerialPort.Name = "btn_new_SerialPort";
            this.btn_new_SerialPort.Size = new System.Drawing.Size(121, 27);
            this.btn_new_SerialPort.TabIndex = 2;
            this.btn_new_SerialPort.Text = "Dongle connect";
            this.btn_new_SerialPort.UseVisualStyleBackColor = true;
            this.btn_new_SerialPort.Click += new System.EventHandler(this.btn_new_SerialPort_Click);
            // 
            // dgv_BER_result
            // 
            this.dgv_BER_result.AllowUserToAddRows = false;
            this.dgv_BER_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BER_result.Location = new System.Drawing.Point(14, 420);
            this.dgv_BER_result.Name = "dgv_BER_result";
            this.dgv_BER_result.ReadOnly = true;
            this.dgv_BER_result.RowHeadersVisible = false;
            this.dgv_BER_result.RowHeadersWidth = 51;
            this.dgv_BER_result.Size = new System.Drawing.Size(505, 220);
            this.dgv_BER_result.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(636, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "value";
            // 
            // dgv_Host
            // 
            this.dgv_Host.AllowUserToAddRows = false;
            this.dgv_Host.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Host.Location = new System.Drawing.Point(14, 48);
            this.dgv_Host.Name = "dgv_Host";
            this.dgv_Host.ReadOnly = true;
            this.dgv_Host.RowHeadersVisible = false;
            this.dgv_Host.RowHeadersWidth = 51;
            this.dgv_Host.Size = new System.Drawing.Size(505, 147);
            this.dgv_Host.TabIndex = 4;
            this.dgv_Host.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Host_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "CMIS PRBS mode open SOP (Host)";
            // 
            // dgv_Media
            // 
            this.dgv_Media.AllowUserToAddRows = false;
            this.dgv_Media.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Media.Location = new System.Drawing.Point(14, 234);
            this.dgv_Media.Name = "dgv_Media";
            this.dgv_Media.ReadOnly = true;
            this.dgv_Media.RowHeadersVisible = false;
            this.dgv_Media.RowHeadersWidth = 51;
            this.dgv_Media.Size = new System.Drawing.Size(505, 147);
            this.dgv_Media.TabIndex = 4;
            this.dgv_Media.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Media_CellClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(525, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "script";
            // 
            // txt_script
            // 
            this.txt_script.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_script.ForeColor = System.Drawing.Color.Blue;
            this.txt_script.Location = new System.Drawing.Point(576, 430);
            this.txt_script.Name = "txt_script";
            this.txt_script.Size = new System.Drawing.Size(454, 27);
            this.txt_script.TabIndex = 3;
            this.txt_script.Text = "ssA07F13wwssA098FFwwssA0A8FFwwssA0B118wwssA07F14wwssA08001";
            // 
            // btn_script_set
            // 
            this.btn_script_set.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_script_set.ForeColor = System.Drawing.Color.Blue;
            this.btn_script_set.Location = new System.Drawing.Point(1035, 430);
            this.btn_script_set.Name = "btn_script_set";
            this.btn_script_set.Size = new System.Drawing.Size(63, 27);
            this.btn_script_set.TabIndex = 2;
            this.btn_script_set.Text = "set";
            this.btn_script_set.UseVisualStyleBackColor = true;
            this.btn_script_set.Click += new System.EventHandler(this.btn_script_set_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "CMIS PRBS mode open SOP (Media)";
            // 
            // cbo_Host_Media
            // 
            this.cbo_Host_Media.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Host_Media.FormattingEnabled = true;
            this.cbo_Host_Media.Items.AddRange(new object[] {
            "Host",
            "Media"});
            this.cbo_Host_Media.Location = new System.Drawing.Point(55, 387);
            this.cbo_Host_Media.Name = "cbo_Host_Media";
            this.cbo_Host_Media.Size = new System.Drawing.Size(94, 27);
            this.cbo_Host_Media.TabIndex = 5;
            this.cbo_Host_Media.SelectedIndexChanged += new System.EventHandler(this.cbo_Host_Media_SelectedIndexChanged);
            // 
            // btn_read_once
            // 
            this.btn_read_once.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_read_once.Location = new System.Drawing.Point(155, 387);
            this.btn_read_once.Name = "btn_read_once";
            this.btn_read_once.Size = new System.Drawing.Size(90, 27);
            this.btn_read_once.TabIndex = 2;
            this.btn_read_once.Text = "Read once";
            this.btn_read_once.UseVisualStyleBackColor = true;
            this.btn_read_once.Click += new System.EventHandler(this.btn_read_once_Click);
            // 
            // btn_I2C_cmd
            // 
            this.btn_I2C_cmd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_I2C_cmd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_I2C_cmd.Location = new System.Drawing.Point(1007, 14);
            this.btn_I2C_cmd.Name = "btn_I2C_cmd";
            this.btn_I2C_cmd.Size = new System.Drawing.Size(90, 27);
            this.btn_I2C_cmd.TabIndex = 2;
            this.btn_I2C_cmd.Text = "I2C Query";
            this.btn_I2C_cmd.UseVisualStyleBackColor = true;
            this.btn_I2C_cmd.Click += new System.EventHandler(this.btn_I2C_cmd_Click);
            // 
            // txt_cmd
            // 
            this.txt_cmd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cmd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txt_cmd.Location = new System.Drawing.Point(916, 14);
            this.txt_cmd.Name = "txt_cmd";
            this.txt_cmd.Size = new System.Drawing.Size(85, 27);
            this.txt_cmd.TabIndex = 3;
            this.txt_cmd.Text = "5A01";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(783, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "SerialPort I2C cmd";
            // 
            // btn_RealTime_ON
            // 
            this.btn_RealTime_ON.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RealTime_ON.Location = new System.Drawing.Point(291, 387);
            this.btn_RealTime_ON.Name = "btn_RealTime_ON";
            this.btn_RealTime_ON.Size = new System.Drawing.Size(111, 27);
            this.btn_RealTime_ON.TabIndex = 2;
            this.btn_RealTime_ON.Text = "Real-time ON";
            this.btn_RealTime_ON.UseVisualStyleBackColor = true;
            this.btn_RealTime_ON.Click += new System.EventHandler(this.btn_RealTime_ON_Click);
            // 
            // btn_RealTime_OFF
            // 
            this.btn_RealTime_OFF.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RealTime_OFF.Location = new System.Drawing.Point(408, 387);
            this.btn_RealTime_OFF.Name = "btn_RealTime_OFF";
            this.btn_RealTime_OFF.Size = new System.Drawing.Size(111, 27);
            this.btn_RealTime_OFF.TabIndex = 2;
            this.btn_RealTime_OFF.Text = "Real-time OFF";
            this.btn_RealTime_OFF.UseVisualStyleBackColor = true;
            this.btn_RealTime_OFF.Click += new System.EventHandler(this.btn_RealTime_OFF_Click);
            // 
            // cbo_Host_pattern
            // 
            this.cbo_Host_pattern.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Host_pattern.FormattingEnabled = true;
            this.cbo_Host_pattern.Items.AddRange(new object[] {
            "0x00, PRBS31Q",
            "0x66, PRBS13Q",
            "0xCC, SSPRQ"});
            this.cbo_Host_pattern.Location = new System.Drawing.Point(256, 15);
            this.cbo_Host_pattern.Name = "cbo_Host_pattern";
            this.cbo_Host_pattern.Size = new System.Drawing.Size(141, 27);
            this.cbo_Host_pattern.TabIndex = 6;
            // 
            // cbo_Media_pattern
            // 
            this.cbo_Media_pattern.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Media_pattern.FormattingEnabled = true;
            this.cbo_Media_pattern.Items.AddRange(new object[] {
            "0x00, PRBS31Q",
            "0x66, PRBS13Q",
            "0xCC, SSPRQ"});
            this.cbo_Media_pattern.Location = new System.Drawing.Point(256, 201);
            this.cbo_Media_pattern.Name = "cbo_Media_pattern";
            this.cbo_Media_pattern.Size = new System.Drawing.Size(141, 27);
            this.cbo_Media_pattern.TabIndex = 6;
            // 
            // btn_Host_pattern
            // 
            this.btn_Host_pattern.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Host_pattern.Location = new System.Drawing.Point(403, 15);
            this.btn_Host_pattern.Name = "btn_Host_pattern";
            this.btn_Host_pattern.Size = new System.Drawing.Size(101, 27);
            this.btn_Host_pattern.TabIndex = 2;
            this.btn_Host_pattern.Text = "set pattern";
            this.btn_Host_pattern.UseVisualStyleBackColor = true;
            this.btn_Host_pattern.Click += new System.EventHandler(this.btn_Host_pattern_Click);
            // 
            // btn_Media_pattern
            // 
            this.btn_Media_pattern.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Media_pattern.Location = new System.Drawing.Point(403, 200);
            this.btn_Media_pattern.Name = "btn_Media_pattern";
            this.btn_Media_pattern.Size = new System.Drawing.Size(101, 27);
            this.btn_Media_pattern.TabIndex = 2;
            this.btn_Media_pattern.Text = "set pattern";
            this.btn_Media_pattern.UseVisualStyleBackColor = true;
            this.btn_Media_pattern.Click += new System.EventHandler(this.btn_Media_pattern_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1117, 685);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbo_Host_Media_2);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.btn_RealTime_OFF2);
            this.tabPage1.Controls.Add(this.btn_RealTime_ON2);
            this.tabPage1.Controls.Add(this.dgv_DDMI2);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1109, 653);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Simplified Mode";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbo_Host_Media_2
            // 
            this.cbo_Host_Media_2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Host_Media_2.FormattingEnabled = true;
            this.cbo_Host_Media_2.Items.AddRange(new object[] {
            "Host",
            "Media"});
            this.cbo_Host_Media_2.Location = new System.Drawing.Point(68, 187);
            this.cbo_Host_Media_2.Name = "cbo_Host_Media_2";
            this.cbo_Host_Media_2.Size = new System.Drawing.Size(134, 31);
            this.cbo_Host_Media_2.TabIndex = 10;
            this.cbo_Host_Media_2.SelectedIndexChanged += new System.EventHandler(this.cbo_Host_Media_2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "BER";
            // 
            // btn_RealTime_OFF2
            // 
            this.btn_RealTime_OFF2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RealTime_OFF2.Location = new System.Drawing.Point(775, 185);
            this.btn_RealTime_OFF2.Name = "btn_RealTime_OFF2";
            this.btn_RealTime_OFF2.Size = new System.Drawing.Size(141, 33);
            this.btn_RealTime_OFF2.TabIndex = 7;
            this.btn_RealTime_OFF2.Text = "Real-time OFF";
            this.btn_RealTime_OFF2.UseVisualStyleBackColor = true;
            this.btn_RealTime_OFF2.Click += new System.EventHandler(this.btn_RealTime_OFF2_Click);
            // 
            // btn_RealTime_ON2
            // 
            this.btn_RealTime_ON2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RealTime_ON2.Location = new System.Drawing.Point(628, 185);
            this.btn_RealTime_ON2.Name = "btn_RealTime_ON2";
            this.btn_RealTime_ON2.Size = new System.Drawing.Size(141, 33);
            this.btn_RealTime_ON2.TabIndex = 8;
            this.btn_RealTime_ON2.Text = "Real-time ON";
            this.btn_RealTime_ON2.UseVisualStyleBackColor = true;
            this.btn_RealTime_ON2.Click += new System.EventHandler(this.btn_RealTime_ON2_Click);
            // 
            // dgv_DDMI2
            // 
            this.dgv_DDMI2.AllowUserToAddRows = false;
            this.dgv_DDMI2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DDMI2.Location = new System.Drawing.Point(21, 226);
            this.dgv_DDMI2.Name = "dgv_DDMI2";
            this.dgv_DDMI2.ReadOnly = true;
            this.dgv_DDMI2.RowHeadersVisible = false;
            this.dgv_DDMI2.RowHeadersWidth = 51;
            this.dgv_DDMI2.Size = new System.Drawing.Size(895, 175);
            this.dgv_DDMI2.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_new_SerialPort);
            this.tabPage2.Controls.Add(this.cbo_Media_pattern);
            this.tabPage2.Controls.Add(this.txt_result);
            this.tabPage2.Controls.Add(this.cbo_Host_pattern);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cbo_Host_Media);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dgv_Media);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dgv_DDMI);
            this.tabPage2.Controls.Add(this.dgv_Host);
            this.tabPage2.Controls.Add(this.btn_read);
            this.tabPage2.Controls.Add(this.dgv_BER_result);
            this.tabPage2.Controls.Add(this.btn_script_set);
            this.tabPage2.Controls.Add(this.dgv_EEPROM);
            this.tabPage2.Controls.Add(this.btn_RealTime_OFF);
            this.tabPage2.Controls.Add(this.btn_I2C_cmd);
            this.tabPage2.Controls.Add(this.btn_RealTime_ON);
            this.tabPage2.Controls.Add(this.txt_address);
            this.tabPage2.Controls.Add(this.btn_Media_pattern);
            this.tabPage2.Controls.Add(this.btn_read_256byte);
            this.tabPage2.Controls.Add(this.btn_Host_pattern);
            this.tabPage2.Controls.Add(this.txt_cmd);
            this.tabPage2.Controls.Add(this.btn_read_once);
            this.tabPage2.Controls.Add(this.btn_write);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txt_script);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txt_value);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txt_port);
            this.tabPage2.Controls.Add(this.txt_baudRate);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1109, 653);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Development Mode";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv_DDMI
            // 
            this.dgv_DDMI.AllowUserToAddRows = false;
            this.dgv_DDMI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DDMI.Location = new System.Drawing.Point(525, 496);
            this.dgv_DDMI.Name = "dgv_DDMI";
            this.dgv_DDMI.ReadOnly = true;
            this.dgv_DDMI.RowHeadersVisible = false;
            this.dgv_DDMI.RowHeadersWidth = 51;
            this.dgv_DDMI.Size = new System.Drawing.Size(573, 144);
            this.dgv_DDMI.TabIndex = 4;
            this.dgv_DDMI.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Host_CellClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 705);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EEPROM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BER_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Host)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Media)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DDMI2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DDMI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.Button btn_write;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_EEPROM;
        private System.Windows.Forms.Button btn_read_256byte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.TextBox txt_baudRate;
        private System.Windows.Forms.Button btn_new_SerialPort;
        private System.Windows.Forms.DataGridView dgv_BER_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Host;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_Media;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_script;
        private System.Windows.Forms.Button btn_script_set;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_Host_Media;
        private System.Windows.Forms.Button btn_read_once;
        private System.Windows.Forms.Button btn_I2C_cmd;
        private System.Windows.Forms.TextBox txt_cmd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_RealTime_ON;
        private System.Windows.Forms.Button btn_RealTime_OFF;
        private System.Windows.Forms.ComboBox cbo_Host_pattern;
        private System.Windows.Forms.ComboBox cbo_Media_pattern;
        private System.Windows.Forms.Button btn_Host_pattern;
        private System.Windows.Forms.Button btn_Media_pattern;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgv_DDMI;
        private System.Windows.Forms.DataGridView dgv_DDMI2;
        private System.Windows.Forms.Button btn_RealTime_OFF2;
        private System.Windows.Forms.Button btn_RealTime_ON2;
        private System.Windows.Forms.ComboBox cbo_Host_Media_2;
        private System.Windows.Forms.Label label7;
    }
}

