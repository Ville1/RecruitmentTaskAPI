using RecruitmentTaskAPI.Data.DB;
using RecruitmentTaskAPI.Data.DB.Model;
using RecruitmentTaskAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentTaskAPI.Data.Repository
{
    public class EmailAttributeRepository
    {
        public List<EmailAttribute> GetAll()
        {
            try {
                List<EmailAttribute> data = null;
                using (DatabaseContext db = new DatabaseContext()) {
                    data = db.EmailAttributes.ToList();
                }
                return data;
            } catch (Exception exception) {
                Logger.LogException(exception);
                throw exception;
            }
        }

        public EmailAttribute Get(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Save(EmailAttribute data)
        {
            using (DatabaseContext db = new DatabaseContext()) {
                db.EmailAttributes.Add(data);
                db.SaveChanges();
            }
        }
    }
}
