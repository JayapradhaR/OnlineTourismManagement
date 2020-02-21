using System.Configuration;
using System.Data.SqlClient;
namespace OnlineTourismManagement.DAL
{
    public class Connection
    {
        public static SqlConnection EstablishConnection()
        {
           string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        
    }
}
