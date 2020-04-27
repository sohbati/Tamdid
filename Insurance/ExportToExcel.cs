using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using RMX_TOOLS.common;
using System.Collections;
using Insurance_Common;

namespace Insurance
{
    public class ExportToExcel
    {
        public static void executeExcel(String reportFile)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = reportFile;
            Process.Start(startInfo);
        }

        public static string getData(AbstractCommonData dataSet, ArrayList selectedFields, ArrayList selectedFieldsTitle)
        {
            if (selectedFieldsTitle.Count < 2)
            {
                return "";
            }
            string data = "";
            string flds = "";
            string t;
            
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                t = generalizeData(selectedFields[0].ToString(), dataSet.Tables[0].Rows[i][selectedFields[0].ToString()].ToString().Trim());

                flds = "<Row>\n\t<Cell ss:Index=\"1\"><Data ss:Type=\"String\">" + t + "</Data></Cell>\n";
                for (int j = 1; j < selectedFields.Count; j++)
                {
                    if (selectedFields[j] == null || selectedFields[j].ToString().Length == 0)
                    {
                        t = "";
                    }
                    else
                    {
                        t = generalizeData(selectedFields[j].ToString(), dataSet.Tables[0].Rows[i][selectedFields[j].ToString()].ToString().Trim());
                    }
                    flds += "\t<Cell><Data ss:Type=\"String\">" + t + "</Data></Cell>\n";
                }
                data += flds + "</Row>\n";
            }
            return data;
        }


        public static string generalizeData(string fld, string value)
        {
            if (fld.ToLower().Equals(InsuranceInfoData.beginDate_FIELD.ToLower()) ||
                fld.ToLower().Equals(InsuranceInfoData.endDate_FIELD.ToLower()))
            {
                return RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Parse(value));
            }

            if (fld.ToLower().Equals(InsuranceInfoData.haveDid_FIELD.ToLower()))
            {
                Boolean b = Boolean.Parse(value);
                return (b ? "انجام شده" : "انجام نشده ");
            }
            return value;
        }


    }
}
