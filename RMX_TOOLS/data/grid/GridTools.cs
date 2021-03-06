using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace RMX_TOOLS.data.grid
{
  
    

    public class GridTools
    {
        public delegate void changingRow(DataGridView grid, int rowIndex, Hashtable hash);

        private DataGridView _grid;

        public GridTools(DataGridView dgv) 
        {
            _grid = dgv;
        }

        public object getValueByRowIndex(int rowIndex, string col)
        {
            DataGridViewRow row = _grid.Rows[rowIndex];
            return row.Cells[col].Value;
        }

        public object getCurrentRowValue(string col)
        {
            if (_grid.CurrentRow != null);
            {
                DataGridViewRow row = _grid.CurrentRow;
                if (row != null) 
                    return row.Cells[col].Value;
            }
            return null;
        }

        public void setValue(Control control, string fieldName)
        {
            object obj = getCurrentRowValue(fieldName);
            if (obj != null)
                control.Text = obj.ToString().Trim();
        }

        public void setValue(ComboBox cmb, string fieldName) 
        {
            setValue(cmb, fieldName, "index");
        }

        public void setValue(ComboBox cmb, string fieldName , string type)
        {
            object obj = getCurrentRowValue(fieldName);
            if (type.Equals("index")) 
            {
                if (obj != null)
                    cmb.SelectedIndex = int.Parse(obj.ToString().Trim());

            }else if (type.Equals("text"))
            {
                if (obj != null)
                    cmb.Text = obj.ToString().Trim();
            }

        }

        public void bindDataToGrid(DataGridView grid , DataSet dataset , string tableName, changingRow chageRow, Hashtable hash)
        {
            grid.Rows.Clear();
            
           int columns = grid.ColumnCount;
           DataTable table = dataset.Tables[tableName];
            if (table ==  null)
                throw new Exception("نا م جدول در دیتا ست یافت نشد");
            
            string field;
            object value = null;
            
            int currentRowIndex;
            for (int tableIndex = 0; tableIndex < table.Rows.Count; tableIndex++) 
            {
                currentRowIndex = grid.Rows.Add();
                for (int gridIndex = 0; gridIndex < grid.Columns.Count; gridIndex++) 
                {
                    field = grid.Columns[gridIndex].Name;

                    if (!field.Equals("SmsSend"))
                    {
                        value = getAsString(table.Rows[tableIndex][field]);
                    }

                    //cell = new DataGridViewCell();
                    //cell.Value = value;
                    grid.Rows[currentRowIndex].Cells[field].Value = value;
                }
                if (chageRow != null)
                    chageRow(grid, currentRowIndex, hash);
            }
        }

        private object getAsString(object obj)
        {
            if (obj is DateTime)
               return RMX_TOOLS.date.DateXFormer.gregorianToPersianString((DateTime)obj).Trim();
            else
               return obj;
        }
        public void changeColor(DataGridView grid, int rowIndex, Hashtable hash)
        {
              string colorField = hash["colorField"].ToString();

            Color defColor = Color.White;
            Color color = Color.White; ;

            string colorStr = null;
            //  grid.currentrow = rowIndex;

            colorStr = getValueByRowIndex(rowIndex, colorField).ToString().Trim();

            if (colorStr == null || colorStr.Length <= 0)
                color = defColor;
            else
                color = ColorTranslator.FromHtml(colorStr);

            for (int i = 0; i < grid.Rows[rowIndex].Cells.Count; i++)
                grid.Rows[rowIndex].Cells[i].Style.BackColor = color;
        }
       
    }


}
