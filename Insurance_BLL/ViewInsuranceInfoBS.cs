using System;
using System.Collections.Generic;
using System.Text;
using Insurance_Common;
using Insurance_dll;

namespace Insurance_BLL
{
    public class ViewInsuranceInfoBS
    {
        private ViewInsuranceInfoDAL _viewInsuranceInfoDAL = new ViewInsuranceInfoDAL();

        public ViewInsuranceInfoBS()
        { 
        }

        public ViewInsuranceInfoData load()
        {
            return load("");
        }

        public ViewInsuranceInfoData load(string condition)
        {
            return _viewInsuranceInfoDAL.load(condition);
        }

        public ViewInsuranceInfoData loadUserLimitedList(int userId, string condition)
        {

            return _viewInsuranceInfoDAL.loadUserLimitedList(userId, condition);
        }

        public ViewInsuranceInfoData loadUserLimitedList(int userId, string condition, string orderBy)
        {

            return _viewInsuranceInfoDAL.loadUserLimitedList(userId, condition, orderBy);
        }

    }
}
