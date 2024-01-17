
namespace GPIB_04_success
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
            this.btn_conn = new System.Windows.Forms.Button();
            this.btn_check_device = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_query = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txt_GPIB_address = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_GPIB_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_conn = new System.Windows.Forms.Label();
            this.btn_write = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_conn
            // 
            this.btn_conn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_conn.Location = new System.Drawing.Point(232, 10);
            this.btn_conn.Name = "btn_conn";
            this.btn_conn.Size = new System.Drawing.Size(71, 30);
            this.btn_conn.TabIndex = 0;
            this.btn_conn.Text = "conn";
            this.btn_conn.UseVisualStyleBackColor = true;
            this.btn_conn.Click += new System.EventHandler(this.btn_conn_Click);
            // 
            // btn_check_device
            // 
            this.btn_check_device.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_check_device.Location = new System.Drawing.Point(16, 56);
            this.btn_check_device.Name = "btn_check_device";
            this.btn_check_device.Size = new System.Drawing.Size(100, 30);
            this.btn_check_device.TabIndex = 0;
            this.btn_check_device.Text = "*IDN?";
            this.btn_check_device.UseVisualStyleBackColor = true;
            this.btn_check_device.Click += new System.EventHandler(this.btn_check_device_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 128);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(322, 124);
            this.textBox1.TabIndex = 1;
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_query.Location = new System.Drawing.Point(238, 56);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(100, 30);
            this.btn_query.TabIndex = 0;
            this.btn_query.Text = "Query";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(16, 95);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(322, 27);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = ":CHANnel1:MEASure:VOLTage ?";
            // 
            // txt_GPIB_address
            // 
            this.txt_GPIB_address.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GPIB_address.Location = new System.Drawing.Point(186, 12);
            this.txt_GPIB_address.Name = "txt_GPIB_address";
            this.txt_GPIB_address.Size = new System.Drawing.Size(41, 27);
            this.txt_GPIB_address.TabIndex = 2;
            this.txt_GPIB_address.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "address";
            // 
            // txt_GPIB_port
            // 
            this.txt_GPIB_port.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GPIB_port.Location = new System.Drawing.Point(52, 12);
            this.txt_GPIB_port.Name = "txt_GPIB_port";
            this.txt_GPIB_port.Size = new System.Drawing.Size(64, 27);
            this.txt_GPIB_port.TabIndex = 2;
            this.txt_GPIB_port.Text = "GPIB0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "port";
            // 
            // lbl_conn
            // 
            this.lbl_conn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_conn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_conn.Location = new System.Drawing.Point(308, 10);
            this.lbl_conn.Name = "lbl_conn";
            this.lbl_conn.Size = new System.Drawing.Size(30, 30);
            this.lbl_conn.TabIndex = 3;
            // 
            // btn_write
            // 
            this.btn_write.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_write.Location = new System.Drawing.Point(132, 56);
            this.btn_write.Name = "btn_write";
            this.btn_write.Size = new System.Drawing.Size(100, 30);
            this.btn_write.TabIndex = 0;
            this.btn_write.Text = "Write";
            this.btn_write.UseVisualStyleBackColor = true;
            this.btn_write.Click += new System.EventHandler(this.btn_write_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 267);
            this.Controls.Add(this.lbl_conn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_GPIB_port);
            this.Controls.Add(this.txt_GPIB_address);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_write);
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.btn_check_device);
            this.Controls.Add(this.btn_conn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_conn;
        private System.Windows.Forms.Button btn_check_device;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txt_GPIB_address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_GPIB_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_conn;
        private System.Windows.Forms.Button btn_write;
    }
}

