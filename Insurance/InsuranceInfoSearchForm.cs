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
using RMX_TOOLS.data.grid;
using RMX_TOOLS.data;
using System.Collections;
using System.IO;
using RMX_TOOLS.common;
namespace Insurance
{
    public partial class InsuranceInfoSearchForm : Form
    {
        string _currentInsuranceNumber = null;
        string _settingFileName = Application.StartupPath + "\\Search1Adjust.xml";
        int _userId = 0;
        string _condition = "";
        RMX_TOOLS.date.DatePicker _datePicker = new DatePicker();
        int tab2ActiveSearch = 1; // recognize when pressing F3 for search which one of buttons must be simulate

        private string _userNameTemplate = "-@USERNAME@-";
        private string _DateTemplate = "-@TODAY@-";
        private string _TitleTemplate = "-@TITLE@-";
        private string _DataTemplate = "-@DATA@-";
        private string _Row = "-@ROW@-";

        private GridTools _gridTools;
        private AbstractCommonData _dataSource;


        public InsuranceInfoSearchForm()
        {
            InitializeComponent();
            _gridTools = new GridTools(dataGridView1);

            //String today = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Now);
            //txtCreationFrom.Text = today;
            //txtcreationTo.Text = today;
            //txtUpdateFrom.Text = today;
            //txtUpdateTo.Text = today;
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
           // str = totBono_HaveDid(cmbHaveDid);
           // condition = merg(condition, str);
            str = totBono(cbxCancel);
            condition = merg(condition, str);
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
                throw new Exception("Misstake in caling this totbono method()");
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
            if (checkBox.Equals(cbxCancel))
            {
                if (intVal == 1)
                    cond = " " + name + " = " + intVal + " ";
                else
                    cond = " (" + name + " = " + intVal + " or " + name + " is null )";
            }
            return cond;
        }

        private string totBono(ComboBox comboBox)
        {
            string value = comboBox.SelectedValue + "";

            value = value.Trim();
            string name = comboBox.Name;
            name = name.Substring(3);
            if (comboBox.SelectedValue != null && int.Parse(comboBox.SelectedValue.ToString()) != 0)
                return " " + name + "=" + value + " ";
            return null;
        }

        private void InsuranceInfoSearchForm_Load(object sender, EventArgs e)
        {
            _userId = int.Parse(UsersBS.loginedUser.Tables[UsersData.users_TABLE].Rows[0][UsersData.id_FIELD] + "");
            fillInsuranceTypeCmboBox();
            //fillGrid("");
            
            // LANGAUGE CHANGEING TO PERSIAN
            InputLanguage persinLanguage = InputLanguage.CurrentInputLanguage;
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Equals("Farsi"))
                    persinLanguage = InputLanguage.InstalledInputLanguages[i];
            InputLanguage.CurrentInputLanguage = persinLanguage;

            FormsAdjusting.loadGridSetting(_settingFileName, dataGridView1);
            permissions();

        }

        private void permissions()
        {

             string userType = UsersBS.loginedUser.Tables[UsersData.users_TABLE].Rows[0][UsersData.userType_FIELD] + "";
             if (userType == "0")
             {
                 return;
             }

            button2.Visible = false;
            UsersAccessBS bs = new UsersAccessBS();
            UsersAccessData uaData = bs.load(_userId);

            if (uaData == null || uaData.Tables.Count <= 0 || uaData.Tables[0].Rows.Count <= 0)
            {
                return;
            }
            string access = uaData.Tables[0].Rows[0][UsersAccessData.printSearchResult_FIELD].ToString() + "";
            bool b = bool.Parse(access == null || access.Trim().Equals("") ? "false" : access);
            button2.Visible = b;

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
            _dataSource = new ViewInsuranceInfoBS().loadUserLimitedList(id, condition);
            _gridTools.bindDataToGrid(dataGridView1, 
                    _dataSource, ViewInsuranceInfoData.VIEW_INSURANCEINFO_TABLE
                    ,new GridTools.changingRow(_gridTools.changeColor), hash);
            
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
            fld = ViewInsuranceInfoData.endDate_FIELD;


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
            IDataProvider dp = Config.provider;
            switch (cmbCondition.SelectedIndex)
            {
                case 0:
                    if (rBtnHaveDid.Checked)
                        condition = dp.getBetweenDate(fld, date, date, null);
                    else if (rBtnOP.Checked)
                        condition = dp.getBetweenDate(fld, date, date, ViewInsuranceInfoData.DAYSBEFOREXP_FIELD);
                    break;
                case 1:
                    if (rBtnHaveDid.Checked)
                       condition = fld + ">" + dp.getAsSqlDate(date.ToShortDateString(), RMX_TOOLS.date.DateConstants.END_OF_DAY );
                    else if (rBtnOP.Checked)
                       condition = fld + ">" + dp.getAsSqlDate(date.ToShortDateString(),
                           RMX_TOOLS.date.DateConstants.END_OF_DAY) + " + "+ ViewInsuranceInfoData.DAYSBEFOREXP_FIELD;
                    break;
                case 2:
                    if (rBtnHaveDid.Checked)
                        condition = fld + " >= " + dp.getAsSqlDate(date.ToShortDateString(), RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY);
                    else if (rBtnOP.Checked)
                        condition = fld + " >= " + dp.getAsSqlDate(date.ToShortDateString(),
                            RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY) + " + " + ViewInsuranceInfoData.DAYSBEFOREXP_FIELD;
                    break;
                case 3:
                    if (rBtnHaveDid.Checked)
                        condition = fld + " < " + dp.getAsSqlDate(date.ToShortDateString(), RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY);
                    else if (rBtnOP.Checked)
                        condition = fld + " < " + dp.getAsSqlDate(date.ToShortDateString(),
                            RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY) + " + " + ViewInsuranceInfoData.DAYSBEFOREXP_FIELD;
                    break;
                case 4:
                    if (rBtnHaveDid.Checked)
                        condition = fld + " < " + dp.getAsSqlDate(date.ToShortDateString(), RMX_TOOLS.date.DateConstants.END_OF_DAY);
                    else if (rBtnOP.Checked)
                        condition = fld + " < " + dp.getAsSqlDate(date.ToShortDateString(),
                            RMX_TOOLS.date.DateConstants.END_OF_DAY) + " + " + ViewInsuranceInfoData.DAYSBEFOREXP_FIELD;
                    break;
            }
          //  int v = (cbxHaveDid2.Checked ? 1 : 0);
          //  condition += " and " + ViewInsuranceInfoData.haveDid_FIELD + "=" + v + " ";
            _condition = condition;
            string cancel = "";// " and(cancel is null or cancel = 0)";
            fillGrid(_condition + cancel);
        }

        private void btnSearchBetWeen_Click(object sender, EventArgs e)
        {

            string dateStr1 = txtBeginDateBetween1.Text;
            string dateStr2 = txtBeginDateBetween2.Text;

            string condition = "";
            string fld;
            fld = ViewInsuranceInfoData.endDate_FIELD;

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
            
            IDataProvider dp = Config.provider;
            
            
            if (rBtnHaveDid.Checked)
                condition = dp.getBetweenDate(fld, date1, date2, null);
            else if (rBtnOP.Checked)
                condition = dp.getBetweenDate(fld, date1, date2, ViewInsuranceInfoData.DAYSBEFOREXP_FIELD);

            int v = (cbxHaveDid3.Checked ? 1 : 0);
         //  condition += " and " + ViewInsuranceInfoData.haveDid_FIELD + "=" + v + " ";
            _condition = condition;
            string cancel = "";// " and(cancel is null or cancel = 0)";
            fillGrid(_condition + cancel);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            IConverter converter = new DateConverter();
            IConverter booleanConverter = new RMX_TOOLS.converter.BooleanConverter();

            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.name_FIELD) != null)
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

            if (_gridTools.getCurrentRowValue(InsuranceInfoData.beginDate_FIELD) != null)
                //txtBeginDate.Text = converter.valueToString(_gridTools.getCurrentRowValue(InsuranceInfoData.beginDate_FIELD));
                txtBeginDate.Text = _gridTools.getCurrentRowValue(InsuranceInfoData.beginDate_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(InsuranceInfoData.endDate_FIELD) != null)
                //txtEndDate.Text = converter.valueToString(_gridTools.getCurrentRowValue(InsuranceInfoData.endDate_FIELD));
                txtEndDate.Text = _gridTools.getCurrentRowValue(InsuranceInfoData.endDate_FIELD).ToString().Trim();

            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.haveDid_FIELD) != null)
            {
                Boolean b = Boolean.Parse(booleanConverter.valueToString(_gridTools.getCurrentRowValue(ViewInsuranceInfoData.haveDid_FIELD)));
                if (b)
                    cmbHaveDid.SelectedIndex = 1;
                else
                    cmbHaveDid.SelectedIndex = 2;
            }
            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.address_FIELD) != null)
                txtAddress.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.address_FIELD).ToString().Trim();
            if (_gridTools.getCurrentRowValue(ViewInsuranceInfoData.description_FIELD) != null)
                txtDescription.Text = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.description_FIELD).ToString().Trim();
 
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

        private Boolean insuranceNumberCheck()
        {
            if (txtInsuranceNumber.Text.Trim().Length <= 0)
            {
                MessageBox.Show("شماره بیمه خالی است");
                return false;
            }

            InsuranceInfoBS isb = new InsuranceInfoBS();
            int id = int.Parse(_gridTools.getCurrentRowValue(InsuranceInfoData.id_FIELD).ToString());
            if (isb.checkInsuranceNumberExists(txtInsuranceNumber.Text.Trim(), id))
            {
                MessageBox.Show(" شماره بیمه تکراری است");
                txtInsuranceNumber.Focus();
                return false;
            }
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (!insuranceNumberCheck())
                return;
            InsuranceInfoBS isb = new InsuranceInfoBS();
            string oldVal = _gridTools.getCurrentRowValue(InsuranceInfoData.insuranceNumber_FIELD).ToString();
            string newValue = txtInsuranceNumber.Text.Trim();

            isb.updateInsuranceNumber(oldVal, newValue);

            string insuranceNumber = txtInsuranceNumber.Text.Trim();

            fillGrid(_condition);

            int addedRow = searcInGrid(insuranceNumber);
            if (addedRow == -1)
                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
                
            else
                dataGridView1.Rows[addedRow].Selected = true;

            // frmMain.MainForm.fillGrid();
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
                string n = dr[ViewInsuranceInfoData.insuranceNumber_FIELD].ToString();
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

        private void InsuranceInfoSearchForm_KeyDown(object sender, KeyEventArgs e)
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
            cmbHaveDid.SelectedValue = "";
            cbxCancel.Checked = false;
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
            InsuranceInfoSearchForm_KeyDown(sender, e);
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1_DoubleClick(null, null);
                e.Handled = true;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            string id = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.id_FIELD).ToString();
            InsuranceInfoForm1 insFrm = new InsuranceInfoForm1();
            _currentInsuranceNumber = id;
            insFrm._id = int.Parse(id);
            insFrm.ShowDialog();
            if (insFrm.isDeleted)
            {
                fillGrid();
            }
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
                val = _gridTools.getCurrentRowValue(ViewInsuranceInfoData.insuranceNumber_FIELD).ToString();
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

        private void OPorHaveDid_Change(object sender, EventArgs e)
        {
            RadioButton rBtn = (RadioButton)sender;
            lblMentionDateFilter.Text = rBtn.Tag.ToString().Trim();
            lblMentionDatefilterBetween.Text = rBtn.Tag.ToString().Trim(); 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String creationFrom = txtCreationFrom.Text;
            String creationTo = txtcreationTo.Text;
            String updateFrom = txtUpdateFrom.Text;
            String updateTo = txtUpdateTo.Text;

            String endDateFrom = txtEndDateFrom.Text;
            String endDateTo = txtEndDateTo.Text;

            if ((!isDateEmpty(creationFrom) && !CheckDate.checkDate(creationFrom)) ||
                (!isDateEmpty(creationTo) && !CheckDate.checkDate(creationTo)))
            {
                MessageBox.Show("تاریخ ایجاد صحیح نمی باشد");
                return;
            }


            string cond = getDateCondition("creationdate", creationFrom, creationTo);
            string cond2 = getDateCondition("lastupdatedate", updateFrom, updateTo);
            string cond3 = getDateCondition("EndDate", endDateFrom, endDateTo);
            string result = cond;

            if (result.Length > 0 && cond2 != null && cond2.Length > 0)
                result += " and";
            result += cond2;

            if (result.Length > 0 && cond3 != null && cond3.Length > 0)
                result += " and";
            result += cond3;

            if (birthDateHasValue.Checked)
            {
                if (result.Length > 0) result += " and ";
                result += " (Birthdate is not null and len(BirthDate) > 0)  ";
            }
            if (mobileNumberHasValue.Checked)
            {
                if (result.Length > 0) result += " and ";
                result += " (MobileNumber is not null and len(MobileNumber) > 0)  ";
            }
            fillGrid(result);  
        }

        private string getDateCondition(String field, string d1, String d2)
        {
            if (isDateEmpty(d1) && isDateEmpty(d2))
                return "";
            if (isDateEmpty(d1))
                d1 = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.MinValue);
            if (isDateEmpty(d2))
                d2 = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Now);

            DateTime dt1 = RMX_TOOLS.date.DateXFormer.persianToGreGorian(d1);
            DateTime dt2 = RMX_TOOLS.date.DateXFormer.persianToGreGorian(d2);
            return
                getBetween(field, dt1, dt2);
                //Config.provider.getBetweenDate(field, dt1, dt2, null);
        }

        private String getBetween(string field, DateTime d1, DateTime d2)
        {
            string shortDate = d1.Year + "/" + d1.Month + "/" + d1.Day;
            string shortDate2 = d2.Year + "/" + d2.Month + "/" + d2.Day;

            return " " + field + " between '" + shortDate +
                " 00:00:00' and '" + shortDate2 + " 23:59:59' ";
        }

        private bool isDateEmpty(String shamsiDate)
        {
            string emptyDate = "    /  /  ".Trim();
            return shamsiDate.Equals("____/__/__") || shamsiDate.Trim().Equals(emptyDate) || shamsiDate.Trim().Length == 0;
        }

        private DateTime toGregorian(String shamsiDate)
        {
            
            string emptyDate = "    /  /  ".Trim();
            if (shamsiDate.Equals(emptyDate))
                return DateTime.Now;
            return RMX_TOOLS.date.DateXFormer.persianToGreGorian(shamsiDate);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //prepare fields
            ArrayList selectedFields = new ArrayList();
            ArrayList selectedFieldsTitle = new ArrayList();

            //selectedFields.Add(ViewInsuranceInfoData.RADIF_FIELD);
            //selectedFieldsTitle.Add("ردیف");

            selectedFields.Add(ViewInsuranceInfoData.mobileNumber_FIELD);
            selectedFieldsTitle.Add("شماره موبایل");

            selectedFields.Add(ViewInsuranceInfoData.name_FIELD);
            selectedFieldsTitle.Add("نام");

            selectedFields.Add(ViewInsuranceInfoData.family_FIELD);
            selectedFieldsTitle.Add("نام خانوادگی");


            //selectedFields.Add(ViewInsuranceInfoData.insuranceNumber_FIELD);
            //selectedFieldsTitle.Add("شماره بیمه");
            selectedFields.Add("");
            selectedFieldsTitle.Add("شرکت/سازمان");
            
            selectedFields.Add("");
            selectedFieldsTitle.Add("ایمیل");

            selectedFields.Add("");
            selectedFieldsTitle.Add("نام مستعار");

            selectedFields.Add("");
            selectedFieldsTitle.Add("جنسیت");

            selectedFields.Add("");
            selectedFieldsTitle.Add("تلفن");

            selectedFields.Add("");
            selectedFieldsTitle.Add("فاکس");
           
            selectedFields.Add("");
            selectedFieldsTitle.Add("کد پستی");
            
            selectedFields.Add("");
            selectedFieldsTitle.Add("آدرس");
            
            selectedFields.Add("");
            selectedFieldsTitle.Add("توضیحات");
            
            selectedFields.Add("");
            selectedFieldsTitle.Add("متن اضافی");
            
            selectedFields.Add(ViewInsuranceInfoData.BirthDate_FIELD + "_SHAMSI");
            selectedFieldsTitle.Add("تاریخ تولد");

            selectedFields.Add(ViewInsuranceInfoData.endDate_FIELD + "_SHAMSI");
            selectedFieldsTitle.Add("تاریخ مناسبت");

            //Prepare template file
            String templateFile = Application.StartupPath + "\\" + "ReportTemplate.xml";
            String reportFile = Application.StartupPath + "\\" + "ExportToExcelData.xml";
            
            TextReader tr = new StreamReader(templateFile);
            String fileStr = tr.ReadToEnd();


            for (int i = 0; i < _dataSource.Tables[0].Rows.Count; i++)
            {
                _dataSource.Tables[0].Rows[i][ViewInsuranceInfoData.endDate_FIELD + "_SHAMSI"] =
                    RMX_TOOLS.date.DateXFormer.gregorianToPersianString((DateTime)
                        _dataSource.Tables[0].Rows[i][ViewInsuranceInfoData.endDate_FIELD]);
            }
            //
            string reportName = "";//no need
            string todayDate = "";
            string title = getTitles(selectedFields, selectedFieldsTitle);
            string allData = ExportToExcel.getData(_dataSource, selectedFields, selectedFieldsTitle);

            //
            if (fileStr == null || fileStr.Length <= 0)
            {
                MessageBox.Show("در خواندن فایل ReportTemplate.xml مشکلی رخ داده ");
                return;
            }
            int row = _dataSource.Tables[0].Rows.Count + 4;

            fileStr = fileStr.Replace(_userNameTemplate, reportName);
            fileStr = fileStr.Replace(_DateTemplate, todayDate);
            fileStr = fileStr.Replace(_TitleTemplate, title);
            fileStr = fileStr.Replace(_DataTemplate, allData);
            fileStr = fileStr.Replace(_Row, row + "");

            System.IO.StreamWriter _excelDoc;
            _excelDoc = new System.IO.StreamWriter(reportFile);
            _excelDoc.Write(fileStr);
            _excelDoc.Close();
            string path = reportFile;
            // System.Diagnostics.Process.Start(path);
            Insurance.ExportToExcel.executeExcel(reportFile);

        }

        private string getTitles(ArrayList selectedFields, ArrayList selectedFieldsTitle)
        {
            if (selectedFields.Count < 2)
            {
                return "";
            }
            
            string title = "<Cell ss:Index=\"1\" ss:StyleID=\"s26\"><Data ss:Type=\"String\">" + selectedFieldsTitle[0] + "</Data></Cell>";
            for (int i = 1; i < selectedFieldsTitle.Count - 1; i++)
            {
                title += "<Cell ss:StyleID=\"s27\"><Data ss:Type=\"String\">" + selectedFieldsTitle[i] + "</Data></Cell>";
            }
            title += "<Cell ss:StyleID=\"s28\"><Data ss:Type=\"String\">" + selectedFieldsTitle[selectedFieldsTitle.Count - 1] + "</Data></Cell>";

            return title;
        }

    }


}