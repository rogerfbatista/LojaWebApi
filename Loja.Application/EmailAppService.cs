using Loja.Application.Interfaces;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces.Services;

namespace Loja.Application
{
    public class EmailAppService : AppServiceBase<Email>, IEmailAppService
    {
        private readonly IEmailService _emailService;

        public EmailAppService(IEmailService emailService)
            :base(emailService)
        {
            _emailService = emailService;
        }
    }

}
