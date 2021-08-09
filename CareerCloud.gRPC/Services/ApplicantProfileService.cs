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
using static CareerCloud.gRPC.Protos.ApplicantProfileService;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantProfileService:ApplicantProfileServiceBase
    {
        public override Task<ApplicantProfile> GetApplicantProfile(IdRequest6 request, ServerCallContext context)
        {
            var logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
            ApplicantProfilePoco Poco = logic.Get(Guid.Parse(request.Id));
            if (Poco == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new Task<ApplicantProfile>(
                 () => { return TranslateFromPoco(Poco); });
        }
        public override Task<Empty> CreateApplicantProfile(ApplicantProfiles request, ServerCallContext context)
        {
            var logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();
            foreach (ApplicantProfile proto in request.AppPro)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteApplicantProfile(ApplicantProfiles request, ServerCallContext context)
        {
            var logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();
            foreach (ApplicantProfile proto in request.AppPro)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> UpdateApplicantProfile(ApplicantProfiles request, ServerCallContext context)
        {
            var logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();
            foreach (ApplicantProfile proto in request.AppPro)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }

        private ApplicantProfile TranslateFromPoco(ApplicantProfilePoco Poco)
        {
            return new ApplicantProfile()
            {
                Id = Poco.Id.ToString(),
                Login = Poco.Login.ToString(),
                CurrentSalary = long.Parse(Poco.CurrentSalary.ToString()),
                CurrentRate = long.Parse(Poco.CurrentRate.ToString()),
                Currency = Poco.Currency,
                Country = Poco.Country,
                Province = Poco.Province,
                City = Poco.City,
                Street = Poco.Street,
                PostalCode = Poco.PostalCode
            };
        }
        private ApplicantProfilePoco TranslateFromProto(ApplicantProfile Proto)
            {
                return new ApplicantProfilePoco()
                {
                    Id = Guid.Parse(Proto.Id.ToString()),
                    Login =Guid.Parse( Proto.Login.ToString()),
                    CurrentSalary = long.Parse(Proto.CurrentSalary.ToString()),
                    CurrentRate = long.Parse(Proto.CurrentRate.ToString()),
                    Currency = Proto.Currency,
                    Country = Proto.Country,
                    Province = Proto.Province,
                    City = Proto.City,
                    Street = Proto.Street,
                    PostalCode = Proto.PostalCode
                };
            }
        }
    }

