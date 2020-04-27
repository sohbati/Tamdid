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
    public class HaveDidLogDAL : AbstractDAL
    {
        IDataProvider dp = Config.provider;

        public HaveDidLogDAL()
        {
        }

        public HaveDidLogData load()
        {
            HaveDidLogData ds = new HaveDidLogData();
            dp.loadToDataSet(HaveDidLogData.TABLE_NAME, ds);
            fillRadif(ds);
            return ds;
        }

        public int add(HaveDidLogData dataSet)
        {
            return dp.add(dataSet, HaveDidLogData.TABLE_NAME);
        }


        public int update(HaveDidLogData dataSet)
        {
            return dp.update(dataSet, HaveDidLogData.TABLE_NAME);
        }

        public int delete(int id)
        {
            string tableName = HaveDidLogData.TABLE_NAME;
            //   string sql = "delete from " + tableName + " where " + InsuranceInfoData.indexField + "=" + id;
            string delQuery = "update " + tableName + " set cancel = 1  where " + HaveDidLogData.indexField + "=" + id;
            return dp.delete(delQuery);
        }


    }
}
