using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobSkillRepository : AdoConnectivity, IDataRepository<CompanyJobSkillPoco>
    {
        public void Add(params CompanyJobSkillPoco[] items)
        {
          using  SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (CompanyJobSkillPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Job_Skills]
                ([Id],
                [Job],
                [Skill],
                [Skill_Level],
                [Importance])
                VALUES         
                (@Id,
                @Job,
                @Skill,
                @Skill_Level,
                @Importance)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Job", item.Job);
                cmd.Parameters.AddWithValue("@Skill", item.Skill);
                cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
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

        public IList<CompanyJobSkillPoco> GetAll(params System.Linq.Expressions.Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM [dbo].[Company_Job_Skills]";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[10000];
            while (sdr.Read())
            {
                CompanyJobSkillPoco poco = new CompanyJobSkillPoco();
                poco.Id = sdr.GetGuid(0);
                poco.Job = sdr.GetGuid(1);
                poco.Skill = sdr.GetString(2);
                poco.SkillLevel = sdr.GetString(3);

                poco.Importance = sdr.GetInt32(4);
                poco.TimeStamp = (byte[])sdr[5];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyJobSkillPoco> GetList(System.Linq.Expressions.Expression<Func<CompanyJobSkillPoco, bool>> where, params System.Linq.Expressions.Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobSkillPoco GetSingle(System.Linq.Expressions.Expression<Func<CompanyJobSkillPoco, bool>> where, params System.Linq.Expressions.Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobSkillPoco> poco = GetAll().AsQueryable();
           return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobSkillPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (CompanyJobSkillPoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Job_Skills]
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

        public void Update(params CompanyJobSkillPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (var item in items)
            {
            cmd.CommandText = @"UPDATE [dbo].[Company_Job_Skills]
            SET
            [Job]=@Job,
            [Skill]=@Skill,
            [Skill_Level]=@Skill_Level,
            [Importance]=@Importance        
            Where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", item.Id);
            cmd.Parameters.AddWithValue("@Job", item.Job);
            cmd.Parameters.AddWithValue("@Skill", item.Skill);
            cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
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
