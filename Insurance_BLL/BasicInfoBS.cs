using System;
using System.Collections.Generic;
using System.Text;
using Insurance_Common;
using Insurance_dll;

namespace Insurance_BLL
{
    public class BasicInfoBS
    {
        BasicInfoDAL _basicInfoDAL;
        public BasicInfoBS()
        {
            _basicInfoDAL = new BasicInfoDAL();
        }

        public BasicInfoData load(int parentId)
        {
            return _basicInfoDAL.load(parentId);
        }

    }
}
