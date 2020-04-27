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
    public class SmsSendHistoryDAL : AbstractDAL
    {
        IDataProvider dp = Config.provider;

        public SmsSendHistoryDAL()
        {
        }

       public int add(SmsSendHistoryData dataSet)
       {
           return dp.add(dataSet, SmsSendHistoryData.TableName);
       }

       public int update(SmsSendHistoryData dataSet)
       {
           return dp.update(dataSet, SmsSendHistoryData.TableName);
       }

       public int delete(int id)
       {
           string tableName = SmsSendHistoryData.TableName;
           string sql = "delete from " + tableName + " where " + SmsSendHistoryData.indexField + "=" + id;
           return dp.delete(sql);
       }
    }
}
