using System;
using System.Collections.Generic;
using System.Text;
using Insurance_Common;
using Insurance_dll;
using System.Data;
namespace Insurance_BLL
{
    public class SmsSendHistoryBS
    {
        SmsSendHistoryDAL _SmsSendHistoryDAL;
      public SmsSendHistoryBS()
      {
          _SmsSendHistoryDAL = new SmsSendHistoryDAL();
      }
      
        public int add(SmsSendHistoryData dataSet)
        {
            _SmsSendHistoryDAL.add(dataSet);
            return 0;
        }

        public int update(SmsSendHistoryData dataSet)
        {
            return _SmsSendHistoryDAL.update(dataSet);
        }

        public int delete(int id)
        {
            return _SmsSendHistoryDAL.delete(id);
        }

    }
        
}