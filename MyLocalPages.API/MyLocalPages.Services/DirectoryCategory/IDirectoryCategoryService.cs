using Microsoft.Extensions.Logging;
using MyLocalPages.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPages.Services
{
    public interface IDirectoryCategoryService : IService<DirectoryCategory, Guid>
    {
    }
}
