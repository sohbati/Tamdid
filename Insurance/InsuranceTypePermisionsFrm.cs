using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Insurance_Common;
using Insurance_BLL;
using RMX_TOOLS.tools;

namespace Insurance
{
    public partial class InsuranceTypePermisionsFrm : Form
    {
        private UsersBS _usersBs = new UsersBS();
        private InsuranceTypeBS _insuranceTypeBS = new InsuranceTypeBS();
        public InsuranceTypePermisionsFrm()
        {
            InitializeComponent();
        }

        private void InsuranceTypePermisionsFrm_Load(object sender, EventArgs e)
        {
            int userype = int.Parse(UsersBS.loginedUser.Tables[UsersData.users_TABLE].Rows[0][UsersData.userType_FIELD] + "");
            if (userype == UsersBS.USER)
            {
                MessageBox.Show("فقط مدیر سیستم می تواند این فرم را مشاهده کند");
                this.Close();
            }
            fillInsuranceTypeCmboBox();
            fillUserList();
            lstUserList_SelectedIndexChanged(null, null);
        }

        private void fillUserList()
        {
            UsersData dataSet = new UsersBS().load();
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    string name = dataSet.Tables[0].Rows[i][UsersData.name_FIELD].ToString();
                    string family = dataSet.Tables[0].Rows[i][UsersData.family_FIELD].ToString();
                    int id = int.Parse(dataSet.Tables[0].Rows[i][UsersData.indexField].ToString());

                    item.Value = id;
                    item.Name = name + " " + family; 
                    lstUserList.Items.Add(item);
                    //lstUserList.DataSource = dataSet.Tables[UsersData.users_TABLE];
                    //lstUserList.DisplayMember = UsersData.family_FIELD;
                    //lstUserList.ValueMember = UsersData.id_FIELD;
                }
            }
        }

        private void fillInsuranceTypeCmboBox()
        {
            InsuranceTypeData dataSet = new InsuranceTypeBS().laod();
            cmbInsuranceType.DataSource = dataSet.Tables[InsuranceTypeData.InsuranceType_TABLE];
            cmbInsuranceType.DisplayMember = InsuranceTypeData.InsuranceCaption_FIELD;
            cmbInsuranceType.ValueMember = InsuranceTypeData.InsuranceId_FIELD;
            
        }

        private void lstUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUserList.SelectedIndex < 0)
                return;

            ComboBoxItem item = (ComboBoxItem)lstUserList.Items[lstUserList.SelectedIndex];

            InsuranceTypeData insTypeDataSet = _insuranceTypeBS.userLimitedList((int)item.Value);
            lstUserInsuranceTypes.DataSource = insTypeDataSet.Tables[InsuranceTypeData.InsuranceType_TABLE];
            lstUserInsuranceTypes.DisplayMember = InsuranceTypeData.InsuranceCaption_FIELD;
            lstUserInsuranceTypes.ValueMember = InsuranceTypeData.InsuranceId_FIELD;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbInsuranceType.SelectedIndex < 0)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید ");
                return;
            }
            
            if (lstUserList.SelectedIndex < 0)
            {
                MessageBox.Show("لطفا یک کاربر را انتخاب کنید");
                return;
            }
            ComboBoxItem cmbItem = (ComboBoxItem)lstUserList.Items[lstUserList.SelectedIndex];
            // check permision existing 
            #region check permision existing
            DataRowView item = (DataRowView)cmbInsuranceType.SelectedItem;
            DataRowView drv;
            
            for (int i = 0; i < lstUserInsuranceTypes.Items.Count; i++)
            {
                drv = (DataRowView)lstUserInsuranceTypes.Items[i];
                if (item.Row[0].ToString().Equals(drv.Row[0].ToString()))
                {
                    MessageBox.Show("مورد انتخابی در لیست وجود دارد");
                    return;
                }
            }
            #endregion

            int insuranceTypeId = int.Parse(cmbInsuranceType.SelectedValue + "");

            ComboBoxItem cbItem = (ComboBoxItem)lstUserList.Items[lstUserList.SelectedIndex];

            int userId = (int)cbItem.Value;
            _usersBs.addInsuranceTypePerm(userId, insuranceTypeId);
            lstUserList_SelectedIndexChanged(null, null);
            MainForm.MainFormInstance.fillGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstUserInsuranceTypes.SelectedValue == null)
            {
                MessageBox.Show("لطفا یک مورد را انتخاب کنید");
                return;
            }
            if (lstUserList.SelectedIndex < 0)
            {
                MessageBox.Show("لطفا یک کاربر را انتخاب کنید");
                return;
            }
            ComboBoxItem item = (ComboBoxItem)lstUserList.Items[lstUserList.SelectedIndex];
            
            DataRowView drv;
            drv = (DataRowView)lstUserInsuranceTypes.SelectedItem;
            int insuranceTypeId = int.Parse(drv.Row[0].ToString());

            int userId = (int)item.Value;
            _usersBs.deleteInsuranceTypePerm(userId, insuranceTypeId);
            lstUserList_SelectedIndexChanged(null, null);
            MainForm.MainFormInstance.fillGrid();


        }

        private void InsuranceTypePermisionsFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

        }

    }
}