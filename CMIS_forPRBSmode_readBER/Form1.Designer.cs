
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgv_DDMI = new System.Windows.Forms.DataGridView();
            this.cbo_Host_Media = new System.Windows.Forms.ComboBox();
            this.btn_read_once = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EEPROM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BER_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Host)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Media)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DDMI)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_result
            // 
            this.txt_result.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_result.Location = new System.Drawing.Point(813, 464);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(573, 46);
            this.txt_result.TabIndex = 0;
            // 
            // btn_read
            // 
            this.btn_read.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_read.Location = new System.Drawing.Point(1186, 397);
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
            this.btn_write.Location = new System.Drawing.Point(1109, 398);
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
            this.txt_value.Location = new System.Drawing.Point(971, 398);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(132, 27);
            this.txt_value.TabIndex = 3;
            this.txt_value.Text = "778899";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "8ch realtime display";
            // 
            // dgv_EEPROM
            // 
            this.dgv_EEPROM.AllowUserToAddRows = false;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_EEPROM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.dgv_EEPROM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_EEPROM.DefaultCellStyle = dataGridViewCellStyle32;
            this.dgv_EEPROM.Location = new System.Drawing.Point(813, 43);
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
            this.btn_read_256byte.Location = new System.Drawing.Point(1298, 398);
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
            this.label5.Location = new System.Drawing.Point(812, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "address";
            // 
            // txt_address
            // 
            this.txt_address.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_address.Location = new System.Drawing.Point(878, 398);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(39, 27);
            this.txt_address.TabIndex = 3;
            this.txt_address.Text = "30";
            // 
            // txt_port
            // 
            this.txt_port.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_port.Location = new System.Drawing.Point(940, 10);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(54, 27);
            this.txt_port.TabIndex = 3;
            this.txt_port.Text = "COM3";
            // 
            // txt_baudRate
            // 
            this.txt_baudRate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_baudRate.Location = new System.Drawing.Point(1000, 10);
            this.txt_baudRate.Name = "txt_baudRate";
            this.txt_baudRate.Size = new System.Drawing.Size(65, 27);
            this.txt_baudRate.TabIndex = 3;
            this.txt_baudRate.Text = "115200";
            // 
            // btn_new_SerialPort
            // 
            this.btn_new_SerialPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_SerialPort.Location = new System.Drawing.Point(813, 10);
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
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_BER_result.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle33;
            this.dgv_BER_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_BER_result.DefaultCellStyle = dataGridViewCellStyle34;
            this.dgv_BER_result.Location = new System.Drawing.Point(12, 381);
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
            this.label1.Location = new System.Drawing.Point(923, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "value";
            // 
            // dgv_Host
            // 
            this.dgv_Host.AllowUserToAddRows = false;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Host.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle35;
            this.dgv_Host.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Host.DefaultCellStyle = dataGridViewCellStyle36;
            this.dgv_Host.Location = new System.Drawing.Point(12, 28);
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
            this.label6.Location = new System.Drawing.Point(12, 6);
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
            this.label7.Location = new System.Drawing.Point(534, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(273, 70);
            this.label7.TabIndex = 1;
            this.label7.Text = "指令說明\r\ntt[A0][address][mask][vlaue]\r\n後面兩個參數  \r\nmask 有1的bit   會把value相對的bit 寫進目標位置\r" +
    "\n引用C語言 位運算的概念設計";
            // 
            // dgv_Media
            // 
            this.dgv_Media.AllowUserToAddRows = false;
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Media.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
            this.dgv_Media.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Media.DefaultCellStyle = dataGridViewCellStyle38;
            this.dgv_Media.Location = new System.Drawing.Point(12, 200);
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
            this.label8.Location = new System.Drawing.Point(812, 435);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "script";
            // 
            // txt_script
            // 
            this.txt_script.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_script.Location = new System.Drawing.Point(863, 431);
            this.txt_script.Name = "txt_script";
            this.txt_script.Size = new System.Drawing.Size(454, 27);
            this.txt_script.TabIndex = 3;
            this.txt_script.Text = "ssA0C072AB6EC679F86F1C";
            // 
            // btn_script_set
            // 
            this.btn_script_set.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_script_set.Location = new System.Drawing.Point(1322, 431);
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
            this.label2.Location = new System.Drawing.Point(12, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "CMIS PRBS mode open SOP (Media)";
            // 
            // dgv_DDMI
            // 
            this.dgv_DDMI.AllowUserToAddRows = false;
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DDMI.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle39;
            this.dgv_DDMI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DDMI.DefaultCellStyle = dataGridViewCellStyle40;
            this.dgv_DDMI.Location = new System.Drawing.Point(523, 183);
            this.dgv_DDMI.Name = "dgv_DDMI";
            this.dgv_DDMI.ReadOnly = true;
            this.dgv_DDMI.RowHeadersVisible = false;
            this.dgv_DDMI.RowHeadersWidth = 51;
            this.dgv_DDMI.Size = new System.Drawing.Size(284, 220);
            this.dgv_DDMI.TabIndex = 4;
            // 
            // cbo_Host_Media
            // 
            this.cbo_Host_Media.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Host_Media.FormattingEnabled = true;
            this.cbo_Host_Media.Items.AddRange(new object[] {
            "Host",
            "Media"});
            this.cbo_Host_Media.Location = new System.Drawing.Point(158, 351);
            this.cbo_Host_Media.Name = "cbo_Host_Media";
            this.cbo_Host_Media.Size = new System.Drawing.Size(94, 27);
            this.cbo_Host_Media.TabIndex = 5;
            this.cbo_Host_Media.SelectedIndexChanged += new System.EventHandler(this.cbo_Host_Media_SelectedIndexChanged);
            // 
            // btn_read_once
            // 
            this.btn_read_once.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_read_once.Location = new System.Drawing.Point(258, 351);
            this.btn_read_once.Name = "btn_read_once";
            this.btn_read_once.Size = new System.Drawing.Size(90, 27);
            this.btn_read_once.TabIndex = 2;
            this.btn_read_once.Text = "Read once";
            this.btn_read_once.UseVisualStyleBackColor = true;
            this.btn_read_once.Click += new System.EventHandler(this.btn_read_once_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 610);
            this.Controls.Add(this.cbo_Host_Media);
            this.Controls.Add(this.dgv_Media);
            this.Controls.Add(this.dgv_Host);
            this.Controls.Add(this.dgv_DDMI);
            this.Controls.Add(this.dgv_BER_result);
            this.Controls.Add(this.dgv_EEPROM);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.txt_script);
            this.Controls.Add(this.txt_baudRate);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.btn_new_SerialPort);
            this.Controls.Add(this.btn_read_once);
            this.Controls.Add(this.btn_write);
            this.Controls.Add(this.btn_read_256byte);
            this.Controls.Add(this.btn_script_set);
            this.Controls.Add(this.btn_read);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DDMI)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv_DDMI;
        private System.Windows.Forms.ComboBox cbo_Host_Media;
        private System.Windows.Forms.Button btn_read_once;
    }
}

