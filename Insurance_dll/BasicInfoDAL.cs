using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using Insurance_Common;

namespace Insurance_dll
{
    public class BasicInfoDAL : AbstractDAL
    {
        IDataProvider dp = Config.provider;

        public BasicInfoDAL()
        {

        }

        public BasicInfoData load(int parent)
        {
            string condition = " parent=" + parent;
            BasicInfoData ds = new BasicInfoData();
            dp.loadToDataSet(BasicInfoData.basicInfo_TABLE, ds,condition);
            fillRadif(ds);
            return ds;
        }

    }
}
