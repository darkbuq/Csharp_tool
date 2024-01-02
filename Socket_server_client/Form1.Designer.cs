
namespace Socket_server_client
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_server_ip = new System.Windows.Forms.TextBox();
            this.txt_server_port = new System.Windows.Forms.TextBox();
            this.btn_server_start = new System.Windows.Forms.Button();
            this.txt_server_note = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_server_start);
            this.groupBox1.Controls.Add(this.txt_server_note);
            this.groupBox1.Controls.Add(this.txt_server_port);
            this.groupBox1.Controls.Add(this.txt_server_ip);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "port";
            // 
            // txt_server_ip
            // 
            this.txt_server_ip.Location = new System.Drawing.Point(45, 26);
            this.txt_server_ip.Name = "txt_server_ip";
            this.txt_server_ip.Size = new System.Drawing.Size(100, 27);
            this.txt_server_ip.TabIndex = 1;
            this.txt_server_ip.Text = "127.0.0.1";
            // 
            // txt_server_port
            // 
            this.txt_server_port.Location = new System.Drawing.Point(199, 26);
            this.txt_server_port.Name = "txt_server_port";
            this.txt_server_port.Size = new System.Drawing.Size(58, 27);
            this.txt_server_port.TabIndex = 1;
            this.txt_server_port.Text = "12345";
            // 
            // btn_server_start
            // 
            this.btn_server_start.Location = new System.Drawing.Point(263, 25);
            this.btn_server_start.Name = "btn_server_start";
            this.btn_server_start.Size = new System.Drawing.Size(96, 27);
            this.btn_server_start.TabIndex = 2;
            this.btn_server_start.Text = "server start";
            this.btn_server_start.UseVisualStyleBackColor = true;
            this.btn_server_start.Click += new System.EventHandler(this.btn_server_start_Click);
            // 
            // txt_server_note
            // 
            this.txt_server_note.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_server_note.Location = new System.Drawing.Point(22, 59);
            this.txt_server_note.Multiline = true;
            this.txt_server_note.Name = "txt_server_note";
            this.txt_server_note.Size = new System.Drawing.Size(337, 94);
            this.txt_server_note.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_server_start;
        private System.Windows.Forms.TextBox txt_server_port;
        private System.Windows.Forms.TextBox txt_server_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_server_note;
    }
}

