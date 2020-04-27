using System;
using System.Collections.Generic;
using RMX_TOOLS.common;
using System.Text;
using System.Data;

namespace Insurance_Common
{
    public class ViewHaveDidLogData : AbstractCommonData
    {
        public const string haveDidLogData_TABLE = "VIEW_HAVEDIDLOG";

        public const string USER_ID_FIELD = "USER_ID";
        public const string USERS_NAME_FIELD = "USERS_NAME";
        public const string USERS_FAMILY_FIELD = "USERS_FAMILY";
        public const string USERNAME_FIELD = "USERNAME";
        public const string USERTYPE_FIELD = "USERTYPE";
        
        public const string INSURANCEINFO_ID_FIELD = "INSURANCEINFO_ID";
        public const string INSURANCEINFO_NAME_FIELD = "NAME";
        public const string INSURANCEINFO_FAMILY_FIELD = "FAMILY";
        public const string InsuranceNumber_FIELD = "InsuranceNumber";
        public const string PhoneNumber_FIELD = "PhoneNumber";
        public const string InsuranceType_FIELD = "InsuranceType";
        public const string BeginDate_FIELD = "BeginDate";
        public const string haveDid_FIELD = "haveDid";
        public const string EndDate_FIELD = "EndDate";
        public const string address_FIELD = "address";
        public const string cancel_FIELD = "cancel";
        public const string description_FIELD = "description";

        public const string HAVEDIDLOG_ID_FIELD = "HAVEDIDLOG_ID";
        public const string HAVEDIDLOG_INSURANCEINFOID_FIELD = "HAVEDIDLOG_INSURANCEINFOID";
        public const string HAVEDIDLOG_CHECKEDDATE_FIELD = "HAVEDIDLOG_CHECKEDDATE";
        public const string HAVEDIDLOG_CHECKEDUSER_FIELD = "HAVEDIDLOG_CHECKEDUSER";
        public const string LOGGEDENDDATE_FIELD = "LOGGEDENDDATE";
        public const string HAVEDIDLOG_CHECKEDDATE_SHAMSI_SHAMSI = "HAVEDIDLOG_CHECKEDDATE_SHAMSI";
        public const string LOGGEDENDDATE_SHAMSI_FIELD = "LOGGEDENDDATE_SHAMSI";

        public const string InsuranceType_Caption_FIELD = "caption";
        public const string INSURANCETYPECOLOR_FILED = "INSURANCETYPECOLOR";
        public const string indexField = HAVEDIDLOG_ID_FIELD;
        
        
        
        
        public ViewHaveDidLogData()
        {
            BuildDataTables();
            generateCommands(haveDidLogData_TABLE, indexField);
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(haveDidLogData_TABLE);
            DataColumnCollection myColumns = dataTable.Columns;

            myColumns.Add(USER_ID_FIELD, typeof(System.Int64));
            myColumns.Add(USERS_NAME_FIELD, typeof(System.String));
            myColumns.Add(USERS_FAMILY_FIELD, typeof(System.String));
            myColumns.Add(USERNAME_FIELD, typeof(System.String));
            myColumns.Add(USERTYPE_FIELD, typeof(System.Int64));
            myColumns.Add(INSURANCEINFO_ID_FIELD, typeof(System.Int64));
            myColumns.Add(INSURANCEINFO_NAME_FIELD, typeof(System.String));
            myColumns.Add(INSURANCEINFO_FAMILY_FIELD, typeof(System.String));
            myColumns.Add(PhoneNumber_FIELD, typeof(System.String));
            myColumns.Add(InsuranceNumber_FIELD, typeof(System.String));
            myColumns.Add(InsuranceType_FIELD, typeof(System.Int64));
            myColumns.Add(BeginDate_FIELD, typeof(System.DateTime));
            myColumns.Add(haveDid_FIELD, typeof(System.Boolean));
            myColumns.Add(EndDate_FIELD, typeof(System.DateTime));
            myColumns.Add(address_FIELD, typeof(System.String));
            myColumns.Add(cancel_FIELD, typeof(System.Boolean));
            myColumns.Add(description_FIELD, typeof(System.String));
            myColumns.Add(SHAMSIDATE, typeof(System.String));
            myColumns.Add(BEGINDATE_SHAMSI, typeof(System.String));
            myColumns.Add(HAVEDIDLOG_ID_FIELD, typeof(System.Int64));
            myColumns.Add(HAVEDIDLOG_INSURANCEINFOID_FIELD, typeof(System.Int64));
            myColumns.Add(HAVEDIDLOG_CHECKEDDATE_FIELD, typeof(System.DateTime));
            myColumns.Add(HAVEDIDLOG_CHECKEDUSER_FIELD, typeof(System.Int64));
            myColumns.Add(InsuranceType_Caption_FIELD, typeof(System.String));
            myColumns.Add(RADIF_FIELD, typeof(System.Int32));
            myColumns.Add(HAVEDIDLOG_CHECKEDDATE_SHAMSI_SHAMSI, typeof(System.String));
            myColumns.Add(LOGGEDENDDATE_FIELD, typeof(System.DateTime));
            myColumns.Add(LOGGEDENDDATE_SHAMSI_FIELD, typeof(System.String));

            this.Tables.Add(dataTable);
        }
    }
}
