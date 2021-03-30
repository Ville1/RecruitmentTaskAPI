using Microsoft.AspNetCore.Http;
using System.Net;

namespace RecruitmentTaskAPI.Data.Http
{
    public class EmailAddResponse : Response
    {
        public bool Success { get; set; }

        public EmailAddResponse(string message, bool success) : base(message)
        {
            Success = success;
        }

        public EmailAddResponse(HttpResponse response, HttpStatusCode code, bool success) : base(response, code)
        {
            Success = success;
        }

        public EmailAddResponse(HttpResponse response, HttpStatusCode code, string message, bool success) : base(response, code, message)
        {
            Success = success;
        }
    }
}
