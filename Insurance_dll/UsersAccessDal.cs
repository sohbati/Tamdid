using Insurance_Common;
using RMX_TOOLS.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance_dll
{
    public class UsersAccessDal
    {
        IDataProvider dp = Config.provider;

        public UsersAccessDal()
        {

        }

        public UsersAccessData load()
        {
            UsersAccessData ds = new UsersAccessData();
            string query = "select * from " + UsersAccessData.usersAccess_TABLE;
            dp.select(query, ds, UsersAccessData.usersAccess_TABLE);
            //dp.loadToDataSet(UsersAccessData.users_TABLE, ds);
             
            return ds;
        }

        public UsersAccessData load(int userid)
        {
            UsersAccessData ds = new UsersAccessData();
            string query = "select * from " + UsersAccessData.usersAccess_TABLE + " where " + 
                UsersAccessData.userid_FIELD + "=" + userid;

            dp.select(query, ds, UsersAccessData.usersAccess_TABLE);
            //dp.loadToDataSet(UsersAccessData.users_TABLE, ds);

            return ds;
        }

        public int add(UsersAccessData dataSet)
        {
            return dp.add(dataSet, UsersAccessData.usersAccess_TABLE);
        }

        public int update(UsersAccessData dataSet)
        {

            return dp.update(dataSet, UsersAccessData.usersAccess_TABLE);
        }

    }
}
