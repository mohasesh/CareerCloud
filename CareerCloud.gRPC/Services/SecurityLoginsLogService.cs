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
using static CareerCloud.gRPC.Protos.SecurityLoginsLogService;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginsLogService:SecurityLoginsLogServiceBase
    {
        public override Task<SecurityLoginsLog> GetSecurityLoginsLog(IdRequest8 request, ServerCallContext context)
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>());
            SecurityLoginsLogPoco Poco = logic.Get(Guid.Parse(request.Id));
            if (Poco == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new Task<SecurityLoginsLog>(
                 () => { return TranslateFromPoco(Poco); });
        }
        public override Task<Empty> CreateSecurityLoginsLog(SecurityLoginsLogs request, ServerCallContext context)
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>());
            List<SecurityLoginsLogPoco> pocos = new List<SecurityLoginsLogPoco>();
            foreach (SecurityLoginsLog proto in request.SecLog)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteSecurityLogin(SecurityLoginsLogs request, ServerCallContext context)
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>());
            List<SecurityLoginsLogPoco> pocos = new List<SecurityLoginsLogPoco>();
            foreach (SecurityLoginsLog proto in request.SecLog)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> UpdateSecurityLogin(SecurityLoginsLogs request, ServerCallContext context)
        {
            var logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>());
            List<SecurityLoginsLogPoco> pocos = new List<SecurityLoginsLogPoco>();
            foreach (SecurityLoginsLog proto in request.SecLog)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        private SecurityLoginsLog TranslateFromPoco(SecurityLoginsLogPoco Poco)
        {
            return new SecurityLoginsLog()
            {
                Id = Poco.Id.ToString(),
                Login = Poco.Login.ToString(),
               SourceIP=Poco.SourceIP,
               LogonDate=Timestamp.FromDateTime(Poco.LogonDate),
               IsSuccessful=Poco.IsSuccesful
            };
        }
        private SecurityLoginsLogPoco TranslateFromProto(SecurityLoginsLog Proto)
        {
            return new SecurityLoginsLogPoco()
            {
                Id = Guid.Parse(Proto.Id.ToString()),
                Login = Guid.Parse(Proto.Login.ToString()),
                SourceIP=Proto.SourceIP,
                LogonDate=Proto.LogonDate.ToDateTime(),
                IsSuccesful=Proto.IsSuccessful
            };
        }
    }
}
