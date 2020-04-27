using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace Insurance_Common
{
    public class SmsTemplateDefinitionData : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_TEMPLATE_TYPE = "TEMPLATETYPE";
        public const string FIELD_TEMPLATE = "TEMPLATE";

        public const string indexField = FIELD_ID;

        public const string TableName = "SMSTEMPLATEDEFINITION";
        public SmsTemplateDefinitionData()
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
            myColumns.Add(FIELD_TEMPLATE_TYPE, typeof(System.Int32));
            myColumns.Add(FIELD_TEMPLATE, typeof(System.String));

            myColumns.Add(RADIF_FIELD, typeof(System.Int32));

            this.Tables.Add(dataTable);
        }

    }
}
