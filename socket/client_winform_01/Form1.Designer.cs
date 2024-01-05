
namespace client_winform_01
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
            this.components = new System.ComponentModel.Container();
            this.btn_start = new System.Windows.Forms.Button();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_note = new System.Windows.Forms.TextBox();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_send = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.cbo_endstr = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_select_SCPI = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(246, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(95, 27);
            this.btn_start.TabIndex = 8;
            this.btn_start.Text = "client start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // txt_port
            // 
            this.txt_port.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_port.Location = new System.Drawing.Point(189, 12);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(51, 27);
            this.txt_port.TabIndex = 5;
            this.txt_port.Text = "5024";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "port";
            // 
            // txt_note
            // 
            this.txt_note.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_note.Location = new System.Drawing.Point(23, 137);
            this.txt_note.Multiline = true;
            this.txt_note.Name = "txt_note";
            this.txt_note.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_note.Size = new System.Drawing.Size(318, 145);
            this.txt_note.TabIndex = 6;
            // 
            // txt_ip
            // 
            this.txt_ip.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ip.Location = new System.Drawing.Point(46, 12);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(101, 27);
            this.txt_ip.TabIndex = 7;
            this.txt_ip.Text = "192.168.7.60";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP";
            // 
            // txt_send
            // 
            this.txt_send.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_send.Location = new System.Drawing.Point(23, 94);
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(197, 27);
            this.txt_send.TabIndex = 6;
            this.txt_send.Text = "*IDN?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "send txt";
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Location = new System.Drawing.Point(93, 60);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(95, 27);
            this.btn_send.TabIndex = 8;
            this.btn_send.Text = "client send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // cbo_endstr
            // 
            this.cbo_endstr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_endstr.FormattingEnabled = true;
            this.cbo_endstr.Items.AddRange(new object[] {
            "null",
            "\\r",
            "\\n",
            "\\r\\n"});
            this.cbo_endstr.Location = new System.Drawing.Point(285, 61);
            this.cbo_endstr.Name = "cbo_endstr";
            this.cbo_endstr.Size = new System.Drawing.Size(56, 27);
            this.cbo_endstr.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(202, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "terminator";
            // 
            // cbo_select_SCPI
            // 
            this.cbo_select_SCPI.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_select_SCPI.FormattingEnabled = true;
            this.cbo_select_SCPI.Items.AddRange(new object[] {
            "訪問",
            "讀電壓"});
            this.cbo_select_SCPI.Location = new System.Drawing.Point(226, 94);
            this.cbo_select_SCPI.Name = "cbo_select_SCPI";
            this.cbo_select_SCPI.Size = new System.Drawing.Size(115, 27);
            this.cbo_select_SCPI.TabIndex = 9;
            this.cbo_select_SCPI.SelectedIndexChanged += new System.EventHandler(this.cbo_select_SCPI_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 298);
            this.Controls.Add(this.cbo_select_SCPI);
            this.Controls.Add(this.cbo_endstr);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_send);
            this.Controls.Add(this.txt_note);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_note;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_send;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.ComboBox cbo_endstr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_select_SCPI;
        private System.Windows.Forms.Timer timer1;
    }
}

