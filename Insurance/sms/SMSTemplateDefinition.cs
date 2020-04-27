using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Insurance_Common;

namespace Insurance.sms
{
    public partial class SMSTemplateDefinition : Form
    {
        Insurance_BLL.SmsTemplateDefinitionBS bs = new Insurance_BLL.SmsTemplateDefinitionBS();

        public SMSTemplateDefinition()
        {
            InitializeComponent();
        }

        private void SMSTemplateDefinition_Load(object sender, EventArgs e)
        {
            cmbTemplateType_SelectedIndexChanged(null, null);   
        }

        private void SMSTemplateDefinition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void nameLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            insert("#نام#");
        }

        private void insert(string text)
        {
            txtTemplate.Text = txtTemplate.Text.Insert(txtTemplate.SelectionStart, text);
        }

        private void FamilyLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            insert("#نام خانوادگی#");
        }

        private void insuranceNumberLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            insert("#شماره بیمه#");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            if (!validate())
            {
                return;
            }

            SmsTemplateDefinitionData data = getTemplateByType();
            if (!isEmpty(data))
            {
                update(data);
            }
            else
            {
                persistNew();
            }

            MessageBox.Show("الگوی مورد نظر ذخیره شد");
            
        }

        private void update(SmsTemplateDefinitionData data)
        {
            data.Tables[0].Rows[0][SmsTemplateDefinitionData.FIELD_TEMPLATE] = txtTemplate.Text.Trim();

            bs.update(data);
        }

        private void persistNew()
        {


            SmsTemplateDefinitionData inData = new SmsTemplateDefinitionData();

            DataRow dr = inData.Tables[SmsTemplateDefinitionData.TableName].NewRow();
            dr[SmsTemplateDefinitionData.FIELD_TEMPLATE_TYPE] = getTemplateType();
            dr[SmsTemplateDefinitionData.FIELD_TEMPLATE] = txtTemplate.Text.Trim();

            inData.Tables[SmsTemplateDefinitionData.TableName].Rows.Add(dr);

            bs.add(inData);

        }

        private SmsTemplateDefinitionData getTemplateByType()
        {
            int type = cmbTemplateType.SelectedIndex;
            return bs.getByTemplatebyType(type);
        }

        private int getTemplateType()
        {
            return cmbTemplateType.SelectedIndex;
        }

        private bool validate()
        {
            if (cmbTemplateType.SelectedIndex < 0)
            {
                MessageBox.Show("نوع الگو را انتخاب نمایید");
                return false;
            }

            if (txtTemplate.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا متن الگو را وارد نمایید");
                return false;
            }

            return true;

        }

        private bool isEmpty(SmsTemplateDefinitionData data)
        {
            return data == null || data.Tables.Count == 0 || data.Tables[0].Rows.Count == 0;
        }

        private void cmbTemplateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTemplate.Text = "";
            SmsTemplateDefinitionData data = bs.getByTemplatebyType(cmbTemplateType.SelectedIndex);
            if (!isEmpty(data)) {
                txtTemplate.Text = data.Tables[0].Rows[0][SmsTemplateDefinitionData.FIELD_TEMPLATE].ToString();
            }
        }
    }

   

}
