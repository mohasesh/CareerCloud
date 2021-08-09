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
    public class SecurityLoginRepository : AdoConnectivity, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (SecurityLoginPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins]
                ([Id],
                [Login],
                [Password],
                [Created_Date],
                [Password_Update_Date],
                [Agreement_Accepted_Date],
                [Is_Locked],
                [Is_Inactive],
                [Email_Address],
                [Phone_Number],
                [Full_Name],
                [Force_Change_Password],
                [Prefferred_Language])
                values         
                (@Id,
                @Login,
                @Password,
                @Create_Date,
                @Password_Update_Date,
                @Agreement_Accepted_Date,
                @Is_Locked,
                @Is_Inactive,
                @Email_Address,
                @Phone_Number,
                @Full_Name,
                @Force_Change_Password,
                @Prefferred_Language)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Login", item.Login);
                cmd.Parameters.AddWithValue("@Password", item.Password);
                cmd.Parameters.AddWithValue("@Create_Date", item.Created);
                cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
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

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM [dbo].[Security_Logins]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            SecurityLoginPoco[] pocos = new SecurityLoginPoco[1000];
            while (sdr.Read())
            {
                SecurityLoginPoco poco = new SecurityLoginPoco();
                poco.Id = sdr.GetGuid(0);
                poco.Login = sdr.GetString(1);
                poco.Password = sdr.GetString(2);
                poco.Created = sdr.GetDateTime(3);
                poco.PasswordUpdate = sdr.IsDBNull(4)?null:(DateTime?)sdr[4];
                poco.AgreementAccepted =sdr.IsDBNull(5)?null:(DateTime?)sdr[5];
                poco.IsLocked = sdr.GetBoolean(6);
                poco.IsInactive = sdr.GetBoolean(7);
                poco.EmailAddress = sdr.GetString(8);
                poco.PhoneNumber = sdr.IsDBNull(9)?null:sdr.GetString(9);
                poco.FullName = sdr.IsDBNull(10)?null:sdr.GetString(10);
                poco.ForceChangePassword = sdr.GetBoolean(11);
                poco.PrefferredLanguage = sdr.IsDBNull(12) ? null : sdr.GetString(12);
                poco.TimeStamp = (byte[])sdr[13];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> poco = GetAll().AsQueryable();
            return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (SecurityLoginPoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Security_Logins]
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

        public void Update(params SecurityLoginPoco[] items)
        {
           using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (SecurityLoginPoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Security_Logins]
                SET
                [Login]= @Login,
                [Password]=@Password,
                [Created_Date]=@Create_Date,
                [Password_Update_Date]=@Password_Update_Date,
                [Agreement_Accepted_Date]=@Agreement_Accepted_Date,
                [Is_Locked]=@Is_Locked,
                [Is_Inactive]=@Is_Inactive,
                [Email_Address]= @Email_Address,
                [Phone_Number]=@Phone_Number,
                [Full_Name]=@Full_Name,
                [Force_Change_Password]=@Force_Change_Password,
                [Prefferred_Language]=@Prefferred_Language        
                WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Login", item.Login);
                cmd.Parameters.AddWithValue("@Password", item.Password);
                cmd.Parameters.AddWithValue("@Create_Date", item.Created);
                cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
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
