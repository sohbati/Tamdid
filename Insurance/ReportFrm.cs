using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Insurance_Common;
using Insurance_BLL;
using System.Diagnostics;
namespace Insurance
{
    public partial class ReportFrm : Form
    {

        private string _userNameTemplate = "-@USERNAME@-";
        private string _DateTemplate = "-@TODAY@-";
        private string _TitleTemplate = "-@TITLE@-";
        private string _DataTemplate = "-@DATA@-";
        private string _Row = "-@ROW@-";

        private string _fileStr = "";
        private string _templateFile = "ReportTemplate.xml";
        private string _reportFile = "generatedReport.xml";
        private ArrayList _selectedFields = new ArrayList();
        private ArrayList _selectedFieldsTitle = new ArrayList();
        private Boolean _reprotState;

        public RMX_TOOLS.common.AbstractCommonData _dataSet;
        public ReportFrm()
        {
            _templateFile = Application.StartupPath + "\\" + _templateFile;
            _reportFile = Application.StartupPath + "\\" + _reportFile;
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            generateReport();
        }

        private void generateReport()
        {
            getSelectedFields();
            readFile();
            // in Report temlplate we replace four text
            //1-  Reporter name
            //2-  Today date
            //3-  Titles
            //4-  filed values
            string reportName = getReportterName();
            string todayDate = getTodayDate();
            string title = getTitles();
            string allData = getData();
            
            // write to file
            if (!_reprotState)
            {
                MessageBox.Show("امکان ایجاد گزارش وجود ندارد");
                return;
            }

            if (_fileStr == null || _fileStr.Length <= 0)
            {
                MessageBox.Show("در خواندن فایل ReportTemplate.xml مشکلی رخ داده ");
                return;
            }
            int row = _dataSet.Tables[0].Rows.Count + 4;

            _fileStr = _fileStr.Replace(_userNameTemplate, reportName);
            _fileStr = _fileStr.Replace(_DateTemplate, todayDate);
            _fileStr = _fileStr.Replace(_TitleTemplate, title);
            _fileStr = _fileStr.Replace(_DataTemplate, allData);
            _fileStr = _fileStr.Replace(_Row, row + "");

            System.IO.StreamWriter _excelDoc;
            _excelDoc = new System.IO.StreamWriter(_reportFile);
            _excelDoc.Write(_fileStr);
            _excelDoc.Close();
            string path = _reportFile;
           // System.Diagnostics.Process.Start(path);
            Insurance.ExportToExcel.executeExcel(_reportFile);
        }

        private string getData()
        {
            if (_selectedFieldsTitle.Count < 2)
            {
                _reprotState = false;
                return "";
            }
            _reprotState = true;
            string data = "";
            string flds = "";
            string t;
            _dataSet = (RMX_TOOLS.common.AbstractCommonData)MainForm.getDataSet();
            for (int i = 0; i < _dataSet.Tables[0].Rows.Count; i++)
            {
                t = Insurance.ExportToExcel.generalizeData(_selectedFields[0].ToString(),_dataSet.Tables[0].Rows[i][_selectedFields[0].ToString()].ToString().Trim());

                flds = "<Row>\n\t<Cell ss:Index=\"3\"><Data ss:Type=\"String\">" + t + "</Data></Cell>\n";
                for (int j = 1; j < _selectedFields.Count ; j++)
                {
                    t = ExportToExcel.generalizeData(_selectedFields[j].ToString(), _dataSet.Tables[0].Rows[i][_selectedFields[j].ToString()].ToString().Trim());
                    flds += "\t<Cell><Data ss:Type=\"String\">" + t + "</Data></Cell>\n";
                }
                data += flds + "</Row>\n";
            }
            return data;
        }

        private string getTitles()
        {
            if (_selectedFields.Count < 2)
            {
                _reprotState = false;
                return "";
            }
            _reprotState = true;
            string title = "<Cell ss:Index=\"3\" ss:StyleID=\"s26\"><Data ss:Type=\"String\">" + _selectedFieldsTitle[0] + "</Data></Cell>";
            for (int i = 1; i < _selectedFieldsTitle.Count - 1; i++)
                {
                    title += "<Cell ss:StyleID=\"s27\"><Data ss:Type=\"String\">" + _selectedFieldsTitle[i] + "</Data></Cell>";
            }
            title += "<Cell ss:StyleID=\"s28\"><Data ss:Type=\"String\">" + _selectedFieldsTitle[_selectedFieldsTitle.Count - 1] + "</Data></Cell>";

            return title;
        }

        private string getReportterName()
        {
            if (cbxUserName.Checked)
               return " نام گزارش گیرنده :" +UsersBS.loginedUser.Tables[0].Rows[0][UsersData.name_FIELD].ToString().Trim() +
                     "  " +
                     UsersBS.loginedUser.Tables[0].Rows[0][UsersData.family_FIELD].ToString().Trim();
           return "";
        }

        private string getTodayDate()
        {
            if (cbxToday.Checked)
            {
                string dt = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Today);
                return "  : تاریخ گزارش " + dt;
            }
            return "";
        }
    
        private void getSelectedFields()
        {
            _selectedFields.Clear();
            _selectedFieldsTitle.Clear();
            if (cbxRadif.Checked)
            {
                _selectedFields.Add(ViewInsuranceInfoData.RADIF_FIELD);
                _selectedFieldsTitle.Add("ردیف");
            }
            if (cbxName.Checked)
            {
                _selectedFields.Add(ViewInsuranceInfoData.name_FIELD);
                _selectedFieldsTitle.Add("نام");
            }
            if (cbxFamily.Checked)
            {
                _selectedFields.Add(ViewInsuranceInfoData.family_FIELD);
                _selectedFieldsTitle.Add("نام خانوادگی");
            }
            if (cbxInsuranceNumber.Checked)
            {
                _selectedFields.Add(ViewInsuranceInfoData.insuranceNumber_FIELD);
                _selectedFieldsTitle.Add("شماره بیمه");
            }
            if (cbxPhoneNumber.Checked)
            {
                _selectedFields.Add(ViewInsuranceInfoData.phoneNumber_FIELD);
                _selectedFieldsTitle.Add("شماره تلفن");
            }
            if (cbxCaption.Checked)
            {
                _selectedFields.Add(ViewInsuranceInfoData.caption_FIELD);
                _selectedFieldsTitle.Add("نوع بیمه");
            }
            if (cbxBeginDate.Checked)
            {
                _selectedFields.Add(ViewInsuranceInfoData.beginDate_FIELD);
                _selectedFieldsTitle.Add("تاریخ شروع");
            }
            if (cbxEndDate.Checked)
            {
                _selectedFields.Add(ViewInsuranceInfoData.endDate_FIELD);
                _selectedFieldsTitle.Add("تاریخ اتمام");
            }
            if (cbxHaveDid.Checked)
            {
                _selectedFields.Add(ViewInsuranceInfoData.haveDid_FIELD);
                _selectedFieldsTitle.Add("انجام شده");
            }
            if (cbxAddress.Checked)
            {
                _selectedFields.Add(ViewInsuranceInfoData.address_FIELD);
                _selectedFieldsTitle.Add("آدرس");
            }
            if (cbxDescription.Checked)
            {
                _selectedFields.Add(ViewInsuranceInfoData.description_FIELD);
                _selectedFieldsTitle.Add("شرح");
            }
        }

        private void readFile()
        {
            TextReader tr = new StreamReader(_templateFile);
            _fileStr = tr.ReadToEnd();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F8)
                button5_Click(null, null);
            
        }
    }
}