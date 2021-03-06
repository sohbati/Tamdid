using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Insurance_Common;
using Insurance_BLL;
using RMX_TOOLS.date;
using System.Collections;
using System.Globalization;
using RMX_TOOLS.converter;
using RMX_TOOLS.data.grid;
using System.Text.RegularExpressions;

namespace Insurance
{
    public partial class InsuranceInfoForm : Form
    {
        public String preEnteredInsuranceNumber = null;
        public int _id;
        string _settingFileName = Application.StartupPath + "\\InformationFormAdjust.xml";
        private Hashtable _searchMap = new Hashtable();
        string _searchField = "";
        private const string NEW_MODE = "new";
        private const string EDIT_MODE = "edit";
        private const string DELETE_MODE = "delete";
        private GridTools _gridTools;
        private DataSet _dataSource;
        private string dataMode = EDIT_MODE;

        RMX_TOOLS.date.DatePicker _datePicker = new RMX_TOOLS.date.DatePicker();

        public InsuranceInfoForm()
        {
            InitializeComponent();
            _gridTools = new GridTools(dataGridView1);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            txtName.Focus();
            dataMode = NEW_MODE;
            emptyForm();
            newModeRestricts();
        }

        private void emptyForm()
        {
            txtName.Text = "";
            txtFamily.Text = "";
            txtPhoneNumber.Text = "";
            txtInsuranceNumber.Text = "";
            txtBeginDate.Text = "";
            txtEndDate.Text = "";
            cbxHaveDid.Checked = false;
            cmbInsuranceType.Text = "";
            txtAddress.Text = "";
            txtDescription.Text = "";
            lblMsg.Text = "";

            cmbInsuranceType.Text = "";
            txtMobilePhone.Text = "";
            txtBirthDate.Text = "";
        }

        private string checkData()
        {
            string tmp;
            tmp = txtName.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
            {
                txtName.Focus();
                return "لطفا نام را وارد کنید";
            }
            tmp = txtFamily.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
            {
                txtFamily.Focus();
                return "لطفا نام خانوادگی را وارد کنید";
            }
            tmp = txtInsuranceNumber.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
            {
                txtInsuranceNumber.Focus();
                return "لطفا شماره بیمه را وارد کنید";
            }
            if (cmbInsuranceType.SelectedIndex < 0)
            {
                cmbInsuranceType.Focus();
                return "لطفا نوع بیمه را وارد کنید";
            }
            if (txtBeginDate.Text.Trim().Length <= 0)
            {
                txtBeginDate.Focus();
                return "لطفا تاریخ شروع را وارد کنید";
            }
            if (!CheckDate.checkDate(txtBeginDate.Text))
            {
                txtBeginDate.Focus();
                return "تاریخ شروع معتبر نیست";
            }
            if (txtEndDate.Text.Trim().Length <= 0)
            {
                txtEndDate.Focus();
                return "لطفا تاریخ اتمام را وارد کنید";
            }
            if (!CheckDate.checkDate(txtEndDate.Text))
            {
                txtEndDate.Focus();
                return "تاریخ اتمام معتبر نیست";
            }
            if (cmbCustomerType.SelectedIndex < 0)
            {
                return "نوع مشتری را وارد نمایید!";
            }

            string dateEmpty = "    /  /";
            //if (cmbCustomerType.SelectedIndex == 1 && txtBirthDate.Text == dateEmpty)
            //{
            //    return "برای ";
            //}
            if (txtBirthDate.Text != dateEmpty && !CheckDate.checkDate(txtBirthDate.Text))
            {
                txtBirthDate.Focus();
                return "تاریخ تولد معتبر نیست";
            }

            string mm = txtMobilePhone.Text;
            if (mm != null && mm.Length > 0)
            {
                if (mm.Length != 11)
                {
                    return "شماره موبایل وارده شده بایستی 11 رقم باشد";
                }
                if (mm.Substring(0,2) != "09")
                {
                    return "موبایل وارد شده معتبر نیست";
                }
            }
            if (cmbCustomerType.SelectedIndex == 0)
            {
              //  tmp = txtPhoneNumber.Text;
               // if (tmp == null || tmp.Trim().Length <= 0)
                //{
                 //   txtInsuranceNumber.Focus();
                //    return "شماره تلفن برای نوع مشتری حقیقی اجباری است";
                //}
                tmp = txtMobilePhone.Text;
                if (tmp == null || tmp.Trim().Length <= 0)
                {
                    txtMobilePhone.Focus();
                    return "شماره موبایل برای نوع مشتری حقیقی اجباری است";
                }
            }

            return null;
        }
         
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string check = checkData();
            if (check != null)
            {
                MessageBox.Show(check);
                return;
            }
            if (dataMode == EDIT_MODE)
            {

                if (dataGridView1.CurrentRow.Selected)
                    if (cbxHaveDid.Checked)
                        cbxHaveDid.Checked = Boolean.Parse(_gridTools.getCurrentRowValue(InsuranceInfoData.haveDid_FIELD).ToString());
            }
            if (dataMode == NEW_MODE)
                cbxHaveDid.Checked = false;
            if (dataGridView1.RowCount <= 0)
                dataMode = NEW_MODE;
            InsuranceInfoBS isb = new InsuranceInfoBS();
            InsuranceInfoData inData = new InsuranceInfoData();
            DataRow dr = inData.Tables[InsuranceInfoData.insuranceInfo_TABLE].NewRow();
            dr[InsuranceInfoData.name_FIELD] = txtName.Text.Trim();
            dr[InsuranceInfoData.family_FIELD] = txtFamily.Text.Trim();
            dr[InsuranceInfoData.phoneNumber_FIELD] = txtPhoneNumber.Text.Trim();
            dr[InsuranceInfoData.insuranceNumber_FIELD] = txtInsuranceNumber.Text.Trim();

            dr[InsuranceInfoData.haveDid_FIELD] = cbxHaveDid.Checked;
            dr[InsuranceInfoData.address_FIELD] = txtAddress.Text.Trim();
            dr[InsuranceInfoData.description_FIELD] = txtDescription.Text.Trim();

            dr[InsuranceInfoData.mobileNumber_FIELD] = txtMobilePhone.Text.Trim();
            dr[InsuranceInfoData.CustomerType_FIELD] = cmbCustomerType.SelectedIndex;

            if (!dataMode.Equals(NEW_MODE))
                dr[InsuranceInfoData.id_FIELD] = _gridTools.getCurrentRowValue(InsuranceInfoData.id_FIELD);
            // Date validation and converion 
            #region dateValidation
            GregorianCalendar gcal = new GregorianCalendar();
            int d = 12;
            int m = 0;
            int y = 0;
            CheckDate.checkDate(txtBeginDate.Text, ref y, ref m, ref d);
            DateTime persianDateDime = new DateTime(y, m, d, new PersianCalendar());
            DateTime greorianDateTime =
                new DateTime(gcal.GetYear(persianDateDime),
                             gcal.GetMonth(persianDateDime),
                             gcal.GetDayOfMonth(persianDateDime), new GregorianCalendar());

            dr[InsuranceInfoData.beginDate_FIELD] = greorianDateTime;

            //
            CheckDate.checkDate(txtEndDate.Text, ref y, ref m, ref d);
            persianDateDime = new DateTime(y, m, d, new PersianCalendar());
            greorianDateTime =
                new DateTime(gcal.GetYear(persianDateDime),
                             gcal.GetMonth(persianDateDime),
                             gcal.GetDayOfMonth(persianDateDime), new GregorianCalendar());

            dr[InsuranceInfoData.endDate_FIELD] = greorianDateTime;
            //

            //Creation Date
            String todayShamsi;
            String[] dateArr;
            CheckDate.checkDate(txtCreationDate.Text, ref y, ref m, ref d);
            if (dataMode.Equals(NEW_MODE))
            {
                todayShamsi = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Now);
                dateArr = todayShamsi.Split('/');

                persianDateDime = new DateTime(int.Parse(dateArr[0]),
                        int.Parse(dateArr[1]),
                        int.Parse(dateArr[2]), new PersianCalendar());
            }
            else
                persianDateDime = new DateTime(y, m, d, new PersianCalendar());
            greorianDateTime =
                new DateTime(gcal.GetYear(persianDateDime),
                             gcal.GetMonth(persianDateDime),
                             gcal.GetDayOfMonth(persianDateDime), new GregorianCalendar());

            dr[InsuranceInfoData.creationDate_FIELD] = greorianDateTime;
            //
            //Last update date
            todayShamsi = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Now);
            dateArr = todayShamsi.Split('/');
             
            persianDateDime = new DateTime(int.Parse(dateArr[0]) ,
                    int.Parse(dateArr[1]),
                    int.Parse(dateArr[2]), new PersianCalendar());
            greorianDateTime =
                new DateTime(gcal.GetYear(persianDateDime),
                             gcal.GetMonth(persianDateDime),
                             gcal.GetDayOfMonth(persianDateDime), new GregorianCalendar());

            dr[InsuranceInfoData.lastUpdateDate_FIELD] = greorianDateTime;
            //
            //Birth date
            if (txtBirthDate.Text.Trim() != DateConstants.NULL_Date.Trim())
            {
                CheckDate.checkDate(txtBirthDate.Text, ref y, ref m, ref d);
                persianDateDime = new DateTime(y, m, d, new PersianCalendar());
                greorianDateTime =
                    new DateTime(gcal.GetYear(persianDateDime),
                                 gcal.GetMonth(persianDateDime),
                                 gcal.GetDayOfMonth(persianDateDime), new GregorianCalendar());

                dr[InsuranceInfoData.BirthDate_FIELD] = greorianDateTime;
            }
            #endregion

            //fetch id from comboBox
            int id = int.Parse(cmbInsuranceType.SelectedValue + "");
            dr[InsuranceInfoData.insuranceType_FIELD] = id;
            string insuranceNumber = txtInsuranceNumber.Text.Trim();
            inData.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows.Add(dr);
            try
            {
                int index;
                if (dataMode == NEW_MODE)
                    index = -1;
                else
                    index = int.Parse(_gridTools.getCurrentRowValue(InsuranceInfoData.id_FIELD).ToString());
                if (isb.checkInsuranceNumberExists(txtInsuranceNumber.Text.Trim(), index))
                {
                    MessageBox.Show("امکان اضافه کردن این رکورد وجود ندارد ، شماره بیمه تکراری است");
                    txtInsuranceNumber.Focus();
                    return;
                }

                if (dataMode.Equals(NEW_MODE))
                {


                    isb.add(inData);
                    InsuranceInfoData iData = isb.getByInsuranceNumer(txtInsuranceNumber.Text.Trim());
                    if (iData.Tables[0].Rows.Count > 0)
                        addlog(cbxHaveDid.Checked, int.Parse(iData.Tables[0].Rows[0][InsuranceInfoData.id_FIELD].ToString()),
                            iData.Tables[0].Rows[0][InsuranceInfoData.endDate_FIELD].ToString());
                }
                else if (dataMode.Equals(EDIT_MODE))
                {
                    if (cbxHaveDid.Checked)
                        checkForLogging(int.Parse(_gridTools.getCurrentRowValue(InsuranceInfoData.id_FIELD).ToString()),
                            _gridTools.getCurrentRowValue(InsuranceInfoData.endDate_FIELD).ToString());
                    isb.update(inData);
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                if (s.IndexOf("duplicate") >= 0)
                {
                    MessageBox.Show("امکان اضافه کردن این رکورد وجود ندارد ، شماره بیمه تکراری است");
                    txtInsuranceNumber.Focus();
                }
                else
                    MessageBox.Show(ex.ToString());
                return;
            }

            btnRefresh_Click(null, null);

            MainForm.MainFormInstance.fillGrid();

            int addedRow = searcInGrid(insuranceNumber);
            if (addedRow == -1)
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount -1].Cells[0];
            else
                dataGridView1.CurrentCell = dataGridView1.Rows[addedRow].Cells[0];
            dataGridView1_SelectionChanged(null, null);

            dataMode = EDIT_MODE;
            fillSearchMap();
            MainForm.MainFormInstance.msDoAgantsJobDirectly();
            //frmMain.msDoAgantsJobDirectly();
        }

        private void checkForLogging(int insuranceInfoId, string endDateStr)
        {
            InsuranceInfoBS insBS = new InsuranceInfoBS();
            InsuranceInfoData insData = insBS.getById(insuranceInfoId);
            if (insData.Tables[0].Rows.Count > 0)
            {
                Boolean haveDid = Boolean.Parse(insData.Tables[0].Rows[0][InsuranceInfoData.haveDid_FIELD].ToString());
                if (haveDid == false)
                    addlog(true, insuranceInfoId, endDateStr);
            }
        }

        private void addlog(Boolean isHaveDidChecked, int insID, string endDateStr)
        {
            if (isHaveDidChecked)
                MainForm.MainFormInstance.addLog(insID, endDateStr);
        }

        private void gotoRow(string insuranceNumber)
        {
            if (insuranceNumber == null)
                return;

            int addedRow = searcInGrid(insuranceNumber);
            if (addedRow == -1)
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
            else
                dataGridView1.CurrentCell = dataGridView1.Rows[addedRow].Cells[0];
            dataGridView1_SelectionChanged(null, null);

            dataMode = EDIT_MODE;

        }

        /*
         *@Return row number of grid
         *@Param insurance Number
         */
        private int searcInGrid(string insNum)
        {
            if (dataGridView1.RowCount <= 0)
                return -1;
            string val;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = true;
                val = _gridTools.getValueByRowIndex(i, ViewInsuranceInfoData.insuranceNumber_FIELD).ToString().Trim();
                
                if (insNum.Equals(val))
                    return i;
            }
            return -1;
        }

        private void InsuranceInfoForm_Load(object sender, EventArgs e)
        {

            fillGrid();
            dataGridView1_SelectionChanged(null, null);
            string y = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Today);
            fillInsuranceTypeCmboBox();

            //
            // LANGAUGE CHANGEING TO PERSIAN
            InputLanguage persinLanguage = InputLanguage.CurrentInputLanguage;
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Equals("Farsi"))
                    persinLanguage = InputLanguage.InstalledInputLanguages[i];
            InputLanguage.CurrentInputLanguage = persinLanguage;
            gotoRow(preEnteredInsuranceNumber);
            fillSearchMap();

            confirmButtonavailability();
            getAttachmentCount();
        }

        private void getAttachmentCount()
        {
            AttachmentBL abl = new AttachmentBL();
            int count = abl.getCount(_id);
            linkAttachment.Text = " ضمائم  " + "("+ count + ")";
        }

        private void fillInsuranceTypeCmboBox()
        {

            InsuranceTypeData dataSet = new InsuranceTypeBS().userLimitedList();
            cmbInsuranceType.DataSource = dataSet.Tables[InsuranceTypeData.InsuranceType_TABLE];
            cmbInsuranceType.DisplayMember = InsuranceTypeData.InsuranceCaption_FIELD;
            cmbInsuranceType.ValueMember = InsuranceTypeData.InsuranceId_FIELD;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //security check()
            LoginForm.CheckJustManager = true;
            LoginForm lFrm = new LoginForm();
            lFrm.ShowDialog();

            if (!LoginForm.Loggined)
                return;
            LoginForm.CheckJustManager = false;

            string val = _gridTools.getCurrentRowValue(InsuranceInfoData.id_FIELD) + "";
            if (val == null || val.Trim().Length <= 0)
                return;
            DialogResult dr = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
            if (dr.Equals(DialogResult.Yes))
            {
                int id = int.Parse(_gridTools.getCurrentRowValue(InsuranceInfoData.id_FIELD) + "");
                new InsuranceInfoBS().delete(id);
                emptyForm();
                fillGrid();
                MainForm.MainFormInstance.fillGrid();
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.id_FIELD) != null)
            {
                _id = (int)_gridTools.getCurrentRowValue(ViewInsuranceInfoData.id_FIELD);
            }
            IConverter converter = new DateConverter();
            IConverter booleanConverter = new RMX_TOOLS.converter.BooleanConverter();
            if (_gridTools.getCurrentRowValue(InsuranceInfoData.name_FIELD) != null)
                txtName.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.name_FIELD).ToString().Trim();

            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.family_FIELD) != null)
                txtFamily.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.family_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.phoneNumber_FIELD) != null)
                txtPhoneNumber.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.phoneNumber_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.insuranceNumber_FIELD) != null)
                txtInsuranceNumber.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.insuranceNumber_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.caption_FIELD) != null)
                cmbInsuranceType.SelectedText = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.caption_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.insuranceType_FIELD) != null)
                cmbInsuranceType.SelectedValue = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.insuranceType_FIELD);

            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.beginDate_FIELD) != null)
                //txtBeginDate.Text = converter.valueToString(_gridTools.getCurrentRowValue(ViewInsuranceInfoData.beginDate_FIELD));
                txtBeginDate.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.beginDate_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.endDate_FIELD) != null)
                //txtEndDate.Text = converter.valueToString(_gridTools.getCurrentRowValue(ViewInsuranceInfoData.endDate_FIELD));
                txtEndDate.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.endDate_FIELD).ToString().Trim();
          
            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.creationDate_FIELD) != null)
                txtCreationDate.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.creationDate_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.lastUpdateDate_FIELD) != null)
                txtLastUpdateDate.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.lastUpdateDate_FIELD).ToString().Trim();

            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.haveDid_FIELD) != null)
                cbxHaveDid.Checked = Boolean.Parse(booleanConverter.valueToString(_gridTools.getCurrentRowValue(ViewInsuranceInfoData.haveDid_FIELD)));

            if (_gridTools.getCurrentRowValue(InsuranceInfoData.address_FIELD) != null)
                txtAddress.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.address_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(InsuranceInfoData.description_FIELD) != null)
                txtDescription.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.description_FIELD).ToString().Trim();

            if (_gridTools.getCurrentRowValue(InsuranceInfoData.BirthDate_FIELD) != null)
                txtBirthDate.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.BirthDate_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(InsuranceInfoData.mobileNumber_FIELD) != null)
                txtMobilePhone.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.mobileNumber_FIELD).ToString().Trim();

            cmbCustomerType.SelectedIndex = -1;
            object v = _gridTools.getCurrentRowValue(InsuranceInfoData.CustomerType_FIELD);
            if ( v != null && v.ToString().Length > 0)
                cmbCustomerType.SelectedIndex = (int)_gridTools.getCurrentRowValue(InsuranceInfoData.CustomerType_FIELD);

            getAttachmentCount();
        }

        private void newModeRestricts()
        {
            dataGridView1.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            toolStripStatusLabel1.Text = "جدید";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            btnDelete.Enabled = true;
            btnNew.Enabled = true;
            toolStripStatusLabel1.Text = "";
            dataMode = EDIT_MODE;
            fillGrid();
            fillSearchMap();

        }

        private void btnDateEnd_Click(object sender, EventArgs e)
        {
            _datePicker.showDialog(txtEndDate.Text);
            if (_datePicker._selected)
            {
                txtEndDate.Text = RMX_TOOLS.date.CheckDate.generalizeDate(_datePicker._selectedYear + "/" + _datePicker._selectedMonth + "/" +
                    _datePicker._selectedDay);

            }

        }

        private void btnDateStart_Click(object sender, EventArgs e)
        {
            _datePicker.showDialog(txtBeginDate.Text);
            if (_datePicker._selected)
            {
                txtBeginDate.Text = RMX_TOOLS.date.CheckDate.generalizeDate(_datePicker._selectedYear + "/" + _datePicker._selectedMonth + "/" +
                    _datePicker._selectedDay);
            }
        }

        private void InsuranceInfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Delete)
            {
                if (!dataMode.Equals(NEW_MODE))
                    btnDelete_Click(null, null);
            }
            if (e.KeyCode == Keys.Insert)
                btnNew_Click(null, null);
            if (e.KeyCode == Keys.F10)
                btnUpdate_Click(null, null);
            if (e.KeyCode == Keys.F9)
                btnRefresh_Click(null, null);

        }

        private void fillGrid()
        {
            fillGrid("");
        }
        private void fillGrid(string condition)
        {
            lblMsg.Text = "";
            System.Collections.Hashtable hash = new Hashtable();
            hash.Add("colorField", InsuranceTypeData.INSURANCETYPECOLOR_FIELD);

            int id = int.Parse(UsersBS.loginedUser.Tables[UsersData.users_TABLE].Rows[0][UsersData.id_FIELD].ToString());
            _dataSource = new ViewInsuranceInfoBS().loadUserLimitedList(id, condition);
            _gridTools.bindDataToGrid(dataGridView1, _dataSource
            , ViewInsuranceInfoData.VIEW_INSURANCEINFO_TABLE, new GridTools.changingRow(_gridTools.changeColor), hash);
             
        }

        private void txtInsuranceNumber_Leave(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (dataMode.Equals(NEW_MODE))
            {
                if (new InsuranceInfoBS().checkInsuranceNumberExists(txtInsuranceNumber.Text.Trim(), -1))
                    lblMsg.Text = "شماره بیمه در بانک موجود است ";
            }
        }

        private void txtInsuranceNumber_Enter(object sender, EventArgs e)
        {
            lblMsg.Text = "";

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            InsuranceInfoForm_KeyDown(sender, e);
        }

        private void ToolStripMenuItemSetting_Click(object sender, EventArgs e)
        {
            FormsAdjusting formsAdjusting = new FormsAdjusting();
            formsAdjusting._fileName = _settingFileName;
            formsAdjusting._formDataGridView = dataGridView1;
            formsAdjusting.ShowDialog();

        }

        private void gotFocus(object sender, EventArgs e)
        {
            string value = "";
            if (sender.GetType() == typeof(TextBox))
            {
                lblFieldName_search.Text = ((TextBox)sender).Tag.ToString();
                _searchField = ((TextBox)sender).Name;
                value = ((TextBox)sender).Text;
            }
            if (sender.GetType() == typeof(ComboBox))
            {
                lblFieldName_search.Text = ((ComboBox)sender).Tag.ToString();
                _searchField = ((ComboBox)sender).Name;
                value = ((ComboBox)sender).Text;
            }
            if (sender.GetType() == typeof(MaskedTextBox))
            {
                lblFieldName_search.Text = ((MaskedTextBox)sender).Tag.ToString();
                _searchField = ((MaskedTextBox)sender).Name;
                value = ((MaskedTextBox)sender).Text.Trim();
            }
            cmbSearch.Text = value.Trim();
            string s = _searchField.Substring(3);
            cmbSearch.AutoCompleteCustomSource.AddRange(getArray((ArrayList)_searchMap[s.ToLower()]));
            cmbSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbSearch.DisplayMember = s;
            cmbSearch.ValueMember = s;
        }

        private string[] getArray(ArrayList ht)
        {
            if (ht == null)
                return new string[1];
            string[] s = new string[ht.Count];
            IEnumerator en = ht.GetEnumerator();
            int i = 0;
            while (en.MoveNext())
                s[i++] = en.Current.ToString().Trim();
            return s;
        }

        private void fillSearchMap()
        {
            cmbSearch.DataSource = ((ViewInsuranceInfoData)_dataSource).Tables[0];
            cmbSearch.DisplayMember = "insuranceNumber";
            cmbSearch.ValueMember = "insuranceNumber";
            _searchField = txtInsuranceNumber.Name;
            lblFieldName_search.Text = txtInsuranceNumber.Tag.ToString();
            _searchMap.Clear();
            string[] fields = { "name", "family", "phonenumber", "insurancenumber", "address", "description", "BeginDate", "EndDate" };
            ArrayList[] colls = {new ArrayList(), new ArrayList(), new ArrayList(),
                                 new ArrayList(), new ArrayList(),new ArrayList(),
                                 new ArrayList(), new ArrayList()};

            DataSet ds = (ViewInsuranceInfoData)_dataSource;
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                for (int i = 0; i < colls.Length; i++)
                    addToHashTable(colls[i], ds.Tables[0].Rows[j][fields[i]].ToString());
            }
            for (int i = 0; i < colls.Length; i++)
            {
                ((ArrayList)colls[i]).Sort();
                _searchMap.Add(fields[i].ToLower(), colls[i]);

            }

        }

        private void addToHashTable(ArrayList al, string value)
        {
            if ((value != null && value.Trim().Length > 0))
            {
                value = value.Trim();
                al.Add(value.Trim());
            }
        }

        private void cmbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dataMode == NEW_MODE)
            {
                MessageBox.Show("هنگام ثبت جدید جستجو غیر فعال است");
                return;
            }
            string condition = "";
            if (_searchField == null || _searchField.Length <= 0)
                return;
            string fld = _searchField.Substring(3).ToLower().Trim();

            if (cmbSearch.Text.IndexOf("date") > 0)
            {
                int d = 0;
                int m = 0;
                int y = 0;
                Boolean b = CheckDate.checkDate(cmbSearch.Text, ref y, ref m, ref d);
                if (b)
                {
                    DateTime dt = RMX_TOOLS.date.DateXFormer.persianToGreGorian(cmbSearch.Text);
                    condition = fld + "=" + dt.ToString();
                }
                else
                    MessageBox.Show("تاریخ معتبر نیست");
            }
            else
            {
                condition = fld + " like '%" + cmbSearch.Text + "%'";
            }

            fillGrid(condition);
            dataGridView1_SelectionChanged(null, null);
        }

        private void InsuranceInfoForm_Activated(object sender, EventArgs e)
        {

        }

        public void confirmButtonavailability()
        {

            bool b = true;

            UsersAccessBS uabs = new UsersAccessBS();
            int userid = int.Parse(UsersBS.loginedUser.Tables[0].Rows[0][UsersData.id_FIELD].ToString());
            int userType = int.Parse(UsersBS.loginedUser.Tables[0].Rows[0][UsersData.userType_FIELD].ToString());
            if (userType == 1)
            {
                UsersAccessData uaData = uabs.load(userid);
                if (uaData == null || uaData.Tables.Count <= 0 || uaData.Tables[0].Rows.Count <= 0)
                    b = false;
                else
                {
                    b = bool.Parse(uaData.Tables[0].Rows[0][UsersAccessData.accessToInsuranceInfo_FIELD].ToString());
                }

            }

            btnUpdate.Enabled = b;
            btnDelete.Enabled = b;
            btnNew.Enabled = b;
            btnRefresh.Enabled = b;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkAttachment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int insuranceId = (int)_gridTools.getCurrentRowValue(ViewInsuranceInfoData.id_FIELD);
            if (insuranceId != null && insuranceId >= 0)
            {
                AttachmentList list = new AttachmentList(insuranceId);
                list.ShowDialog();
            }
        }

    }
}