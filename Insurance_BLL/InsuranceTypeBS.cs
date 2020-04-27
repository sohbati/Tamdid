using System;
using System.Collections.Generic;
using System.Text;
using Insurance_Common;
using Insurance_dll;
using System.Data;
namespace Insurance_BLL
{
    public class InsuranceTypeBS
    {
        InsuranceTypeDAL _insuranceTypeDAL;
      public InsuranceTypeBS()
      {
          _insuranceTypeDAL = new InsuranceTypeDAL();
      }

        public InsuranceTypeData laod()
        {
            return _insuranceTypeDAL.load();
        }

        public int add(InsuranceTypeData dataSet)
        {
            _insuranceTypeDAL.add(dataSet);
            return 0;
        }

        public int update(InsuranceTypeData dataSet)
        {
            return _insuranceTypeDAL.update(dataSet);
        }

        public int delete(int id)
        {
            return _insuranceTypeDAL.delete(id);
        }

        public InsuranceTypeData userLimitedList()
        {
            int id = int.Parse(UsersBS.loginedUser.Tables[UsersData.users_TABLE].Rows[0][UsersData.id_FIELD].ToString());
            return _insuranceTypeDAL.userLimitedList(id);
        }
        public InsuranceTypeData userLimitedList(int id)
        {
            return _insuranceTypeDAL.userLimitedList(id);
        }
    }
        
}