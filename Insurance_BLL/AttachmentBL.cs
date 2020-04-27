using System;
using System.Collections.Generic;
using System.Text;
using Insurance_dll;
using Insurance_Common;

namespace Insurance_BLL
{
    public class AttachmentBL  
    {
        AttachmentDA _abstractDA = null;
        public AttachmentBL()
        {
            _abstractDA = new AttachmentDA();
        }
        public AttachmentEntity get(int letterid)
        {
            return ((AttachmentDA)_abstractDA).get(letterid);
        }

        public int getCount(int insuranceId)
        {
            return ((AttachmentDA)_abstractDA).getCount(insuranceId);
        }

        public AttachmentEntity getById(int id)
        {
            return ((AttachmentDA)_abstractDA).getById(id);
        }

        public int add(AttachmentEntity entity)
        {
            return ((AttachmentDA)_abstractDA).add(entity);
        }

        public int update(AttachmentEntity entity)
        {
            return ((AttachmentDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((AttachmentDA)_abstractDA).delete(id);
        }
    }
}
