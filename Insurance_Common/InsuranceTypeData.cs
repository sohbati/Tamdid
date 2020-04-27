using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using RMX_TOOLS.common;

namespace Insurance_Common
{
    public class InsuranceTypeData : AbstractCommonData
    {

        public const string InsuranceType_TABLE = "InsuranceType";
        public const string InsuranceId_FIELD = "ID";
        public const string InsuranceCaption_FIELD = "CAPTION";
        public const string INSURANCETYPECOLOR_FIELD = "INSURANCETYPECOLOR";
        public const string DAYSBEFOREXP_FIELD = "DAYSBEFOREXP";

        public const string indexField = InsuranceId_FIELD;
        public InsuranceTypeData()
        {
            BuildDataTables();
            generateCommands(InsuranceType_TABLE, indexField);
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(InsuranceType_TABLE);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(InsuranceId_FIELD, typeof(System.Int64));
            myColumns.Add(InsuranceCaption_FIELD, typeof(System.String));
            myColumns.Add(INSURANCETYPECOLOR_FIELD, typeof(System.String));
            myColumns.Add(DAYSBEFOREXP_FIELD, typeof(System.Int64));
            myColumns.Add(RADIF_FIELD, typeof(System.Int32));
            this.Tables.Add(dataTable);

            //updateCommand = "UPDATE [dbo].[INSURANCETYPE] SET [CAPTION] = @CAPTION WHERE ([ID] = @ID)";
            //insertCommand = "INSERT INTO INSURANCETYPE ([CAPTION]) VALUES (@CAPTION); ";
            //deleteCommand = "DELETE FROM [dbo].[INSURANCETYPE] WHERE [ID] = @ID" ;
        }

        


    }
}
