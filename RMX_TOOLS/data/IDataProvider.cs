using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RMX_TOOLS.common;
namespace RMX_TOOLS.data
{
    public abstract class  IDataProvider 
    {
        protected SqlConnection dbCon;
        protected SqlDataAdapter sqlda;
        protected SqlCommand LoadCommand;
        protected SqlCommand InsertCommand;
        protected SqlCommand UpdateCommand;
        protected SqlCommand deleteCommand;
        protected string serverName;
        protected string userName;
        protected string password;
        protected string databaseName;
        protected string fileName = "myXmFile.xml";
        public Boolean connectionStatus = false;
        public abstract Boolean connect();
        public abstract void close();
        public abstract void loadToDataSet(string tableName,AbstractCommonData dataSet);
        public abstract void loadToDataSet(string tableName, AbstractCommonData dataSet, string condition);
        public abstract void executeSelect(string query, AbstractCommonData dataSet, string tableName);
        public abstract int add(AbstractCommonData dataSet, string tableName);
        public abstract int update(AbstractCommonData dataSet, string tableName);
        public abstract int executeNonQuery(string query);
        public abstract int delete(AbstractCommonData dataSet, string tableName);
        public abstract int delete(string query);
        public abstract void select(string query, AbstractCommonData dataSet, string tableName);
        /*
         *tools  
         */

        public abstract string getAsSqlDate(string date, string time);
        public abstract string getBetweenDate(string fld, DateTime betw1, DateTime betw2, string daysBeforExp);
        
        
    }
}
