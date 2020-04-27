using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Insurance_Common;
using Insurance_BLL;
using Insurance.smsSendService;

namespace Insurance.sms
{
    public partial class SmsSelectedListForm : Form
    {
        ArrayList selectedIds = null;
        public SmsSelectedListForm(ArrayList ids)
        {
            this.selectedIds = ids;
            InitializeComponent();
        }

        private void SmsSelectedListForm_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void fillGrid()
        {
            if (selectedIds.Count == 0)
            {
                return;
            }
            InsuranceInfoBS bs = new InsuranceInfoBS();
            InsuranceInfoData data = bs.getByIds(selectedIds);

            DataRowCollection rows = data.Tables[0].Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                long id = (long)rows[i][InsuranceInfoData.id_FIELD];

                Object[] row = new object[8];
                row[0] = i + 1;
                row[1] = "";
                row[2] = "";
                row[3] = rows[i][InsuranceInfoData.mobileNumber_FIELD];
                row[4] = rows[i][InsuranceInfoData.name_FIELD];
                row[5] = rows[i][InsuranceInfoData.family_FIELD];
                row[6] = rows[i][InsuranceInfoData.insuranceNumber_FIELD];
                row[7] = rows[i][InsuranceInfoData.id_FIELD] = id;
                dataGridView1.Rows.Add(row);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SmsSelectedListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SmsSendService service = new SmsSendService();
            service.sendTest();
        }


    }
}
