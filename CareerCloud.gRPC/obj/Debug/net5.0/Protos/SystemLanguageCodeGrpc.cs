// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/SystemLanguageCode.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CareerCloud.gRPC.Protos {
  public static partial class SystemLanguageCodeService
  {
    static readonly string __ServiceName = "CareerCloud.gRPC.SystemLanguageCodeService";

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

    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.Idrequest9> __Marshaller_CareerCloud_gRPC_Idrequest9 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.Idrequest9.Parser));
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.SystemLanguageCode> __Marshaller_CareerCloud_gRPC_SystemLanguageCode = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.SystemLanguageCode.Parser));
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.Protos.SystemLanguageCodes> __Marshaller_CareerCloud_gRPC_SystemLanguageCodes = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.Protos.SystemLanguageCodes.Parser));
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.Idrequest9, global::CareerCloud.gRPC.Protos.SystemLanguageCode> __Method_GetSystemLanguageCode = new grpc::Method<global::CareerCloud.gRPC.Protos.Idrequest9, global::CareerCloud.gRPC.Protos.SystemLanguageCode>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetSystemLanguageCode",
        __Marshaller_CareerCloud_gRPC_Idrequest9,
        __Marshaller_CareerCloud_gRPC_SystemLanguageCode);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty> __Method_CreateSystemLanguageCode = new grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateSystemLanguageCode",
        __Marshaller_CareerCloud_gRPC_SystemLanguageCodes,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteSystemLanguageCode = new grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteSystemLanguageCode",
        __Marshaller_CareerCloud_gRPC_SystemLanguageCodes,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateSystemLanguageCode = new grpc::Method<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateSystemLanguageCode",
        __Marshaller_CareerCloud_gRPC_SystemLanguageCodes,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CareerCloud.gRPC.Protos.SystemLanguageCodeReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of SystemLanguageCodeService</summary>
    [grpc::BindServiceMethod(typeof(SystemLanguageCodeService), "BindService")]
    public abstract partial class SystemLanguageCodeServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::CareerCloud.gRPC.Protos.SystemLanguageCode> GetSystemLanguageCode(global::CareerCloud.gRPC.Protos.Idrequest9 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> CreateSystemLanguageCode(global::CareerCloud.gRPC.Protos.SystemLanguageCodes request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteSystemLanguageCode(global::CareerCloud.gRPC.Protos.SystemLanguageCodes request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateSystemLanguageCode(global::CareerCloud.gRPC.Protos.SystemLanguageCodes request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(SystemLanguageCodeServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetSystemLanguageCode, serviceImpl.GetSystemLanguageCode)
          .AddMethod(__Method_CreateSystemLanguageCode, serviceImpl.CreateSystemLanguageCode)
          .AddMethod(__Method_DeleteSystemLanguageCode, serviceImpl.DeleteSystemLanguageCode)
          .AddMethod(__Method_UpdateSystemLanguageCode, serviceImpl.UpdateSystemLanguageCode).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SystemLanguageCodeServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetSystemLanguageCode, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.Idrequest9, global::CareerCloud.gRPC.Protos.SystemLanguageCode>(serviceImpl.GetSystemLanguageCode));
      serviceBinder.AddMethod(__Method_CreateSystemLanguageCode, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.CreateSystemLanguageCode));
      serviceBinder.AddMethod(__Method_DeleteSystemLanguageCode, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteSystemLanguageCode));
      serviceBinder.AddMethod(__Method_UpdateSystemLanguageCode, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.Protos.SystemLanguageCodes, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateSystemLanguageCode));
    }

  }
}
#endregion
