using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;

namespace Insurance_Common
{
    public class HaveDidLogData : AbstractCommonData
    {
        public const string TABLE_NAME = "HAVEDIDLOG";

        public const string ID_FIELD = "ID";
        public const string INSURANCEINFOID_FIELD = "INSURANCEINFOID";
        public const string CHECKEDDATE_FIELD = "CHECKEDDATE";
        public const string CHECKEDUSER_FIELD = "CHECKEDUSER";
        public const string LOGGEDENDDATE_FIELD = "LOGGEDENDDATE";

        public const string indexField = ID_FIELD;

        public HaveDidLogData()
        {
            BuildDataTables();
            generateCommands(TABLE_NAME, indexField);
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TABLE_NAME);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(ID_FIELD, typeof(System.Int64));
            myColumns.Add(INSURANCEINFOID_FIELD, typeof(System.Int64));
            myColumns.Add(CHECKEDDATE_FIELD, typeof(System.DateTime));
            myColumns.Add(CHECKEDUSER_FIELD, typeof(System.Int64));
            myColumns.Add(LOGGEDENDDATE_FIELD, typeof(System.DateTime));
            myColumns.Add(RADIF_FIELD, typeof(System.Int32));

            this.Tables.Add(dataTable);
        }

    }
}
