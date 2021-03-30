using RecruitmentTaskAPI.Data;
using RecruitmentTaskAPI.Data.Http;
using System.Linq;

namespace RecruitmentTaskAPI.Utils
{
    public class Validation
    {
        public static EmailAddResponse Validate(EmailData input)
        {
            if(input.Email.Where(x => x == '@').Count() != 1) {
                return new EmailAddResponse("Invalid email address", false);
            }
            if(input.Attributes.Count != input.Attributes.Distinct().Count()) {
                return new EmailAddResponse("Duplicated attributes", false);
            }
            return null;
        }
    }
}
