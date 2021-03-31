using RecruitmentTaskAPI.Data.DB;
using RecruitmentTaskAPI.Data.DB.Model;
using RecruitmentTaskAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentTaskAPI.Data.Repository
{
    public class EmailRepository
    {
        public List<EmailModel> GetAll()
        {
            try {
                List<EmailModel> data = null;
                using (DatabaseContext db = new DatabaseContext()) {
                    data = db.Emails.ToList();
                    foreach (EmailAttribute attribute in Repository.EmailAttributes.GetAll()) {
                        data.First(x => x.EmailKey == attribute.EmailKey).Attributes.Add(Repository.Attributes.Get(attribute.AttributeId));
                    }
                }
                return data;
            } catch (Exception exception) {
                Logger.LogException(exception);
                throw exception;
            }
        }

        public EmailModel Get(string key)
        {
            return GetAll().FirstOrDefault(x => x.EmailKey == key);
        }

        public void Save(EmailModel data)
        {
            using (DatabaseContext db = new DatabaseContext()) {
                db.Emails.Add(data);
                db.SaveChanges();
            }
        }
    }
}
