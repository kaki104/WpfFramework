using System.Data.SqlClient;

namespace WpfFramework.Services
{
    /// <summary>
    /// MS SQL 전용 서비스
    /// </summary>
    public class SqlService : DatabaseService
    {
        public SqlService(string connectionString)
            : base(connectionString)
        {
            //기본 컨넥션을 MS SqlConnection으로 생성합니다.
            Connection = new SqlConnection(ConnectionString);
            //기본 커맨드를 MS SqlCommand로 생성합니다.
            Command = new SqlCommand();
        }
    }
}
