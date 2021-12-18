using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Interfaces
{
    public interface IDapperContext
    {
        Task<List<T>> GetAsync<T>(string sqlQuery);
        Task ExecuteAsync(string sqlQuery);
    }
}
