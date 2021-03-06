using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using Insurance_Common;

namespace Insurance_dll
{
    public class ViewInsuranceInfoDAL :AbstractDAL
    {
        IDataProvider dp = Config.provider;

        public ViewInsuranceInfoDAL()
        { 
        }


        public ViewInsuranceInfoData load()
        {
            return load("");
        }

        public ViewInsuranceInfoData load(string condition)
        {
            ViewInsuranceInfoData ds = new ViewInsuranceInfoData();
            dp.loadToDataSet(ViewInsuranceInfoData.VIEW_INSURANCEINFO_TABLE, ds,condition);
            fillRadif(ds);
         
            return ds;
        }

        public ViewInsuranceInfoData loadUserLimitedList(int userId, string condition)
        {
            return loadUserLimitedList(userId, condition, null);
        }

        public ViewInsuranceInfoData loadUserLimitedList(int userId,string condition, string orderby)
        {
            ViewInsuranceInfoData dataSet = new ViewInsuranceInfoData();
            dp.executeSelect(userLimitedQuery(userId, condition, orderby), dataSet, ViewInsuranceInfoData.VIEW_INSURANCEINFO_TABLE);
            int count = dataSet.Tables[ViewInsuranceInfoData.VIEW_INSURANCEINFO_TABLE].Rows.Count;
            fillRadif(dataSet);
            fillPastExpirTime_and_shamsiEndDate(dataSet);
            return dataSet;
        }

        private string userLimitedQuery(int userId, string condition, string orderby)
        {
            // date analyse

            string query =  "select * from view_insuranceinfo ins where ins.insuranceType in( " +
                    "select a.id from insuranceType a  where a.id in (select insurancetypecode from INSURANCETYPEPERM where usercode =" + userId + "  )) ";
            if (condition.ToLower().IndexOf("cancel") < 0)
                query += " and (cancel is null or cancel = 0)";
            if (condition != null && condition.Trim().Length > 0)
                query += " and " + condition;
            if (orderby != null && orderby.Length > 0)
            {
                query += " ORDER BY " + orderby;
            }
            return query;
        }

        /*
         * آنهایی که تاریخ Expier 
         * آنها از امروز رد شده و هنوز انجام نشده نگردیده اند در یک ستون به نام EXP
         * یک علامت دو ستاره قرار می  دهیم
         * یک ستون با تاریخ اتمام شمسی اضافه میکنیم
         */
        protected void fillPastExpirTime_and_shamsiEndDate(ViewInsuranceInfoData ds)
        {
            string condition = " haveDid = 0 ";
            condition += " and enddate >= getdate()  and enddate - daysbeforExp < getdate() ";
         
            Boolean haveDid;
            DateTime date =DateTime.Now;
            int daysBeforExp = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][ViewInsuranceInfoData.haveDid_FIELD].ToString() != null)
                    haveDid =  Boolean.Parse(ds.Tables[0].Rows[i][ViewInsuranceInfoData.haveDid_FIELD].ToString());
                if (ds.Tables[0].Rows[i][ViewInsuranceInfoData.endDate_FIELD].ToString() != null)
                    date = DateTime.Parse(ds.Tables[0].Rows[i][ViewInsuranceInfoData.endDate_FIELD].ToString());
                if (ds.Tables[0].Rows[i][ViewInsuranceInfoData.DAYSBEFOREXP_FIELD].ToString() != null)
                    daysBeforExp = int.Parse(ds.Tables[0].Rows[i][ViewInsuranceInfoData.DAYSBEFOREXP_FIELD].ToString());
             //   TimeSpan ts = new TimeSpan(daysBeforExp, 0, 0, 0);
                if (date < DateTime.Now)
                    ds.Tables[0].Rows[i][ViewInsuranceInfoData.PASTOFEXPIRE] = "**";
                if (date != null)
                    ds.Tables[0].Rows[i][ViewInsuranceInfoData.SHAMSIDATE] = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(date);

                if (ds.Tables[0].Rows[i][ViewInsuranceInfoData.beginDate_FIELD].ToString() != null)
                    date = DateTime.Parse(ds.Tables[0].Rows[i][ViewInsuranceInfoData.beginDate_FIELD].ToString());
                ds.Tables[0].Rows[i][ViewInsuranceInfoData.BEGINDATE_SHAMSI] = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(date);
            }

        }

    }
}
