
namespace Factory_Pattren1
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
            this.btn_ICinitialize = new System.Windows.Forms.Button();
            this.btn_FWsystem = new System.Windows.Forms.Button();
            this.btn_EEPROM = new System.Windows.Forms.Button();
            this.btn_SQLcontrol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_result
            // 
            this.txt_result.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_result.Location = new System.Drawing.Point(12, 61);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(306, 137);
            this.txt_result.TabIndex = 5;
            // 
            // btn_ICinitialize
            // 
            this.btn_ICinitialize.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ICinitialize.Location = new System.Drawing.Point(220, 12);
            this.btn_ICinitialize.Name = "btn_ICinitialize";
            this.btn_ICinitialize.Size = new System.Drawing.Size(98, 33);
            this.btn_ICinitialize.TabIndex = 2;
            this.btn_ICinitialize.Text = "ICinitialize";
            this.btn_ICinitialize.UseVisualStyleBackColor = true;
            this.btn_ICinitialize.Click += new System.EventHandler(this.btn_ICinitialize_Click);
            // 
            // btn_FWsystem
            // 
            this.btn_FWsystem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FWsystem.Location = new System.Drawing.Point(116, 12);
            this.btn_FWsystem.Name = "btn_FWsystem";
            this.btn_FWsystem.Size = new System.Drawing.Size(98, 33);
            this.btn_FWsystem.TabIndex = 3;
            this.btn_FWsystem.Text = "FWsystem";
            this.btn_FWsystem.UseVisualStyleBackColor = true;
            this.btn_FWsystem.Click += new System.EventHandler(this.btn_FWsystem_Click);
            // 
            // btn_EEPROM
            // 
            this.btn_EEPROM.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EEPROM.Location = new System.Drawing.Point(12, 12);
            this.btn_EEPROM.Name = "btn_EEPROM";
            this.btn_EEPROM.Size = new System.Drawing.Size(98, 33);
            this.btn_EEPROM.TabIndex = 4;
            this.btn_EEPROM.Text = "EEPROM";
            this.btn_EEPROM.UseVisualStyleBackColor = true;
            this.btn_EEPROM.Click += new System.EventHandler(this.btn_EEPROM_Click);
            // 
            // btn_SQLcontrol
            // 
            this.btn_SQLcontrol.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SQLcontrol.Location = new System.Drawing.Point(12, 204);
            this.btn_SQLcontrol.Name = "btn_SQLcontrol";
            this.btn_SQLcontrol.Size = new System.Drawing.Size(98, 33);
            this.btn_SQLcontrol.TabIndex = 4;
            this.btn_SQLcontrol.Text = "SQL control";
            this.btn_SQLcontrol.UseVisualStyleBackColor = true;
            this.btn_SQLcontrol.Click += new System.EventHandler(this.btn_SQLcontrol_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 278);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.btn_ICinitialize);
            this.Controls.Add(this.btn_FWsystem);
            this.Controls.Add(this.btn_SQLcontrol);
            this.Controls.Add(this.btn_EEPROM);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.Button btn_ICinitialize;
        private System.Windows.Forms.Button btn_FWsystem;
        private System.Windows.Forms.Button btn_EEPROM;
        private System.Windows.Forms.Button btn_SQLcontrol;
    }
}

