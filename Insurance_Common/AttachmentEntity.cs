using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace Insurance_Common
{

    public class AttachmentEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_INSURANCE_ID = "INSURANCEID";
        public const string FIELD_CONTENT = "CONTENT";
        public const string FIELD_FILE_NAME = "FILENAME";
        public const string TableName = "ATTACHMENT";

        public const string indexField = FIELD_ID;

        public AttachmentEntity()
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
            myColumns.Add(FIELD_INSURANCE_ID, typeof(System.Int32));
            myColumns.Add(FIELD_CONTENT, typeof(System.Byte[]));
            myColumns.Add(FIELD_FILE_NAME, typeof(System.String));

            myColumns.Add(RADIF_FIELD, typeof(System.Int32));

           // myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            //DataTable viewDataTable = dataTable.Copy();
           // viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            this.Tables.Add(dataTable);
            //this.Tables.Add(viewDataTable);
        }

    }
}
