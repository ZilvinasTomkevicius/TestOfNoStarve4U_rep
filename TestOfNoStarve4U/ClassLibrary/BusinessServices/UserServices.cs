using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessServices;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibrary.BusinessServices
{
    public class UserServices : IUserServices
    {
        private string connectionString;

        public UserServices()
        {
            this.connectionString = ClassLibrary.Properties.Settings.Default.ConnectionString;
        }

        private SqlDataReader reader;

        public void Add(UserEntity user)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                try
                {
                    con.Open();

                    SqlTransaction tr = con.BeginTransaction();

                    SqlCommand cmd = new SqlCommand("insert into dbo.UserTable(userName, userEmail, userPassword) values (@Name, @Email, @Password)", con, tr);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", user.userName);
                    cmd.Parameters.AddWithValue("@Email", user.userEmail);
                    cmd.Parameters.AddWithValue("@Password", user.userPassword);

                    cmd.ExecuteNonQuery();

                    tr.Commit();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }

        }

        public void Update(UserEntity user)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                try
                {
                    con.Open();

                    SqlTransaction tr = con.BeginTransaction();

                    SqlCommand cmd = new SqlCommand("update UserTable set userName = @Name, userEmail = @Email, userPassword = @Password where userID = @ID", con, tr);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", user.userID);
                    cmd.Parameters.AddWithValue("@Password", user.userPassword);
                    cmd.Parameters.AddWithValue("@Name", user.userName);
                    cmd.Parameters.AddWithValue("@Email", user.userEmail);

                    cmd.ExecuteNonQuery();

                    tr.Commit();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public void Delete(int userID)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("delete from UserTable where userID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", userID);

                cmd.ExecuteNonQuery();
            }
        }

        public UserEntity Get(int userID)
        {

            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select userID,userName,userDateTime from UserTable where userID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", userID);

                reader = cmd.ExecuteReader();

                UserEntity user = new UserEntity();

                while (reader.Read())
                {
                    user.userID = reader.GetInt32(0);
                    user.userName = reader.GetString(1);
                    user.lastLogin = reader.GetDateTime(2);
                }

                reader.Close();

                return user;
            }

        }

        public List<UserEntity> GetList()
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                con.Open();

                List<UserEntity> userList = new List<UserEntity>();

                SqlCommand cmd = new SqlCommand("select userID, userName, userDateTime from UserTable", con);
                cmd.CommandType = CommandType.Text;

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UserEntity user = new UserEntity();

                    user.userID = reader.GetInt32(0);
                    user.userName = reader.GetString(1);
                    user.lastLogin = reader.GetDateTime(2);

                    userList.Add(user);
                }

                reader.Close();

                return userList;
            }
        }
    }
}
