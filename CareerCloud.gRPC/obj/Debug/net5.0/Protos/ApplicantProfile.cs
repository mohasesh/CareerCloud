// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/ApplicantProfile.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CareerCloud.gRPC.Protos {

  /// <summary>Holder for reflection information generated from Protos/ApplicantProfile.proto</summary>
  public static partial class ApplicantProfileReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/ApplicantProfile.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ApplicantProfileReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch1Qcm90b3MvQXBwbGljYW50UHJvZmlsZS5wcm90bxIQQ2FyZWVyQ2xvdWQu",
            "Z1JQQxofZ29vZ2xlL3Byb3RvYnVmL3RpbWVzdGFtcC5wcm90bxobZ29vZ2xl",
            "L3Byb3RvYnVmL0VtcHR5LnByb3RvIhgKCklkUmVxdWVzdDYSCgoCSWQYASAB",
            "KAkiwAEKEEFwcGxpY2FudFByb2ZpbGUSCgoCSWQYASABKAkSDQoFTG9naW4Y",
            "AiABKAkSFQoNQ3VycmVudFNhbGFyeRgDIAEoAxITCgtDdXJyZW50UmF0ZRgE",
            "IAEoAxIQCghDdXJyZW5jeRgFIAEoCRIPCgdDb3VudHJ5GAYgASgJEhAKCFBy",
            "b3ZpbmNlGAcgASgJEg4KBlN0cmVldBgIIAEoCRIMCgRjaXR5GAkgASgJEhIK",
            "ClBvc3RhbENvZGUYCiABKAkiRwoRQXBwbGljYW50UHJvZmlsZXMSMgoGQXBw",
            "UHJvGAEgAygLMiIuQ2FyZWVyQ2xvdWQuZ1JQQy5BcHBsaWNhbnRQcm9maWxl",
            "MvcCChdBcHBsaWNhbnRQcm9maWxlU2VydmljZRJXChNHZXRBcHBsaWNhbnRQ",
            "cm9maWxlEhwuQ2FyZWVyQ2xvdWQuZ1JQQy5JZFJlcXVlc3Q2GiIuQ2FyZWVy",
            "Q2xvdWQuZ1JQQy5BcHBsaWNhbnRQcm9maWxlElUKFkNyZWF0ZUFwcGxpY2Fu",
            "dFByb2ZpbGUSIy5DYXJlZXJDbG91ZC5nUlBDLkFwcGxpY2FudFByb2ZpbGVz",
            "GhYuZ29vZ2xlLnByb3RvYnVmLkVtcHR5ElUKFkRlbGV0ZUFwcGxpY2FudFBy",
            "b2ZpbGUSIy5DYXJlZXJDbG91ZC5nUlBDLkFwcGxpY2FudFByb2ZpbGVzGhYu",
            "Z29vZ2xlLnByb3RvYnVmLkVtcHR5ElUKFlVwZGF0ZUFwcGxpY2FudFByb2Zp",
            "bGUSIy5DYXJlZXJDbG91ZC5nUlBDLkFwcGxpY2FudFByb2ZpbGVzGhYuZ29v",
            "Z2xlLnByb3RvYnVmLkVtcHR5QhqqAhdDYXJlZXJDbG91ZC5nUlBDLlByb3Rv",
            "c2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CareerCloud.gRPC.Protos.IdRequest6), global::CareerCloud.gRPC.Protos.IdRequest6.Parser, new[]{ "Id" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CareerCloud.gRPC.Protos.ApplicantProfile), global::CareerCloud.gRPC.Protos.ApplicantProfile.Parser, new[]{ "Id", "Login", "CurrentSalary", "CurrentRate", "Currency", "Country", "Province", "Street", "City", "PostalCode" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CareerCloud.gRPC.Protos.ApplicantProfiles), global::CareerCloud.gRPC.Protos.ApplicantProfiles.Parser, new[]{ "AppPro" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class IdRequest6 : pb::IMessage<IdRequest6>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<IdRequest6> _parser = new pb::MessageParser<IdRequest6>(() => new IdRequest6());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<IdRequest6> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CareerCloud.gRPC.Protos.ApplicantProfileReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IdRequest6() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IdRequest6(IdRequest6 other) : this() {
      id_ = other.id_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IdRequest6 Clone() {
      return new IdRequest6(this);
    }

    /// <summary>Field number for the "Id" field.</summary>
    public const int IdFieldNumber = 1;
    private string id_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Id {
      get { return id_; }
      set {
        id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as IdRequest6);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(IdRequest6 other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id.Length != 0) hash ^= Id.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Id.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Id);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Id.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Id);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(IdRequest6 other) {
      if (other == null) {
        return;
      }
      if (other.Id.Length != 0) {
        Id = other.Id;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Id = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Id = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class ApplicantProfile : pb::IMessage<ApplicantProfile>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ApplicantProfile> _parser = new pb::MessageParser<ApplicantProfile>(() => new ApplicantProfile());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ApplicantProfile> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CareerCloud.gRPC.Protos.ApplicantProfileReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ApplicantProfile() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ApplicantProfile(ApplicantProfile other) : this() {
      id_ = other.id_;
      login_ = other.login_;
      currentSalary_ = other.currentSalary_;
      currentRate_ = other.currentRate_;
      currency_ = other.currency_;
      country_ = other.country_;
      province_ = other.province_;
      street_ = other.street_;
      city_ = other.city_;
      postalCode_ = other.postalCode_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ApplicantProfile Clone() {
      return new ApplicantProfile(this);
    }

    /// <summary>Field number for the "Id" field.</summary>
    public const int IdFieldNumber = 1;
    private string id_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Id {
      get { return id_; }
      set {
        id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Login" field.</summary>
    public const int LoginFieldNumber = 2;
    private string login_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Login {
      get { return login_; }
      set {
        login_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "CurrentSalary" field.</summary>
    public const int CurrentSalaryFieldNumber = 3;
    private long currentSalary_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long CurrentSalary {
      get { return currentSalary_; }
      set {
        currentSalary_ = value;
      }
    }

    /// <summary>Field number for the "CurrentRate" field.</summary>
    public const int CurrentRateFieldNumber = 4;
    private long currentRate_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long CurrentRate {
      get { return currentRate_; }
      set {
        currentRate_ = value;
      }
    }

    /// <summary>Field number for the "Currency" field.</summary>
    public const int CurrencyFieldNumber = 5;
    private string currency_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Currency {
      get { return currency_; }
      set {
        currency_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Country" field.</summary>
    public const int CountryFieldNumber = 6;
    private string country_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Country {
      get { return country_; }
      set {
        country_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Province" field.</summary>
    public const int ProvinceFieldNumber = 7;
    private string province_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Province {
      get { return province_; }
      set {
        province_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Street" field.</summary>
    public const int StreetFieldNumber = 8;
    private string street_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Street {
      get { return street_; }
      set {
        street_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "city" field.</summary>
    public const int CityFieldNumber = 9;
    private string city_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string City {
      get { return city_; }
      set {
        city_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "PostalCode" field.</summary>
    public const int PostalCodeFieldNumber = 10;
    private string postalCode_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PostalCode {
      get { return postalCode_; }
      set {
        postalCode_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ApplicantProfile);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ApplicantProfile other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Login != other.Login) return false;
      if (CurrentSalary != other.CurrentSalary) return false;
      if (CurrentRate != other.CurrentRate) return false;
      if (Currency != other.Currency) return false;
      if (Country != other.Country) return false;
      if (Province != other.Province) return false;
      if (Street != other.Street) return false;
      if (City != other.City) return false;
      if (PostalCode != other.PostalCode) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id.Length != 0) hash ^= Id.GetHashCode();
      if (Login.Length != 0) hash ^= Login.GetHashCode();
      if (CurrentSalary != 0L) hash ^= CurrentSalary.GetHashCode();
      if (CurrentRate != 0L) hash ^= CurrentRate.GetHashCode();
      if (Currency.Length != 0) hash ^= Currency.GetHashCode();
      if (Country.Length != 0) hash ^= Country.GetHashCode();
      if (Province.Length != 0) hash ^= Province.GetHashCode();
      if (Street.Length != 0) hash ^= Street.GetHashCode();
      if (City.Length != 0) hash ^= City.GetHashCode();
      if (PostalCode.Length != 0) hash ^= PostalCode.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Id.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Id);
      }
      if (Login.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Login);
      }
      if (CurrentSalary != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(CurrentSalary);
      }
      if (CurrentRate != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(CurrentRate);
      }
      if (Currency.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Currency);
      }
      if (Country.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Country);
      }
      if (Province.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Province);
      }
      if (Street.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(Street);
      }
      if (City.Length != 0) {
        output.WriteRawTag(74);
        output.WriteString(City);
      }
      if (PostalCode.Length != 0) {
        output.WriteRawTag(82);
        output.WriteString(PostalCode);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Id.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Id);
      }
      if (Login.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Login);
      }
      if (CurrentSalary != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(CurrentSalary);
      }
      if (CurrentRate != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(CurrentRate);
      }
      if (Currency.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Currency);
      }
      if (Country.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Country);
      }
      if (Province.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Province);
      }
      if (Street.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(Street);
      }
      if (City.Length != 0) {
        output.WriteRawTag(74);
        output.WriteString(City);
      }
      if (PostalCode.Length != 0) {
        output.WriteRawTag(82);
        output.WriteString(PostalCode);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
      }
      if (Login.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Login);
      }
      if (CurrentSalary != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(CurrentSalary);
      }
      if (CurrentRate != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(CurrentRate);
      }
      if (Currency.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Currency);
      }
      if (Country.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Country);
      }
      if (Province.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Province);
      }
      if (Street.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Street);
      }
      if (City.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(City);
      }
      if (PostalCode.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PostalCode);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ApplicantProfile other) {
      if (other == null) {
        return;
      }
      if (other.Id.Length != 0) {
        Id = other.Id;
      }
      if (other.Login.Length != 0) {
        Login = other.Login;
      }
      if (other.CurrentSalary != 0L) {
        CurrentSalary = other.CurrentSalary;
      }
      if (other.CurrentRate != 0L) {
        CurrentRate = other.CurrentRate;
      }
      if (other.Currency.Length != 0) {
        Currency = other.Currency;
      }
      if (other.Country.Length != 0) {
        Country = other.Country;
      }
      if (other.Province.Length != 0) {
        Province = other.Province;
      }
      if (other.Street.Length != 0) {
        Street = other.Street;
      }
      if (other.City.Length != 0) {
        City = other.City;
      }
      if (other.PostalCode.Length != 0) {
        PostalCode = other.PostalCode;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Id = input.ReadString();
            break;
          }
          case 18: {
            Login = input.ReadString();
            break;
          }
          case 24: {
            CurrentSalary = input.ReadInt64();
            break;
          }
          case 32: {
            CurrentRate = input.ReadInt64();
            break;
          }
          case 42: {
            Currency = input.ReadString();
            break;
          }
          case 50: {
            Country = input.ReadString();
            break;
          }
          case 58: {
            Province = input.ReadString();
            break;
          }
          case 66: {
            Street = input.ReadString();
            break;
          }
          case 74: {
            City = input.ReadString();
            break;
          }
          case 82: {
            PostalCode = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Id = input.ReadString();
            break;
          }
          case 18: {
            Login = input.ReadString();
            break;
          }
          case 24: {
            CurrentSalary = input.ReadInt64();
            break;
          }
          case 32: {
            CurrentRate = input.ReadInt64();
            break;
          }
          case 42: {
            Currency = input.ReadString();
            break;
          }
          case 50: {
            Country = input.ReadString();
            break;
          }
          case 58: {
            Province = input.ReadString();
            break;
          }
          case 66: {
            Street = input.ReadString();
            break;
          }
          case 74: {
            City = input.ReadString();
            break;
          }
          case 82: {
            PostalCode = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class ApplicantProfiles : pb::IMessage<ApplicantProfiles>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ApplicantProfiles> _parser = new pb::MessageParser<ApplicantProfiles>(() => new ApplicantProfiles());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ApplicantProfiles> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CareerCloud.gRPC.Protos.ApplicantProfileReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ApplicantProfiles() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ApplicantProfiles(ApplicantProfiles other) : this() {
      appPro_ = other.appPro_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ApplicantProfiles Clone() {
      return new ApplicantProfiles(this);
    }

    /// <summary>Field number for the "AppPro" field.</summary>
    public const int AppProFieldNumber = 1;
    private static readonly pb::FieldCodec<global::CareerCloud.gRPC.Protos.ApplicantProfile> _repeated_appPro_codec
        = pb::FieldCodec.ForMessage(10, global::CareerCloud.gRPC.Protos.ApplicantProfile.Parser);
    private readonly pbc::RepeatedField<global::CareerCloud.gRPC.Protos.ApplicantProfile> appPro_ = new pbc::RepeatedField<global::CareerCloud.gRPC.Protos.ApplicantProfile>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CareerCloud.gRPC.Protos.ApplicantProfile> AppPro {
      get { return appPro_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ApplicantProfiles);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ApplicantProfiles other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!appPro_.Equals(other.appPro_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= appPro_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      appPro_.WriteTo(output, _repeated_appPro_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      appPro_.WriteTo(ref output, _repeated_appPro_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += appPro_.CalculateSize(_repeated_appPro_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ApplicantProfiles other) {
      if (other == null) {
        return;
      }
      appPro_.Add(other.appPro_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            appPro_.AddEntriesFrom(input, _repeated_appPro_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            appPro_.AddEntriesFrom(ref input, _repeated_appPro_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
