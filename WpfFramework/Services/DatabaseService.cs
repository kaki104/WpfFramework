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
        /// <summary>
        /// 기본 connection
        /// </summary>
        protected DbConnection Connection { get; set; }
        /// <summary>
        /// 기본 command
        /// </summary>
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
        public virtual async Task<IList<T>> GetDatasAsync<T>(string query) where T : class
        {
            if (Connection == null || Command == null || string.IsNullOrEmpty(query))
            {
                return null;
            }
            //컨넥션 열기
            await Connection.OpenAsync();
            //쿼리 입력
            Command.CommandText = query;
            Command.Connection = Connection;
            var returnDatas = new List<T>();
            //커맨드 실행하고 리더 반환
            using var reader = await Command.ExecuteReaderAsync();
            //리터를 이용해서 한줄 읽음
            while (await reader.ReadAsync())
            {
                var row = (IDataRecord)reader;
                //T를 이용해서 인스턴스 생성
                var model = Activator.CreateInstance(typeof(T));
                //결과 목록에 추가
                returnDatas.Add(model as T);
                //이 아래 부분은 프로퍼티 한개씩 하드코딩 하지 않고, 값을 입력하기 위해서 사용하는 부분입니다.
                //모델에서 프로퍼티 추출
                var propertys = model.GetType().GetProperties();
                //프로퍼티 중 HasErrors라는 이름의 프로퍼티 빼고 나머지 데이터 입력
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
            //컨넥션 닫기
            await Connection.CloseAsync();
            //결과 반환
            return returnDatas;
        }
    }
}
