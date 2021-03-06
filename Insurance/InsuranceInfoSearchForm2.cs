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
using System.Globalization;
using RMX_TOOLS.converter;
using System.Reflection;
using RMX_TOOLS.data.grid;


namespace Insurance
{
    public partial class InsuranceInfoSearchForm2 : Form
    {
        string _currentInsuranceNumber = null;
        string _settingFileName = Application.StartupPath + "\\Search2Adjust.xml";
        int _userId = 0;
        string _condition = "";
        RMX_TOOLS.date.DatePicker _datePicker = new DatePicker();
        int tab2ActiveSearch = 1; // recognize when pressing F3 for search which one of buttons must be simulate

        private GridTools _gridTools;
        private DataSet _dataSource;

        public InsuranceInfoSearchForm2()
        {
            InitializeComponent();
            _gridTools = new GridTools(dataGridView1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _condition = getCondition();
            //MessageBox.Show(condition);
            fillGrid(_condition);            
        }


        private string getCondition()
        {
            string condition = "";
            string str;
            str = totBono(txtName, "string");
            condition = merg(condition, str);
            str = totBono(txtFamily, "string");
            condition = merg(condition, str);
            str = totBono(txtPhoneNumber, "string");
            condition = merg(condition, str);
            str = totBono(txtInsuranceNumber, "string");
            condition = merg(condition, str);
            str = totBono(cmbInsuranceType);
            condition = merg(condition, str);
            str = totBono(txtBeginDate, "datetime");
            condition = merg(condition, str);
            str = totBono(txtEndDate, "datetime");
            condition = merg(condition, str);
            str = totBono_HaveDid(cmbHaveDid);
            condition = merg(condition, str);
            //str = totBono(cbxCancel);
            //condition = merg(condition, str);
            str = totBono(txtAddress, "string");
            condition = merg(condition, str);
            str = totBono(txtDescription, "string");
            condition = merg(condition, str);
            return condition;
        }

        private string merg(string condition, string str)
        {
            if (str == null || str.Length <= 0)
                return condition;

            if (condition == null || condition.Length <= 0)
                return str;

            return condition + " and " + str;

        }

        private string totBono_HaveDid(ComboBox cmbHaveDid)
        {
            switch (cmbHaveDid.SelectedIndex)
            {
                case -1:
                    return "";
                case 0:
                    return "";
                case 1:
                    return " haveDid = 1 ";
                case 2:
                    return " haveDid = 0 ";

            }
            return "";
        }

        private string totBono(object textBox, string type)
        {
            string name = "";
            string value = "";


            if (textBox.GetType() == new TextBox().GetType())
            {
                name = ((TextBox)textBox).Name.Trim();
                value = ((TextBox)textBox).Text.Trim();
            }
            else if (textBox.GetType() == new MaskedTextBox().GetType())
            {
                name = ((MaskedTextBox)textBox).Name.Trim();
                value = ((MaskedTextBox)textBox).Text.Trim();
            }
            else
                throw new Exception("Misstake in calling this totbono method()");
            type = type.ToLower().Trim();
            name = name.Substring(3);

            if (value != null && value.Trim().Length > 0)
            {
                if (type.Equals("string"))
                    return " " + name + " like '%" + value + "%' ";
                else if (type.Equals("datetime"))
                {
                    DateTime dt = RMX_TOOLS.date.DateXFormer.persianToGreGorian(value);
                    if (dt == DateTime.MinValue)
                        return null;
                    string shortDate = dt.Year + "/" + dt.Month + "/" + dt.Day;

                    return " " + name + " between '" + shortDate +
                        " 00:00:00' and '" + shortDate + " 23:59:59' ";
                }
                else
                    return " " + name + "=" + value + " ";
            }
            return null;
        }

        private string totBono(CheckBox checkBox)
        {
            Boolean value = checkBox.Checked;
            string name = checkBox.Name;
            name = name.Substring(3);
            int intVal = (value ? 1 : 0);
            string cond = " " + name + " = " + intVal;
            //if (checkBox.Equals(cbxCancel)){
            //    if (intVal == 1)
            //        cond = " " + name + " = " + intVal +" ";
            //    else
            //    cond = " (" + name + " = " + intVal + " or " + name + " is null )";
            //}
            return cond;
        }

        private string totBono(ComboBox comboBox)
        {
            string value = comboBox.SelectedValue + "";

            value = value.Trim();
            string name = comboBox.Name;
            name = name.Substring(3);
            if (comboBox.SelectedIndex > 1)
                return " " + name + "=" + value + " ";
            return null;
        }

        private void InsuranceInfoSearchForm2_Load(object sender, EventArgs e)
        {
            _userId = int.Parse(UsersBS.loginedUser.Tables[UsersData.users_TABLE].Rows[0][UsersData.id_FIELD] + "");
            fillInsuranceTypeCmboBox();
            fillGrid("");
            // LANGAUGE CHANGEING TO PERSIAN
            InputLanguage persinLanguage = InputLanguage.CurrentInputLanguage;
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Equals("Farsi"))
                    persinLanguage = InputLanguage.InstalledInputLanguages[i];
            InputLanguage.CurrentInputLanguage = persinLanguage;
            //
            FormsAdjusting.loadGridSetting(_settingFileName, dataGridView1);

        }

        private void fillInsuranceTypeCmboBox()
        {
            cmbInsuranceType.Items.Clear();

            int userId = int.Parse(UsersBS.loginedUser.Tables[UsersData.users_TABLE].Rows[0][UsersData.id_FIELD] + "");
            InsuranceTypeData dataSet = new InsuranceTypeBS().userLimitedList();
            //add empty row
            DataRow dr = dataSet.Tables[0].NewRow();
            dr[InsuranceTypeData.InsuranceCaption_FIELD] = "";
            dr[InsuranceTypeData.InsuranceId_FIELD] = 0;
            dataSet.Tables[0].Rows.InsertAt(dr, 0);
            //

            cmbInsuranceType.DataSource = dataSet.Tables[InsuranceTypeData.InsuranceType_TABLE];
            cmbInsuranceType.DisplayMember = InsuranceTypeData.InsuranceCaption_FIELD;
            cmbInsuranceType.ValueMember = InsuranceTypeData.InsuranceId_FIELD;
        }

        private void fillGrid()
        {
            fillGrid("");
        }

        private void fillGrid(string condition)
        {

            int id = int.Parse(UsersBS.loginedUser.Tables[UsersData.users_TABLE].Rows[0][UsersData.id_FIELD].ToString());

            System.Collections.Hashtable hash = new System.Collections.Hashtable();
            hash.Add("colorField", InsuranceTypeData.INSURANCETYPECOLOR_FIELD);

            _dataSource = new ViewHaveDidLogBS().loadUserLimitedList(id, condition);
            _gridTools.bindDataToGrid(dataGridView1,
                _dataSource,
                    ViewHaveDidLogData.haveDidLogData_TABLE
                    , new GridTools.changingRow(_gridTools.changeColor), hash);
            selectCurrentRow();
        }

        private void bntSearchDate_Click(object sender, EventArgs e)
        {
            /**
             * the vaues of comboBox cmbCondition
             * 0 = equal
             * 1 = greater
             * 2 = greater and equal
             * 3 = less than
             * 4 = less and equal
             */
            txtBeginDateFilter_TextChanged(null, null);
            string dateStr = txtBeginDateFilter.Text;

            string condition = "";
            string fld;
            fld = " havedidlog_checkeddate ";

            if (cmbCondition.SelectedIndex < 0)
            {
                MessageBox.Show("شرط تاریخ تعیین نشده است");
                return;
            }

            if (!CheckDate.checkDate(dateStr))
            {
                MessageBox.Show("تاریخ معتبر نیست");
                return;
            }
            
            DateTime date = RMX_TOOLS.date.DateXFormer.persianToGreGorian(dateStr);
            string dateS = date.Year + "/" + date.Month + "/" + date.Day;

            switch (cmbCondition.SelectedIndex)
            {
                case 0:
                    condition = fld + " BETWEEN '" + dateS + " " +
                            RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY + "' and '" +
                            dateS + " " + RMX_TOOLS.date.DateConstants.END_OF_DAY + "' ";
                    break;
                case 1:
                    condition = fld + " > '" + dateS + " " + RMX_TOOLS.date.DateConstants.END_OF_DAY + "' ";
                    break;
                case 2:
                    condition = fld + " >= '" + dateS + " " + RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY + "' ";
                    break;
                case 3:
                    condition = fld + " < '" + dateS + " " + RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY + "' ";
                    break;
                case 4:
                    condition = fld + " <= '" + dateS + " " + RMX_TOOLS.date.DateConstants.END_OF_DAY + "' ";
                    break;
            }
            //int v = (cbxHaveDid2.Checked ? 1 : 0);
            // condition += " and " + ViewHaveDidLogData.haveDid_FIELD + "=" + v + " ";
            _condition = condition;
            string cancel = "";// " and(cancel is null or cancel = 0)";
            fillGrid(_condition + cancel);
        }

        private void btnSearchBetWeen_Click(object sender, EventArgs e)
        {
            string dateStr1 = txtBeginDateBetween1.Text;
            string dateStr2 = txtBeginDateBetween2.Text;


            string fld = " havedidlog_checkeddate ";

            txtBeginDateBetween1_TextChanged(null, null);
            if (!CheckDate.checkDate(dateStr1))
            {
                MessageBox.Show("تاریخ اولی معتبر نیست");
                return;
            }
            if (!CheckDate.checkDate(dateStr1))
            {
                MessageBox.Show("تاریخ دومی معتبر نیست");
                return;
            }

            DateTime date1 = RMX_TOOLS.date.DateXFormer.persianToGreGorian(dateStr1);
            DateTime date2 = RMX_TOOLS.date.DateXFormer.persianToGreGorian(dateStr2);
            
            string date1Str = date1.Year + "/" + date1.Month + "/" + date1.Day;
            string date2Str = date2.Year + "/" + date2.Month + "/" + date2.Day;

            _condition = fld + " BETWEEN '" + date1Str + " " +
                            RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY + "' and '" +
                            date2Str  + " " + RMX_TOOLS.date.DateConstants.END_OF_DAY + "' ";

            string cancel = "";// " and(cancel is null or cancel = 0)";
            fillGrid(_condition + cancel);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            IConverter converter = new DateConverter();
            IConverter booleanConverter = new RMX_TOOLS.converter.BooleanConverter();
            cmbHaveDid.SelectedIndex = -1;
            if (_gridTools.getCurrentRowValue(ViewHaveDidLogData.INSURANCEINFO_NAME_FIELD) != null)
                txtName.Text = _gridTools.getCurrentRowValue(ViewHaveDidLogData.INSURANCEINFO_NAME_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewHaveDidLogData.INSURANCEINFO_FAMILY_FIELD) != null)
                txtFamily.Text = _gridTools.getCurrentRowValue(ViewHaveDidLogData.INSURANCEINFO_FAMILY_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewHaveDidLogData.PhoneNumber_FIELD) != null)
                txtPhoneNumber.Text = _gridTools.getCurrentRowValue(ViewHaveDidLogData.PhoneNumber_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewHaveDidLogData.InsuranceNumber_FIELD) != null)
                txtInsuranceNumber.Text = _gridTools.getCurrentRowValue(ViewHaveDidLogData.InsuranceNumber_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewHaveDidLogData.InsuranceType_Caption_FIELD) != null)
                cmbInsuranceType.SelectedText = _gridTools.getCurrentRowValue(ViewHaveDidLogData.InsuranceType_Caption_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewHaveDidLogData.InsuranceType_FIELD) != null)
                cmbInsuranceType.SelectedValue = _gridTools.getCurrentRowValue(ViewHaveDidLogData.InsuranceType_FIELD);

            if (_gridTools.getCurrentRowValue(ViewHaveDidLogData.BeginDate_FIELD) != null)
                //txtBeginDate.Text = converter.valueToString(_gridTools.getCurrentRowValue(ViewHaveDidLogData.BeginDate_FIELD));
                txtBeginDate.Text = _gridTools.getCurrentRowValue(ViewHaveDidLogData.BeginDate_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewHaveDidLogData.EndDate_FIELD) != null)
                //txtEndDate.Text = converter.valueToString(_gridTools.getCurrentRowValue(ViewHaveDidLogData.EndDate_FIELD));
                txtEndDate.Text = _gridTools.getCurrentRowValue(ViewHaveDidLogData.EndDate_FIELD).ToString().Trim();

            if (_gridTools.getCurrentRowValue(ViewHaveDidLogData.haveDid_FIELD) != null)
            {
                Boolean b = Boolean.Parse(booleanConverter.valueToString(_gridTools.getCurrentRowValue(ViewHaveDidLogData.haveDid_FIELD)));
                if (b)
                    cmbHaveDid.SelectedIndex = 1;
                //else
                //    cmbHaveDid.SelectedIndex = 2;
            }
            if (_gridTools.getCurrentRowValue(ViewHaveDidLogData.address_FIELD) != null)
                txtAddress.Text = _gridTools.getCurrentRowValue(ViewHaveDidLogData.address_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewHaveDidLogData.description_FIELD) != null)
                txtDescription.Text = _gridTools.getCurrentRowValue(ViewHaveDidLogData.description_FIELD).ToString().Trim();

        }


        private string checkData()
        {
            string tmp;
            tmp = txtName.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا نام را وارد کنید";
            tmp = txtFamily.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا نام خانوادگی را وارد کنید";
            tmp = txtInsuranceNumber.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا شماره بیمه را وارد کنید";
            int indx = cmbCondition.SelectedIndex;
            if (indx == 0)
                return "لطفا نوع بیمه را وارد کنید";
            if (txtBeginDate.Text.Trim().Length <= 0)
                return "لطفا تاریخ شروع را وارد کنید";
            if (txtEndDate.Text.Trim().Length <= 0)
                return "لطفا تاریخ پایان را وارد کنید";
            if (!CheckDate.checkDate(txtBeginDate.Text))
                return "تاریخ شروع معتبر نیست";
            if (!CheckDate.checkDate(txtEndDate.Text))
                return "تاریخ پایان معتبر نیست";

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
            if (_gridTools.getCurrentRowValue(InsuranceInfoData.id_FIELD) == null)
                return;
            InsuranceInfoBS isb = new InsuranceInfoBS();
            InsuranceInfoData inData = new InsuranceInfoData();
            DataRow dr = inData.Tables[InsuranceInfoData.insuranceInfo_TABLE].NewRow();

            // if (cmbHaveDid.SelectedIndex == 1)
            //      dr[InsuranceInfoData.haveDid_FIELD] = true;
            // if (cmbHaveDid.SelectedIndex == 2)
            //      dr[InsuranceInfoData.haveDid_FIELD] = false;

            dr[InsuranceInfoData.name_FIELD] = txtName.Text;
            dr[InsuranceInfoData.family_FIELD] = txtFamily.Text;
            dr[InsuranceInfoData.phoneNumber_FIELD] = txtPhoneNumber.Text;
            dr[InsuranceInfoData.insuranceNumber_FIELD] = txtInsuranceNumber.Text;
            dr[InsuranceInfoData.id_FIELD] = _gridTools.getCurrentRowValue(InsuranceInfoData.id_FIELD);
            dr[InsuranceInfoData.address_FIELD] = _gridTools.getCurrentRowValue(InsuranceInfoData.address_FIELD);
            dr[InsuranceInfoData.haveDid_FIELD] = _gridTools.getCurrentRowValue(InsuranceInfoData.haveDid_FIELD);
            dr[InsuranceInfoData.cancel_FIELD] = _gridTools.getCurrentRowValue(InsuranceInfoData.cancel_FIELD);
            dr[InsuranceInfoData.address_FIELD] = txtAddress.Text.Trim();
            dr[InsuranceInfoData.description_FIELD] = txtDescription.Text.Trim();
            // Date validation and converion 
            #region dateValidation
            GregorianCalendar gcal = new GregorianCalendar();
            int d = 0;
            int m = 0;
            int y = 0;
            CheckDate.checkDate(txtBeginDate.Text, ref y, ref m, ref d);
            DateTime persianDateDime = new DateTime(y, m, d, new PersianCalendar());
            DateTime greorianDateTime =
                new DateTime(gcal.GetYear(persianDateDime),
                             gcal.GetMonth(persianDateDime),
                             gcal.GetDayOfMonth(persianDateDime), new GregorianCalendar());

            dr[InsuranceInfoData.beginDate_FIELD] = greorianDateTime;

            CheckDate.checkDate(txtEndDate.Text, ref y, ref m, ref d);
            persianDateDime = new DateTime(y, m, d, new PersianCalendar());
            greorianDateTime =
                new DateTime(gcal.GetYear(persianDateDime),
                             gcal.GetMonth(persianDateDime),
                             gcal.GetDayOfMonth(persianDateDime), new GregorianCalendar());

            dr[InsuranceInfoData.endDate_FIELD] = greorianDateTime;

            #endregion

            //fetch id from comboBox
            int id = int.Parse(cmbInsuranceType.SelectedValue + "");
            dr[InsuranceInfoData.insuranceType_FIELD] = id;

            inData.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows.Add(dr);
            isb.update(inData);

            string insuranceNumber = txtInsuranceNumber.Text.Trim();

            fillGrid(_condition);

            int addedRow = searcInGrid(insuranceNumber);
            if (addedRow == -1)
                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;

            else
                dataGridView1.Rows[addedRow].Selected = true;

            MainForm.MainFormInstance.fillGrid();
            MessageBox.Show("به روز رسانی انجام شد");
        }

        /*
         *@Return row number of grid
         *@Param insurance Number
         */
        private int searcInGrid(string insuranceNumber)
        {
            DataSet ds = (DataSet)_dataSource;
            int index = -1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                index++;
                string n = dr[ViewHaveDidLogData.InsuranceNumber_FIELD].ToString();
                if (n.Equals(insuranceNumber))
                    return index;
            }
            return -1;
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

        private void btnDateEnd_Click(object sender, EventArgs e)
        {
            _datePicker.showDialog(txtEndDate.Text);
            if (_datePicker._selected)
            {
                txtEndDate.Text = RMX_TOOLS.date.CheckDate.generalizeDate(_datePicker._selectedYear + "/" + _datePicker._selectedMonth + "/" +
                    _datePicker._selectedDay);

            }

        }

        private void btnBeginDateFilter_Click(object sender, EventArgs e)
        {
            _datePicker.showDialog(txtBeginDateFilter.Text);
            if (_datePicker._selected)
            {
                txtBeginDateFilter.Text = RMX_TOOLS.date.CheckDate.generalizeDate(_datePicker._selectedYear + "/" + _datePicker._selectedMonth + "/" +
                    _datePicker._selectedDay);
            }

        }

        private void btnBeginDateBetween1_Click(object sender, EventArgs e)
        {
            _datePicker.showDialog(txtBeginDateBetween1.Text);
            if (_datePicker._selected)
            {
                txtBeginDateBetween1.Text = RMX_TOOLS.date.CheckDate.generalizeDate(_datePicker._selectedYear + "/" + _datePicker._selectedMonth + "/" +
                    _datePicker._selectedDay);

            }

        }

        private void btnBeginDateBetween2_Click(object sender, EventArgs e)
        {
            _datePicker.showDialog(txtBeginDateBetween2.Text);
            if (_datePicker._selected)
            {
                txtBeginDateBetween2.Text = RMX_TOOLS.date.CheckDate.generalizeDate(_datePicker._selectedYear + "/" + _datePicker._selectedMonth + "/" +
                    _datePicker._selectedDay);

            }

        }

        private void InsuranceInfoSearchForm2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F11)
                btnEmpty_Click(null, null);
            if (e.KeyCode == Keys.F10)
                btnUpdate_Click(null, null);
            if (e.KeyCode == Keys.F3)
            {
                if (tabControl1.SelectedIndex == 0)
                    btnSearch_Click(null, null);
                else
                {
                    if (tab2ActiveSearch == 1)
                        bntSearchDate_Click(null, null);
                    else
                        btnSearchBetWeen_Click(null, null);
                }
            }
            if (e.KeyCode == Keys.F8)
                btnReport1_Click(null, null);

        }

        private void btnEmpty_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtFamily.Text = "";
            txtPhoneNumber.Text = "";
            txtInsuranceNumber.Text = "";
            txtBeginDate.Text = "";
            txtEndDate.Text = "";
            cmbHaveDid.SelectedIndex = 0;
            //cbxCancel.Checked = false;
            cmbInsuranceType.Text = "";
            txtAddress.Text = "";
            txtDescription.Text = "";
            _condition = "";
        }

        private void btnReport1_Click(object sender, EventArgs e)
        {
            //security check()
            LoginForm.CheckJustManager = true;
            LoginForm lFrm = new LoginForm();
            lFrm.ShowDialog();

            if (!LoginForm.Loggined)
                return;
            LoginForm.CheckJustManager = false;

            DataSet ds = (DataSet)_dataSource;

            ReportFrm rf = new ReportFrm();
            rf._dataSet = (RMX_TOOLS.common.AbstractCommonData)ds;
            rf.ShowDialog();

        }

        private void btnReport2_Click(object sender, EventArgs e)
        {
            btnReport1_Click(sender, e);
        }

        private void txtBeginDateFilter_TextChanged(object sender, EventArgs e)
        {
            // recognize when pressing F3 for search which one of buttons must be simulate
            panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            panel3.BackColor = System.Drawing.SystemColors.Control;
            tab2ActiveSearch = 1;

        }

        private void txtBeginDateBetween1_TextChanged(object sender, EventArgs e)
        {
            // recognize when pressing F3 for search which one of buttons must be simulate
            panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            panel2.BackColor = System.Drawing.SystemColors.Control;
            tab2ActiveSearch = 2;

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            InsuranceInfoSearchForm2_KeyDown(sender, e);
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1_DoubleClick(null, null);
                e.Handled = true;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
            string id = _gridTools.getCurrentRowValue(ViewHaveDidLogData.InsuranceNumber_FIELD).ToString();
            InsuranceInfoForm insFrm = new InsuranceInfoForm();
            _currentInsuranceNumber = id;
            insFrm.preEnteredInsuranceNumber = id;
            insFrm.ShowDialog();
           // fillGrid();

        }


        private void selectCurrentRow()
        {
            if (dataGridView1.RowCount <= 0)
            {
                btnEmpty_Click(null, null);
                return;
            }
            if (_currentInsuranceNumber == null)
            {
                dataGridView1.Rows[0].Cells[0].Selected = true;
                dataGridView1_SelectionChanged(null, null);
                return;
            }
            string val;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = true;
                
                val = _gridTools.getCurrentRowValue(ViewHaveDidLogData.InsuranceNumber_FIELD).ToString();
                if (_currentInsuranceNumber.Equals(val))
                    return;
            }
        }

        private void ToolStripMenuItemSetting_Click(object sender, EventArgs e)
        {
            FormsAdjusting formsAdjusting = new FormsAdjusting();
            formsAdjusting._fileName = _settingFileName;
            formsAdjusting._formDataGridView = dataGridView1;
            formsAdjusting.ShowDialog();
        }
    }
}