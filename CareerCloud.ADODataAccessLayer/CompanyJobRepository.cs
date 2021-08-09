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
    public class CompanyJobRepository : AdoConnectivity, IDataRepository<CompanyJobPoco>
    {
        public void Add(params CompanyJobPoco[] items)
        {
           using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (CompanyJobPoco item in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Jobs]
                ([Id],
                [Company],
                [Profile_Created],
                [Is_Inactive],
                [IS_Company_Hidden])
                VALUES         
                (@Id,
                @Company,
                @Profile_Created,
                @Inactive,
                @Is_Company_Hidden)";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Company", item.Company);
                cmd.Parameters.AddWithValue("@Profile_Created", item.ProfileCreated);
                cmd.Parameters.AddWithValue("@Inactive", item.IsInactive);
                cmd.Parameters.AddWithValue("@Is_Company_Hidden", item.IsCompanyHidden);
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

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM Company_Jobs";
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            int counter = 0;
            CompanyJobPoco[] pocos = new CompanyJobPoco[1024];
            while (sdr.Read())
            {
                CompanyJobPoco poco = new CompanyJobPoco();
                poco.Id = sdr.GetGuid(0);
                poco.Company = sdr.GetGuid(1);
                poco.ProfileCreated = sdr.GetDateTime(2);
                poco.IsInactive = sdr.GetBoolean(3);
                poco.IsCompanyHidden = sdr.GetBoolean(4);
                poco.TimeStamp =sdr.IsDBNull(5)?null:(byte[])sdr[5];
                pocos[counter] = poco;
                counter++;
            }
            conn.Close();
            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable< CompanyJobPoco> poco = GetAll().AsQueryable();
            return poco.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            foreach (CompanyJobPoco item in items)
            {
                cmd.Connection = conn;
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Jobs]
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

        public void Update(params CompanyJobPoco[] items)
        {
            using SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            foreach (var item in items)
            {
                cmd.CommandText = @"UPDATE  [dbo].[Company_Jobs]
                SET
                [Company]=@Company,
                [Profile_Created]=@Profile_Created,
                [Is_Inactive]=@Is_Inactive,
                [Is_Company_Hidden]=@Is_Company_Hidden        
                WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Company", item.Company);
                cmd.Parameters.AddWithValue("@Profile_Created", item.ProfileCreated);
                cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                cmd.Parameters.AddWithValue("@Is_Company_Hidden", item.IsCompanyHidden);
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
