using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CareerCloud.gRPC.Protos.CompanyDescriptionService;

namespace CareerCloud.gRPC.Services
{
    public class CompanyDescriptionService:CompanyDescriptionServiceBase
    {
        public override Task<CompanyDescription> GetCompanyDescription(IdRequest3 request, ServerCallContext context)
        {
            var logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>());
            CompanyDescriptionPoco Poco = logic.Get(Guid.Parse(request.Id));
            if (Poco == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new Task<CompanyDescription>(
                 () => { return TranslateFromPoco(Poco); });
        }
        public override Task<Empty> CreateCompanyDescription(CompanyDescriptions request, ServerCallContext context)
        {
            var logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>());
            List<CompanyDescriptionPoco> pocos = new List<CompanyDescriptionPoco>();
            foreach (CompanyDescription proto in request.ComDes)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteCompanyDescription(CompanyDescriptions request, ServerCallContext context)
        {
            var logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>());
            List<CompanyDescriptionPoco> pocos = new List<CompanyDescriptionPoco>();
            foreach (CompanyDescription proto in request.ComDes)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> UpdateCompanyDescription(CompanyDescriptions request, ServerCallContext context)
        {
            var logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>());
            List<CompanyDescriptionPoco> pocos = new List<CompanyDescriptionPoco>();
            foreach (CompanyDescription proto in request.ComDes)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        private CompanyDescription TranslateFromPoco(CompanyDescriptionPoco poco)
        {
            return new CompanyDescription()
            {
                Id = poco.Id.ToString(),
                Company = poco.Company.ToString(),
                LanguageId = poco.LanguageId,
                CompanyName=poco.CompanyName,
                CompanyDescription_= poco.CompanyDescription.ToString()

            };
        }
        private CompanyDescriptionPoco TranslateFromProto(CompanyDescription proto)
        {
            return new CompanyDescriptionPoco()
            {
                Id=Guid.Parse(proto.Id.ToString()),
                Company=Guid.Parse(proto.Company.ToString()),
                LanguageId=proto.LanguageId,
                CompanyName=proto.CompanyName,
                CompanyDescription=proto.CompanyDescription_
            };
        }
    }
}
