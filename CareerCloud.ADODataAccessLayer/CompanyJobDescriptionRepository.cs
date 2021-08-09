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
    public class CompanyJobDescriptionRepository : AdoConnectivity, IDataRepository<CompanyJobDescriptionPoco>
    {
        public void Add(params CompanyJobDescriptionPoco[] items)
        {
          using  SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (CompanyJobDescriptionPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Jobs_Descriptions]
                ([Id],
                [Job],
                [Job_Name],
                [Job_Descriptions])
                values         
                (@Id,
                @Job,
                @Job_Name,
                @Job_Descriptions)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Job", item.Job);
                cmd.Parameters.AddWithValue("@Job_Name", item.JobName);
                cmd.Parameters.AddWithValue("@Job_Descriptions", item.JobDescriptions);
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

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring); 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM [dbo].[Company_Jobs_Descriptions]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            CompanyJobDescriptionPoco[] pocos = new CompanyJobDescriptionPoco[1024];
            int counter=0;
            while(sdr.Read())
            {
                CompanyJobDescriptionPoco poco = new CompanyJobDescriptionPoco();
                poco.Id = sdr.GetGuid(0);
                poco.Job = sdr.GetGuid(1);
                poco.JobName = sdr.GetString(2);
                poco.JobDescriptions = sdr.GetString(3);
                poco.TimeStamp = (byte[])sdr[4];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobDescriptionPoco> poco = GetAll().AsQueryable();
            return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (CompanyJobDescriptionPoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Jobs_Descriptions]
                WHERE [Id]=@Id";
                cmd.Parameters.AddWithValue("@Id",item.Id);
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

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (CompanyJobDescriptionPoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Company_Jobs_Descriptions]
                SET
                [Job]=@Job,
                [Job_Name]=@Job_Name,
                [Job_Descriptions]=@Job_Descriptions
                WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Job", item.Job);
                cmd.Parameters.AddWithValue("@Job_Name", item.JobName);
                cmd.Parameters.AddWithValue("@Job_Descriptions", item.JobDescriptions);
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
    }
}
