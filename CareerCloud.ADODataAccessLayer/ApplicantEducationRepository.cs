using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using DocumentFormat.OpenXml.Vml;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : AdoConnectivity, IDataRepository<ApplicantEducationPoco>
    {

        public void Add(params ApplicantEducationPoco[] items)
        {

            using SqlConnection conn = new SqlConnection(_connectionstring);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    
            foreach (ApplicantEducationPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Educations]
                ([Id],
                [Applicant],
                [Major],
                [Certificate_Diploma],
                [Start_date],
                [Completion_Date],
                [Completion_Percent])  VALUES         
                (@Id,
                @Applicant,
                @Major,
                @Certificate_Diploma,
                @Start_date,
                @Completion_Date,
                @Completion_Percent)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Major", item.Major);
                cmd.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                cmd.Parameters.AddWithValue("@Start_date", item.StartDate);
                cmd.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                cmd.Parameters.AddWithValue("@Completion_Percent", item.CompletionPercent);
                 try { 
                    conn.Open();
                    cmd.ExecuteNonQuery();
                     }catch(Exception e)
                     {
                     Console.WriteLine("The error :" + e.Message);
                     }
            }
                conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM [dbo].[Applicant_Educations]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1000];
            while(sdr.Read())
            {
                ApplicantEducationPoco poco = new ApplicantEducationPoco();
                poco.Id = sdr.GetGuid(0);
                poco.Applicant = sdr.GetGuid(1);
                poco.Major = sdr.GetString(2);
                poco.CertificateDiploma = sdr.GetString(3);
                poco.StartDate = sdr.IsDBNull(4) ? null : (DateTime?)sdr[4];
                poco.CompletionDate = (DateTime?)sdr[5];
                poco.CompletionPercent = (byte?)sdr[6];
                poco.TimeStamp = (byte[])sdr[7];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p=>p!=null).ToList();
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> poco = GetAll().AsQueryable();
            return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (var item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Educations]
                WHERE [Id]=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }catch(Exception e)
                {
                   Console.WriteLine("The Error is :" + e.Message);
                }

            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantEducationPoco item in items)
            {
                cmd.CommandText = @"UPDATE[dbo].[Applicant_Educations]
                   SET[Applicant] = @Applicant
                  ,[Major] = @Major
                  ,[Certificate_Diploma] = @CertificateDiploma
                  ,[Start_Date] = @StartDate
                  ,[Completion_Date] = @CompletionDate
                  ,[Completion_Percent] =@CompletionPercent
                   WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Major", item.Major);
                cmd.Parameters.AddWithValue("@CertificateDiploma", item.CertificateDiploma);
                cmd.Parameters.AddWithValue("@StartDate", item.StartDate);
                cmd.Parameters.AddWithValue("@CompletionDate", item.CompletionDate);
                cmd.Parameters.AddWithValue("@CompletionPercent", item.CompletionPercent);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }catch (Exception e)
                {
                    Console.WriteLine("The Error :" + e.Message);
                }
            }
        }
    }
}
