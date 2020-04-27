using System;
using System.Collections.Generic;
using System.Text;
using Insurance_Common;
using Insurance_dll;

namespace Insurance_BLL
{
    public class UsersAccessBS
    {
        public static UsersAccessData loginedUser;
        private UsersAccessDal _usersAccessDal;

        public UsersAccessBS()
        {
            _usersAccessDal = new UsersAccessDal();
        }

        public UsersAccessData load()
        {
            return _usersAccessDal.load();
        }
        public UsersAccessData load(int userid)
        {
            return _usersAccessDal.load(userid);
        }

        public int add(UsersAccessData dataSet)
        {
            return _usersAccessDal.add(dataSet);
        }

        public int update(UsersAccessData dataSet)
        {
            return _usersAccessDal.update(dataSet);
        }
    }

}
