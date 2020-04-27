using System;
using System.Collections.Generic;
using System.Text;
using Insurance_Common;
using Insurance_dll;
using System.Collections;
namespace Insurance_BLL
{
    public class InsuranceInfoBS
    {
        private InsuranceInfoDAL _insuranceInfoDAL;

        public InsuranceInfoBS()
        {
            _insuranceInfoDAL = new InsuranceInfoDAL();
        }

        public InsuranceInfoData load()
        {
            return _insuranceInfoDAL.load();
        }

        public int add(InsuranceInfoData dataSet)
        {
            return _insuranceInfoDAL.add(dataSet);
        }

        public int update(InsuranceInfoData dataSet)
        {
            return _insuranceInfoDAL.update(dataSet);
        }

        public int delete(int id)
        {
            return _insuranceInfoDAL.delete(id);
        }
        
        public int recover(int id)
        {
            return _insuranceInfoDAL.recover(id);
        }

        public int updateHaveDid(int id, Boolean haveDid)
        {
            return _insuranceInfoDAL.updateHaveDid(id, haveDid);
        }

        public int updateInsuranceNumber(string oldVal, string newVal ) 
        {
            return _insuranceInfoDAL.updateInsuranceNumber(oldVal, newVal);
        }

        public Boolean checkInsuranceNumberExists(string insNumber,int index)
        {
            return _insuranceInfoDAL.checkInsuranceNumberExists(insNumber, index);
        }

        public InsuranceInfoData getById(int id)
        {
            return _insuranceInfoDAL.getById(id);
        }
        
        public InsuranceInfoData getByIds(ArrayList ids)
        {
            return _insuranceInfoDAL.getByIds(ids);
        }

        public InsuranceInfoData getByInsuranceNumer(string insNum)
        {
            return _insuranceInfoDAL.getByInsuranceNumer(insNum);
        }
        public string getEndDateByInsuranceNumer(string insNum)
        {
            InsuranceInfoData data = _insuranceInfoDAL.getByInsuranceNumer(insNum);
            string enddate = 
                data.Tables[InsuranceInfoData.insuranceInfo_TABLE].Rows[0][InsuranceInfoData.endDate_FIELD].ToString();
            return enddate;
        }

        public void addLastChecked(int insuranceinfoId)
        {
            _insuranceInfoDAL.addLastChecked(insuranceinfoId);
        }

        public void deleteLastChecked(int insuranceinfoId)
        {
            _insuranceInfoDAL.deleteLastChecked(insuranceinfoId);
        }
    }
}
