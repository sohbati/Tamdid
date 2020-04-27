using System;
using System.Collections.Generic;
using System.Text;
using Insurance_Common;
using Insurance_dll;
using System.Data.SqlClient;

namespace Insurance_BLL
{
    public class HaveDidLogBS
    {
        HaveDidLogDAL _haveDidLogDAL;

        public HaveDidLogBS()
        {
            _haveDidLogDAL = new HaveDidLogDAL();
        }

        public HaveDidLogData load()
        {
            return _haveDidLogDAL.load();
        }

        public int add(HaveDidLogData dataSet)
        {
            return _haveDidLogDAL.add(dataSet);
        }

        public int update(HaveDidLogData dataSet)
        {
            return _haveDidLogDAL.update(dataSet);
        }

        public int delete(int id)
        {
            return _haveDidLogDAL.delete(id);
        }
    }
}
