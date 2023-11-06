using huce.phuhuynh.entities.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huce.motcua.repository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly HucePhuHuynhDbContext _dbContext;
        protected readonly ILogger _logger;

        public BaseRepository(HucePhuHuynhDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}
