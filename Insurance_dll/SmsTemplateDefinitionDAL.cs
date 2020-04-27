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
    public class SmsTemplateDefinitionDAL : AbstractDAL
    {
        IDataProvider dp = Config.provider;

        public SmsTemplateDefinitionDAL()
        {
        }
        
        public SmsTemplateDefinitionData load()
        {
            SmsTemplateDefinitionData ds = new SmsTemplateDefinitionData() ;
            dp.loadToDataSet(SmsTemplateDefinitionData.TableName, ds);
            fillRadif(ds);
            return ds;
        }

        public SmsTemplateDefinitionData getByTemplateByType(int type)
        {
            SmsTemplateDefinitionData dataSet = new SmsTemplateDefinitionData();
            string query = "SELECT * " +
                 " FROM         dbo.SMSTEMPLATEDEFINITION a" +
                 " WHERE  TEMPLATETYPE = " + type;
            dp.executeSelect(query, dataSet, SmsTemplateDefinitionData.TableName);
            return dataSet;

        }


       public int add(SmsTemplateDefinitionData dataSet)
       {
           return dp.add(dataSet, SmsTemplateDefinitionData.TableName);
       }

       public int update(SmsTemplateDefinitionData dataSet)
       {
           return dp.update(dataSet, SmsTemplateDefinitionData.TableName);
       }

       public int delete(int id)
       {
           //return dp.delete(dataSet, SmsTemplateDefinitionData.InsuranceType_TABLE);
           string tableName = SmsTemplateDefinitionData.TableName;
           string sql = "delete from " + tableName + " where " + SmsTemplateDefinitionData.indexField + "=" + id;
           return dp.delete(sql);
       }
    }
}
