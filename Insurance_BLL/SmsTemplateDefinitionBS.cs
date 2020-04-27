using System;
using System.Collections.Generic;
using System.Text;
using Insurance_Common;
using Insurance_dll;
using System.Data;
namespace Insurance_BLL
{
    public class SmsTemplateDefinitionBS
    {
        SmsTemplateDefinitionDAL _SmsTemplateDefinitionDAL;
      public SmsTemplateDefinitionBS()
      {
          _SmsTemplateDefinitionDAL = new SmsTemplateDefinitionDAL();
      }

      
        public SmsTemplateDefinitionData laod()
        {
          return _SmsTemplateDefinitionDAL.load();
        }

        public SmsTemplateDefinitionData getByTemplatebyType(int type)
        {
            return _SmsTemplateDefinitionDAL.getByTemplateByType(type);
        }

        public int add(SmsTemplateDefinitionData dataSet)
        {
            _SmsTemplateDefinitionDAL.add(dataSet);
            return 0;
        }

        public int update(SmsTemplateDefinitionData dataSet)
        {
            return _SmsTemplateDefinitionDAL.update(dataSet);
        }

        public int delete(int id)
        {
            return _SmsTemplateDefinitionDAL.delete(id);
        }

    }
        
}