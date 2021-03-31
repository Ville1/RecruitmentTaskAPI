using Microsoft.AspNetCore.Http;
using System.Net;

namespace RecruitmentTaskAPI.Data.Http
{
    public class GetEmailsResponse : Response
    {
        public string Csv { get; set; }

        public GetEmailsResponse(string message, string csv) : base(message)
        {
            Csv = csv;
        }

        public GetEmailsResponse(HttpResponse response, HttpStatusCode code, string csv) : base(response, code)
        {
            Csv = csv;
        }

        public GetEmailsResponse(HttpResponse response, HttpStatusCode code, string message, string csv) : base(response, code, message)
        {
            Csv = csv;
        }
    }
}
