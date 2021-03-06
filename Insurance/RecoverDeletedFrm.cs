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

namespace Insurance
{ 
    public partial class RecoverDeletedFrm : Form
    { 
        public RecoverDeletedFrm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
        private void btnDo_Click(object sender, EventArgs e)
        {
            txtInsuranceNumber.Text = txtInsuranceNumber.Text.Trim();
            if (txtInsuranceNumber.Text.Length <= 0)
                return;

            string cond = "insuranceNumber='" + txtInsuranceNumber.Text + "' and cancel=1";
            ViewInsuranceInfoBS bs = new ViewInsuranceInfoBS();

            ViewInsuranceInfoData dataset = bs.load(cond);
            if (dataset.Tables[0].Rows.Count <= 0){
                MessageBox.Show("پیدا نشد");
                return;
            }

           int n =  new InsuranceInfoBS().recover(int.Parse(dataset.Tables[0].Rows[0][InsuranceInfoData.id_FIELD].ToString()));
           if (n <= 0)
               MessageBox.Show("امکان بازگرداندن این رکورد حذف شده نیست");
           else
               MessageBox.Show("رکورد مورد نظر بازگردانده شد");

        }

        private void txtInsuranceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDo_Click(null, null);
        }

        private void RecoverDeletedFrm_Load(object sender, EventArgs e)
        {
            int userype = int.Parse(UsersBS.loginedUser.Tables[UsersData.users_TABLE].Rows[0][UsersData.userType_FIELD] + "");
            if (userype == UsersBS.USER)
            {
                MessageBox.Show("فقط مدیر سیستم می تواند این فرم را مشاهده کند");
                this.Close();
            }
            txtInsuranceNumber.Focus();

        }

        private void RecoverDeletedFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}