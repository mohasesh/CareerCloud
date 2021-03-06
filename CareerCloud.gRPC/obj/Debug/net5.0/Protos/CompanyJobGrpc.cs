// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/CompanyJob.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CareerCloud.gRPC.Protos {
  public static partial class CompanyJobService
  {
    static readonly string __ServiceName = "CareerCloud.gRPC.CompanyJobService";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.IdRequest5> __Marshaller_CareerCloud_gRPC_IdRequest5 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.IdRequest5.Parser));
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.CompanyJob> __Marshaller_CareerCloud_gRPC_CompanyJob = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.CompanyJob.Parser));
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.CompanyJobs> __Marshaller_CareerCloud_gRPC_CompanyJobs = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.CompanyJobs.Parser));
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.IdRequest5, global::CareerCloud.gRPC.Protos.CompanyJob> __Method_GetCompanyJob = new grpc::Method<global::CareerCloud.gRPC.Protos.IdRequest5, global::CareerCloud.gRPC.Protos.CompanyJob>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCompanyJob",
        __Marshaller_CareerCloud_gRPC_IdRequest5,
        __Marshaller_CareerCloud_gRPC_CompanyJob);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobs, global::Google.Protobuf.WellKnownTypes.Empty> __Method_CreateCompanyJob = new grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobs, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateCompanyJob",
        __Marshaller_CareerCloud_gRPC_CompanyJobs,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobs, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteCompanyJob = new grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobs, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteCompanyJob",
        __Marshaller_CareerCloud_gRPC_CompanyJobs,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobs, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateCompanyJob = new grpc::Method<global::CareerCloud.gRPC.Protos.CompanyJobs, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateCompanyJob",
        __Marshaller_CareerCloud_gRPC_CompanyJobs,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CareerCloud.gRPC.Protos.CompanyJobReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of CompanyJobService</summary>
    [grpc::BindServiceMethod(typeof(CompanyJobService), "BindService")]
    public abstract partial class CompanyJobServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::CareerCloud.gRPC.Protos.CompanyJob> GetCompanyJob(global::CareerCloud.gRPC.Protos.IdRequest5 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> CreateCompanyJob(global::CareerCloud.gRPC.Protos.CompanyJobs request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteCompanyJob(global::CareerCloud.gRPC.Protos.CompanyJobs request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateCompanyJob(global::CareerCloud.gRPC.Protos.CompanyJobs request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(CompanyJobServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetCompanyJob, serviceImpl.GetCompanyJob)
          .AddMethod(__Method_CreateCompanyJob, serviceImpl.CreateCompanyJob)
          .AddMethod(__Method_DeleteCompanyJob, serviceImpl.DeleteCompanyJob)
          .AddMethod(__Method_UpdateCompanyJob, serviceImpl.UpdateCompanyJob).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CompanyJobServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetCompanyJob, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.IdRequest5, global::CareerCloud.gRPC.Protos.CompanyJob>(serviceImpl.GetCompanyJob));
      serviceBinder.AddMethod(__Method_CreateCompanyJob, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.CompanyJobs, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.CreateCompanyJob));
      serviceBinder.AddMethod(__Method_DeleteCompanyJob, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.CompanyJobs, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteCompanyJob));
      serviceBinder.AddMethod(__Method_UpdateCompanyJob, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.CompanyJobs, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateCompanyJob));
    }

  }
}
#endregion
