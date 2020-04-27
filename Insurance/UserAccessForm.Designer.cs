namespace Insurance
{
    partial class UserAccessForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUserList = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbxAccessToInsuranceInfo = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxAccessToArchive = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbxAccessPrintSeachResult = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbUserList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 51);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(511, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "کاربران غیر مدیر : ";
            // 
            // cmbUserList
            // 
            this.cmbUserList.FormattingEnabled = true;
            this.cmbUserList.Location = new System.Drawing.Point(266, 13);
            this.cmbUserList.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUserList.Name = "cmbUserList";
            this.cmbUserList.Size = new System.Drawing.Size(216, 26);
            this.cmbUserList.TabIndex = 0;
            this.cmbUserList.SelectedIndexChanged += new System.EventHandler(this.cmbUserList_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(643, 330);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SkyBlue;
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Controls.Add(this.btnClose);
            this.panel5.Location = new System.Drawing.Point(21, 289);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(609, 30);
            this.panel5.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(288, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(190, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "بستن";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightBlue;
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Location = new System.Drawing.Point(21, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(610, 276);
            this.panel4.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel6.Controls.Add(this.cbxAccessToInsuranceInfo);
            this.panel6.Location = new System.Drawing.Point(320, 59);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(273, 39);
            this.panel6.TabIndex = 4;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // cbxAccessToInsuranceInfo
            // 
            this.cbxAccessToInsuranceInfo.AutoSize = true;
            this.cbxAccessToInsuranceInfo.Location = new System.Drawing.Point(10, 3);
            this.cbxAccessToInsuranceInfo.Name = "cbxAccessToInsuranceInfo";
            this.cbxAccessToInsuranceInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxAccessToInsuranceInfo.Size = new System.Drawing.Size(226, 22);
            this.cbxAccessToInsuranceInfo.TabIndex = 3;
            this.cbxAccessToInsuranceInfo.Text = "دسترسی تغییر در اطلاعات بیمه";
            this.cbxAccessToInsuranceInfo.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.cbxAccessToArchive);
            this.panel3.Location = new System.Drawing.Point(320, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 39);
            this.panel3.TabIndex = 3;
            // 
            // cbxAccessToArchive
            // 
            this.cbxAccessToArchive.AutoSize = true;
            this.cbxAccessToArchive.Location = new System.Drawing.Point(10, 3);
            this.cbxAccessToArchive.Name = "cbxAccessToArchive";
            this.cbxAccessToArchive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxAccessToArchive.Size = new System.Drawing.Size(220, 22);
            this.cbxAccessToArchive.TabIndex = 3;
            this.cbxAccessToArchive.Text = "دسترسی اعمال در فرم اصلی ";
            this.cbxAccessToArchive.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel7.Controls.Add(this.cbxAccessPrintSeachResult);
            this.panel7.Location = new System.Drawing.Point(320, 103);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(273, 39);
            this.panel7.TabIndex = 5;
            // 
            // cbxAccessPrintSeachResult
            // 
            this.cbxAccessPrintSeachResult.AutoSize = true;
            this.cbxAccessPrintSeachResult.Location = new System.Drawing.Point(10, 3);
            this.cbxAccessPrintSeachResult.Name = "cbxAccessPrintSeachResult";
            this.cbxAccessPrintSeachResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxAccessPrintSeachResult.Size = new System.Drawing.Size(223, 22);
            this.cbxAccessPrintSeachResult.TabIndex = 3;
            this.cbxAccessPrintSeachResult.Text = "چاپ لیست مشخصات مشتریان";
            this.cbxAccessPrintSeachResult.UseVisualStyleBackColor = true;
            // 
            // UserAccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 381);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserAccessForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دسترسی به کاربران";
            this.Load += new System.EventHandler(this.UserAccessForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserAccessForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbUserList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbxAccessToArchive;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox cbxAccessToInsuranceInfo;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox cbxAccessPrintSeachResult;
    }
}