
namespace PowerSupply_GW_PST3202
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
            this.btn_power_on = new System.Windows.Forms.Button();
            this.btn_power_off = new System.Windows.Forms.Button();
            this.btn_new_PST3202 = new System.Windows.Forms.Button();
            this.btn_device_info = new System.Windows.Forms.Button();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.txt_setV = new System.Windows.Forms.TextBox();
            this.btn_setV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_power_on
            // 
            this.btn_power_on.Location = new System.Drawing.Point(17, 137);
            this.btn_power_on.Name = "btn_power_on";
            this.btn_power_on.Size = new System.Drawing.Size(97, 38);
            this.btn_power_on.TabIndex = 0;
            this.btn_power_on.Text = "power on";
            this.btn_power_on.UseVisualStyleBackColor = true;
            this.btn_power_on.Click += new System.EventHandler(this.btn_power_on_Click);
            // 
            // btn_power_off
            // 
            this.btn_power_off.Location = new System.Drawing.Point(151, 137);
            this.btn_power_off.Name = "btn_power_off";
            this.btn_power_off.Size = new System.Drawing.Size(97, 38);
            this.btn_power_off.TabIndex = 0;
            this.btn_power_off.Text = "power off";
            this.btn_power_off.UseVisualStyleBackColor = true;
            this.btn_power_off.Click += new System.EventHandler(this.btn_power_off_Click);
            // 
            // btn_new_PST3202
            // 
            this.btn_new_PST3202.Location = new System.Drawing.Point(17, 21);
            this.btn_new_PST3202.Name = "btn_new_PST3202";
            this.btn_new_PST3202.Size = new System.Drawing.Size(191, 38);
            this.btn_new_PST3202.TabIndex = 0;
            this.btn_new_PST3202.Text = "new PST3202";
            this.btn_new_PST3202.UseVisualStyleBackColor = true;
            this.btn_new_PST3202.Click += new System.EventHandler(this.btn_new_PST3202_Click);
            // 
            // btn_device_info
            // 
            this.btn_device_info.Location = new System.Drawing.Point(17, 79);
            this.btn_device_info.Name = "btn_device_info";
            this.btn_device_info.Size = new System.Drawing.Size(136, 38);
            this.btn_device_info.TabIndex = 0;
            this.btn_device_info.Text = "*IDN?";
            this.btn_device_info.UseVisualStyleBackColor = true;
            this.btn_device_info.Click += new System.EventHandler(this.btn_device_info_Click);
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(274, 21);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(320, 154);
            this.txt_result.TabIndex = 1;
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(17, 290);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(191, 38);
            this.btn_disconnect.TabIndex = 0;
            this.btn_disconnect.Text = "disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // txt_setV
            // 
            this.txt_setV.Location = new System.Drawing.Point(68, 227);
            this.txt_setV.Name = "txt_setV";
            this.txt_setV.Size = new System.Drawing.Size(85, 27);
            this.txt_setV.TabIndex = 2;
            this.txt_setV.Text = "3.5";
            // 
            // btn_setV
            // 
            this.btn_setV.Location = new System.Drawing.Point(159, 220);
            this.btn_setV.Name = "btn_setV";
            this.btn_setV.Size = new System.Drawing.Size(97, 38);
            this.btn_setV.TabIndex = 0;
            this.btn_setV.Text = "setV";
            this.btn_setV.UseVisualStyleBackColor = true;
            this.btn_setV.Click += new System.EventHandler(this.btn_setV_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 384);
            this.Controls.Add(this.txt_setV);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.btn_power_off);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.btn_new_PST3202);
            this.Controls.Add(this.btn_device_info);
            this.Controls.Add(this.btn_setV);
            this.Controls.Add(this.btn_power_on);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_power_on;
        private System.Windows.Forms.Button btn_power_off;
        private System.Windows.Forms.Button btn_new_PST3202;
        private System.Windows.Forms.Button btn_device_info;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.TextBox txt_setV;
        private System.Windows.Forms.Button btn_setV;
    }
}

