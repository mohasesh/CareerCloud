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
using static CareerCloud.gRPC.Protos.SystemLanguageCodeService;

namespace CareerCloud.gRPC.Services
{
    public class SystemLanguageCodeService:SystemLanguageCodeServiceBase
    {
        public override Task<SystemLanguageCode> GetSystemLanguageCode(Idrequest9 request, ServerCallContext context)
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>());
            SystemLanguageCodePoco Poco = logic.Get(request.Id);
            if (Poco == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new Task<SystemLanguageCode>(
                 () => { return TranslateFromPoco(Poco); });
        }
        public override Task<Empty> CreateSystemLanguageCode(SystemLanguageCodes request, ServerCallContext context)
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>());
            List<SystemLanguageCodePoco> pocos = new List<SystemLanguageCodePoco>();
            foreach (SystemLanguageCode proto in request.SysLCode)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Add(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteSystemLanguageCode(SystemLanguageCodes request, ServerCallContext context)
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>());
            List<SystemLanguageCodePoco> pocos = new List<SystemLanguageCodePoco>();
            foreach (SystemLanguageCode proto in request.SysLCode)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Delete(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> UpdateSystemLanguageCode(SystemLanguageCodes request, ServerCallContext context)
        {
            var logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>());
            List<SystemLanguageCodePoco> pocos = new List<SystemLanguageCodePoco>();
            foreach (SystemLanguageCode proto in request.SysLCode)
            {
                pocos.Add(TranslateFromProto(proto));
            }
            logic.Update(pocos.ToArray());
            return Task.FromResult(new Empty());
        }
        private SystemLanguageCode TranslateFromPoco(SystemLanguageCodePoco Poco)
        {
            return new SystemLanguageCode()
            {
               LanguageId=Poco.LanguageID,
               Name=Poco.Name,
               NativeName=Poco.NativeName
            };
        }
        private SystemLanguageCodePoco TranslateFromProto(SystemLanguageCode Proto)
        {
            return new SystemLanguageCodePoco()
            {
                LanguageID = Proto.LanguageId,
                Name = Proto.Name,
                NativeName = Proto.NativeName
            };
        }
    }
}
