using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repo) : base(repo)
        {

        }
        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            string[] com = new string[] {".ca",".com",".biz"};
            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyWebsite))
                {
                    exceptions.Add(new ValidationException(600,"company website can not be empty or null"));
                }
                else if (!com.Any(t=> poco.CompanyWebsite.EndsWith(t)))
                {
                    exceptions.Add(new ValidationException(600,"Invalid company website name"));
                }
                if (string.IsNullOrEmpty(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, "PhoneNumber is not Empty"));
                }
                else
                {
                    string[] phonecontact = poco.ContactPhone.Split('-');
                    if (phonecontact.Length != 3)
                    {
                        exceptions.Add(new ValidationException(601, "PhoneNumber is not in the required format."));
                    }
                    else
                    {
                        if (phonecontact[0].Length != 3)
                        {
                            exceptions.Add(new ValidationException(601, "PhoneNumber for Company profile is not in the required format."));
                        }
                        else if (phonecontact[1].Length != 3)
                        {
                            exceptions.Add(new ValidationException(601, "PhoneNumber for Company profile is not in the required format."));
                        }
                        else if (phonecontact[2].Length != 4)
                        {
                            exceptions.Add(new ValidationException(601, "PhoneNumber for Company profile is not in the required format."));
                        }
                    }
                }
                if(exceptions.Count>0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}
