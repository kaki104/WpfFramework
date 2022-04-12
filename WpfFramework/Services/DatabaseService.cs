using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WpfFramework.Services
{
    /// <summary>
    /// DatabaseService 
    /// </summary>
    public abstract class DatabaseService : IDatabaseService
    {
        private string _connectionString;
        /// <summary>
        /// ConnectionString
        /// </summary>
        public string ConnectionString => _connectionString;

        protected DbConnection Connection { get; set; }

        protected DbCommand Command { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="connectionString"></param>
        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// 쿼리 실행 후 결과 반환
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual async Task<IList<T>> GetDatasAsync<T>(string query) where T : class
        {
            if (Connection == null || Command == null || string.IsNullOrEmpty(query))
            {
                return null;
            }
            await Connection.OpenAsync();
            Command.CommandText = query;
            Command.Connection = Connection;
            var returnDatas = new List<T>();
            using var reader = await Command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var row = (IDataRecord)reader;
                var model = Activator.CreateInstance(typeof(T));
                returnDatas.Add(model as T);
                var propertys = model.GetType().GetProperties();
                foreach (var prop in propertys.Where(p => p.Name != "HasErrors"))
                {
                    try
                    {
                        var value = row[prop.Name];
                        if (value is DBNull == false)
                        {
                            prop.SetValue(model, value);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
            await Connection.CloseAsync();
            return returnDatas;
        }
    }
}
