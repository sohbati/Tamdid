using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace Insurance_Common
{
    public class SmsSendHistoryData : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_SENDDATE = "SENDDATE";
        public const string FIELD_INSURANCEINFOID = "INSURANCEINFOID";
        public const string FIELD_USERID = "USERID";

        public const string indexField = FIELD_ID;

        public const string TableName = "SMSSENDHISTORY";
        public SmsSendHistoryData()
        {
            
            //IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands(TableName, indexField);

        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);

            DataColumnCollection myColumns = dataTable.Columns;

            myColumns.Add(FIELD_ID, typeof(System.Int32));
            myColumns.Add(FIELD_SENDDATE, typeof(System.DateTime));
            myColumns.Add(FIELD_INSURANCEINFOID, typeof(System.Int32));
            myColumns.Add(FIELD_USERID, typeof(System.Int32));

            myColumns.Add(RADIF_FIELD, typeof(System.Int32));

            this.Tables.Add(dataTable);
        }

    }
}
