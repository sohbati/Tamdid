using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;

namespace RMX_TOOLS.DAL
{
    public class AbstractDAL
    {
        public AbstractDAL()
        {
        }

        /*
         * ردیف اضافه می کنیم
         * 
         */
        protected void fillRadif(AbstractCommonData ds)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i][AbstractCommonData.RADIF_FIELD] = i + 1;

            }
        }


    }
}
