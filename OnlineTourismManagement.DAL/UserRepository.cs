using OnlineTourismManagement.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public class UserRepository
    {
        //static SqlConnection connection;

        public static IEnumerable<UserDetails> GetUsers()
        {
            DBContext context = new DBContext();
            return context.UserDB.ToList();
        }
        public static void AddUser(UserDetails user)
        {
            DBContext context = new DBContext();
            context.UserDB.Add(user);
            context.SaveChanges();
            //string procedure = "usp_Customer_Signup";
            //int rows;
            //connection = Connection.EstablishConnection();
            //using (SqlCommand command = new SqlCommand(procedure, connection))
            //{
            //    command.CommandType = System.Data.CommandType.StoredProcedure;
            //    SqlParameter param = new SqlParameter();
            //    param.ParameterName = "@firstName";
            //    param.Value = user.FirstName;
            //    param.SqlDbType = System.Data.SqlDbType.VarChar;
            //    command.Parameters.Add(param);

            //    param = new SqlParameter();
            //    param.ParameterName = "@lastName";
            //    param.Value = user.LastName;
            //    param.SqlDbType = System.Data.SqlDbType.VarChar;
            //    command.Parameters.Add(param);

            //    param = new SqlParameter();
            //    param.ParameterName = "@mobileNumber";
            //    param.Value = user.MobileNumber;
            //    param.SqlDbType = System.Data.SqlDbType.BigInt;
            //    command.Parameters.Add(param);

            //    param = new SqlParameter();
            //    param.ParameterName = "@dateOfBirth";
            //    param.Value = user.DateOfBirth;
            //    param.SqlDbType = SqlDbType.Date;
            //    command.Parameters.Add(param);

            //    param = new SqlParameter();
            //    param.ParameterName = "@gender";
            //    param.Value = user.Gender;
            //    param.SqlDbType = System.Data.SqlDbType.VarChar;
            //    command.Parameters.Add(param);

            //    param = new SqlParameter();
            //    param.ParameterName = "@mailId";
            //    param.Value = user.MailId;
            //    param.SqlDbType = System.Data.SqlDbType.VarChar;
            //    command.Parameters.Add(param);

            //    param = new SqlParameter();
            //    param.ParameterName = "@password";
            //    param.Value = user.Password;
            //    param.SqlDbType = System.Data.SqlDbType.VarChar;
            //    command.Parameters.Add(param);

            //    param = new SqlParameter();
            //    param.ParameterName = "@customerRole";
            //    param.Value = user.UserRole;
            //    param.SqlDbType = SqlDbType.VarChar;
            //    command.Parameters.Add(param);

            //    connection.Open();
            //    rows = command.ExecuteNonQuery();
            //}
            //return rows;
        }
        
    }
}
