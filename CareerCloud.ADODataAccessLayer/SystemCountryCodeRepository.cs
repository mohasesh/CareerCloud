using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemCountryCodeRepository : AdoConnectivity, IDataRepository<SystemCountryCodePoco>
    {
        public void Add(params SystemCountryCodePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (SystemCountryCodePoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[System_Country_Codes]
                ([Code],
                [Name])
                values         
                (@Code,
                @Name)";
                cmd.Parameters.AddWithValue("@Code", item.Code);
                cmd.Parameters.AddWithValue("@Name", item.Name);
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

        public IList<SystemCountryCodePoco> GetAll(params System.Linq.Expressions.Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM [dbo].[System_Country_Codes]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            SystemCountryCodePoco[] pocos = new SystemCountryCodePoco[1000];
            while (sdr.Read())
            {
                SystemCountryCodePoco poco = new SystemCountryCodePoco();
                poco.Code = sdr.GetString(0);
                poco.Name = sdr.GetString(1);
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SystemCountryCodePoco> GetList(System.Linq.Expressions.Expression<Func<SystemCountryCodePoco, bool>> where, params System.Linq.Expressions.Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(System.Linq.Expressions.Expression<Func<SystemCountryCodePoco, bool>> where, params System.Linq.Expressions.Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemCountryCodePoco> poco = GetAll().AsQueryable();
            return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (SystemCountryCodePoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[System_Country_Codes]
                WHERE [Code]=@code";
                cmd.Parameters.AddWithValue("@code", item.Code);
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

        public void Update(params SystemCountryCodePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (SystemCountryCodePoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[System_Country_Codes]
                SET [Code]=@Code,
                [Name]=@Name WHERE code=@code";
                cmd.Parameters.AddWithValue("@Code", item.Code);
                cmd.Parameters.AddWithValue("@Name", item.Name);
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
