using System;
using System.Collections.Generic;
using System.Text;
using Insurance_Common;
using Insurance_dll;

namespace Insurance_BLL
{
    public class ViewHaveDidLogBS
    {
        private ViewHaveDidLogDAL _viewHaveDidLogDAL = new ViewHaveDidLogDAL();

        public ViewHaveDidLogBS()
        {
        }

        public ViewHaveDidLogData load()
        {
            return load("");
        }

        public ViewHaveDidLogData load(string condition)
        {
            return _viewHaveDidLogDAL.load(condition);
        }

        public ViewHaveDidLogData loadUserLimitedList(int userId, string condition)
        {
            return _viewHaveDidLogDAL.loadUserLimitedList(userId, condition);
        }

    }
}
