using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RMX_TOOLS.common
{
    public class AbstractCommonData :DataSet
    {
        public const string RADIF_FIELD = "RADIF";
        public const string PASTOFEXPIRE = "EXP";
        public const string SHAMSIDATE = "SHAMSIDATE";
        public const string BEGINDATE_SHAMSI = "BEGINDATE_SHAMSI";
        public string updatecmdWithIndexedWhereCluse;
        public string updatecmdWithoutWhereCluse;
        public string deleteCmdWithIndexedWhereCluse;
        public string deleteCmdWithoutWhereCluse;
        public string insertCommand;

        public SqlParameterCollection sqlParamColl;
 
        public AbstractCommonData()
        {
        }

        private Boolean checkIsAppearable(string field, string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                if (field.Equals(arr[i]))
                    return false;
            return true;
        }

        protected void generateCommands(string InsuranceType_TABLE, string indexField)
        {
            // the field that don't want to display in query
            string[] disappears = new string[2];
            disappears[0] = indexField;
            disappears[1] = RADIF_FIELD;
            // create  an array for filed who must appear in query
            string[] appears = new string[this.Tables[InsuranceType_TABLE].Columns.Count - disappears.Length];
            string fld;
            int index = 0;
            for (int i = 0; i < this.Tables[InsuranceType_TABLE].Columns.Count; i++)
            {
                fld = this.Tables[InsuranceType_TABLE].Columns[i].Caption;
                if (checkIsAppearable(fld, disappears))
                {
                    appears[index] = fld;
                    index++;
                }
            }
            string whereCluse = " WHERE [" + indexField + "] = @" + indexField; ;
            //delete Command 
            string delete = "DELETE FROM [dbo].[" + InsuranceType_TABLE + "] ";

            deleteCmdWithIndexedWhereCluse = delete + whereCluse;
            deleteCmdWithoutWhereCluse = delete;

            // insert command 
             
            string insert = "INSERT INTO " + InsuranceType_TABLE;
            string fields = "(";
            string values = "VALUES(";
            for (int i = 0; i < appears.Length - 1; i++)
            {
                fld = appears[i];
                fields += "[" + fld + "],";
                values += "@" + fld + ",";
                 
            }
             
            fld = appears[appears.Length - 1];
            fields += "[" + fld + "])";
            values += "@" + fld + ")";
            
            insert += fields + values;
            insertCommand = insert;

            //update command
            string update = "UPDATE [dbo].[" + InsuranceType_TABLE + "] SET ";
            for (int i = 0; i < appears.Length -1 ; i++)
            {
                fld = appears[i];
                update += " [" + fld + "] = @" + fld + ",";
                 
            }
             
            fld = appears[appears.Length -1];
                update += "[" + fld + "] = @" + fld + "";

            updatecmdWithIndexedWhereCluse = update + whereCluse;
            updatecmdWithoutWhereCluse = update;
        }

    }


}
