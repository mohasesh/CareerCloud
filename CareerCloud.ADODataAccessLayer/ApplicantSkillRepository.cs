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
    public class ApplicantSkillRepository : AdoConnectivity, IDataRepository<ApplicantSkillPoco>
    {
        public void Add(params ApplicantSkillPoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (ApplicantSkillPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Skills]
                ([Id],
                [Applicant],
                [Skill],
                [Skill_Level],
                [Start_Month],
                [Start_Year],
                [End_Month],
                [End_Year])
                VALUES         
                (@Id,
                @Applicant,
                @Skill,
                @Skill_Level,
                @Start_Month,
                @Start_Year,
                @End_Month,
                @End_Year)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Skill", item.Skill);
                cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
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

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM [dbo].[Applicant_Skills]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[1000];
            while (sdr.Read())
            {
                ApplicantSkillPoco poco = new ApplicantSkillPoco();
                poco.Id = sdr.GetGuid(0);
                poco.Applicant = sdr.GetGuid(1);
                poco.Skill = sdr.GetString(2);
                poco.SkillLevel = sdr.GetString(3);
                poco.StartMonth = sdr.GetByte(4);
                poco.StartYear = sdr.GetInt32(5);
                poco.EndMonth = sdr.GetByte(6) ;
                poco.EndYear = sdr.GetInt32(7);
                poco.TimeStamp = (byte[])sdr[8];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantSkillPoco> poco = GetAll().AsQueryable();
            return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (ApplicantSkillPoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Skills]
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

        public void Update(params ApplicantSkillPoco[] items)
        {
           using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (var item in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Skills]
                SET
                [Applicant]=@Applicant,
                [Skill]=@Skill,
                [Skill_Level]=@Skill_Level,
                [Start_Month]=@Start_Month,
                [Start_Year]=@Start_Year,
                [End_Month]=@End_Month,
                [End_Year]=@End_Year
                WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Skill", item.Skill);
                cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
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
    }
}
