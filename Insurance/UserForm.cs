using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Insurance_Common;
using Insurance_BLL;
using RMX_TOOLS.data.grid;

namespace Insurance
{
    public partial class UserForm : Form
    {
        private const string NEW_MODE = "new";
        private const string EDIT_MODE = "edit";
        private const string DELETE_MODE = "delete";

        private string dataMode = EDIT_MODE;
        private GridTools _gridTools;
        public UserForm()
        {
            InitializeComponent();
            _gridTools = new GridTools(dataGridView1);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtName.Focus();
            dataMode = NEW_MODE;
            emptyForm();
            newModeRestricts();
        }

        private void newModeRestricts()
        {
            dataGridView1.Enabled = false;
            btnDelete.Enabled = false;
            toolStripStatusLabel1.Text = "جدید";
        }

        private void emptyForm()
        {
            txtName.Text = "";
            txtFamily.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            cmbUserType.SelectedIndex = -1;
        }

        private string checkData()
        {
            txtName.Text = txtName.Text.Trim();
            txtFamily.Text = txtFamily.Text.Trim();
            txtUserName.Text = txtUserName.Text.Trim();
            txtPassword.Text = txtPassword.Text.Trim();

            string tmp;
            tmp = txtName.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا نام را وارد کنید";
            tmp = txtFamily.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا نام خانوادگی را وارد کنید";
            tmp = txtUserName.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا نام کاربری را وارد کنید";
            tmp = txtPassword.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا  کلمه عبور را وارد کنید";
            if (cmbUserType.SelectedIndex == -1)
                return "لطفا  نوع کاربر را وارد کنید";
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
            if (dataGridView1.RowCount <= 0)
                dataMode = NEW_MODE;

            UsersBS isb = new UsersBS();
            UsersData inData = new UsersData();

            DataRow dr = inData.Tables[UsersData.users_TABLE].NewRow();

            dr[UsersData.name_FIELD] = txtName.Text;
            dr[UsersData.family_FIELD] = txtFamily.Text;
            dr[UsersData.userName_FIELD] = txtUserName.Text;
            dr[UsersData.password_FIELD] = txtPassword.Text;
            dr[UsersData.userType_FIELD] = cmbUserType.SelectedIndex;

            if (!dataMode.Equals(NEW_MODE))
                dr[UsersData.id_FIELD] = _gridTools.getCurrentRowValue(UsersData.id_FIELD);

            object id = _gridTools.getCurrentRowValue(UsersData.id_FIELD);
            inData.Tables[UsersData.users_TABLE].Rows.Add(dr);

            int count;
            if (dataMode.Equals(NEW_MODE))
                count = isb.add(inData);
            else if (dataMode.Equals(EDIT_MODE))
                count = isb.update(inData);

            dataMode = EDIT_MODE;
            btnRefresh_Click(null, null);
            fillGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string val = _gridTools.getCurrentRowValue(UsersData.id_FIELD) + "";
            if (val == null || val.Trim().Length <= 0)
                return;
            DialogResult dr = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
            if (dr.Equals(DialogResult.Yes))
            {
                int id = int.Parse(val);
                new UsersBS().delete(id);
                emptyForm();

            }
            fillGrid();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            int userype = int.Parse(UsersBS.loginedUser.Tables[UsersData.users_TABLE].Rows[0][UsersData.userType_FIELD] + "");
            if (userype == UsersBS.USER)
            {
                MessageBox.Show("فقط مدیر سیستم می تواند این فرم را مشاهده کند");
                this.Close();
            }
            fillGrid();
            // LANGAUGE CHANGEING TO PERSIAN
            InputLanguage persinLanguage = InputLanguage.CurrentInputLanguage;
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Equals("Farsi"))
                    persinLanguage = InputLanguage.InstalledInputLanguages[i];
            InputLanguage.CurrentInputLanguage = persinLanguage;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            btnDelete.Enabled = true;
            toolStripStatusLabel1.Text = "";
            dataMode = EDIT_MODE;
        }

        private void UserForm_KeyDown(object sender, KeyEventArgs e)
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
            dataGridView1.DataSource = new UsersBS().load();
            dataGridView1.DataMember = UsersData.users_TABLE;
            setControls();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            UserForm_KeyDown(sender, e);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            setControls();
        }

        private void setControls()
        {
            _gridTools.setValue(txtName, UsersData.name_FIELD);
            _gridTools.setValue(txtFamily, UsersData.family_FIELD);
            _gridTools.setValue(txtUserName, UsersData.userName_FIELD);
            _gridTools.setValue(txtUserName, UsersData.userName_FIELD);
            _gridTools.setValue(txtPassword, UsersData.password_FIELD);
            _gridTools.setValue(cmbUserType, UsersData.userType_FIELD);
        }

    }
}