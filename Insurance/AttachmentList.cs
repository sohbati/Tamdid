﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Insurance_Common;
using Insurance_BLL;
using RMX_TOOLS.data.grid;
using System.Collections;

namespace Insurance
{
    public partial class AttachmentList : Form
    {
        private AttachmentBL _attachmentBl;
        private GridTools _gridTools;
        private int _insuranceId;

        public AttachmentList(int insuranceId)
        {
            _insuranceId = insuranceId;

            _gridTools = new GridTools(dataGridView1);
            _attachmentBl = new AttachmentBL();

            InitializeComponent();

            fillGrid();
        }

        private void AttachmentList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1_DoubleClick(dataGridView1, null);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.SelectedRows.Count <= 0)
                return;

            DataGridViewRow dr = gv.SelectedRows[0];
            int id = -1;
            id = int.Parse(dr.Cells[AttachmentEntity.FIELD_ID].Value.ToString());
            //AttachmentForm form = new AttachmentForm(id, _letterId);
            //form.ShowDialog();
            //fillGrid();
            loadAttachment(id);
        }

        private void loadAttachment(int id)
        {
            string fp = "";
            try
            {
                AttachmentBL attachmentBL = new AttachmentBL();
                AttachmentEntity entity = attachmentBL.getById(id);
                string fileName = entity.Tables[0].Rows[0][AttachmentEntity.FIELD_FILE_NAME].ToString();
                try
                {
                    fileName = fileName.Substring(fileName.LastIndexOf("\\")).Replace("\\", "");
                }
                catch (Exception e) { }
                byte[] imageData = (byte[])entity.Tables[AttachmentEntity.TableName].Rows[0][AttachmentEntity.FIELD_CONTENT];

                string s = Application.ExecutablePath;
                fp = s.Substring(0, s.LastIndexOf("\\")) + "\\tmp\\";
                fp += fileName;
                File.WriteAllBytes(fp, imageData);

                Process.Start(fp);
            }
            catch (Exception e)
            {
                string tt = "خطای زیر رخ داده است" + "\n" +
                    "سیستم قادر به نمایش این فایل نیست" + "\n" +
                        "\n" + e.Message + "\n"
                    + "برای مشاهده این فایل به مسیر زیر مراجعه نمایید" + "\n"
                    + fp;

                MessageBox.Show(tt);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AttachmentForm form = new AttachmentForm(_insuranceId);
            form.ShowDialog();
            fillGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridView gv = dataGridView1;
            if (gv.SelectedCells.Count > 0)
            {
                DataGridViewColumn col = gv.Columns[gv.SelectedCells[0].ColumnIndex];

                if (col.DataGridView.SelectedCells.Count > 0 && gv.SelectedCells[0].Selected)
                {
                    DataGridViewRow dr = gv.SelectedCells[0].OwningRow;
                    int id = -1;
                    id = int.Parse(dr.Cells[AttachmentEntity.FIELD_ID].Value.ToString());
                    if (id > 0)
                    {
                        DialogResult dres = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
                        if (dres.Equals(DialogResult.Yes))
                        {
                            _attachmentBl.delete(id);
                            fillGrid();
                        }
                    }
                }
            }
        }

        private void fillGrid()
        {
            AttachmentEntity entity = null;
            entity = _attachmentBl.get(_insuranceId);

            System.Collections.Hashtable hash = new Hashtable();
            _gridTools.bindDataToGrid(dataGridView1, entity, AttachmentEntity.TableName, null, hash);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
