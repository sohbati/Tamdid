using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using RMX_TOOLS.common;
namespace Insurance_Common
{
    /// <summary>
    /// Summary description for VIEW_INSURANCEINFOData.
    /// </summary>
    public class ViewInsuranceInfoData : AbstractCommonData
    {
        public const string VIEW_INSURANCEINFO_TABLE = "VIEW_INSURANCEINFO";
		public const string caption_FIELD = "caption";
        public const string INSURANCETYPECOLOR_FIELD = "INSURANCETYPECOLOR";
        public const string DAYSBEFOREXP_FIELD = "DAYSBEFOREXP";
        public const string family_FIELD = "Family";
		public const string haveDid_FIELD = "haveDid";
		public const string id_FIELD = "Id";
		public const string insuranceNumber_FIELD = "InsuranceNumber";
		public const string insuranceType_FIELD = "InsuranceType";
		public const string beginDate_FIELD = "BeginDate";
        public const string endDate_FIELD = "EndDate";
		public const string name_FIELD = "Name";
		public const string phoneNumber_FIELD = "PhoneNumber";
        public const string address_FIELD = "address";
        public const string description_FIELD = "description";    
        public const string cancel_FIELD = "cancel";

        public const string BirthDate_FIELD = "BirthDate";
        public const string CustomerType_FIELD = "CustomerType";
        public const string mobileNumber_FIELD = "mobileNumber";

        public const string creationDate_FIELD = "CreationDate";
        public const string lastUpdateDate_FIELD = "LastUpdateDate";

        public const string indexField = id_FIELD;
        public ViewInsuranceInfoData()
        {
            BuildDataTables();
            generateCommands(VIEW_INSURANCEINFO_TABLE, indexField);

        }

        private void BuildDataTables()
        {
            DataTable table = new DataTable(VIEW_INSURANCEINFO_TABLE);
            DataColumnCollection myColumns = table.Columns;
            myColumns.Add(caption_FIELD, typeof(System.String));
            myColumns.Add(INSURANCETYPECOLOR_FIELD, typeof(System.String));
            myColumns.Add(DAYSBEFOREXP_FIELD, typeof(System.Int64));
            myColumns.Add(family_FIELD, typeof(System.String));
            myColumns.Add(haveDid_FIELD, typeof(System.Boolean));
            myColumns.Add(id_FIELD, typeof(System.Int32));
            myColumns.Add(insuranceNumber_FIELD, typeof(System.String));
            myColumns.Add(insuranceType_FIELD, typeof(System.Int32));
            myColumns.Add(beginDate_FIELD, typeof(System.DateTime));
            myColumns.Add(endDate_FIELD, typeof(System.DateTime));
            myColumns.Add(name_FIELD, typeof(System.String));
            myColumns.Add(phoneNumber_FIELD, typeof(System.String));
            myColumns.Add(RADIF_FIELD, typeof(System.Int32));
            myColumns.Add(address_FIELD, typeof(System.String));
            myColumns.Add(cancel_FIELD, typeof(System.Boolean));
            myColumns.Add(PASTOFEXPIRE, typeof(System.String));
            myColumns.Add(description_FIELD, typeof(System.String));
            myColumns.Add(SHAMSIDATE, typeof(System.String));
            myColumns.Add(BEGINDATE_SHAMSI, typeof(System.String));

            myColumns.Add(BirthDate_FIELD, typeof(System.DateTime));
            myColumns.Add(BirthDate_FIELD + "_SHAMSI", typeof(System.String));
            myColumns.Add(endDate_FIELD + "_SHAMSI", typeof(System.String));
            myColumns.Add(CustomerType_FIELD, typeof(System.Int32));
            myColumns.Add(mobileNumber_FIELD, typeof(System.String));
            myColumns.Add(creationDate_FIELD, typeof(System.DateTime));
            myColumns.Add(lastUpdateDate_FIELD, typeof(System.DateTime));
            myColumns.Add(creationDate_FIELD + "_SHAMSI", typeof(System.String));
            myColumns.Add(lastUpdateDate_FIELD + "_SHAMSI", typeof(System.String));

            this.Tables.Add(table);
        }
    }
}
