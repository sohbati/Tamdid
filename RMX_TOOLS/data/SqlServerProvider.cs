using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RMX_TOOLS.common;
namespace RMX_TOOLS.data 
{
    public class SqlServerProvider : IDataProvider
    {
        public SqlServerProvider()
        {
             
        } 
           
        private Boolean setPrimitiveData()
        {
            DataSet dataset = new DataSet();
            try
            {
                dataset.ReadXmlSchema(fileName);
                dataset.ReadXml(fileName);
                serverName = dataset.Tables[0].Rows[0][0].ToString();
                userName = dataset.Tables[0].Rows[0][1].ToString();
                password = dataset.Tables[0].Rows[0][2].ToString();
                databaseName = dataset.Tables[0].Rows[0][3].ToString();
        }
        catch (Exception e)
        {
            connectionStatus = false;
            return false;

        }
        return true;
      }

        public override Boolean  connect()
        {
            try {
                if (!setPrimitiveData())
                    return false;
                //string str = "Data Source=anishtain;Initial Catalog=insurance;User ID=sa;Password=;";
                string str = "Data Source=" + serverName +
                    ";User ID=" + userName + ";Password=" + password + ";Initial Catalog=" + databaseName + ";";
                dbCon = new SqlConnection(str);

                dbCon.Open();
                sqlda = new SqlDataAdapter();
                sqlda.TableMappings.Add("Table", "insurancetype");
                connectionStatus = true;
                
            }catch(Exception e)
            {
                connectionStatus = false;
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public override void close()
        {

        }

        public override void loadToDataSet(string tableName, AbstractCommonData dataSet )
        {
            loadToDataSet(tableName, dataSet, "");
        }

        public override void loadToDataSet(string tableName, AbstractCommonData dataSet,string condition)
        {
            string query = "";
            if (condition != null && condition.Length > 0)
                query = "SELECT * FROM " + tableName + " WHERE " + condition;
            else
                query = "SELECT * FROM " + tableName;
            SqlCommand cmd = new SqlCommand(query, dbCon);
            sqlda.SelectCommand = cmd;
           sqlda.Fill(dataSet, tableName);
        }

        public override void executeSelect(string query,AbstractCommonData dataSet,string tableName)
        {
            SqlCommand cmd = new SqlCommand(query, dbCon);
            sqlda.SelectCommand = cmd;

            sqlda.Fill(dataSet, tableName);
        }

        public override int add(AbstractCommonData dataSet, String tableName)
        {
           // sqlda.
            SqlCommand cmd = new SqlCommand(dataSet.insertCommand, dbCon);
             
            sqlda.InsertCommand = cmd;
            SqlParameterCollection sqlParams = cmd.Parameters;
            for (int i = 0; i < dataSet.Tables[tableName].Columns.Count; i++)
            {
                string p = dataSet.Tables[tableName].Columns[i].Caption;
                System.Type type = dataSet.Tables[tableName].Columns[i].GetType();
                object value = dataSet.Tables[tableName].Rows[0][p];
                if (value != null)
                {
                    sqlParams.Add(new SqlParameter("@" + p, type));
                    sqlParams["@" + p].Value = value;
                }
            }
            return cmd.ExecuteNonQuery();
            //return sqlda.Update(dataSet);
        }

        public override int executeNonQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, dbCon);
            return cmd.ExecuteNonQuery();
                        
        }

        public override int update(AbstractCommonData dataSet,string tableName)
        {
            
            SqlCommand cmd = new SqlCommand(dataSet.updatecmdWithIndexedWhereCluse, dbCon);
            sqlda.InsertCommand = cmd;

            dataSet.Tables[0].Columns.Remove("RADIF");
            SqlParameterCollection sqlParams = cmd.Parameters;
             
            for (int i = 0; i < dataSet.Tables[tableName].Columns.Count; i++)
            {
                string p = dataSet.Tables[tableName].Columns[i].Caption;
                System.Type type = dataSet.Tables[tableName].Columns[i].GetType();
                object value = dataSet.Tables[tableName].Rows[0][p];
                if (value != null   )
                {
                    sqlParams.Add(new SqlParameter("@" + p, type));
                    sqlParams["@" + p].Value = value;
                }
            }
             
            return cmd.ExecuteNonQuery(); 
            //cmd.Parameters.Add(
            //return sqlda.Update(dataSet);
            
        }

        public override int delete(AbstractCommonData dataSet,string tableName)
        {
            SqlCommand cmd = new SqlCommand(dataSet.deleteCmdWithIndexedWhereCluse, dbCon);

            sqlda.DeleteCommand = cmd;
            SqlParameterCollection sqlParams = cmd.Parameters;
            for (int i = 0; i < dataSet.Tables[tableName].Columns.Count; i++)
            {
                string p = dataSet.Tables[tableName].Columns[i].Caption;
                System.Type type = dataSet.Tables[tableName].Columns[i].GetType();
                object value = dataSet.Tables[tableName].Rows[0][p];
                if (value != null)
                {
                    sqlParams.Add(new SqlParameter("@" + p, type));
                    sqlParams["@" + p].Value = value;
                }
            }
            cmd.ExecuteNonQuery();
            sqlda.Update(dataSet);
            return 0;
            
        }

        public override int delete(string query)
        {
            int n =1;//   if n become zero so we couldn't delete any records
            try
            {
                SqlCommand cmd = new SqlCommand(query, dbCon);
                 n = cmd.ExecuteNonQuery();
            }
            catch (SqlException es)
            {
                n = 0;
            }
            return n;
        }

        public int runExec(string query){
            SqlCommand cmd = new SqlCommand(query,dbCon);
            int i = cmd.ExecuteNonQuery();
            return i;
        }

        public int RunStoredProcedure(string procedureName)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(procedureName, dbCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // do nothing 
            }
            return i;
        }

        public override void select(string query, AbstractCommonData dataSet,string tableName)
        {
            SqlCommand cmd = new SqlCommand(query, dbCon);
            sqlda.SelectCommand = cmd;
            sqlda.Fill(dataSet, tableName);
        }

        public override string getAsSqlDate(string date, string time )
        {
            return "cast('" + date + " " + time + "' AS DateTime)";
        }

        public override string getBetweenDate(string fld, DateTime betw1, DateTime betw2, string daysBeforExp)
        {
            string d1 = betw1.ToShortDateString() + " " + RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY;
            string d2 = betw2.ToShortDateString() + " " + RMX_TOOLS.date.DateConstants.END_OF_DAY;
            string result;

            result = fld + " between CAST('" + d1 + "' AS DATETime) and ";
            if (daysBeforExp != null)
                result += " cast('" + d2 + "' AS DATETime) + daysBeforExp";
            else
                result += "cast('" + d2 + "' AS DATETime)";
            return result;
        }
    }
}
