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
    public class ApplicantProfileRepository : AdoConnectivity, IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
           using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantProfilePoco item in items)
            {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Profiles]
                    ([Id],
                    [Login],
                    [Current_Salary],
                    [Current_Rate],
                    [Currency],
                    [Country_Code],
                    [State_Province_Code],
                    [street_Address],
                    [City_Town],
                    [Zip_Postal_Code])
                    VALUES         
                    (@Id,
                    @Login,
                    @Current_Salary,
                    @Current_Rate,
                    @Currency,
                    @Country_Code,
                    @State_Province_Code,
                    @street_Address,
                    @City_Town,
                    @Zip_Postal_Code)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", item.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", item.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                    cmd.Parameters.AddWithValue("@street_Address", item.Street);
                    cmd.Parameters.AddWithValue("@City_Town", item.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
                try
                {
                    conn.Open();
                   int rowaffected= cmd.ExecuteNonQuery();
                    Console.WriteLine(rowaffected+" Row Affected");
                    conn.Close();
                }catch(Exception e)
                {
                    Console.WriteLine("The Error is :" + e.Message);
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM [dbo].[Applicant_Profiles]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[1000];
            while (sdr.Read())
            {
                ApplicantProfilePoco poco = new ApplicantProfilePoco();
                poco.Id = sdr.GetGuid(0);
                poco.Login = sdr.GetGuid(1);
                poco.CurrentSalary = (Decimal?)sdr[2];
                poco.CurrentRate = (Decimal?)sdr[3];
                poco.Currency = sdr.GetString(4);
                poco.Country = sdr.GetString(5);
                poco.Province = sdr.GetString(6);
                poco.Street = sdr.GetString(7);
                poco.City = sdr.GetString(8);
                poco.PostalCode = sdr.GetString(9);
                poco.TimeStamp = (byte[])sdr[10];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (var item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Profiles]
                WHERE [Id]=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                try
                {
                    conn.Open();
                    int rowaffected = cmd.ExecuteNonQuery();
                    Console.WriteLine(rowaffected+"Row Affected");
                    conn.Close();
                }catch(Exception e)
                {
                    Console.WriteLine("The Error is :" + e.Message);
                }
            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantProfilePoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Profiles]
                  SET 
                  [Current_Salary]=@Current_Salary,
                  [Current_Rate]= @Current_Rate,
                  [Currency]=@Currency,
                  [Country_Code]=@Country_Code,
                  [State_Province_Code]=@State_Province_Code,
                  [street_Address]=@street_Address,
                  [City_Town]= @City_Town,
                  [Zip_Postal_Code]=@Zip_Postal_Code
                    Where [Id]=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                cmd.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                cmd.Parameters.AddWithValue("@Currency", item.Currency);
                cmd.Parameters.AddWithValue("@Country_Code", item.Country);
                cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                cmd.Parameters.AddWithValue("@street_Address", item.Street);
                cmd.Parameters.AddWithValue("@City_Town", item.City);
                cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
                try
                {
                conn.Open();
                int rowaffected=cmd.ExecuteNonQuery();
                Console.WriteLine(rowaffected + "Row Affected");
                conn.Close();
                }catch(Exception e)
                {
                Console.WriteLine("The Error is :" + e.Message);
                }
            }
        }
    }
}

        
