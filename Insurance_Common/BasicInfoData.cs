using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;

namespace Insurance_Common
{
    public class BasicInfoData : AbstractCommonData
    {

        public const string  basicInfo_TABLE = "BASICINFO";
        public const string ID_FIELD = "ID";
        public const string PARENT_FIELD = "PARENT";
        public const string CAPTION_FIELD = "CAPTION";

        public const string indexField = ID_FIELD;
        public BasicInfoData()
        {

            BuildDataTables();
            generateCommands(basicInfo_TABLE, indexField);
        }
        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(basicInfo_TABLE);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(ID_FIELD, typeof(System.Int64));
            myColumns.Add(PARENT_FIELD, typeof(System.Int64));
            myColumns.Add(CAPTION_FIELD, typeof(System.String));
            myColumns.Add(RADIF_FIELD, typeof(System.Int32));

            this.Tables.Add(dataTable);
        }
    }
}
