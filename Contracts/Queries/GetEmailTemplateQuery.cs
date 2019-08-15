using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    public class GetEmailTemplateQuery : IQuery<EmailTemplate>
    {
        public EmailTemplate EmailTemplate;

        public GetEmailTemplateQuery(EmailTemplate emailTemplate)
        {
            EmailTemplate = emailTemplate;
        }
    }
}
