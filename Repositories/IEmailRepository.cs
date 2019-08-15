using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Repositories
{
    public interface IEmailRepository
    {
        EmailTemplate GetEmailTemplate(EmailTemplate emailTemplate);

        void SendEmail(Email email);
    }
}
