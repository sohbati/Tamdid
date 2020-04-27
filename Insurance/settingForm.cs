using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Insurance_Common;
using Insurance_BLL;
using System.Collections;

namespace Insurance
{
    public partial class settingForm : Form
    {
        string _fileName = Application.StartupPath + "\\myXmFile.xml";
        public static string _publicSettingXML = Application.StartupPath + "\\publicSetting.xml";

        public static string cbxShowConfirmDialog_Alias = "cbxShowConfirmDialog";
        public static Hashtable _ht = new Hashtable();

        public settingForm()
        {
            InitializeComponent();
        }



        private void writeToXML()
        {
            string serverName = txtServerName.Text;
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            string databaseName = txtDatabaseName.Text;

            // Create a new file in C:\\ dir
            XmlTextWriter textWriter = new XmlTextWriter(_fileName, null);
            // Opens the document 
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("Server");
            textWriter.WriteStartElement("r", "RECORD", "urn:record");

            textWriter.WriteStartElement("ServerName", "");
            textWriter.WriteString(serverName);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("UserName", "");
            textWriter.WriteString(userName);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Password", "");
            textWriter.WriteString(password);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("DataBaseName", "");
            textWriter.WriteString(databaseName);
            textWriter.WriteEndElement();
            // Ends the document.

            textWriter.WriteEndDocument();

            // close writer

            textWriter.Close();


        }

        private void loadServerDataFromXMLFile()
        {

            DataSet dataset = new DataSet();
            try
            {
                dataset.ReadXmlSchema(_fileName);
                dataset.ReadXml(_fileName);
            }
            catch (Exception e)
            {
                return;
            }
            txtServerName.Text = dataset.Tables[0].Rows[0][0].ToString();
            txtUserName.Text = dataset.Tables[0].Rows[0][1].ToString();
            txtPassword.Text = dataset.Tables[0].Rows[0][2].ToString();
            txtDatabaseName.Text = dataset.Tables[0].Rows[0][3].ToString();


        }

        //  load public setting 
        public static void loadPublicSettingToHashTable()
        {
            DataSet psDataset = new DataSet();
            try
            {
                psDataset.ReadXmlSchema(_publicSettingXML);
                psDataset.ReadXml(_publicSettingXML);
            }
            catch (Exception e)
            {
                return;
            }
            string columnName = "";
            string t;
            _ht.Clear();
            for (int i = 0; i < psDataset.Tables[0].Rows.Count; i++)
            {
                for (int k = 0; k < psDataset.Tables[0].Columns.Count; k++)
                {
                    columnName = psDataset.Tables[0].Columns[k].Caption;
                    t = psDataset.Tables[0].Rows[i][columnName].ToString();
                    //                    if (t.Length <= 0)
                    //                        t = "false";
                    _ht.Add(columnName, t.ToString());
                }


            }

        }

        private void fillFormOfPubicSetting()
        {
            string value;
            if (_ht.Count <= 0)
                return;
            value = _ht[cmbScheduleForRefresh.Name].ToString();
            if (value != null || value.Length > 0)
                cmbScheduleForRefresh.Text = value.ToString();
            for (int i = 0; i < gbcheckBoxList.Controls.Count; i++)
            {
                CheckBox cb = (CheckBox)gbcheckBoxList.Controls[0];
                value = _ht[cb.Name].ToString();
                if (value != null || value.Length > 0)
                    cb.Checked = Boolean.Parse(value);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tmp;
            tmp = txtServerName.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
            {
                MessageBox.Show("نام سرور نباید خالی باشد");
                return;
            }
            tmp = txtUserName.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
            {
                MessageBox.Show("نام کاربر نباید خالی باشد");
                return;
            }
            tmp = txtPassword.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
            {
                //MessageBox.Show("کلمه عبور نباید خالی باشد");
                //return;
            }
            tmp = txtDatabaseName.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
            {
                MessageBox.Show("نام بانک اطلاعاتی نباید خالی باشد");
                return;
            }
            try
            {
                writeToXML();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در نوشتن در فایل");
                return;
            }
        }

        private void settingForm_Load(object sender, EventArgs e)
        {
            object value = null;
            try
            {
                value = UsersBS.loginedUser.Tables[UsersData.users_TABLE].Rows[0][UsersData.userType_FIELD];
            }
            catch (Exception ex)
            {
            }
            int userype = -1;
            if (value != null)
                userype = int.Parse(value.ToString().Trim());
            if (userype == UsersBS.USER && value != null)
            {
                MessageBox.Show("فقط مدیر سیستم می تواند این فرم را مشاهده کند");
                this.Close();
            }
            loadServerDataFromXMLFile();
            loadPublicSettingToHashTable();
            fillFormOfPubicSetting();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxShowConfirmDialog_CheckedChanged(object sender, EventArgs e)
        {
            //  _ht.Add(cbxShowConfirmDialog.Name, cbxShowConfirmDialog.Checked);
            SavePrivateSetting();
            loadPublicSettingToHashTable();

        }


        private void SavePrivateSetting()
        {

            XmlTextWriter textWriter = new XmlTextWriter(_publicSettingXML, null);
            // Opens the document 
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("setting");
            textWriter.WriteStartElement("r", "RECORD", "urn:record");
            for (int i = 0; i < gbcheckBoxList.Controls.Count; i++)
            {
                CheckBox cb = (CheckBox)gbcheckBoxList.Controls[i];
                string name = cb.Name;
                string value = cb.Checked.ToString();
                textWriter.WriteStartElement(name, "");
                textWriter.WriteString(value);
                textWriter.WriteEndElement();
            }
            //
            textWriter.WriteStartElement(cmbScheduleForRefresh.Name, "");
            textWriter.WriteString(cmbScheduleForRefresh.Text);
            textWriter.WriteEndElement();

            textWriter.WriteEndDocument();
            textWriter.Close();
        }

        private void settingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SavePrivateSetting();
            this.Close();

        }

    }
}