using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using Insurance_Common;

namespace Insurance_dll
{
    public class UsersDal : AbstractDAL
    {
        IDataProvider dp = Config.provider;

        public UsersDal()
        {

        }

        public UsersData load()
        {
            UsersData ds = new UsersData();
            string query = "select *,ltrim(rtrim([name]))+' '+ltrim(rtrim([family]))as nameFamily from users ";
            dp.select(query, ds, UsersData.users_TABLE);
            //dp.loadToDataSet(UsersData.users_TABLE, ds);
            fillRadif(ds);
            return ds;
        }
        public UsersData loadNonManagers()
        {
            UsersData ds = new UsersData();
            string query = "select *,ltrim(rtrim([name]))+' '+ltrim(rtrim([family]))as nameFamily from users where usertype =1";
            dp.select(query, ds, UsersData.users_TABLE);
            //dp.loadToDataSet(UsersData.users_TABLE, ds);
            fillRadif(ds);
            return ds;
        }

        public int add(UsersData dataSet)
        {
            return dp.add(dataSet, UsersData.users_TABLE);
        }

        public int update(UsersData dataSet)
        {
            
            return dp.update(dataSet, UsersData.users_TABLE);
        }

        public int delete(int id)
        {
            string tableName = UsersData.users_TABLE;
            string sql = "delete from " + tableName + " where " + UsersData.indexField + "=" + id; 
            return dp.delete(sql);
        }

        public UsersData checkUser(string userName, String password,Boolean isManager)
        {
            UsersData dataSet = new UsersData();
            userName = userName.Trim();
            password = password.Trim();
            string s  = (isManager ? "AND USERTYPE =0 " : "");
            string condition = "";
            condition += " USERNAME = '" + userName + "' AND ";
            condition += " PASSWORD = '" + password + "' ";
            condition += s; 
            dp.loadToDataSet(UsersData.users_TABLE, dataSet, condition);
            return dataSet;
        }
        public void addInsuranceTypePerm(int userId, int insuranceTypeId)
        {
            string inserQ = "insert into INSURANCETYPEPERM(userCode,insuranceTypeCode)values(" +
               userId + "," + insuranceTypeId + ")";
            dp.executeNonQuery(inserQ);
        }

        public void deleteInsuranceTypePerm(int userId, int insuranceTypeId)
        {
            string inserQ = "DELETE  FROM INSURANCETYPEPERM WHERE " +
             " userCode = " + userId + " and insuranceTypeCode = " + insuranceTypeId + "";
            dp.executeNonQuery(inserQ);
            
        }

    }
}
