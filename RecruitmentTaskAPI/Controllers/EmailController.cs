using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using RecruitmentTaskAPI.Data;
using RecruitmentTaskAPI.Data.Http;
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
                return new EmailAddResponse(Response, HttpStatusCode.InternalServerError, exception.Message, false);
            }
            return new EmailAddResponse(Response, HttpStatusCode.OK, true);
        }
    }
}
