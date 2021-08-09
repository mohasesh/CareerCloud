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
    public class CompanyProfileRepository : AdoConnectivity, IDataRepository<CompanyProfilePoco>
    {
        public void Add(params CompanyProfilePoco[] items)
        {
           using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (CompanyProfilePoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Profiles]
                ([Id],
                [Registration_Date],
                [Company_Website],
                [Contact_Phone],
                [Contact_Name],
                [Company_Logo])
                VALUES         
                (@Id,
                @Registration_Date,
                @Company_Website,
                @Contact_Phone,
                @Contact_Name,
                @Company_Logo)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Registration_Date", item.RegistrationDate);
                cmd.Parameters.AddWithValue("@Company_Website", item.CompanyWebsite);
                cmd.Parameters.AddWithValue("@Contact_Phone", item.ContactPhone);
                cmd.Parameters.AddWithValue("@Contact_Name", item.ContactName);
                cmd.Parameters.AddWithValue("@Company_Logo", item.CompanyLogo);
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

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM [dbo].[Company_Profiles]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            CompanyProfilePoco[] pocos = new CompanyProfilePoco[1024];
            while (sdr.Read())
            {
                CompanyProfilePoco poco = new CompanyProfilePoco();
                poco.Id = sdr.GetGuid(0);
                poco.RegistrationDate = sdr.GetDateTime(1);
                poco.CompanyWebsite = sdr.IsDBNull(2) ? null : sdr.GetString(2); 
                poco.ContactPhone = sdr.GetString(3);
                poco.ContactName = sdr.IsDBNull(4)?null:sdr.GetString(4);
                poco.CompanyLogo= sdr.IsDBNull(5)?null:(byte[])sdr[5];
                poco.TimeStamp = sdr.IsDBNull(6)?null:(byte[])sdr[6];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> poco = GetAll().AsQueryable();
            return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (CompanyProfilePoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Profiles]
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

        public void Update(params CompanyProfilePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (var item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Company_Profiles]
                SET
                [Registration_Date]=@Registration_Date,
                [Company_Website]=@Company_Website,
                [Contact_Phone]=@Contact_Phone,
                [Contact_Name]=@Contact_Name,
                [Company_Logo]=@Company_Logo         
                WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Registration_Date", item.RegistrationDate);
                cmd.Parameters.AddWithValue("@Company_Website", item.CompanyWebsite);
                cmd.Parameters.AddWithValue("@Contact_Phone", item.ContactPhone);
                cmd.Parameters.AddWithValue("@Contact_Name", item.ContactName);
                cmd.Parameters.AddWithValue("@Company_Logo", item.CompanyLogo);
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
