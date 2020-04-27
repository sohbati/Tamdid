using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;
namespace Insurance_Common
{
    public class UsersData : AbstractCommonData
    {
        public const string users_TABLE = "users";
        public const string id_FIELD = "ID";
        public const string name_FIELD = "NAME";
        public const string family_FIELD = "FAMILY";
        public const string userName_FIELD = "USERNAME";
        public const string password_FIELD = "PASSWORD";
        public const string userType_FIELD = "USERTYPE";
        
        public const string indexField = id_FIELD;
        public UsersData()
        {
            BuildDataTables();
            generateCommands(users_TABLE, indexField);
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(users_TABLE);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(id_FIELD, typeof(System.Int64));
            myColumns.Add(name_FIELD, typeof(System.String));
            myColumns.Add(family_FIELD, typeof(System.String));
            myColumns.Add(userName_FIELD, typeof(System.String));
            myColumns.Add(password_FIELD, typeof(System.String));
            myColumns.Add(userType_FIELD, typeof(System.Int16));
            myColumns.Add(RADIF_FIELD, typeof(System.Int32));
            
            
            this.Tables.Add(dataTable);
            
        }

        public override string ToString()
        {
            string name = this.Tables[users_TABLE].Rows[0][name_FIELD].ToString();
            string family = this.Tables[users_TABLE].Rows[0][family_FIELD].ToString();
            return name.Trim() + "_" + family.Trim();
        }
    }
}
