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
    public partial class InsuranceTypeForm : Form
    {
        InsuranceTypeBS _insuranceTypeBS;
        private const string NEW_MODE = "new";
        private const string EDIT_MODE = "edit";
        private const string DELETE_MODE = "delete";

        private string dataMode = EDIT_MODE;
        private GridTools _gridTools;

        public InsuranceTypeForm()
        {
            InitializeComponent();
            _insuranceTypeBS = new InsuranceTypeBS();
            _gridTools = new GridTools(dataGridView1);
        }

        private void InsuranceTypeForm_Load(object sender, EventArgs e)
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
            txtInsuranceType.Focus();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            setControls();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = -1;
            if (dataGridView1.RowCount <= 0)

                dataMode = NEW_MODE;
            if (!dataMode.Equals(NEW_MODE))
                id = int.Parse(_gridTools.getCurrentRowValue(InsuranceTypeData.InsuranceId_FIELD) + "");

            string caption = _gridTools.getCurrentRowValue(InsuranceTypeData.InsuranceCaption_FIELD) + "";


            InsuranceTypeBS isb = new InsuranceTypeBS();
            string strCaption = this.txtInsuranceType.Text;
            if (strCaption.Trim().Length <= 0)
            {
                txtInsuranceType.Focus();
                MessageBox.Show("لطفا یک مقدار برای نوع بیمه وارد کنید");
                return;
            }
            string str = this.cmbDaysBeforExp.Text;
            int d = 0;
            if (str.Trim().Length <= 0)
            {
                cmbDaysBeforExp.Focus();
                MessageBox.Show("لطفا یک مقدار برای نوع بیمه وارد کنید");
                return;
            }
            try
            {
                d = int.Parse(str);
            }
            catch (Exception ex)
            {
                cmbDaysBeforExp.Focus();
                MessageBox.Show("عدد وارد شده برای روز صحیح نیست");
                return;
            }

            string colorStr = ColorTranslator.ToHtml(pnlColor.BackColor);
            InsuranceTypeData inData = new InsuranceTypeData();
            DataRow dr = inData.Tables[InsuranceTypeData.InsuranceType_TABLE].NewRow();
            dr[InsuranceTypeData.InsuranceCaption_FIELD] = strCaption;
            dr[InsuranceTypeData.DAYSBEFOREXP_FIELD] = d;
            dr[InsuranceTypeData.InsuranceId_FIELD] = id;
            dr[InsuranceTypeData.INSURANCETYPECOLOR_FIELD] = colorStr;

            inData.Tables[InsuranceTypeData.InsuranceType_TABLE].Rows.Add(dr);
            if (dataMode.Equals(NEW_MODE))
                isb.add(inData);
            else if (dataMode.Equals(EDIT_MODE))
                isb.update(inData);

            dataMode = EDIT_MODE;
            btnRefresh_Click(null, null);
            fillGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            InsuranceTypeBS isb = new InsuranceTypeBS();
            string idStr = _gridTools.getCurrentRowValue(InsuranceTypeData.InsuranceId_FIELD) + "";
            if (idStr == null || idStr.Length <= 0)
                return;
            DialogResult dr = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
            if (dr.Equals(DialogResult.Yes))
            {

                int id = int.Parse(idStr);
                InsuranceTypeData inData = new InsuranceTypeData();
                int n = isb.delete(id);
                if (n == 0) // there is an error in deleting
                    MessageBox.Show("امکان حذف این مقدار وجود ندارد");
                emptyForm();
                fillGrid();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtInsuranceType.Focus();
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
            txtInsuranceType.Text = "";
            cmbDaysBeforExp.Text = "";
            pnlColor.BackColor = Color.White;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            btnDelete.Enabled = true;
            toolStripStatusLabel1.Text = "";
            dataMode = EDIT_MODE;
            fillGrid();
        }

        private void btnColorSelect_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            pnlColor.BackColor = cd.Color;
        }

        private void fillGrid()
        {
            System.Collections.Hashtable hash = new System.Collections.Hashtable();
            hash.Add("colorField", InsuranceTypeData.INSURANCETYPECOLOR_FIELD);
            _gridTools.bindDataToGrid(
                dataGridView1, new InsuranceTypeBS().laod(),
                InsuranceTypeData.InsuranceType_TABLE, new GridTools.changingRow(_gridTools.changeColor), hash);
            setControls();
        }

        private void setControls()
        {
            _gridTools.setValue(txtInsuranceType, InsuranceTypeData.InsuranceCaption_FIELD);
            _gridTools.setValue(cmbDaysBeforExp, InsuranceTypeData.DAYSBEFOREXP_FIELD, "text");
            string val = _gridTools.getCurrentRowValue(InsuranceTypeData.INSURANCETYPECOLOR_FIELD) + "";
            if (val != null)
                pnlColor.BackColor = ColorTranslator.FromHtml(val);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            InsuranceTypeForm_KeyDown(sender, e);
        }

        private void InsuranceTypeForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
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

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            setControls();
        }

        
    }
}