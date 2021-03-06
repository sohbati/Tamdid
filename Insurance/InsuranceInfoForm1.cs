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
    public partial class InsuranceInfoForm1 : Form
    {
        public int _id = 0;
        public bool isDeleted = false;
        private DataSet _dataSource;

        RMX_TOOLS.date.DatePicker _datePicker = new RMX_TOOLS.date.DatePicker();
        private InsuranceInfoBS insuranceInfoBs = new InsuranceInfoBS();

        public InsuranceInfoForm1()
        {
            InitializeComponent();
            
        }
 
        private void initForm()
        {
            isDeleted = false;
            if (_id > 0)
            {
                InsuranceInfoData data = insuranceInfoBs.getById(_id);
                txtName.Text = data.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows[0][InsuranceInfoData.name_FIELD].ToString();
                cmbCustomerType.SelectedIndex =
                    (int)data.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows[0][InsuranceInfoData.CustomerType_FIELD];
                txtFamily.Text = data.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows[0][InsuranceInfoData.family_FIELD].ToString();
                txtPhoneNumber.Text = data.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows[0][InsuranceInfoData.phoneNumber_FIELD].ToString();
                txtMobilePhone.Text = data.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows[0][InsuranceInfoData.mobileNumber_FIELD].ToString();
                txtBirthDate.Text = toShamsiString(data, InsuranceInfoData.BirthDate_FIELD);
                txtAddress.Text = data.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows[0][InsuranceInfoData.address_FIELD].ToString();

                selectComboItemForInsuraceType(int.Parse(
                     data.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows[0][InsuranceInfoData.insuranceType_FIELD].ToString()));
                txtInsuranceNumber.Text = data.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows[0][InsuranceInfoData.insuranceNumber_FIELD].ToString();

                txtBeginDate.Text = toShamsiString(data, InsuranceInfoData.beginDate_FIELD);
                txtEndDate.Text = toShamsiString(data, InsuranceInfoData.endDate_FIELD);

                txtLastUpdateDate.Text = toShamsiString(data, InsuranceInfoData.creationDate_FIELD);
                txtCreationDate.Text = toShamsiString(data, InsuranceInfoData.lastUpdateDate_FIELD);

                txtDescription.Text = data.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows[0][InsuranceInfoData.description_FIELD].ToString();
            }else
            {
                linkAttachment.Enabled = false;
                txtCreationDate.Text = getTodayShamsi();
                txtLastUpdateDate.Text = getTodayShamsi();
            }
        }

        private string getTodayShamsi()
        {
            string todayShamsi = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Now);
            /*String[] dateArr = todayShamsi.Split('/');

            DateTime persianDateDime = new DateTime(int.Parse(dateArr[0]),
                    int.Parse(dateArr[1]),
                    int.Parse(dateArr[2]), new PersianCalendar());*/
            return todayShamsi;
        }
        private void selectComboItemForInsuraceType(int value)
        {
            cmbInsuranceType.SelectedValue = value;
        }

        private String toShamsiString(InsuranceInfoData data, string fieldName)
        {
            Object obj = data.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows[0][fieldName];
            if (obj != null && obj.ToString().Length > 0)
            {
                return RMX_TOOLS.date.DateXFormer.gregorianToPersianString((DateTime)obj);
            }
            return "";
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
 
            InsuranceInfoData inData = new InsuranceInfoData();
            DataRow dr = inData.Tables[InsuranceInfoData.insuranceInfo_TABLE].NewRow();
            dr[InsuranceInfoData.id_FIELD] = _id;
            dr[InsuranceInfoData.name_FIELD] = txtName.Text.Trim();
            dr[InsuranceInfoData.family_FIELD] = txtFamily.Text.Trim();
            dr[InsuranceInfoData.phoneNumber_FIELD] = txtPhoneNumber.Text.Trim();
            dr[InsuranceInfoData.insuranceNumber_FIELD] = txtInsuranceNumber.Text.Trim();

            dr[InsuranceInfoData.haveDid_FIELD] = cbxHaveDid.Checked;
            dr[InsuranceInfoData.address_FIELD] = txtAddress.Text.Trim();
            dr[InsuranceInfoData.description_FIELD] = txtDescription.Text.Trim();

            dr[InsuranceInfoData.mobileNumber_FIELD] = txtMobilePhone.Text.Trim();
            dr[InsuranceInfoData.CustomerType_FIELD] = cmbCustomerType.SelectedIndex;
 
            #region dateValidation
            GregorianCalendar gcal = new GregorianCalendar();
            int d = 12;
            int m = 0;
            int y = 0;
            CheckDate.checkDate(txtBeginDate.Text, ref y, ref m, ref d);
            DateTime persianDateTime = new DateTime(y, m, d, new PersianCalendar());
            DateTime greorianDateTime =
                new DateTime(gcal.GetYear(persianDateTime),
                             gcal.GetMonth(persianDateTime),
                             gcal.GetDayOfMonth(persianDateTime), new GregorianCalendar());

            dr[InsuranceInfoData.beginDate_FIELD] = greorianDateTime;

            //
            CheckDate.checkDate(txtEndDate.Text, ref y, ref m, ref d);
            persianDateTime = new DateTime(y, m, d, new PersianCalendar());
            greorianDateTime =
                new DateTime(gcal.GetYear(persianDateTime),
                             gcal.GetMonth(persianDateTime),
                             gcal.GetDayOfMonth(persianDateTime), new GregorianCalendar());

            dr[InsuranceInfoData.endDate_FIELD] = greorianDateTime;
            //

            //Creation Date
            String todayShamsi;
            String[] dateArr;
            CheckDate.checkDate(txtCreationDate.Text, ref y, ref m, ref d);
             
            persianDateTime = new DateTime(y, m, d, new PersianCalendar());
            greorianDateTime =
                new DateTime(gcal.GetYear(persianDateTime),
                             gcal.GetMonth(persianDateTime),
                             gcal.GetDayOfMonth(persianDateTime), new GregorianCalendar());

            dr[InsuranceInfoData.creationDate_FIELD] = greorianDateTime;
            //
            //Last update date
            todayShamsi = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Now);
            dateArr = todayShamsi.Split('/');
             
            persianDateTime = new DateTime(int.Parse(dateArr[0]) ,
                    int.Parse(dateArr[1]),
                    int.Parse(dateArr[2]), new PersianCalendar());
            greorianDateTime =
                new DateTime(gcal.GetYear(persianDateTime),
                             gcal.GetMonth(persianDateTime),
                             gcal.GetDayOfMonth(persianDateTime), new GregorianCalendar());

            dr[InsuranceInfoData.lastUpdateDate_FIELD] = greorianDateTime;
            //
            //Birth date
            if (txtBirthDate.Text.Trim() != DateConstants.NULL_Date.Trim())
            {
                CheckDate.checkDate(txtBirthDate.Text, ref y, ref m, ref d);
                persianDateTime = new DateTime(y, m, d, new PersianCalendar());
                greorianDateTime =
                    new DateTime(gcal.GetYear(persianDateTime),
                                 gcal.GetMonth(persianDateTime),
                                 gcal.GetDayOfMonth(persianDateTime), new GregorianCalendar());

                dr[InsuranceInfoData.BirthDate_FIELD] = greorianDateTime;
            }
            #endregion

            //fetch id from comboBox
            int insuranceTypeId = int.Parse(cmbInsuranceType.SelectedValue + "");
            dr[InsuranceInfoData.insuranceType_FIELD] = insuranceTypeId;
            string insuranceNumber = txtInsuranceNumber.Text.Trim();
            inData.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows.Add(dr);
            try
            {
                if (insuranceInfoBs.checkInsuranceNumberExists(txtInsuranceNumber.Text.Trim(), _id))
                {
                    MessageBox.Show("امکان اضافه کردن این رکورد وجود ندارد ، شماره بیمه تکراری است");
                    txtInsuranceNumber.Focus();
                    return;
                }

                if (cbxHaveDid.Checked)
                {
                    string endDate = insuranceInfoBs.getEndDateByInsuranceNumer(txtInsuranceNumber.Text.Trim());
                    checkForLogging(_id, endDate);
                }

                if (_id > 0)
                {
                    insuranceInfoBs.update(inData);
                }else
                {
                    insuranceInfoBs.add(inData);
                }
                this.Close();
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

 
           // MainForm.MainFormInstance.fillGrid();

            
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
 
 

        private void InsuranceInfoForm_Load(object sender, EventArgs e)
        {

             string y = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Today);
            fillInsuranceTypeCmboBox();

            //
            // LANGAUGE CHANGEING TO PERSIAN
            InputLanguage persinLanguage = InputLanguage.CurrentInputLanguage;
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Equals("Farsi"))
                    persinLanguage = InputLanguage.InstalledInputLanguages[i];
            InputLanguage.CurrentInputLanguage = persinLanguage;
 
             getAttachmentCount();

            initForm();
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
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkAttachment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int insuranceId = _id;
            if (insuranceId != null && insuranceId >= 0)
            {
                AttachmentList list = new AttachmentList(insuranceId);
                list.ShowDialog();
            }
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

                 
            DialogResult dr = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
            if (dr.Equals(DialogResult.Yes)) {

                insuranceInfoBs.delete(_id);
                isDeleted = true;
                this.Close();
            }
            

        }
        
    }
}