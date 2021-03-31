using RecruitmentTaskAPI.Data.DB;
using RecruitmentTaskAPI.Data.DB.Model;
using RecruitmentTaskAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentTaskAPI.Data.Repository
{
    public class AttributeRepository
    {
        public List<AttributeData> GetAll()
        {
            try {
                List<AttributeData> data = null;
                using (DatabaseContext db = new DatabaseContext()) {
                    data = db.Attributes.ToList();
                }
                return data;
            } catch (Exception exception) {
                Logger.LogException(exception);
                throw exception;
            }
        }

        public AttributeData Get(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Save(AttributeData data)
        {
            using (DatabaseContext db = new DatabaseContext()) {
                db.Attributes.Add(data);
                db.SaveChanges();
            }
        }
    }
}
