using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Insurance_Common;
using Insurance_BLL;
using RMX_TOOLS.data;
using RMX_TOOLS.data.grid;
using Insurance.sms;
using System.Threading;
using System.Collections;

namespace Insurance
{
    public partial class MainForm : Form
    {
        public static MainForm MainFormInstance;
        private string _currentInsuranceNumber = null;
        private string _settingFile = Application.StartupPath + "\\MainFormGridAdjust.xml";
        public SqlServerSettingCheckBS _sqlServerSettingCheckBS = new SqlServerSettingCheckBS();
        private GridTools _gridTools;
        private string _title = "  کنترل اطلاعات بیمه ";
        public MainForm()
        {
            InitializeComponent();
            MainFormInstance = this;
            _gridTools = new GridTools(dataGridView1);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        public void LoadForm()
        {
            // TODO: This line of code loads data into the 'insuranceDataSet1.VIEW_INSURANCEINFO' table. You can move, or remove it, as needed.
            //this.vIEW_INSURANCEINFOTableAdapter.Fill(this.insuranceDataSet1.VIEW_INSURANCEINFO);

            if (RMX_TOOLS.data.Config.provider.connectionStatus == false)
            {
                MessageBox.Show("اطلاعات بانک اطلاعاتی درست تنظیم نشده");
                new settingForm().ShowDialog();
                this.Close();
            }
            LoginForm lFrm = new LoginForm();
            
            lFrm.ShowDialog();

            if (!LoginForm.Loggined)
                Application.Exit();
            else
            {
                this.Text = _title + "(" + UsersBS.loginedUser.ToString() + ")";
                // load 
                FormsAdjusting.loadGridSetting(_settingFile, dataGridView1);

                fillGrid();
                settingForm.loadPublicSettingToHashTable();

                // CHECK JOB exist
                runAgent();
                // RUN Timer 
                String s = settingForm._ht["cmbScheduleForRefresh"].ToString();
                int interval = -1;
                try
                {
                    interval = int.Parse(s);
                }
                catch (Exception ex)
                {
                    interval = 10;
                }
                if (interval == -1)
                    interval = 10;

                timer1.Interval = interval * (1000 * 60);
                timer1.Enabled = true;
            }
            //enable or diable confirm button Button1
            confirmButtonavailability();
        }

        public void confirmButtonavailability()
        {
            if (UsersBS.loginedUser == null)
                return;
            button1.Enabled = true;
            UsersAccessBS uabs = new UsersAccessBS();
            int userid = int.Parse(UsersBS.loginedUser.Tables[0].Rows[0][UsersData.id_FIELD].ToString());
            int userType = int.Parse(UsersBS.loginedUser.Tables[0].Rows[0][UsersData.userType_FIELD].ToString());
            if (userType == 1)
            {
                UsersAccessData uaData = uabs.load(userid);
                if (uaData == null || uaData.Tables.Count <= 0 || uaData.Tables[0].Rows.Count <= 0)
                    button1.Enabled = false;
                else
                {
                    button1.Enabled = bool.Parse(uaData.Tables[0].Rows[0][UsersAccessData.accessToArchive_FIELD].ToString());
                }

            }

        }
        private void runAgent()
        {
            int n = _sqlServerSettingCheckBS.runAgent();
            //if (n == 0)
            // {
            //MessageBox.Show("SQL Server Agent not Runing please strat this program");
            // }
        }

        public void msDoAgantsJobDirectly()
        {
           // _sqlServerSettingCheckBS.msDoAgantsJobDirectly();
        }

        private void selectCurrentRow()
        {
            


            if (dataGridView1.RowCount <= 0)
                return;
            if (_currentInsuranceNumber == null)
                return;
            string val;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = true;
                val = dataGridView1.CurrentRow.Cells[ViewInsuranceInfoData.insuranceNumber_FIELD].Value.ToString().Trim();
                if (_currentInsuranceNumber.Equals(val))
                    return;
            }

        }

        public static DataSet getDataSet() {
            string condition = " haveDid = 0 ";
            condition += " and enddate - daysbeforExp < getdate() ";
            string orderBy = "enddate";
            int userId = int.Parse(UsersBS.loginedUser.Tables[0].Rows[0][UsersData.id_FIELD].ToString());

            return new ViewInsuranceInfoBS().loadUserLimitedList(userId, condition, orderBy);

        }

        public void fillGrid()
        {
            if (LoginForm.Loggined == false)
                return;
            System.Collections.Hashtable hash = new System.Collections.Hashtable();
            hash.Add("colorField", InsuranceTypeData.INSURANCETYPECOLOR_FIELD);

            
            _gridTools.bindDataToGrid(dataGridView1,
                    getDataSet(),
                    ViewInsuranceInfoData.VIEW_INSURANCEINFO_TABLE, _gridTools.changeColor, hash);
            
            
             
            DateTime t = DateTime.Now;
            lblTime.Text = t.Hour + ":" + t.Minute + ":" + t.Second;
            selectCurrentRow();
        }

        private void InsuranceInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InsuranceInfoForm().ShowDialog();
        }

        private void ToolStripMenuItemsearch_Click(object sender, EventArgs e)
        {
            new InsuranceInfoSearchForm2().ShowDialog();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InsuranceInfoSearchForm().ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InsuranceTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InsuranceTypeForm().ShowDialog();
        }

        private void ServerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new settingForm().ShowDialog();
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UserForm().ShowDialog();
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InsuranceTypePermisionsFrm().ShowDialog();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
          //  if (LoginForm._loggined)
         //       fillGrid();
        }

        private void ReportFromList_Click(object sender, EventArgs e)
        {

            //security check()
            LoginForm.CheckJustManager = true;
            LoginForm lFrm = new LoginForm();
            lFrm.ShowDialog();

            if (!LoginForm.Loggined)
                return;
            LoginForm.CheckJustManager = false;
            
            DataSet ds = (DataSet)dataGridView1.DataSource;
            ds = (DataSet)dataGridView1.DataSource;

            ReportFrm rf = new ReportFrm();
            //rf._dataSet = (RMX_TOOLS.common.AbstractCommonData)ds;
            rf.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void recoveredDeletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RecoverDeletedFrm().ShowDialog();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                fillGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string insNo = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.insuranceNumber_FIELD).ToString();
            int id =(int) _gridTools.getCurrentRowValue(ViewInsuranceInfoData.id_FIELD);
            InsuranceInfoForm1 insFrm = new InsuranceInfoForm1();
            _currentInsuranceNumber = insNo;
            insFrm._id = id;
            insFrm.ShowDialog();
            if (insFrm.isDeleted)
            {
                MainForm.MainFormInstance.fillGrid();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int rowCount = dataGridView1.RowCount;
            Boolean[] b = new Boolean[rowCount];
            int[] id = new int[rowCount];
            string[] dateTime = new string[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                //dataGridView1.Rows[i].Selected = true;
                
                b[i] = Boolean.Parse(_gridTools.getValueByRowIndex(i, ViewInsuranceInfoData.haveDid_FIELD).ToString().Trim());
                id[i] = int.Parse(_gridTools.getValueByRowIndex(i, ViewInsuranceInfoData.id_FIELD).ToString());
                dateTime[i] = RMX_TOOLS.date.DateXFormer.persianToGreGorian(_gridTools.getValueByRowIndex(i, ViewInsuranceInfoData.endDate_FIELD).ToString()).ToString();
            }
            string v = settingForm._ht[settingForm.cbxShowConfirmDialog_Alias].ToString();
            Boolean b1 = Boolean.Parse(v);
            if (b1)
            {
                DialogResult dialog = MessageBox.Show("اطلاعات تغییر داده شده ذخیره شوند ؟", "",
                    MessageBoxButtons.YesNo);
                if (dialog == DialogResult.No)
                    return;
            }
            InsuranceInfoBS insBs = new InsuranceInfoBS();
            bool ok = false;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i])
                {
                    addLog(id[i], dateTime[i]);
                    insBs.updateHaveDid(id[i], true);
                    ok = true;
                }
            }
            if (ok)
            {
                fillGrid();
                msDoAgantsJobDirectly();
            }
        }

        public void addLog(int insuranceInfoId, string endDateStr)
        {

            DateTime dt = DateTime.Now;
            int userId = int.Parse(UsersBS.loginedUser.Tables[0].Rows[0][UsersData.id_FIELD].ToString());

            HaveDidLogData inData = new HaveDidLogData();
            DataRow dr = inData.Tables[HaveDidLogData.TABLE_NAME].NewRow();
            dr[HaveDidLogData.INSURANCEINFOID_FIELD] = insuranceInfoId;
            dr[HaveDidLogData.CHECKEDUSER_FIELD] = userId;
            dr[HaveDidLogData.CHECKEDDATE_FIELD] = dt;
            dr[HaveDidLogData.LOGGEDENDDATE_FIELD] = endDateStr;
            inData.Tables[HaveDidLogData.TABLE_NAME].Rows.Add(dr);
            new HaveDidLogBS().add(inData);

        }

        private void ToolStripMenuItemadust_Click(object sender, EventArgs e)
        {
            FormsAdjusting formsAdjusting = new FormsAdjusting();
            formsAdjusting._fileName = _settingFile;
            formsAdjusting._formDataGridView = dataGridView1;
            formsAdjusting.ShowDialog();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1_CellDoubleClick(null, null);
                e.Handled = true;
            }
        }

        private void mnuChangeUser_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.ShowDialog();
            string i = UsersBS.loginedUser.Tables[0].Rows[0][UsersData.name_FIELD].ToString();
            this.Text = _title + "(" + UsersBS.loginedUser.ToString() + ")";
            confirmButtonavailability();
            fillGrid();
            settingForm.loadPublicSettingToHashTable();

        }

        private void UsersAccess_Click(object sender, EventArgs e)
        {
            UserAccessForm form = new UserAccessForm();
            form.ShowDialog();
        }

        private void mnuSendSmsTemplate_Click(object sender, EventArgs e)
        {
            SMSTemplateDefinition smsTemplate = new SMSTemplateDefinition();
            smsTemplate.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                btnRefresh.Enabled = false;
                fillGrid();
                btnRefresh.Enabled = true;
            }));
        }

        private void btnSendSms_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection rows = dataGridView1.Rows;
            if (rows.Count == 0)
            {
                return;
            }
            ArrayList ids = new ArrayList();
            for(int i = 0; i < dataGridView1.Rows.Count; i++) 
            {
                bool smsSend = (bool)dataGridView1.Rows[i].Cells[3].Value;
                if (smsSend)
                {
                    ids.Add((int)dataGridView1.Rows[i].Cells[8].Value);
                }
            }
            
            SmsSelectedListForm form = new SmsSelectedListForm(ids);
            form.ShowDialog();

        }

        private void InsuranceInfoToolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            new InsuranceInfoForm1().ShowDialog();
        }
    }
}