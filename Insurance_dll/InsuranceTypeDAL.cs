using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using Insurance_Common;


namespace Insurance_dll
{
    public class InsuranceTypeDAL : AbstractDAL
    {
        IDataProvider dp = Config.provider;

        public InsuranceTypeDAL()
        {
        }
        
        public InsuranceTypeData load()
        {
            InsuranceTypeData ds = new InsuranceTypeData() ;
            dp.loadToDataSet(InsuranceTypeData.InsuranceType_TABLE,ds);
            fillRadif(ds);
            return ds;
        }

       public int add(InsuranceTypeData dataSet)
       {
           return dp.add(dataSet, InsuranceTypeData.InsuranceType_TABLE);
       }

       public int update(InsuranceTypeData dataSet)
       {
           return dp.update(dataSet, InsuranceTypeData.InsuranceType_TABLE);
       }

       public int delete(int id)
       {
           //return dp.delete(dataSet, InsuranceTypeData.InsuranceType_TABLE);
           string tableName = InsuranceTypeData.InsuranceType_TABLE;
           string sql = "delete from " + tableName + " where " + InsuranceTypeData.indexField + "=" + id;
           return dp.delete(sql);
       }

       public InsuranceTypeData userLimitedList(int userId)
       {
           InsuranceTypeData dataSet = new InsuranceTypeData();
           string query = "SELECT * " +
                " FROM         dbo.INSURANCETYPE a" +
                " WHERE     (ID IN" +
                          " (SELECT     insurancetypecode " +
                             " FROM         INSURANCETYPEPERM " +
                             " WHERE     usercode = "+ userId +" ))";
           dp.executeSelect(query, dataSet, InsuranceTypeData.InsuranceType_TABLE);
           return dataSet;
           
       }
    }
}
