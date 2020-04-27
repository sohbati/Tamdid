using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using  RMX_TOOLS.common;


namespace Insurance_Common
{
    public class InsuranceInfoData : AbstractCommonData
    {
        public const string insuranceInfo_TABLE = "INSURANCEINFO";
        public const string id_FIELD = "ID";
        public const string name_FIELD = "NAME";
        public const string family_FIELD = "FAMILY";
        public const string insuranceNumber_FIELD = "INSURANCENUMBER";
        public const string phoneNumber_FIELD = "PHONENUMBER";
        public const string insuranceType_FIELD = "INSURANCETYPE";
        public const string beginDate_FIELD = "BEGINDATE";
        public const string endDate_FIELD = "ENDDATE";
        public const string haveDid_FIELD = "HAVEDID";
        public const string address_FIELD = "address";
        public const string description_FIELD = "DESCRIPTION";
        public const string cancel_FIELD = "cancel";

        public const string BirthDate_FIELD = "BirthDate";
        public const string CustomerType_FIELD = "CustomerType";
        public const string mobileNumber_FIELD = "mobileNumber";

        public const string creationDate_FIELD = "CreationDate";
        public const string lastUpdateDate_FIELD = "LastUpdateDate";

        public const string indexField = id_FIELD;
        public InsuranceInfoData()
        {

            BuildDataTables();
            generateCommands(insuranceInfo_TABLE, indexField);
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(insuranceInfo_TABLE);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(id_FIELD, typeof(System.Int64));
            myColumns.Add(name_FIELD, typeof(System.String));
            myColumns.Add(family_FIELD, typeof(System.String));
            myColumns.Add(phoneNumber_FIELD, typeof(System.String));
            myColumns.Add(insuranceNumber_FIELD, typeof(System.String));
            myColumns.Add(insuranceType_FIELD, typeof(System.Int64));
            myColumns.Add(beginDate_FIELD, typeof(System.DateTime));
            myColumns.Add(endDate_FIELD, typeof(System.DateTime));
            myColumns.Add(haveDid_FIELD, typeof(System.Boolean));
            myColumns.Add(RADIF_FIELD, typeof(System.Int32));
            myColumns.Add(address_FIELD, typeof(System.String));
            myColumns.Add(description_FIELD, typeof(System.String));
            myColumns.Add(cancel_FIELD, typeof(System.Boolean));

            myColumns.Add(BirthDate_FIELD, typeof(System.DateTime));
            myColumns.Add(CustomerType_FIELD, typeof(System.Int32));
            myColumns.Add(mobileNumber_FIELD, typeof(System.String));
            myColumns.Add(creationDate_FIELD, typeof(System.DateTime));
            myColumns.Add(lastUpdateDate_FIELD, typeof(System.DateTime));


            this.Tables.Add(dataTable);

        }

    }
}
