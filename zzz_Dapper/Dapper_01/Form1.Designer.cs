
namespace Dapper_01
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_insert = new System.Windows.Forms.Button();
            this.txt_lot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_gg = new System.Windows.Forms.Label();
            this.txt_sn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ch = new System.Windows.Forms.TextBox();
            this.btn_query = new System.Windows.Forms.Button();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "[FormericaOE].[dbo].[PAM4_FinalTest]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(399, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Dapper test";
            // 
            // btn_insert
            // 
            this.btn_insert.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_insert.Location = new System.Drawing.Point(384, 44);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(100, 27);
            this.btn_insert.TabIndex = 1;
            this.btn_insert.Text = "insert";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // txt_lot
            // 
            this.txt_lot.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lot.Location = new System.Drawing.Point(65, 44);
            this.txt_lot.Name = "txt_lot";
            this.txt_lot.Size = new System.Drawing.Size(204, 27);
            this.txt_lot.TabIndex = 2;
            this.txt_lot.Text = "12345678";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Lot";
            // 
            // txt_gg
            // 
            this.txt_gg.AutoSize = true;
            this.txt_gg.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_gg.Location = new System.Drawing.Point(12, 81);
            this.txt_gg.Name = "txt_gg";
            this.txt_gg.Size = new System.Drawing.Size(26, 19);
            this.txt_gg.TabIndex = 0;
            this.txt_gg.Text = "SN";
            // 
            // txt_sn
            // 
            this.txt_sn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sn.Location = new System.Drawing.Point(65, 77);
            this.txt_sn.Name = "txt_sn";
            this.txt_sn.Size = new System.Drawing.Size(204, 27);
            this.txt_sn.TabIndex = 2;
            this.txt_sn.Text = "1090704buq";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "CH";
            // 
            // txt_ch
            // 
            this.txt_ch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ch.Location = new System.Drawing.Point(65, 110);
            this.txt_ch.Name = "txt_ch";
            this.txt_ch.Size = new System.Drawing.Size(204, 27);
            this.txt_ch.TabIndex = 2;
            this.txt_ch.Text = "1";
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_query.Location = new System.Drawing.Point(384, 110);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(100, 27);
            this.btn_query.TabIndex = 1;
            this.btn_query.Text = "select";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // dgv_result
            // 
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Location = new System.Drawing.Point(12, 146);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.RowTemplate.Height = 24;
            this.dgv_result.Size = new System.Drawing.Size(472, 295);
            this.dgv_result.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 450);
            this.Controls.Add(this.dgv_result);
            this.Controls.Add(this.txt_ch);
            this.Controls.Add(this.txt_sn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_lot);
            this.Controls.Add(this.txt_gg);
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.TextBox txt_lot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txt_gg;
        private System.Windows.Forms.TextBox txt_sn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ch;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.DataGridView dgv_result;
    }
}

