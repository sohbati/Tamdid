using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Insurance_Common;
using Insurance_BLL;

namespace Insurance
{
    public partial class LoginForm : Form
    {
        private static Boolean _loggined = false;

        public static Boolean Loggined
        {
            get { return LoginForm._loggined; }
            set { LoginForm._loggined = value; }
        }

        private static Boolean _checkJustManager = false;

        public static Boolean CheckJustManager
        {
            get { return LoginForm._checkJustManager; }
            set { LoginForm._checkJustManager = value; }
        }

        private bool isExitAfterUnLogin;

        public bool IsExitAfterUnLogin
        {
            get { return isExitAfterUnLogin; }
            set { isExitAfterUnLogin = value; }
        }
        
        public LoginForm()
        {
            InitializeComponent();
            _loggined = false;
        }

        
        private string checkData()
        {
            string tmp;
            tmp = txtUserName.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا نام کاربری را وارد کنید";
            tmp = txtPassword.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا  کلمه عبور را وارد کنید";
            return null;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loggined = false;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEnter_Click(null,null);
            }
        }

        private void txtEnter_Click(object sender, EventArgs e)
        {
            string check = checkData();
            if (check != null)
            {
                MessageBox.Show(check);
                return;
            }
            UsersBS isb = new UsersBS();
            UsersData userData = new UsersData();
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
             
            userData = isb.checkUser(userName, password,_checkJustManager);
            int userCount = userData.Tables[UsersData.users_TABLE].Rows.Count;
            if (userCount > 0)
            {
                UsersBS.loginedUser = userData;
                _loggined = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("نام کاربر یا کلمه عبور معتبر نیست");
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}