
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label7 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EEPROM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BER_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Host)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Media)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_result
            // 
            this.txt_result.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_result.Location = new System.Drawing.Point(523, 462);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(573, 46);
            this.txt_result.TabIndex = 0;
            // 
            // btn_read
            // 
            this.btn_read.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_read.ForeColor = System.Drawing.Color.Blue;
            this.btn_read.Location = new System.Drawing.Point(896, 395);
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
            this.btn_write.Location = new System.Drawing.Point(819, 396);
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
            this.txt_value.Location = new System.Drawing.Point(681, 396);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(132, 27);
            this.txt_value.TabIndex = 3;
            this.txt_value.Text = "778899";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "8ch realtime display";
            // 
            // dgv_EEPROM
            // 
            this.dgv_EEPROM.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_EEPROM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_EEPROM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_EEPROM.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_EEPROM.Location = new System.Drawing.Point(523, 41);
            this.dgv_EEPROM.Name = "dgv_EEPROM";
            this.dgv_EEPROM.ReadOnly = true;
            this.dgv_EEPROM.RowHeadersVisible = false;
            this.dgv_EEPROM.RowHeadersWidth = 51;
            this.dgv_EEPROM.Size = new System.Drawing.Size(573, 346);
            this.dgv_EEPROM.TabIndex = 4;
            // 
            // btn_read_256byte
            // 
            this.btn_read_256byte.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_read_256byte.ForeColor = System.Drawing.Color.Blue;
            this.btn_read_256byte.Location = new System.Drawing.Point(1008, 396);
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
            this.label5.Location = new System.Drawing.Point(522, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "address";
            // 
            // txt_address
            // 
            this.txt_address.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_address.ForeColor = System.Drawing.Color.Blue;
            this.txt_address.Location = new System.Drawing.Point(588, 396);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(39, 27);
            this.txt_address.TabIndex = 3;
            this.txt_address.Text = "30";
            // 
            // txt_port
            // 
            this.txt_port.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_port.Location = new System.Drawing.Point(650, 8);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(54, 27);
            this.txt_port.TabIndex = 3;
            this.txt_port.Text = "COM3";
            // 
            // txt_baudRate
            // 
            this.txt_baudRate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_baudRate.Location = new System.Drawing.Point(710, 8);
            this.txt_baudRate.Name = "txt_baudRate";
            this.txt_baudRate.Size = new System.Drawing.Size(65, 27);
            this.txt_baudRate.TabIndex = 3;
            this.txt_baudRate.Text = "115200";
            // 
            // btn_new_SerialPort
            // 
            this.btn_new_SerialPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_SerialPort.Location = new System.Drawing.Point(523, 8);
            this.btn_new_SerialPort.Name = "btn_new_SerialPort";
            this.btn_new_SerialPort.Size = new System.Drawing.Size(121, 27);
            this.btn_new_SerialPort.TabIndex = 2;
            this.btn_new_SerialPort.Text = "new SerialPort";
            this.btn_new_SerialPort.UseVisualStyleBackColor = true;
            this.btn_new_SerialPort.Click += new System.EventHandler(this.btn_new_SerialPort_Click);
            // 
            // dgv_BER_result
            // 
            this.dgv_BER_result.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_BER_result.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_BER_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_BER_result.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_BER_result.Location = new System.Drawing.Point(12, 394);
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
            this.label1.Location = new System.Drawing.Point(633, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "value";
            // 
            // dgv_Host
            // 
            this.dgv_Host.AllowUserToAddRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Host.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Host.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Host.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Host.Location = new System.Drawing.Point(12, 41);
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
            this.label6.Location = new System.Drawing.Point(12, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "CMIS PRBS mode open SOP (Host)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(822, 548);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(273, 70);
            this.label7.TabIndex = 1;
            this.label7.Text = "指令說明\r\ntt[A0][address][mask][vlaue]\r\n後面兩個參數  \r\nmask 有1的bit   會把value相對的bit 寫進目標位置\r" +
    "\n引用C語言 位運算的概念設計";
            // 
            // dgv_Media
            // 
            this.dgv_Media.AllowUserToAddRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Media.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_Media.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Media.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_Media.Location = new System.Drawing.Point(12, 213);
            this.dgv_Media.Name = "dgv_Media";
            this.dgv_Media.ReadOnly = true;
            this.dgv_Media.RowHeadersVisible = false;
            this.dgv_Media.RowHeadersWidth = 51;
            this.dgv_Media.Size = new System.Drawing.Size(505, 147);
            this.dgv_Media.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(522, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "script";
            // 
            // txt_script
            // 
            this.txt_script.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_script.ForeColor = System.Drawing.Color.Blue;
            this.txt_script.Location = new System.Drawing.Point(573, 429);
            this.txt_script.Name = "txt_script";
            this.txt_script.Size = new System.Drawing.Size(454, 27);
            this.txt_script.TabIndex = 3;
            this.txt_script.Text = "ssA0C072AB6EC679F86F1C";
            // 
            // btn_script_set
            // 
            this.btn_script_set.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_script_set.ForeColor = System.Drawing.Color.Blue;
            this.btn_script_set.Location = new System.Drawing.Point(1032, 429);
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
            this.label2.Location = new System.Drawing.Point(12, 191);
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
            this.cbo_Host_Media.Location = new System.Drawing.Point(158, 364);
            this.cbo_Host_Media.Name = "cbo_Host_Media";
            this.cbo_Host_Media.Size = new System.Drawing.Size(94, 27);
            this.cbo_Host_Media.TabIndex = 5;
            this.cbo_Host_Media.SelectedIndexChanged += new System.EventHandler(this.cbo_Host_Media_SelectedIndexChanged);
            // 
            // btn_read_once
            // 
            this.btn_read_once.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_read_once.Location = new System.Drawing.Point(258, 364);
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
            this.btn_I2C_cmd.Location = new System.Drawing.Point(1006, 514);
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
            this.txt_cmd.Location = new System.Drawing.Point(650, 514);
            this.txt_cmd.Name = "txt_cmd";
            this.txt_cmd.Size = new System.Drawing.Size(350, 27);
            this.txt_cmd.TabIndex = 3;
            this.txt_cmd.Text = "5A01";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(522, 518);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "SerialPort I2C cmd";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 627);
            this.Controls.Add(this.cbo_Host_Media);
            this.Controls.Add(this.dgv_Media);
            this.Controls.Add(this.dgv_Host);
            this.Controls.Add(this.dgv_BER_result);
            this.Controls.Add(this.dgv_EEPROM);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.txt_cmd);
            this.Controls.Add(this.txt_script);
            this.Controls.Add(this.txt_baudRate);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.btn_new_SerialPort);
            this.Controls.Add(this.btn_read_once);
            this.Controls.Add(this.btn_write);
            this.Controls.Add(this.btn_read_256byte);
            this.Controls.Add(this.btn_I2C_cmd);
            this.Controls.Add(this.btn_script_set);
            this.Controls.Add(this.btn_read);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_result);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EEPROM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BER_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Host)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Media)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label7;
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
    }
}

