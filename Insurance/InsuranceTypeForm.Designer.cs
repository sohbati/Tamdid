namespace Insurance
{
    partial class InsuranceTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsuranceTypeForm));
            this.cmbDaysBeforExp = new System.Windows.Forms.ComboBox();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.lblDaysBeforExp = new System.Windows.Forms.Label();
            this.btnColorSelect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtInsuranceType = new System.Windows.Forms.TextBox();
            this.lblInsuranceType = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DAYSBEFOREXP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INSURANCETYPECOLOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insuranceTypeData1 = new Insurance_Common.InsuranceTypeData();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.insuranceTypeData1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDaysBeforExp
            // 
            this.cmbDaysBeforExp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbDaysBeforExp.FormattingEnabled = true;
            this.cmbDaysBeforExp.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbDaysBeforExp.Location = new System.Drawing.Point(265, 41);
            this.cmbDaysBeforExp.Name = "cmbDaysBeforExp";
            this.cmbDaysBeforExp.Size = new System.Drawing.Size(82, 21);
            this.cmbDaysBeforExp.TabIndex = 2;
            // 
            // pnlColor
            // 
            this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pnlColor.Location = new System.Drawing.Point(79, 39);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(73, 28);
            this.pnlColor.TabIndex = 13;
            // 
            // lblDaysBeforExp
            // 
            this.lblDaysBeforExp.AutoSize = true;
            this.lblDaysBeforExp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDaysBeforExp.Location = new System.Drawing.Point(353, 44);
            this.lblDaysBeforExp.Name = "lblDaysBeforExp";
            this.lblDaysBeforExp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDaysBeforExp.Size = new System.Drawing.Size(86, 13);
            this.lblDaysBeforExp.TabIndex = 12;
            this.lblDaysBeforExp.Text = "روز تا تاریخ اتمام :";
            // 
            // btnColorSelect
            // 
            this.btnColorSelect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnColorSelect.Location = new System.Drawing.Point(158, 39);
            this.btnColorSelect.Name = "btnColorSelect";
            this.btnColorSelect.Size = new System.Drawing.Size(57, 23);
            this.btnColorSelect.TabIndex = 3;
            this.btnColorSelect.Text = "رنگ";
            this.btnColorSelect.UseVisualStyleBackColor = true;
            this.btnColorSelect.Click += new System.EventHandler(this.btnColorSelect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRefresh.Location = new System.Drawing.Point(23, 83);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "بازیابی(F9)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnNew.Location = new System.Drawing.Point(345, 83);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(89, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "جدید(INSERT)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUpdate.Location = new System.Drawing.Point(229, 83);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "به روز رسانی(F10)";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = "   ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 291);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(459, 22);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDelete.Location = new System.Drawing.Point(126, 83);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "حذف(DELETE)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtInsuranceType
            // 
            this.txtInsuranceType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtInsuranceType.Location = new System.Drawing.Point(79, 13);
            this.txtInsuranceType.Name = "txtInsuranceType";
            this.txtInsuranceType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtInsuranceType.Size = new System.Drawing.Size(268, 21);
            this.txtInsuranceType.TabIndex = 0;
            // 
            // lblInsuranceType
            // 
            this.lblInsuranceType.AutoSize = true;
            this.lblInsuranceType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblInsuranceType.Location = new System.Drawing.Point(353, 16);
            this.lblInsuranceType.Name = "lblInsuranceType";
            this.lblInsuranceType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInsuranceType.Size = new System.Drawing.Size(52, 13);
            this.lblInsuranceType.TabIndex = 8;
            this.lblInsuranceType.Text = "نوع بیمه :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDaysBeforExp);
            this.groupBox1.Controls.Add(this.pnlColor);
            this.groupBox1.Controls.Add(this.lblDaysBeforExp);
            this.groupBox1.Controls.Add(this.btnColorSelect);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.txtInsuranceType);
            this.groupBox1.Controls.Add(this.lblInsuranceType);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(0, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(457, 112);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "عملیات";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.radif,
            this.caption,
            this.DAYSBEFOREXP,
            this.INSURANCETYPECOLOR,
            this.ID});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(459, 179);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged_1);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // radif
            // 
            this.radif.HeaderText = "ردیف";
            this.radif.Name = "radif";
            this.radif.ReadOnly = true;
            this.radif.Width = 50;
            // 
            // caption
            // 
            this.caption.HeaderText = "نوع بیمه";
            this.caption.Name = "caption";
            this.caption.ReadOnly = true;
            this.caption.Width = 250;
            // 
            // DAYSBEFOREXP
            // 
            this.DAYSBEFOREXP.HeaderText = "روز تا تاریخ اتمام";
            this.DAYSBEFOREXP.Name = "DAYSBEFOREXP";
            this.DAYSBEFOREXP.ReadOnly = true;
            this.DAYSBEFOREXP.Width = 150;
            // 
            // INSURANCETYPECOLOR
            // 
            this.INSURANCETYPECOLOR.HeaderText = "رنگ";
            this.INSURANCETYPECOLOR.Name = "INSURANCETYPECOLOR";
            this.INSURANCETYPECOLOR.ReadOnly = true;
            this.INSURANCETYPECOLOR.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ایندکس جدول";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // insuranceTypeData1
            // 
            this.insuranceTypeData1.DataSetName = "NewDataSet";
            // 
            // InsuranceTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 313);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsuranceTypeForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نوع بیمه";
            this.Load += new System.EventHandler(this.InsuranceTypeForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InsuranceTypeForm_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.insuranceTypeData1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbDaysBeforExp;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Label lblDaysBeforExp;
        private System.Windows.Forms.Button btnColorSelect;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtInsuranceType;
        private System.Windows.Forms.Label lblInsuranceType;
        private System.Windows.Forms.GroupBox groupBox1;
        private Insurance_Common.InsuranceTypeData insuranceTypeData1;
        private System.Windows.Forms.DataGridViewTextBoxColumn radif;
        private System.Windows.Forms.DataGridViewTextBoxColumn caption;
        private System.Windows.Forms.DataGridViewTextBoxColumn DAYSBEFOREXP;
        private System.Windows.Forms.DataGridViewTextBoxColumn INSURANCETYPECOLOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        
    }
}