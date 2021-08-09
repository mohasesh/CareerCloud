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
using static CareerCloud.gRPC.Protos.CompanyJobService;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobService:CompanyJobServiceBase
    {
        public override Task<CompanyJob> GetCompanyJob(IdRequest5 request, ServerCallContext context)
        {
            var logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
            CompanyJobPoco Poco = logic.Get(Guid.Parse(request.Id));
            if (Poco == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new Task<CompanyJob>(
                 () => { return TranslateFromPoco(Poco); });
        }
        public override Task<Empty> CreateCompanyJob(CompanyJobs request, ServerCallContext context)
        {
            var logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
            List<CompanyJobPoco> pocos = new List<CompanyJobPoco>();
            foreach (CompanyJob proto in request.ComJob)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteCompanyJob(CompanyJobs request, ServerCallContext context)
        {
            var logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
            List<CompanyJobPoco> pocos = new List<CompanyJobPoco>();
            foreach (CompanyJob proto in request.ComJob)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> UpdateCompanyJob(CompanyJobs request, ServerCallContext context)
        {
            var logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
            List<CompanyJobPoco> pocos = new List<CompanyJobPoco>();
            foreach (CompanyJob proto in request.ComJob)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        private CompanyJob TranslateFromPoco(CompanyJobPoco Poco)
        {
            return new CompanyJob()
            {
                Id = Poco.Id.ToString(),
                Company = Poco.Company.ToString(),
                ProfileCreated= Timestamp.FromDateTime(Poco.ProfileCreated),
                IsInactive=Poco.IsInactive,
                IsCompanyHidden=Poco.IsCompanyHidden

            };
        }
        private CompanyJobPoco TranslateFromProto(CompanyJob proto)
        {
            return new CompanyJobPoco()
            {
             Id=Guid.Parse(proto.Id),
             Company= Guid.Parse(proto.Company),
             ProfileCreated=proto.ProfileCreated.ToDateTime(),
             IsInactive=proto.IsInactive,
             IsCompanyHidden=proto.IsCompanyHidden

            };
        }
    }
}
