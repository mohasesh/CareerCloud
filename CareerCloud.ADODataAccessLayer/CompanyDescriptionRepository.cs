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
    public class CompanyDescriptionRepository : AdoConnectivity, IDataRepository<CompanyDescriptionPoco>
    {
        public void Add(params CompanyDescriptionPoco[] items)
        {
           using  SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (CompanyDescriptionPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Descriptions]
                ([Id],
                [Company],
                [LanguageID],
                [Company_Name],
                [Company_Description])
                VALUES         
                (@Id,
                @Company,
                @LanguageID,
                @Company_Name,
                @Company_Description)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Company", item.Company);
                cmd.Parameters.AddWithValue("@LanguageID", item.LanguageId);
                cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                cmd.Parameters.AddWithValue("@Company_Description", item.CompanyDescription);
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

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM [dbo].[Company_Descriptions]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            CompanyDescriptionPoco[] pocos = new CompanyDescriptionPoco[1000];
            while (sdr.Read())
            {
                CompanyDescriptionPoco poco = new CompanyDescriptionPoco();
                poco.Id = sdr.GetGuid(0);
                poco.Company = sdr.GetGuid(1);
                poco.LanguageId = sdr.GetString(2);
                poco.CompanyName = sdr.GetString(3);
                poco.CompanyDescription = sdr.GetString(4);
                poco.TimeStamp = (byte[])sdr[5];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyDescriptionPoco> poco = GetAll().AsQueryable();
           return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (CompanyDescriptionPoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Descriptions]
                WHERE [Id]=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                try
                {
                    conn.Open();
                    int rowaffected = cmd.ExecuteNonQuery();
                    Console.WriteLine(rowaffected + "Row Affected");
                    conn.Close();
                }catch(Exception e)
                {
                    Console.WriteLine("The Error is :" + e.Message);
                }

            }
    }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (CompanyDescriptionPoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Company_Descriptions]
                SET
                [Company]=@Company,
                [LanguageID]=@LanguageID,
                [Company_Name]=@Company_Name,
                [Company_Description]=@Company_Description
                WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Company", item.Company);
                cmd.Parameters.AddWithValue("@LanguageID", item.LanguageId);
                cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                cmd.Parameters.AddWithValue("@Company_Description", item.CompanyDescription);
                try
                {
                    conn.Open();
                    int rowaffected=cmd.ExecuteNonQuery();
                    Console.WriteLine(rowaffected+"Row Affected");
                    conn.Close();
                }catch(Exception e)
                {
                    Console.WriteLine("The Error is :" + e.Message);
                }
            }
        }
    }
}
