
namespace WinForms_device_PSS_DCA10021
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
            this.btn_new_PSS_DCA10021 = new System.Windows.Forms.Button();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.btn_queryInfo = new System.Windows.Forms.Button();
            this.btn_autoScale = new System.Windows.Forms.Button();
            this.btn_queryPower = new System.Windows.Forms.Button();
            this.btn_queryER = new System.Windows.Forms.Button();
            this.btn_queryCrossing = new System.Windows.Forms.Button();
            this.btn_queryJitter = new System.Windows.Forms.Button();
            this.btn_queryMargin = new System.Windows.Forms.Button();
            this.btn_saveImage = new System.Windows.Forms.Button();
            this.txt_saveImage_pathfilename = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_new_PSS_DCA10021
            // 
            this.btn_new_PSS_DCA10021.Location = new System.Drawing.Point(190, 164);
            this.btn_new_PSS_DCA10021.Name = "btn_new_PSS_DCA10021";
            this.btn_new_PSS_DCA10021.Size = new System.Drawing.Size(181, 27);
            this.btn_new_PSS_DCA10021.TabIndex = 0;
            this.btn_new_PSS_DCA10021.Text = "new PSS DCA 10021";
            this.btn_new_PSS_DCA10021.UseVisualStyleBackColor = true;
            this.btn_new_PSS_DCA10021.Click += new System.EventHandler(this.btn_new_PSS_DCA10021_Click);
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(34, 164);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(150, 27);
            this.txt_ip.TabIndex = 1;
            this.txt_ip.Text = "192.168.12.12";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(567, 95);
            this.label1.TabIndex = 2;
            this.label1.Text = "筆電上原廠程式  用設備顯示的ip  連線  \r\n\r\n經過設定  第三方    要用我的筆電 ip去登記    原廠程式會幫我的筆電開 port  5001\r\n\r" +
    "\n在筆電上用網口工具  直接訪問  我的筆電IP  port 5001      即可下指令\r\n";
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(439, 163);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(123, 27);
            this.btn_disconnect.TabIndex = 0;
            this.btn_disconnect.Text = "disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(190, 213);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(573, 69);
            this.txt_result.TabIndex = 1;
            // 
            // btn_queryInfo
            // 
            this.btn_queryInfo.Location = new System.Drawing.Point(640, 163);
            this.btn_queryInfo.Name = "btn_queryInfo";
            this.btn_queryInfo.Size = new System.Drawing.Size(123, 27);
            this.btn_queryInfo.TabIndex = 0;
            this.btn_queryInfo.Text = "*IDN?";
            this.btn_queryInfo.UseVisualStyleBackColor = true;
            this.btn_queryInfo.Click += new System.EventHandler(this.btn_queryInfo_Click);
            // 
            // btn_autoScale
            // 
            this.btn_autoScale.Location = new System.Drawing.Point(61, 213);
            this.btn_autoScale.Name = "btn_autoScale";
            this.btn_autoScale.Size = new System.Drawing.Size(123, 27);
            this.btn_autoScale.TabIndex = 0;
            this.btn_autoScale.Text = "autoScale";
            this.btn_autoScale.UseVisualStyleBackColor = true;
            this.btn_autoScale.Click += new System.EventHandler(this.btn_autoScale_Click);
            // 
            // btn_queryPower
            // 
            this.btn_queryPower.Location = new System.Drawing.Point(61, 246);
            this.btn_queryPower.Name = "btn_queryPower";
            this.btn_queryPower.Size = new System.Drawing.Size(123, 27);
            this.btn_queryPower.TabIndex = 0;
            this.btn_queryPower.Text = "power";
            this.btn_queryPower.UseVisualStyleBackColor = true;
            this.btn_queryPower.Click += new System.EventHandler(this.btn_queryPower_Click);
            // 
            // btn_queryER
            // 
            this.btn_queryER.Location = new System.Drawing.Point(61, 279);
            this.btn_queryER.Name = "btn_queryER";
            this.btn_queryER.Size = new System.Drawing.Size(123, 27);
            this.btn_queryER.TabIndex = 0;
            this.btn_queryER.Text = "ER";
            this.btn_queryER.UseVisualStyleBackColor = true;
            this.btn_queryER.Click += new System.EventHandler(this.btn_queryER_Click);
            // 
            // btn_queryCrossing
            // 
            this.btn_queryCrossing.Location = new System.Drawing.Point(61, 312);
            this.btn_queryCrossing.Name = "btn_queryCrossing";
            this.btn_queryCrossing.Size = new System.Drawing.Size(123, 27);
            this.btn_queryCrossing.TabIndex = 0;
            this.btn_queryCrossing.Text = "Crossing";
            this.btn_queryCrossing.UseVisualStyleBackColor = true;
            this.btn_queryCrossing.Click += new System.EventHandler(this.btn_queryCrossing_Click);
            // 
            // btn_queryJitter
            // 
            this.btn_queryJitter.Location = new System.Drawing.Point(61, 345);
            this.btn_queryJitter.Name = "btn_queryJitter";
            this.btn_queryJitter.Size = new System.Drawing.Size(123, 27);
            this.btn_queryJitter.TabIndex = 0;
            this.btn_queryJitter.Text = "Jitter";
            this.btn_queryJitter.UseVisualStyleBackColor = true;
            this.btn_queryJitter.Click += new System.EventHandler(this.btn_queryJitter_Click);
            // 
            // btn_queryMargin
            // 
            this.btn_queryMargin.Location = new System.Drawing.Point(61, 378);
            this.btn_queryMargin.Name = "btn_queryMargin";
            this.btn_queryMargin.Size = new System.Drawing.Size(123, 27);
            this.btn_queryMargin.TabIndex = 0;
            this.btn_queryMargin.Text = "Margin";
            this.btn_queryMargin.UseVisualStyleBackColor = true;
            this.btn_queryMargin.Click += new System.EventHandler(this.btn_queryMargin_Click);
            // 
            // btn_saveImage
            // 
            this.btn_saveImage.Location = new System.Drawing.Point(559, 328);
            this.btn_saveImage.Name = "btn_saveImage";
            this.btn_saveImage.Size = new System.Drawing.Size(123, 27);
            this.btn_saveImage.TabIndex = 0;
            this.btn_saveImage.Text = "save Image";
            this.btn_saveImage.UseVisualStyleBackColor = true;
            this.btn_saveImage.Click += new System.EventHandler(this.btn_saveImage_Click);
            // 
            // txt_saveImage_pathfilename
            // 
            this.txt_saveImage_pathfilename.Location = new System.Drawing.Point(403, 328);
            this.txt_saveImage_pathfilename.Name = "txt_saveImage_pathfilename";
            this.txt_saveImage_pathfilename.Size = new System.Drawing.Size(150, 27);
            this.txt_saveImage_pathfilename.TabIndex = 1;
            this.txt_saveImage_pathfilename.Text = "D:\\\\gg\\gg.jpg";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 418);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.txt_saveImage_pathfilename);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.btn_saveImage);
            this.Controls.Add(this.btn_queryMargin);
            this.Controls.Add(this.btn_queryJitter);
            this.Controls.Add(this.btn_queryCrossing);
            this.Controls.Add(this.btn_queryER);
            this.Controls.Add(this.btn_queryPower);
            this.Controls.Add(this.btn_autoScale);
            this.Controls.Add(this.btn_queryInfo);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.btn_new_PSS_DCA10021);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_new_PSS_DCA10021;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.Button btn_queryInfo;
        private System.Windows.Forms.Button btn_autoScale;
        private System.Windows.Forms.Button btn_queryPower;
        private System.Windows.Forms.Button btn_queryER;
        private System.Windows.Forms.Button btn_queryCrossing;
        private System.Windows.Forms.Button btn_queryJitter;
        private System.Windows.Forms.Button btn_queryMargin;
        private System.Windows.Forms.Button btn_saveImage;
        private System.Windows.Forms.TextBox txt_saveImage_pathfilename;
    }
}

