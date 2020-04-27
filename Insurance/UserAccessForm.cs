using Insurance_BLL;
using Insurance_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Insurance_BLL;
using Insurance_Common;

namespace Insurance
{
    public partial class UserAccessForm : Form
    {
        private UsersAccessData m_userAccessData = null;
        Insurance_BLL.UsersAccessBS m_UseraccessBS = new Insurance_BLL.UsersAccessBS();
        public UserAccessForm()
        {
            InitializeComponent();

         }

        private void load()
        {
            int userype = int.Parse(UsersBS.loginedUser.Tables[UsersData.users_TABLE].Rows[0][UsersData.userType_FIELD] + "");
            if (userype == UsersBS.USER)
            {
                MessageBox.Show("فقط مدیر سیستم می تواند این فرم را مشاهده کند");
                this.Close();
            }
            
            UsersBS usersbs = new UsersBS();
            UsersData usersData = usersbs.loadNonManagers();

            for (int i = 0; i < usersData.Tables[0].Rows.Count; i++)
            {
                int id =  int.Parse(usersData.Tables[0].Rows[i][UsersData.id_FIELD].ToString());
                string name = usersData.Tables[0].Rows[i][UsersData.name_FIELD].ToString().Trim() + "  " + 
                    usersData.Tables[0].Rows[i][UsersData.family_FIELD].ToString().Trim();
                string username = usersData.Tables[0].Rows[i][UsersData.userName_FIELD].ToString().Trim();
                name += "(" + username + ")";

                cmbUserList.Items.Add(new CmbUserItem(id, name));
            }

        }

        private void UserAccessForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserAccessForm_Load(object sender, EventArgs e)
        {
            load();
        }

        private class CmbUserItem
        {
            public CmbUserItem(int id, string name)
            {
                this.Id = id;
                this.name = name;
            }

            private int id;

            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //user id
            if (cmbUserList.SelectedIndex < 0)
            {
                MessageBox.Show("لطفا یک کابر انتخاب نمایید");
                return;
            }

            CmbUserItem item = (CmbUserItem)cmbUserList.Items[cmbUserList.SelectedIndex];
            int userid = item.Id;


            if (m_userAccessData == null)  
            {
                m_userAccessData = new Insurance_Common.UsersAccessData();
            }

            DataRow dr = null;
            if (m_userAccessData.Tables[0].Rows.Count <= 0) 
                 dr = m_userAccessData.Tables[UsersAccessData.usersAccess_TABLE].NewRow();
            else
                dr = m_userAccessData.Tables[UsersAccessData.usersAccess_TABLE].Rows[0];

            dr[UsersAccessData.accessToArchive_FIELD] = cbxAccessToArchive.Checked;
            dr[UsersAccessData.accessToInsuranceInfo_FIELD] = cbxAccessToInsuranceInfo.Checked;
            dr[UsersAccessData.printSearchResult_FIELD] = cbxAccessPrintSeachResult.Checked;
            dr[UsersAccessData.userid_FIELD] = userid;
    
            if (m_userAccessData.Tables[0].Rows.Count <= 0)
            {
                m_userAccessData.Tables[UsersAccessData.usersAccess_TABLE].Rows.Add(dr);
                m_UseraccessBS.add(m_userAccessData);
            }else
                m_UseraccessBS.update(m_userAccessData);
            MessageBox.Show("ذخیره شد");
        }

        private void cmbUserList_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbxAccessToArchive.Checked = false;
            cbxAccessToInsuranceInfo.Checked = false;
            cbxAccessPrintSeachResult.Checked = false;

            CmbUserItem useritem = (CmbUserItem)cmbUserList.Items[cmbUserList.SelectedIndex];
            int userid = useritem.Id;
            if (userid <= 0)
            {
                //MessageBox.Show("");
            }
            else
            {

                m_userAccessData = m_UseraccessBS.load(userid);
                if (m_userAccessData.Tables.Count > 0 && m_userAccessData.Tables[0].Rows.Count > 0)
                {
                    string access = m_userAccessData.Tables[0].Rows[0][UsersAccessData.accessToArchive_FIELD].ToString();
                    cbxAccessToArchive.Checked = bool.Parse(access == null || access.Trim() == "" ? "false" : access);

                    access = m_userAccessData.Tables[0].Rows[0][UsersAccessData.accessToInsuranceInfo_FIELD].ToString();
                    cbxAccessToInsuranceInfo.Checked = bool.Parse(access == null || access.Trim() == "" ? "false" : access);
                    
                    access =  m_userAccessData.Tables[0].Rows[0][UsersAccessData.printSearchResult_FIELD].ToString();
                    cbxAccessPrintSeachResult.Checked = bool.Parse(access == null || access.Trim() == "" ? "false" : access);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
