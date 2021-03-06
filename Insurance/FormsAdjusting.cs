using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Insurance
{
    public partial class FormsAdjusting : Form
    {
        public DataSet _dataSet;
        public string _fileName;

        public DataGridView _formDataGridView;
        public FormsAdjusting()
        {
            InitializeComponent();
            _dataSet = new DataSet();
            
        }

        private void FormsAdjusting_Load(object sender, EventArgs e)
        {
            loadXML();
        }

        //save
        private void button1_Click(object sender, EventArgs e)
        {
            SaveXML();
            loadGridSetting(_fileName, _formDataGridView);
//            MainForm.MainFormInstance.loadGridSetting();
        }

        private void loadXML()
        {
            try
            {
                _dataSet.ReadXmlSchema(_fileName);
                _dataSet.ReadXml(_fileName);
            }
            catch (Exception ed)
            {
                MessageBox.Show("فایل تنظیمات آلارم پیدا نشد "+"\n" + ed.Message);
            }
            if (_dataSet.Tables.Count <= 0)
                return;
            if (_dataSet.Tables[0].Rows.Count <= 0)
                return;

            for (int i = 0; i < _dataSet.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(_dataSet.Tables[0].Rows[i][0],
                        _dataSet.Tables[0].Rows[i][1],
                        _dataSet.Tables[0].Rows[i][2],
                        _dataSet.Tables[0].Rows[i][3],
                        _dataSet.Tables[0].Rows[i][4]);
            }
        }

        private void SaveXML()
        {
            if(_dataSet.Tables.Count <= 0)
                _dataSet.Tables.Add("table0");
            if (_dataSet.Tables[0].Columns.Count <= 0)
                for (int i = 0; i < 5; i++)
                    _dataSet.Tables[0].Columns.Add();
            _dataSet.Tables[0].Clear();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow data = dataGridView1.Rows[i];
                _dataSet.Tables[0].Rows.Add(new Object[] { data.Cells[0].Value,
                                                           data.Cells[1].Value, 
                                                           data.Cells[2].Value,
                                                           data.Cells[3].Value ,
                                                           data.Cells[4].Value });
            }
            _dataSet.WriteXml(_fileName);
        }

        //exit
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void loadGridSetting(string fileName, DataGridView grid )
        {

            DataSet gridSettingDataSet = new DataSet();
            try
            {
                gridSettingDataSet.ReadXml(fileName);
            }
            catch (Exception ex)
            {
                return;
            }
            if (gridSettingDataSet.Tables[0].Rows.Count <= 0)
                return;
            int count = gridSettingDataSet.Tables[0].Rows.Count;

            Boolean visible = false;
            int width = 0;

            for (int i = 0; i < count; i++)
            {
                fileName = gridSettingDataSet.Tables[0].Rows[i][3].ToString();
                if (fileName != null && fileName.Length > 0)
                {
                    grid.Columns[fileName].HeaderText = gridSettingDataSet.Tables[0].Rows[i][0].ToString();

                    if (gridSettingDataSet.Tables[0].Rows[i][1].ToString().Length > 0)
                        width = int.Parse(gridSettingDataSet.Tables[0].Rows[i][1].ToString());

                    grid.Columns[fileName].Width = width;

                    if (gridSettingDataSet.Tables[0].Rows[i][2].ToString().Length > 0)
                        visible = Boolean.Parse(gridSettingDataSet.Tables[0].Rows[i][2].ToString());

                    grid.Columns[fileName].Visible = visible;
                    
                    if (gridSettingDataSet.Tables[0].Rows[i][4].ToString().Length > 0)
                        grid.Columns[fileName].DisplayIndex = int.Parse(gridSettingDataSet.Tables[0].Rows[i][4].ToString());
                }
            }
        }

        private void FormsAdjusting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}