namespace Insurance.sms
{
    partial class SMSTemplateDefinition
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
            this.cmbTemplateType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.insuranceNumberLink = new System.Windows.Forms.LinkLabel();
            this.FamilyLink = new System.Windows.Forms.LinkLabel();
            this.nameLink = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTemplateType
            // 
            this.cmbTemplateType.FormattingEnabled = true;
            this.cmbTemplateType.Items.AddRange(new object[] {
            "الگو جهت ارسال پیام تمدید",
            "الگو جهت اسال پیام تولد"});
            this.cmbTemplateType.Location = new System.Drawing.Point(238, 18);
            this.cmbTemplateType.Name = "cmbTemplateType";
            this.cmbTemplateType.Size = new System.Drawing.Size(171, 21);
            this.cmbTemplateType.TabIndex = 0;
            this.cmbTemplateType.SelectedIndexChanged += new System.EventHandler(this.cmbTemplateType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "نوع الگو :‌";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.insuranceNumberLink);
            this.panel1.Controls.Add(this.FamilyLink);
            this.panel1.Controls.Add(this.nameLink);
            this.panel1.Location = new System.Drawing.Point(66, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 29);
            this.panel1.TabIndex = 6;
            // 
            // insuranceNumberLink
            // 
            this.insuranceNumberLink.AutoSize = true;
            this.insuranceNumberLink.Location = new System.Drawing.Point(234, 9);
            this.insuranceNumberLink.Name = "insuranceNumberLink";
            this.insuranceNumberLink.Size = new System.Drawing.Size(57, 13);
            this.insuranceNumberLink.TabIndex = 8;
            this.insuranceNumberLink.TabStop = true;
            this.insuranceNumberLink.Text = "شماره بیمه";
            this.insuranceNumberLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.insuranceNumberLink_LinkClicked);
            // 
            // FamilyLink
            // 
            this.FamilyLink.AutoSize = true;
            this.FamilyLink.Location = new System.Drawing.Point(295, 9);
            this.FamilyLink.Name = "FamilyLink";
            this.FamilyLink.Size = new System.Drawing.Size(69, 13);
            this.FamilyLink.TabIndex = 7;
            this.FamilyLink.TabStop = true;
            this.FamilyLink.Text = "نام خانوادگی";
            this.FamilyLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FamilyLink_LinkClicked);
            // 
            // nameLink
            // 
            this.nameLink.AutoSize = true;
            this.nameLink.Location = new System.Drawing.Point(370, 9);
            this.nameLink.Name = "nameLink";
            this.nameLink.Size = new System.Drawing.Size(20, 13);
            this.nameLink.TabIndex = 6;
            this.nameLink.TabStop = true;
            this.nameLink.Text = "نام";
            this.nameLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nameLink_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 270);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 30);
            this.panel2.TabIndex = 7;
            // 
            // txtTemplate
            // 
            this.txtTemplate.Location = new System.Drawing.Point(66, 82);
            this.txtTemplate.Multiline = true;
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(400, 178);
            this.txtTemplate.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(249, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(168, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SMSTemplateDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 300);
            this.Controls.Add(this.txtTemplate);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTemplateType);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SMSTemplateDefinition";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تعیین الگو جهت ارسال پیام";
            this.Load += new System.EventHandler(this.SMSTemplateDefinition_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SMSTemplateDefinition_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTemplateType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel insuranceNumberLink;
        private System.Windows.Forms.LinkLabel FamilyLink;
        private System.Windows.Forms.LinkLabel nameLink;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}