using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginsRoleRepository : AdoConnectivity, IDataRepository<SecurityLoginsRolePoco>
    {
        public void Add(params SecurityLoginsRolePoco[] items)
        {
           using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (SecurityLoginsRolePoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins_Roles]
                ([Id],
                [Login],
                [Role])
                VALUES         
                (@Id,
                @Login,
                @Role)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Login", item.Login);
                cmd.Parameters.AddWithValue("@Role", item.Role);
                try
                {
                    conn.Open();
                    int rowaffected = cmd.ExecuteNonQuery();
                    Console.WriteLine(rowaffected + "Row Affected");
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("The Error is :" + e.Message);
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM [dbo].[Security_Logins_Roles]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            SecurityLoginsRolePoco[] pocos = new SecurityLoginsRolePoco[1000];
            while (sdr.Read())
            {
                SecurityLoginsRolePoco poco = new SecurityLoginsRolePoco();
                poco.Id = sdr.GetGuid(0);
                poco.Login = sdr.GetGuid(1);
                poco.Role = sdr.GetGuid(2);
                poco.TimeStamp = (byte[])sdr[3];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
            
        }

        public IList<SecurityLoginsRolePoco> GetList(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsRolePoco GetSingle(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsRolePoco> poco = GetAll().AsQueryable();
            return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsRolePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (SecurityLoginsRolePoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Security_Logins_Roles]
                WHERE [Id]=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                try
                {
                    conn.Open();
                    int rowaffected = cmd.ExecuteNonQuery();
                    Console.WriteLine(rowaffected + "Row Affected");
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("The Error is :" + e.Message);
                }

            }
        }

        public void Update(params SecurityLoginsRolePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (SecurityLoginsRolePoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Security_Logins_Roles]
                SET
                [Login]=@Login,
                [Role]=@Role        
                WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Login", item.Login);
                cmd.Parameters.AddWithValue("@Role", item.Role);
                try
                {
                    conn.Open();
                    int rowaffected = cmd.ExecuteNonQuery();
                    Console.WriteLine(rowaffected + "Row Affected");
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("The Error is :" + e.Message);
                }
            }
        }
    }
}
