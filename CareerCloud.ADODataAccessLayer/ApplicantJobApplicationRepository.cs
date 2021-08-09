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
    public class ApplicantJobApplicationRepository : AdoConnectivity, IDataRepository<ApplicantJobApplicationPoco>
    {
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantJobApplicationPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Job_Applications]
                ([Id],
                [Applicant],
                [Job],
                [Application_Date])
                values         
                (@Id,
                @Applicant,
                @Job,
                @Application_Date)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Job", item.Job);
                cmd.Parameters.AddWithValue("@Application_Date", item.ApplicationDate);
                try
                {
                    conn.Open();
                    int rowaffected = cmd.ExecuteNonQuery();
                    Console.WriteLine(rowaffected + " Row Affected");
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

        public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM [dbo].[Applicant_Job_Applications]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[1000];
            while (sdr.Read())
            {
                ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco();
                poco.Id = sdr.GetGuid(0);
                poco.Applicant = sdr.GetGuid(1);
                poco.Job = sdr.GetGuid(2);
                poco.ApplicationDate = sdr.GetDateTime(3);
                poco.TimeStamp = (byte[])sdr[4];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }
    
        public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantJobApplicationPoco> pocos = GetAll().AsQueryable();
           return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (var item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Job_Applications]
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

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantJobApplicationPoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Job_Applications]
                SET 
                [Applicant]=@Applicant,
                [Job]= @Job,
                [Application_Date]=@Application_Date
                where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Job", item.Job);
                cmd.Parameters.AddWithValue("@Application_Date", item.ApplicationDate);
                try
                {
                    conn.Open();
                    int rowaffected = cmd.ExecuteNonQuery();
                    Console.WriteLine(rowaffected + " Row Affected");
                    conn.Close();
                }catch(Exception e)
                {
                    Console.WriteLine("The Error :" + e.Message);
                }
            }
        }

        IList<ApplicantJobApplicationPoco> IDataRepository<ApplicantJobApplicationPoco>.GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }
    }
}
