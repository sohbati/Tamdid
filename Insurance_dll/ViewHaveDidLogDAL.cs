using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using Insurance_Common;

namespace Insurance_dll
{
    public class ViewHaveDidLogDAL : AbstractDAL
    {
        IDataProvider dp = Config.provider;

        public ViewHaveDidLogDAL()
        {

        }

        public ViewHaveDidLogData load()
        {
            return load("");
        }

        public ViewHaveDidLogData load(string condition)
        {
            ViewHaveDidLogData ds = new ViewHaveDidLogData();
            dp.loadToDataSet(ViewHaveDidLogData.haveDidLogData_TABLE, ds, condition);
            fillRadif(ds);
            
            return ds;
        }

        public ViewHaveDidLogData loadUserLimitedList(int userId, string condition)
        {
            ViewHaveDidLogData dataSet = new ViewHaveDidLogData();
            dp.executeSelect(userLimitedQuery(userId, condition), dataSet, ViewHaveDidLogData.haveDidLogData_TABLE);
            int count = dataSet.Tables[ViewHaveDidLogData.haveDidLogData_TABLE].Rows.Count;
            fillRadif(dataSet);
            fillPastExpirTime_and_shamsiEndDate(dataSet);
            return dataSet;
        }

        private string userLimitedQuery(int userId, string condition)
        {
            // date analyse

            string query = "select * from view_haveDidLog hLog where hLog.insuranceType in( " +
                    "select a.id from insuranceType a  where a.id in (select insurancetypecode from INSURANCETYPEPERM where usercode =" + userId + "  )) ";
            if (condition != null && condition.Trim().Length > 0)
                query += " and (cancel is null or cancel = 0) and " + condition;
            return query;
        }

        /*
         * آنهایی که تاریخ Expier 
         * آنها از امروز رد شده و هنوز انجام نشده نگردیده اند در یک ستون به نام EXP
         * یک علامت دو ستاره قرار می  دهیم
         * یک ستون با تاریخ اتمام شمسی اضافه میکنیم
         */
        protected void fillPastExpirTime_and_shamsiEndDate(ViewHaveDidLogData ds)
        {
            string condition = " haveDid = 0 ";
            condition += " and enddate >= getdate()  and enddate - daysbeforExp < getdate() ";
            Boolean haveDid;
            DateTime date = DateTime.Now;
          //  int daysBeforExp = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][ViewHaveDidLogData.haveDid_FIELD].ToString() != null)
                    haveDid = Boolean.Parse(ds.Tables[0].Rows[i][ViewHaveDidLogData.haveDid_FIELD].ToString());
                if (ds.Tables[0].Rows[i][ViewHaveDidLogData.EndDate_FIELD].ToString() != null)
                    date = DateTime.Parse(ds.Tables[0].Rows[i][ViewHaveDidLogData.EndDate_FIELD].ToString());

                //if (ds.Tables[0].Rows[i][ViewHaveDidLogData.DAYSBEFOREXP_FIELD].ToString() != null)
                    //daysBeforExp = int.Parse(ds.Tables[0].Rows[i][ViewHaveDidLogData.DAYSBEFOREXP_FIELD].ToString());
                //   TimeSpan ts = new TimeSpan(daysBeforExp, 0, 0, 0);
                //if (date < DateTime.Now)
                //    ds.Tables[0].Rows[i][ViewHaveDidLogData.PASTOFEXPIRE] = "**";
                if (date != null)
                    ds.Tables[0].Rows[i][ViewHaveDidLogData.SHAMSIDATE] = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(date);

                if (ds.Tables[0].Rows[i][ViewHaveDidLogData.BeginDate_FIELD].ToString() != null)
                {
                    date = DateTime.Parse(ds.Tables[0].Rows[i][ViewHaveDidLogData.BeginDate_FIELD].ToString());
                    ds.Tables[0].Rows[i][ViewHaveDidLogData.BEGINDATE_SHAMSI] = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(date);
                }
                if (ds.Tables[0].Rows[i][ViewHaveDidLogData.HAVEDIDLOG_CHECKEDDATE_FIELD].ToString() != null)
                {
                    date = DateTime.Parse(ds.Tables[0].Rows[i][ViewHaveDidLogData.HAVEDIDLOG_CHECKEDDATE_FIELD].ToString());
                    ds.Tables[0].Rows[i][ViewHaveDidLogData.HAVEDIDLOG_CHECKEDDATE_SHAMSI_SHAMSI] = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(date);
                }
                if (ds.Tables[0].Rows[i][ViewHaveDidLogData.LOGGEDENDDATE_FIELD] != null && ds.Tables[0].Rows[i][ViewHaveDidLogData.LOGGEDENDDATE_FIELD].ToString().Length > 0)
                {
                    date = DateTime.Parse(ds.Tables[0].Rows[i][ViewHaveDidLogData.LOGGEDENDDATE_FIELD].ToString());
                    ds.Tables[0].Rows[i][ViewHaveDidLogData.LOGGEDENDDATE_SHAMSI_FIELD] = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(date);
                }
            }

        }
    }
}
