namespace Insurance
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.InsuranceInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemsearch = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تنظیماتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InsuranceTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsersAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.recoveredDeletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemadust = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportFromList = new System.Windows.Forms.ToolStripMenuItem();
            this.ارسالپیامToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSendSmsTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Exp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.haveDid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SmsSend = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Family = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsuranceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insuranceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancetypeColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysBeforExp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shamsidate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beginDate_shamsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSendSms = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.InsuranceInfoToolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.تنظیماتToolStripMenuItem,
            this.ارسالپیامToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1027, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsuranceInfoToolStripMenuItemNew,
            this.InsuranceInfoToolStripMenuItem,
            this.ToolStripMenuItemsearch,
            this.searchToolStripMenuItem,
            this.mnuChangeUser,
            this.ExitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
            this.toolStripMenuItem1.Text = "بیمه";
            // 
            // InsuranceInfoToolStripMenuItem
            // 
            this.InsuranceInfoToolStripMenuItem.Name = "InsuranceInfoToolStripMenuItem";
            this.InsuranceInfoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.InsuranceInfoToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.InsuranceInfoToolStripMenuItem.Text = "اطلاعات بیمه";
            this.InsuranceInfoToolStripMenuItem.Click += new System.EventHandler(this.InsuranceInfoToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemsearch
            // 
            this.ToolStripMenuItemsearch.Name = "ToolStripMenuItemsearch";
            this.ToolStripMenuItemsearch.Size = new System.Drawing.Size(243, 22);
            this.ToolStripMenuItemsearch.Text = "لیست  انجام شده ها ";
            this.ToolStripMenuItemsearch.Click += new System.EventHandler(this.ToolStripMenuItemsearch_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.searchToolStripMenuItem.Text = "جستجوی پیشرفته اطلاعات بیمه";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // mnuChangeUser
            // 
            this.mnuChangeUser.Name = "mnuChangeUser";
            this.mnuChangeUser.Size = new System.Drawing.Size(243, 22);
            this.mnuChangeUser.Text = "تغییر کاربر";
            this.mnuChangeUser.Click += new System.EventHandler(this.mnuChangeUser_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.ExitToolStripMenuItem.Text = "خروج";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // تنظیماتToolStripMenuItem
            // 
            this.تنظیماتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsuranceTypeToolStripMenuItem,
            this.ServerInfoToolStripMenuItem,
            this.UsersToolStripMenuItem,
            this.LoginToolStripMenuItem,
            this.UsersAccess,
            this.recoveredDeletedToolStripMenuItem,
            this.ToolStripMenuItemadust,
            this.reportToolStripMenuItem});
            this.تنظیماتToolStripMenuItem.Name = "تنظیماتToolStripMenuItem";
            this.تنظیماتToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.تنظیماتToolStripMenuItem.Text = "تنظیمات";
            // 
            // InsuranceTypeToolStripMenuItem
            // 
            this.InsuranceTypeToolStripMenuItem.Name = "InsuranceTypeToolStripMenuItem";
            this.InsuranceTypeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.InsuranceTypeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.InsuranceTypeToolStripMenuItem.Text = "نوع بیمه";
            this.InsuranceTypeToolStripMenuItem.Click += new System.EventHandler(this.InsuranceTypeToolStripMenuItem_Click);
            // 
            // ServerInfoToolStripMenuItem
            // 
            this.ServerInfoToolStripMenuItem.Name = "ServerInfoToolStripMenuItem";
            this.ServerInfoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.ServerInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ServerInfoToolStripMenuItem.Text = "تنظیمات";
            this.ServerInfoToolStripMenuItem.Click += new System.EventHandler(this.ServerInfoToolStripMenuItem_Click);
            // 
            // UsersToolStripMenuItem
            // 
            this.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem";
            this.UsersToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.UsersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.UsersToolStripMenuItem.Text = "کاربران";
            this.UsersToolStripMenuItem.Click += new System.EventHandler(this.UsersToolStripMenuItem_Click);
            // 
            // LoginToolStripMenuItem
            // 
            this.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem";
            this.LoginToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.LoginToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.LoginToolStripMenuItem.Text = "دسترسی بیمه";
            this.LoginToolStripMenuItem.Click += new System.EventHandler(this.LoginToolStripMenuItem_Click);
            // 
            // UsersAccess
            // 
            this.UsersAccess.Name = "UsersAccess";
            this.UsersAccess.Size = new System.Drawing.Size(180, 22);
            this.UsersAccess.Text = "دسترسی کاربران";
            this.UsersAccess.Click += new System.EventHandler(this.UsersAccess_Click);
            // 
            // recoveredDeletedToolStripMenuItem
            // 
            this.recoveredDeletedToolStripMenuItem.Name = "recoveredDeletedToolStripMenuItem";
            this.recoveredDeletedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.recoveredDeletedToolStripMenuItem.Text = "بازگرداندن حذف شده";
            this.recoveredDeletedToolStripMenuItem.Click += new System.EventHandler(this.recoveredDeletedToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemadust
            // 
            this.ToolStripMenuItemadust.Name = "ToolStripMenuItemadust";
            this.ToolStripMenuItemadust.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemadust.Text = "تنظیم فرم آلارم";
            this.ToolStripMenuItemadust.Click += new System.EventHandler(this.ToolStripMenuItemadust_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportFromList});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reportToolStripMenuItem.Text = "گزارش";
            // 
            // ReportFromList
            // 
            this.ReportFromList.Name = "ReportFromList";
            this.ReportFromList.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.ReportFromList.Size = new System.Drawing.Size(199, 22);
            this.ReportFromList.Text = "گزارش  از لیست موجود";
            this.ReportFromList.Click += new System.EventHandler(this.ReportFromList_Click);
            // 
            // ارسالپیامToolStripMenuItem
            // 
            this.ارسالپیامToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSendSmsTemplate});
            this.ارسالپیامToolStripMenuItem.Name = "ارسالپیامToolStripMenuItem";
            this.ارسالپیامToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ارسالپیامToolStripMenuItem.Text = "ارسال پیام";
            this.ارسالپیامToolStripMenuItem.Visible = false;
            // 
            // mnuSendSmsTemplate
            // 
            this.mnuSendSmsTemplate.Name = "mnuSendSmsTemplate";
            this.mnuSendSmsTemplate.Size = new System.Drawing.Size(198, 22);
            this.mnuSendSmsTemplate.Text = "تنظیم الگو جهت ارسال پیام";
            this.mnuSendSmsTemplate.Click += new System.EventHandler(this.mnuSendSmsTemplate_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(10, 13, 13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1027, 549);
            this.panel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1005, 484);
            this.panel3.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Exp,
            this.radif,
            this.haveDid,
            this.SmsSend,
            this.name,
            this.Family,
            this.InsuranceNumber,
            this.caption,
            this.id,
            this.insuranceType,
            this.BeginDate,
            this.endDate,
            this.phoneNumber,
            this.insurancetypeColor,
            this.DaysBeforExp,
            this.shamsidate,
            this.description,
            this.address,
            this.beginDate_shamsi});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1005, 484);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // Exp
            // 
            this.Exp.HeaderText = "Exp";
            this.Exp.Name = "Exp";
            this.Exp.ReadOnly = true;
            this.Exp.Width = 50;
            // 
            // radif
            // 
            this.radif.HeaderText = "ردیف";
            this.radif.Name = "radif";
            this.radif.ReadOnly = true;
            this.radif.Width = 40;
            // 
            // haveDid
            // 
            this.haveDid.HeaderText = "انجام شده";
            this.haveDid.Name = "haveDid";
            this.haveDid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.haveDid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SmsSend
            // 
            this.SmsSend.HeaderText = "ارسال پیام";
            this.SmsSend.Name = "SmsSend";
            // 
            // name
            // 
            this.name.HeaderText = "نام";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Family
            // 
            this.Family.HeaderText = "نام خانوادگی";
            this.Family.Name = "Family";
            this.Family.ReadOnly = true;
            this.Family.Width = 130;
            // 
            // InsuranceNumber
            // 
            this.InsuranceNumber.HeaderText = "شماره بیمه";
            this.InsuranceNumber.Name = "InsuranceNumber";
            this.InsuranceNumber.ReadOnly = true;
            // 
            // caption
            // 
            this.caption.HeaderText = "نوع بیمه";
            this.caption.Name = "caption";
            this.caption.ReadOnly = true;
            this.caption.Width = 150;
            // 
            // id
            // 
            this.id.HeaderText = "ایندکس جدول";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // insuranceType
            // 
            this.insuranceType.HeaderText = "کد نوع بیمه";
            this.insuranceType.Name = "insuranceType";
            this.insuranceType.ReadOnly = true;
            this.insuranceType.Visible = false;
            // 
            // BeginDate
            // 
            this.BeginDate.HeaderText = "تاریخ شروع میلادی";
            this.BeginDate.Name = "BeginDate";
            this.BeginDate.ReadOnly = true;
            this.BeginDate.Visible = false;
            // 
            // endDate
            // 
            this.endDate.HeaderText = "تاریخ اتمام میلادی";
            this.endDate.Name = "endDate";
            this.endDate.ReadOnly = true;
            this.endDate.Visible = false;
            // 
            // phoneNumber
            // 
            this.phoneNumber.HeaderText = "شماره تلفن";
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.ReadOnly = true;
            this.phoneNumber.Width = 90;
            // 
            // insurancetypeColor
            // 
            this.insurancetypeColor.HeaderText = "رنگ نوع بیمه";
            this.insurancetypeColor.Name = "insurancetypeColor";
            this.insurancetypeColor.ReadOnly = true;
            this.insurancetypeColor.Visible = false;
            // 
            // DaysBeforExp
            // 
            this.DaysBeforExp.HeaderText = "روز مانده به اتمام";
            this.DaysBeforExp.Name = "DaysBeforExp";
            this.DaysBeforExp.ReadOnly = true;
            this.DaysBeforExp.Visible = false;
            // 
            // shamsidate
            // 
            this.shamsidate.HeaderText = "تاریخ اتمام";
            this.shamsidate.Name = "shamsidate";
            this.shamsidate.ReadOnly = true;
            this.shamsidate.Width = 110;
            // 
            // description
            // 
            this.description.HeaderText = "شرح";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 150;
            // 
            // address
            // 
            this.address.HeaderText = "آدرس";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // beginDate_shamsi
            // 
            this.beginDate_shamsi.HeaderText = "تاریخ شروع";
            this.beginDate_shamsi.Name = "beginDate_shamsi";
            this.beginDate_shamsi.ReadOnly = true;
            this.beginDate_shamsi.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.lblTime);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.panel2.Location = new System.Drawing.Point(10, 494);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 43);
            this.panel2.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSendSms);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(630, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 43);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnSendSms
            // 
            this.btnSendSms.Location = new System.Drawing.Point(22, 14);
            this.btnSendSms.Name = "btnSendSms";
            this.btnSendSms.Size = new System.Drawing.Size(90, 23);
            this.btnSendSms.TabIndex = 4;
            this.btnSendSms.Tag = "ارسال پیام";
            this.btnSendSms.Text = "ارسال پیام";
            this.btnSendSms.UseVisualStyleBackColor = true;
            this.btnSendSms.Visible = false;
            this.btnSendSms.Click += new System.EventHandler(this.btnSendSms_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(119, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Tag = "باز خوانی لیست";
            this.btnRefresh.Text = "باز خوانی لیست";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 2;
            this.button1.Tag = "اعمال انجام شده ";
            this.button1.Text = "تمدید به مدت یک سال ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblTime
            // 
            this.lblTime.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTime.Location = new System.Drawing.Point(4, 6);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(98, 13);
            this.lblTime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "زمان آخرین به روز رسانی :";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // InsuranceInfoToolStripMenuItemNew
            // 
            this.InsuranceInfoToolStripMenuItemNew.Name = "InsuranceInfoToolStripMenuItemNew";
            this.InsuranceInfoToolStripMenuItemNew.Size = new System.Drawing.Size(243, 22);
            this.InsuranceInfoToolStripMenuItemNew.Text = "اطلاعات بیمه جدید";
            this.InsuranceInfoToolStripMenuItemNew.Click += new System.EventHandler(this.InsuranceInfoToolStripMenuItemNew_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1027, 573);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "  کنترل اطلاعات بیمه";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem InsuranceInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemsearch;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تنظیماتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InsuranceTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ServerInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recoveredDeletedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemadust;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportFromList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeUser;
        private System.Windows.Forms.ToolStripMenuItem UsersAccess;
        private System.Windows.Forms.ToolStripMenuItem ارسالپیامToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSendSmsTemplate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSendSms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exp;
        private System.Windows.Forms.DataGridViewTextBoxColumn radif;
        private System.Windows.Forms.DataGridViewCheckBoxColumn haveDid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SmsSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Family;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsuranceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn caption;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn insuranceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancetypeColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysBeforExp;
        private System.Windows.Forms.DataGridViewTextBoxColumn shamsidate;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn beginDate_shamsi;
        private System.Windows.Forms.ToolStripMenuItem InsuranceInfoToolStripMenuItemNew;
    }
}