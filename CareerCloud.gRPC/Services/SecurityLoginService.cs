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
using static CareerCloud.gRPC.Protos.SecurityLoginService;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginService:SecurityLoginServiceBase
    {
        public override Task<SecurityLogin> GetSecurityLogin(IdRequest7 request, ServerCallContext context)
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>());
            SecurityLoginPoco Poco = logic.Get(Guid.Parse(request.Id));
            if (Poco == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new Task<SecurityLogin>(
                 () => { return TranslateFromPoco(Poco); });
        }
        public override Task<Empty> CreateSecurityLogin(SecurityLogins request, ServerCallContext context)
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>());
            List<SecurityLoginPoco> pocos = new List<SecurityLoginPoco>();
            foreach (SecurityLogin proto in request.SecLog)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteSecurityLogin(SecurityLogins request, ServerCallContext context)
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>());
            List<SecurityLoginPoco> pocos = new List<SecurityLoginPoco>();
            foreach (SecurityLogin proto in request.SecLog)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> UpdateSecurityLogin(SecurityLogins request, ServerCallContext context)
        {
            var logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>());
            List<SecurityLoginPoco> pocos = new List<SecurityLoginPoco>();
            foreach (SecurityLogin proto in request.SecLog)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        private SecurityLogin TranslateFromPoco(SecurityLoginPoco Poco)
        {
            return new SecurityLogin()
            {
             Id = Poco.Id.ToString(),
             Login = Poco.Login.ToString(),
             Password = Poco.Password.ToString(),
             Created = Timestamp.FromDateTime(Poco.Created),
             PasswordUpdate=Poco.PasswordUpdate==null?null: Timestamp.FromDateTime((DateTime)Poco.PasswordUpdate),
            AgreementAccepted = Poco.AgreementAccepted == null ? null : Timestamp.FromDateTime((DateTime)Poco.AgreementAccepted),
            IsInactive=Poco.IsInactive,
            IsLocked=Poco.IsLocked,
            EmailAddress=Poco.EmailAddress,
            PhoneNumber=Poco.PhoneNumber,
            FullName=Poco.FullName,
            ForceChangePassword=Poco.ForceChangePassword,
            PrefferredLanguage=Poco.PrefferredLanguage
        };
        }
        private SecurityLoginPoco TranslateFromProto(SecurityLogin Proto)
        {
            return new SecurityLoginPoco()
            {
                Id = Guid.Parse(Proto.Id.ToString()),
                Login = Proto.Login.ToString(),
                Password = Proto.Password.ToString(),
                Created = Proto.Created.ToDateTime(),
                PasswordUpdate = Proto.PasswordUpdate.ToDateTime(),
                AgreementAccepted = Proto.AgreementAccepted.ToDateTime(),
                IsInactive = Proto.IsInactive,
                IsLocked = Proto.IsLocked,
                EmailAddress = Proto.EmailAddress,
                PhoneNumber = Proto.PhoneNumber,
                FullName = Proto.FullName,
                ForceChangePassword = Proto.ForceChangePassword,
                PrefferredLanguage = Proto.PrefferredLanguage
            };
        }
    }
}
