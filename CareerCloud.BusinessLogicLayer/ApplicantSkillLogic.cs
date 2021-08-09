using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
   public class ApplicantSkillLogic:BaseLogic<ApplicantSkillPoco>
    {
        public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repo):base(repo)
        {
        }
        public override void Add(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(ApplicantSkillPoco[] pocos)
        {
            List<ValidationException> Exceptions = new List<ValidationException>();
            foreach(ApplicantSkillPoco poco in pocos)
            {
                if(poco.StartMonth>12)
                {
                    Exceptions.Add(new ValidationException(101, "Start Month must be earlier than or equal to 12"));
                }
                if (poco.EndMonth > 12)
                {
                    Exceptions.Add(new ValidationException(102, "End Month must be earlier than or equal to 12"));
                }
                if(poco.StartYear<1900)
                {
                    Exceptions.Add(new ValidationException(103, "Start Year must be later than 1900"));
                }
                if(poco.StartYear>poco.EndYear)
                {
                    Exceptions.Add(new ValidationException(104, "Start Year must be earlier than End Year"));
                }
                if (Exceptions.Count > 0)
                {
                    throw new AggregateException(Exceptions);
                }
            }
        }
    }
}
