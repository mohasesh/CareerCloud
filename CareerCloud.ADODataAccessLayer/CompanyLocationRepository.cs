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
    public class CompanyLocationRepository : AdoConnectivity, IDataRepository<CompanyLocationPoco>
    {
        public void Add(params CompanyLocationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (CompanyLocationPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Locations]
                ([Id],
                [Company],
                [Country_Code],
                [State_Province_Code],
                [Street_Address],
                [City_Town],
                [Zip_Postal_Code])
                values         
                (@Id,
                @Company,
                @Country_Code,
                @State_Province_Code,
                @Street_Address,
                @City_Town,
                @Zip_Postal_Code)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Company", item.Company);
                cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                cmd.Parameters.AddWithValue("@City_Town", item.City);
                cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
                try
                {
                    conn.Open();
                   int rowaffected= cmd.ExecuteNonQuery();
                    Console.WriteLine(rowaffected + "Row Affected");
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

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {

            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM Company_Locations";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            CompanyLocationPoco[] pocos = new CompanyLocationPoco[1000];
                while (sdr.Read())
                {
                    CompanyLocationPoco poco = new CompanyLocationPoco();
                    poco.Id = sdr.GetGuid(0);
                    poco.Company = sdr.GetGuid(1);
                    poco.CountryCode = sdr.GetString(2);
                    poco.Province = sdr.IsDBNull(3) ?null: sdr.GetString(3);
                    poco.Street = sdr.IsDBNull(4)?null:sdr.GetString(4);
                    poco.City = sdr.IsDBNull(5)?null:sdr.GetString(5);
                    poco.PostalCode =sdr.IsDBNull(6)?null:sdr.GetString(6);
                    poco.TimeStamp = (byte[])sdr[7];
                    pocos[counter] = poco;
                    counter++;
                }
                conn.Close();
                return pocos.Where(p => p != null).ToList();
            }

        public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyLocationPoco> poco = GetAll().AsQueryable();
            return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (CompanyLocationPoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Locations]
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

        public void Update(params CompanyLocationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (var item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Company_Locations]
                SET
                [Company]=@Company,
                [Country_Code]=@Country_Code,
                [State_Province_Code]=@State_Province_Code,
                [Street_Address]=@Street_Address,
                [City_Town]=@City_Town,
                [Zip_Postal_Code]=@Zip_Postal_Code      
                WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Company", item.Company);
                cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                cmd.Parameters.AddWithValue("@City_Town", item.City);
                cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
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
