// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/SecurityLoginsLog.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CareerCloud.gRPC.Protos {
  public static partial class SecurityLoginsLogService
  {
    static readonly string __ServiceName = "SecurityLoginsLogService";

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

    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.IdRequest8> __Marshaller_IdRequest8 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.IdRequest8.Parser));
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.SecurityLoginsLog> __Marshaller_SecurityLoginsLog = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.SecurityLoginsLog.Parser));
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.SecurityLoginsLogs> __Marshaller_SecurityLoginsLogs = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.SecurityLoginsLogs.Parser));
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.IdRequest8, global::CareerCloud.gRPC.Protos.SecurityLoginsLog> __Method_GetSecurityLoginsLog = new grpc::Method<global::CareerCloud.gRPC.Protos.IdRequest8, global::CareerCloud.gRPC.Protos.SecurityLoginsLog>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetSecurityLoginsLog",
        __Marshaller_IdRequest8,
        __Marshaller_SecurityLoginsLog);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogs, global::Google.Protobuf.WellKnownTypes.Empty> __Method_CreateSecurityLoginsLog = new grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogs, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateSecurityLoginsLog",
        __Marshaller_SecurityLoginsLogs,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogs, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteSecurityLogin = new grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogs, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteSecurityLogin",
        __Marshaller_SecurityLoginsLogs,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogs, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateSecurityLogin = new grpc::Method<global::CareerCloud.gRPC.Protos.SecurityLoginsLogs, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateSecurityLogin",
        __Marshaller_SecurityLoginsLogs,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CareerCloud.gRPC.Protos.SecurityLoginsLogReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of SecurityLoginsLogService</summary>
    [grpc::BindServiceMethod(typeof(SecurityLoginsLogService), "BindService")]
    public abstract partial class SecurityLoginsLogServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::CareerCloud.gRPC.Protos.SecurityLoginsLog> GetSecurityLoginsLog(global::CareerCloud.gRPC.Protos.IdRequest8 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> CreateSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteSecurityLogin(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateSecurityLogin(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for SecurityLoginsLogService</summary>
    public partial class SecurityLoginsLogServiceClient : grpc::ClientBase<SecurityLoginsLogServiceClient>
    {
      /// <summary>Creates a new client for SecurityLoginsLogService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public SecurityLoginsLogServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for SecurityLoginsLogService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public SecurityLoginsLogServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected SecurityLoginsLogServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected SecurityLoginsLogServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::CareerCloud.gRPC.Protos.SecurityLoginsLog GetSecurityLoginsLog(global::CareerCloud.gRPC.Protos.IdRequest8 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetSecurityLoginsLog(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::CareerCloud.gRPC.Protos.SecurityLoginsLog GetSecurityLoginsLog(global::CareerCloud.gRPC.Protos.IdRequest8 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetSecurityLoginsLog, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::CareerCloud.gRPC.Protos.SecurityLoginsLog> GetSecurityLoginsLogAsync(global::CareerCloud.gRPC.Protos.IdRequest8 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetSecurityLoginsLogAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::CareerCloud.gRPC.Protos.SecurityLoginsLog> GetSecurityLoginsLogAsync(global::CareerCloud.gRPC.Protos.IdRequest8 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetSecurityLoginsLog, null, options, request);
      }
      public virtual global::Google.Protobuf.WellKnownTypes.Empty CreateSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateSecurityLoginsLog(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Google.Protobuf.WellKnownTypes.Empty CreateSecurityLoginsLog(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateSecurityLoginsLog, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> CreateSecurityLoginsLogAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateSecurityLoginsLogAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> CreateSecurityLoginsLogAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateSecurityLoginsLog, null, options, request);
      }
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteSecurityLogin(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteSecurityLogin(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteSecurityLogin(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteSecurityLogin, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteSecurityLoginAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteSecurityLoginAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteSecurityLoginAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteSecurityLogin, null, options, request);
      }
      public virtual global::Google.Protobuf.WellKnownTypes.Empty UpdateSecurityLogin(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateSecurityLogin(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Google.Protobuf.WellKnownTypes.Empty UpdateSecurityLogin(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateSecurityLogin, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> UpdateSecurityLoginAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateSecurityLoginAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> UpdateSecurityLoginAsync(global::CareerCloud.gRPC.Protos.SecurityLoginsLogs request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateSecurityLogin, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override SecurityLoginsLogServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new SecurityLoginsLogServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(SecurityLoginsLogServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetSecurityLoginsLog, serviceImpl.GetSecurityLoginsLog)
          .AddMethod(__Method_CreateSecurityLoginsLog, serviceImpl.CreateSecurityLoginsLog)
          .AddMethod(__Method_DeleteSecurityLogin, serviceImpl.DeleteSecurityLogin)
          .AddMethod(__Method_UpdateSecurityLogin, serviceImpl.UpdateSecurityLogin).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SecurityLoginsLogServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetSecurityLoginsLog, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.IdRequest8, global::CareerCloud.gRPC.Protos.SecurityLoginsLog>(serviceImpl.GetSecurityLoginsLog));
      serviceBinder.AddMethod(__Method_CreateSecurityLoginsLog, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SecurityLoginsLogs, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.CreateSecurityLoginsLog));
      serviceBinder.AddMethod(__Method_DeleteSecurityLogin, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SecurityLoginsLogs, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteSecurityLogin));
      serviceBinder.AddMethod(__Method_UpdateSecurityLogin, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SecurityLoginsLogs, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateSecurityLogin));
    }

  }
}
#endregion
