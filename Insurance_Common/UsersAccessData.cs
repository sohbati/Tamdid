using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;
namespace Insurance_Common
{
    public class UsersAccessData : AbstractCommonData
    {
        public const string usersAccess_TABLE = "USERPERMISSIONS";
        public const string id_FIELD = "ID";
        public const string userid_FIELD = "USERID";
        public const string accessToArchive_FIELD = "ACCESSTOARCHIVE";
        public const string accessToInsuranceInfo_FIELD = "ACCESSTOINSURANCEINFO";
        public const string printSearchResult_FIELD = "PRINTSEARCHRESULT";
        

        public const string indexField = id_FIELD;
        public UsersAccessData()
        {
            BuildDataTables();
            generateCommands(usersAccess_TABLE, indexField);
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(usersAccess_TABLE);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(id_FIELD, typeof(System.Int64));
            myColumns.Add(userid_FIELD, typeof(System.Int64));
            myColumns.Add(accessToArchive_FIELD, typeof(System.Boolean));
            myColumns.Add(accessToInsuranceInfo_FIELD, typeof(System.Boolean));
            myColumns.Add(printSearchResult_FIELD, typeof(System.Boolean));

            myColumns.Add(RADIF_FIELD, typeof(System.Int32));
            
            this.Tables.Add(dataTable);
            
        }   
    }
}
