﻿
namespace client_winform_02
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
            this.btn_write = new System.Windows.Forms.Button();
            this.btn_query = new System.Windows.Forms.Button();
            this.btn_check_device = new System.Windows.Forms.Button();
            this.cbo_endstr = new System.Windows.Forms.ComboBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_send = new System.Windows.Forms.TextBox();
            this.txt_note = new System.Windows.Forms.TextBox();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_write
            // 
            this.btn_write.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_write.Location = new System.Drawing.Point(131, 134);
            this.btn_write.Name = "btn_write";
            this.btn_write.Size = new System.Drawing.Size(100, 30);
            this.btn_write.TabIndex = 22;
            this.btn_write.Text = "Write";
            this.btn_write.UseVisualStyleBackColor = true;
            this.btn_write.Click += new System.EventHandler(this.btn_write_Click);
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_query.Location = new System.Drawing.Point(237, 134);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(100, 30);
            this.btn_query.TabIndex = 23;
            this.btn_query.Text = "Query";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // btn_check_device
            // 
            this.btn_check_device.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_check_device.Location = new System.Drawing.Point(19, 53);
            this.btn_check_device.Name = "btn_check_device";
            this.btn_check_device.Size = new System.Drawing.Size(100, 30);
            this.btn_check_device.TabIndex = 24;
            this.btn_check_device.Text = "*IDN?";
            this.btn_check_device.UseVisualStyleBackColor = true;
            this.btn_check_device.Click += new System.EventHandler(this.btn_check_device_Click);
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
            this.cbo_endstr.Location = new System.Drawing.Point(281, 61);
            this.cbo_endstr.Name = "cbo_endstr";
            this.cbo_endstr.Size = new System.Drawing.Size(56, 27);
            this.cbo_endstr.TabIndex = 21;
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(242, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(95, 27);
            this.btn_start.TabIndex = 20;
            this.btn_start.Text = "client start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // txt_port
            // 
            this.txt_port.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_port.Location = new System.Drawing.Point(185, 12);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(51, 27);
            this.txt_port.TabIndex = 16;
            this.txt_port.Text = "12345";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(198, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "terminator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(149, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "port";
            // 
            // txt_send
            // 
            this.txt_send.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_send.Location = new System.Drawing.Point(19, 94);
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(318, 27);
            this.txt_send.TabIndex = 17;
            this.txt_send.Text = "LINS0:INP:ATT?";
            // 
            // txt_note
            // 
            this.txt_note.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_note.Location = new System.Drawing.Point(19, 170);
            this.txt_note.Multiline = true;
            this.txt_note.Name = "txt_note";
            this.txt_note.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_note.Size = new System.Drawing.Size(318, 112);
            this.txt_note.TabIndex = 18;
            // 
            // txt_ip
            // 
            this.txt_ip.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ip.Location = new System.Drawing.Point(42, 12);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(101, 27);
            this.txt_ip.TabIndex = 19;
            this.txt_ip.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "IP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 331);
            this.Controls.Add(this.btn_write);
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.btn_check_device);
            this.Controls.Add(this.cbo_endstr);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_send);
            this.Controls.Add(this.txt_note);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_write;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Button btn_check_device;
        private System.Windows.Forms.ComboBox cbo_endstr;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_send;
        private System.Windows.Forms.TextBox txt_note;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label label1;
    }
}

