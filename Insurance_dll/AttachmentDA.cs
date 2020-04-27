using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.DAL;
using Insurance_Common;
using RMX_TOOLS.data;

namespace Insurance_dll
{
    public class AttachmentDA : AbstractDAL
    {
        IDataProvider provider = Config.provider;

        public AttachmentEntity get(int id)
        {
            AttachmentEntity entity = new AttachmentEntity();
            String cond = AttachmentEntity.FIELD_INSURANCE_ID + "=" +id ;
            provider.loadToDataSet(AttachmentEntity.TableName, entity, cond);
            fillRadif(entity);
            return entity;
        }

        public int getCount(int insuranceId)
        {
            //ToDo reprogram this lines
            AttachmentEntity entity = new AttachmentEntity();
            String sql = "SELECT COUNT(1) FROM " + AttachmentEntity.TableName + " WHERE " + AttachmentEntity.FIELD_INSURANCE_ID
                + "=" + insuranceId;
            String cond = AttachmentEntity.FIELD_INSURANCE_ID + "=" + insuranceId;
            provider.loadToDataSet(AttachmentEntity.TableName, entity, cond);
            return entity.Tables[AttachmentEntity.TableName].Rows.Count;
        }

        public AttachmentEntity getById(int id)
        {
            AttachmentEntity entity = new AttachmentEntity();
            String cond = AttachmentEntity.FIELD_ID + "=" + id;
            provider.loadToDataSet(AttachmentEntity.TableName, entity, cond);
            fillRadif(entity);
            return entity;
        }

        public int add(AttachmentEntity entity)
        {
            return provider.add(entity, AttachmentEntity.TableName);
        }

        public int update(AttachmentEntity entity)
        {
            return provider.update(entity, AttachmentEntity.TableName);
        }

        public int delete(int id)
        {
            AttachmentEntity entity = new AttachmentEntity();
            string delQuery = "DELETE FROM " + AttachmentEntity.TableName + " WHERE " + AttachmentEntity.indexField + "=" + id;
            return provider.delete(delQuery);
        }

    }
}
