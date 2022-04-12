using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfFramework.Services
{
    public interface IDatabaseService
    {
        string ConnectionString { get; }

        Task<IList<T>> GetDatasAsync<T>(string query) where T : class;
    }
}