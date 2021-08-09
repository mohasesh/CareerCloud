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
    public class ApplicantWorkHistoryRepository : AdoConnectivity, IDataRepository<ApplicantWorkHistoryPoco>
    {
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
           using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantWorkHistoryPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Work_History]
                ([Id],
                [Applicant],
                [Company_Name],
                [Country_Code],
                [Location],
                [Job_Title],
                [Job_Description],
                [Start_Month],
                [Start_Year],
                [End_Month],
                [End_Year])
                values         
                (@Id,
                @Applicant,
                @Company_Name,
                @Country_Code,
                @Location,
                @Job_Title,
                @Job_Description,
                @Start_Month,
                @Start_Year,
                @End_Month,
                @End_Year)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                cmd.Parameters.AddWithValue("@Location", item.Location);
                cmd.Parameters.AddWithValue("@Job_Title", item.JobTitle);
                cmd.Parameters.AddWithValue("@Job_Description", item.JobDescription);
                cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                cmd.Parameters.AddWithValue("@End_Year", item.EndYear);
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

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM [dbo].[Applicant_Work_History]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[1000];
            while (sdr.Read())
            {
                ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco();
                poco.Id = sdr.GetGuid(0);
                poco.Applicant = sdr.GetGuid(1);
                poco.CompanyName = sdr.GetString(2);
                poco.CountryCode = sdr.GetString(3);
                poco.Location = sdr.GetString(4);
                poco.JobTitle = sdr.GetString(5);
                poco.JobDescription = sdr.GetString(6);
                poco.StartMonth = sdr.GetInt16(7);
                poco.StartYear = sdr.GetInt32(8);
                poco.EndMonth = sdr.GetInt16(9);
                poco.EndYear = sdr.GetInt32(10);
                poco.TimeStamp = (byte[])sdr[11];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> poco = GetAll().AsQueryable();
            return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (ApplicantWorkHistoryPoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Work_History]
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

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantWorkHistoryPoco item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Work_History]
                SET
                [Applicant]=@Applicant,
                [Company_Name]=@Company_Name,
                [Country_Code]= @Country_Code,
                [Location]=@Location,
                [Job_Title]=@Job_Title,
                [Job_Description]=@Job_Description,
                [Start_Month]=@Start_Month,
                [Start_Year]=@Start_Year,
                [End_Month]=@End_Month,
                [End_Year]=@End_Year  WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                cmd.Parameters.AddWithValue("@Location", item.Location);
                cmd.Parameters.AddWithValue("@Job_Title", item.JobTitle);
                cmd.Parameters.AddWithValue("@Job_Description", item.JobDescription);
                cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                cmd.Parameters.AddWithValue("@End_Year", item.EndYear);
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
