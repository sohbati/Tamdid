using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Insurance_Common;
using System.IO;
using Insurance_BLL;
using System.Diagnostics;

namespace Insurance
{
    public partial class AttachmentForm : Form
    {
        private byte[] _imageData;

        //private int _id = -1;
        private int _insuranceId;
        //private string _fileName;
        private AttachmentBL _attachmentBL;

        public AttachmentForm(int letterId)
        {
            _insuranceId = letterId;
            _attachmentBL = new AttachmentBL();

            InitializeComponent();

             
        }

        private void AttachmentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "انتخاب عکس";
            openFileDialog1.Filter = "ALL Files|*.*";
            //openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();

            //string s = openFileDialog1.FileName;
            string[] selecteds = openFileDialog1.FileNames;
            /* if (s != null && s.Length > 0 && isImage(s))
             {
                 txtFullFileName.Text = s;
                 txtFileName.Text = s.Substring(s.LastIndexOf('\\') + 1, s.Length - s.LastIndexOf('\\') - 1);
                 Image img = Image.FromFile(s);
                 //pictureBox1.Image = img;
                 //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
             }
             else*/
            if (selecteds == null || selecteds.Length <= 0)
                return;
            for (int i = 0; i < selecteds.Length; i++)
            {
                //txtFullFileName.Text = s;
                checkedListBox1.Items.Add(selecteds[i], true);
                //txtFileName.Text = s.Substring(s.LastIndexOf('\\') + 1, s.Length - s.LastIndexOf('\\') - 1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count == 0)
                return;
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                string txtFullFileName = checkedListBox1.CheckedItems[i].ToString().Trim();
                try
                {
                    string s = txtFullFileName;
                    if (txtFullFileName.Length > 0)
                    {
                        s = s.Substring(s.LastIndexOf("\\")).Replace("\\", "");
                        AttachmentEntity entity = new AttachmentEntity();
                        DataRow dr = entity.Tables[AttachmentEntity.TableName].NewRow();

                        dr[AttachmentEntity.FIELD_INSURANCE_ID] = _insuranceId;
                        dr[AttachmentEntity.FIELD_FILE_NAME] = s;
                        // dr[AttachmentEntity.FIELD_ID] = _id;
                        dr[AttachmentEntity.FIELD_CONTENT] = ReadFile(txtFullFileName);
                        entity.Tables[AttachmentEntity.TableName].Rows.Add(dr);

                        /*if (_id > 0)
                        {
                            _attachmentBL.update(entity);
                            //lblMsg.Text = "به روز رسانی گردید";
                        }
                        else*/
                        {
                            _attachmentBL.add(entity);
                            //lblMsg.Text = "ذخیره شد  ";
                        }

                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message != null && (ex.Message.IndexOf("cannot access the file ") >= 0 ||
                        ex.Message.IndexOf("") >= 0))
                    {
                        MessageBox.Show("فایل مورد نظر توسط برنامه ای دیگر در حال استفاده است!" +
                            "\n" + ex.Message);
                        return;
                    }
                }
            }
            this.Close();
        }

        private byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes 
            //to read from file.
            //In this case we want to read entire file. 
            //So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);

            return data;
        }

        private void btnDisplayInWindows_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem == null)
                return;
            string s = Application.ExecutablePath;
            string fp = s.Substring(0, s.LastIndexOf("\\")) + "\\tmp\\";
            fp = checkedListBox1.SelectedItem.ToString();
            //File.WriteAllBytes(fp, _imageData);

            Process.Start(fp);
        }
    }
}
