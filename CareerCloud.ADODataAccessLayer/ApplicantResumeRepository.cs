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
    public class ApplicantResumeRepository : AdoConnectivity, IDataRepository<ApplicantResumePoco>
    {
        public void Add(params ApplicantResumePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantResumePoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Resumes]
                ([Id],
                [Applicant],
                [Resume],
                [Last_Updated])
                VALUES         
                (@Id,
                @Applicant,
                @Resume,
                @Last_Updated)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Resume", item.Resume);
                cmd.Parameters.AddWithValue("@Last_Updated", item.LastUpdated);
                try
                {
                    conn.Open();
                   int rowaffected= cmd.ExecuteNonQuery();
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

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM [dbo].[Applicant_Resumes]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            ApplicantResumePoco[] pocos = new ApplicantResumePoco[1000];
            while (sdr.Read())
            {
                ApplicantResumePoco poco = new ApplicantResumePoco();
                poco.Id = sdr.GetGuid(0);
                poco.Applicant = sdr.GetGuid(1);
                poco.Resume = sdr.GetString(2);
                poco.LastUpdated = sdr.IsDBNull(3) ? (DateTime?)null : sdr.GetDateTime(3);
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> poco = GetAll().AsQueryable();
            return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (ApplicantResumePoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Resumes]
                WHERE [Id]=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                try
                {
                    conn.Open();
                  int rowaffected= cmd.ExecuteNonQuery();
                    Console.WriteLine(rowaffected + "Row Affected");
                    conn.Close();
                }catch(Exception e)
                {
                Console.WriteLine("The Error is :"+e.Message);
                }

            }
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantResumePoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Resumes]
                SET
                [Applicant]=@Applicant,
                [Resume]=@Resume,
                [Last_Updated]=@Last_Updated  WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Resume", item.Resume);
                cmd.Parameters.AddWithValue("@Last_Updated", item.LastUpdated);
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
