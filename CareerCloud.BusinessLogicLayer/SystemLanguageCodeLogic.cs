using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic : BaseLogic<SystemLanguageCodePoco>
    {
        //protected IDataRepository<SystemLanguageCodePoco> repo;
        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> Pocos) : base(Pocos)
        {
           
        }
        public void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public void Update(SystemLanguageCodePoco [] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        public void Delete(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            base.Delete(pocos);
        }
        public SystemLanguageCodePoco Get(string Id)
        {
            return _repository.GetSingle(c => c.LanguageID == Id);
        }
        //public IList<SystemLanguageCodePoco> GetAll()
        //{
        //    IList<SystemLanguageCodePoco> lan = repo.GetAll();
        //    return lan.ToList();
        //}
        protected  void Verify(SystemLanguageCodePoco [] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SystemLanguageCodePoco poco in pocos)
            {

                if (string.IsNullOrEmpty(poco.LanguageID))
                {
                    exceptions.Add(new ValidationException(1000, "The LanguageId must have value which is not Empty"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(1001, "The Name must have value which is not Empty"));
                }
                if (string.IsNullOrEmpty(poco.NativeName))
                {
                    exceptions.Add(new ValidationException(1002, "The Native Name must have value which is not Empty"));
                }
                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }

            }
        }
        }
}
    

