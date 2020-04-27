using System;
using System.Collections.Generic;
using System.Text;
using Insurance_Common;
using Insurance_dll;

namespace Insurance_BLL
{
    public class UsersBS
    {
        public static int ADMIN = 0;
        public static int USER = 1;
        public static UsersData loginedUser;
        private UsersDal _usersDal;

        public UsersBS()
        {
            _usersDal = new UsersDal();
        }

        public UsersData load()
        {
            return _usersDal.load();
        }
        public UsersData loadNonManagers()
        {
            return _usersDal.loadNonManagers();
        }

        public int add(UsersData dataSet)
        {
            return _usersDal.add(dataSet);
        }

        public int update(UsersData dataSet)
        {
            return _usersDal.update(dataSet);
        }

        public int delete(int id)
        {
            return _usersDal.delete(id);
        }

        public UsersData checkUser(string userName, String password,Boolean isManager)
        {
            return _usersDal.checkUser(userName, password,isManager);
        }

        public void addInsuranceTypePerm(int userId, int insuranceTypeId)
        {
            _usersDal.addInsuranceTypePerm(userId,insuranceTypeId);
        }

        public void deleteInsuranceTypePerm(int userId, int insuranceTypeId)
        {
            _usersDal.deleteInsuranceTypePerm(userId, insuranceTypeId);
        }
    }

}
