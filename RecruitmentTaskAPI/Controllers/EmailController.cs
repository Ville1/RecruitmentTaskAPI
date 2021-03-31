using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RecruitmentTaskAPI.Data;
using RecruitmentTaskAPI.Data.DB.Model;
using RecruitmentTaskAPI.Data.Http;
using RecruitmentTaskAPI.Data.Repository;
using RecruitmentTaskAPI.Utils;

namespace RecruitmentTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        [Produces("application/json")]
        public EmailAddResponse Add(EmailData input)
        {
            //Validate
            EmailAddResponse error_response = Validation.Validate(input);
            if (error_response != null) {
                return error_response;
            }

            //Save to file
            try {
                FileManager.Save(input);
            } catch (Exception exception) {
                Logger.LogException(exception);
                return new EmailAddResponse(Response, HttpStatusCode.InternalServerError, exception.Message, false);
            }
            return new EmailAddResponse(Response, HttpStatusCode.OK, true);
        }

        [HttpGet]
        [Route("getEmailsToday")]
        [Produces("application/json")]
        public GetEmailsResponse getEmailsToday()
        {
            try {
                List<EmailModel> emails = Repository.Emails.GetAll().Where(x =>
                    x.Created != null &&
                    x.Created.Value.Year == DateTime.Now.Year &&
                    x.Created.Value.Month == DateTime.Now.Month &&
                    x.Created.Value.Day == DateTime.Now.Day
                ).ToList();
                StringBuilder csv = new StringBuilder();

                char separator = ';';
                foreach(EmailModel email in emails) {
                    csv.Append(email.EmailKey).Append(separator).Append(email.Email).Append(separator).Append(string.Join(',', email.Attributes.Select(x => x.Name).ToArray()))
                        .Append(separator).Append(Environment.NewLine);
                }

                return new GetEmailsResponse(null, csv.ToString());
            } catch(Exception exception) {
                Logger.LogException(exception);
                return new GetEmailsResponse(Response, HttpStatusCode.InternalServerError, exception.Message, null);
            }
        }
    }
}
