using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobEducationRepository : AdoConnectivity, IDataRepository<CompanyJobEducationPoco>
    {
        public void Add(params CompanyJobEducationPoco[] items)
        {
          using  SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (CompanyJobEducationPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Job_Educations]
                ([Id],
                [Job],
                [Major],
                [Importance])
                VALUES         
                (@Id,
                @Job,
                @Major,
                @Importance)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Job", item.Job);
                cmd.Parameters.AddWithValue("@Major", item.Major);
                cmd.Parameters.AddWithValue("@Importance", item.Importance);
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

        public IList<CompanyJobEducationPoco> GetAll(params System.Linq.Expressions.Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM Company_Job_Educations";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[1024];
            while(sdr.Read())
            {
            CompanyJobEducationPoco poco = new CompanyJobEducationPoco();
                poco.Id = sdr.GetGuid(0);
                poco.Job = sdr.GetGuid(1);
                poco.Major = sdr.GetString(2);
                poco.Importance = sdr.GetInt16(3);
                poco.TimeStamp = (byte[])sdr[4];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyJobEducationPoco> GetList(System.Linq.Expressions.Expression<Func<CompanyJobEducationPoco, bool>> where, params System.Linq.Expressions.Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobEducationPoco GetSingle(System.Linq.Expressions.Expression<Func<CompanyJobEducationPoco, bool>> where, params System.Linq.Expressions.Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> poco = GetAll().AsQueryable();
            return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobEducationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (CompanyJobEducationPoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Job_Educations]
                WHERE [Id]=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
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

        public void Update(params CompanyJobEducationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (CompanyJobEducationPoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Company_Job_Educations]
                SET
                [Job]=@Job,
                [Major]=@Major,
                [Importance]=@Importance
                WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Job", item.Job);
                cmd.Parameters.AddWithValue("@Major", item.Major);
                cmd.Parameters.AddWithValue("@Importance", item.Importance);
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
