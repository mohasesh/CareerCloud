using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic:BaseLogic<SystemCountryCodePoco>
    {
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> Pocos) : base(Pocos)
        {
        }
        public void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        public void Delete(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            base.Delete(pocos);
        }
        public SystemCountryCodePoco Get(string id)
        {
            
            return _repository.GetSingle(c => c.Code == id);
        }
        //public IList<SystemCountryCodePoco> GetAll()
        //{
        //    IList<SystemCountryCodePoco> lan = repo.GetAll();
        //    return lan.ToList();
        //}
        public void Verify(SystemCountryCodePoco[] pocos)
        {
    
        List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SystemCountryCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Code))
                {
                   exceptions.Add(new ValidationException(900, "The Role must have value which is not Empty"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                   exceptions.Add(new ValidationException(901, "The Name must have value which is not Empty"));
                }
                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}
