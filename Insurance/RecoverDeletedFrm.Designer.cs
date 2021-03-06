namespace Insurance
{
    partial class RecoverDeletedFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtInsuranceNumber = new System.Windows.Forms.TextBox();
            this.lblInsuranceNumber = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDo);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.txtInsuranceNumber);
            this.groupBox1.Controls.Add(this.lblInsuranceNumber);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(349, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بازگرداندن رکورد حذف شده";
            // 
            // btnDo
            // 
            this.btnDo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDo.Location = new System.Drawing.Point(145, 68);
            this.btnDo.Name = "btnDo";
            this.btnDo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDo.Size = new System.Drawing.Size(54, 22);
            this.btnDo.TabIndex = 1;
            this.btnDo.Text = "انجام";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExit.Location = new System.Drawing.Point(85, 68);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(54, 22);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "انصراف";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtInsuranceNumber
            // 
            this.txtInsuranceNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtInsuranceNumber.Location = new System.Drawing.Point(145, 30);
            this.txtInsuranceNumber.Name = "txtInsuranceNumber";
            this.txtInsuranceNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtInsuranceNumber.Size = new System.Drawing.Size(129, 21);
            this.txtInsuranceNumber.TabIndex = 0;
            this.txtInsuranceNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInsuranceNumber_KeyDown);
            // 
            // lblInsuranceNumber
            // 
            this.lblInsuranceNumber.AutoSize = true;
            this.lblInsuranceNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblInsuranceNumber.Location = new System.Drawing.Point(280, 33);
            this.lblInsuranceNumber.Name = "lblInsuranceNumber";
            this.lblInsuranceNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInsuranceNumber.Size = new System.Drawing.Size(67, 13);
            this.lblInsuranceNumber.TabIndex = 0;
            this.lblInsuranceNumber.Text = "شماره بیمه :";
            // 
            // RecoverDeletedFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 130);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecoverDeletedFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بازگرداندن رکورد حذف شده";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RecoverDeletedFrm_KeyDown);
            this.Load += new System.EventHandler(this.RecoverDeletedFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInsuranceNumber;
        private System.Windows.Forms.Label lblInsuranceNumber;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDo;
    }
}