using Microsoft.Extensions.Configuration;

namespace MyLocalPages.Services.BusinessDirectory
{
    public class BusinessDirectoryService : IBusinessDirectoryService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public BusinessDirectoryService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }
    }
}
