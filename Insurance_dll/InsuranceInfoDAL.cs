 using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using Insurance_Common;
using System.Collections;

namespace Insurance_dll
{
    public class InsuranceInfoDAL : AbstractDAL
    {
       IDataProvider dp = Config.provider;

       public InsuranceInfoDAL()
       {
       }

       public InsuranceInfoData load()
       {
           return load("");
       }

       public InsuranceInfoData load(string condition)
       {
           InsuranceInfoData ds = new InsuranceInfoData();
           dp.loadToDataSet(InsuranceInfoData.insuranceInfo_TABLE, ds, "(cancel is null or cancel=0)" + condition);
           fillRadif(ds);
           return ds;
       }

       public int add(InsuranceInfoData dataSet)
       {
           return dp.add(dataSet, InsuranceInfoData.insuranceInfo_TABLE);
       }

       public int update(InsuranceInfoData dataSet) 
       {
           return dp.update(dataSet, InsuranceInfoData.insuranceInfo_TABLE);
       }

       public int delete(int id)
       {
           string tableName = InsuranceInfoData.insuranceInfo_TABLE;
        //   string sql = "delete from " + tableName + " where " + InsuranceInfoData.indexField + "=" + id;
           string delQuery = "update " + tableName + " set cancel = 1  where " + InsuranceInfoData.indexField + "=" + id;
           return dp.delete(delQuery);
       }

        public int recover(int id)
        {
            string query = "update insuranceInfo set cancel = 0 where id = " + id;
            return dp.executeNonQuery(query);

        }

        public int updateInsuranceNumber(string oldVal, string newVal)
        {
            string query = "update insuranceInfo set InsuranceNumber ='" + newVal +
                "' where InsuranceNumber = '" + oldVal + "'";
            return dp.executeNonQuery(query);

        }

       public int updateHaveDid(int id, Boolean b)
        {
            int h = (b ? 1 : 0);
            string query = "update " + InsuranceInfoData.insuranceInfo_TABLE + " set ";
            query += " haveDid= " + h + " where id=" + id;
            return dp.executeNonQuery(query);
        }

       public Boolean checkInsuranceNumberExists(string insNumber, int index)
        {
            InsuranceInfoData dataSet = new InsuranceInfoData();
            //string query = "SELECT * FROM INSURACEINFO WHERE INSURANCENUMBER = '" + insNumber + "'";
           string cond = "INSURANCENUMBER = '" + insNumber + "'";
           if (index >= 0)
               cond += "and id <>" + index;
            dp.loadToDataSet("INSURANCEINFO", dataSet,cond);
            if (dataSet.Tables[0].Rows.Count <= 0)
                return false;
            else
                return true;
        }

       public InsuranceInfoData getById(int id)
       {
           return load(" AND id= " + id);
       }
       
        public InsuranceInfoData getByIds(ArrayList ids)
       {
           string strIds = "";
           for (int i = 0; i < ids.Count; i++)
           {
               strIds += ids[i] + ",";
           }
           strIds = strIds.Substring(0, strIds.Length - 1);
           return load(" AND id in (" + strIds + ")");
       }

        public InsuranceInfoData getByInsuranceNumer(string insNum) {
            return load(" AND InsuranceNumber= '" + insNum + "'");
        }
// مربوط به آخرین چک شده ها
    // جدول 
        public void addLastChecked(int insuranceinfoId)
        {
            string insert = "INSERT INTO LASTCHECKEDLIST VALUES("+ insuranceinfoId +")";
            dp.executeNonQuery(insert);
        }

        public void deleteLastChecked(int insuranceinfoId)
        {
            string delete = "DELETE FROM LASTCHECKEDLIST WHERE insuranceid = " + insuranceinfoId ;
            dp.executeNonQuery(delete);
        }
    }

    
} 
