﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XLoc.Contracts
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GameFileUploadInfo", Namespace="http://schemas.datacontract.org/2004/07/XLoc.Contracts")]
    public partial class GameFileUploadInfo : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool CaseSensitiveField;
        
        private string FileNameField;
        
        private bool HistoricalTranslationField;
        
        private string LanguageIdField;
        
        private string LocalizationIdField;
        
        private string PlatformIdField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool CaseSensitive
        {
            get
            {
                return this.CaseSensitiveField;
            }
            set
            {
                this.CaseSensitiveField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string FileName
        {
            get
            {
                return this.FileNameField;
            }
            set
            {
                this.FileNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool HistoricalTranslation
        {
            get
            {
                return this.HistoricalTranslationField;
            }
            set
            {
                this.HistoricalTranslationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string LanguageId
        {
            get
            {
                return this.LanguageIdField;
            }
            set
            {
                this.LanguageIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string LocalizationId
        {
            get
            {
                return this.LocalizationIdField;
            }
            set
            {
                this.LocalizationIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string PlatformId
        {
            get
            {
                return this.PlatformIdField;
            }
            set
            {
                this.PlatformIdField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="urn:XLoc.Services", ConfigurationName="ITransferService")]
public interface ITransferService
{
    
    // CODEGEN: Generating message contract since the operation UploadGameFile is neither RPC nor document wrapped.
    [System.ServiceModel.OperationContractAttribute(Action="urn:XLoc.Services/ITransferService/UploadGameFile", ReplyAction="urn:XLoc.Services/ITransferService/UploadGameFileResponse")]
    UploadGameFileResponse UploadGameFile(GameFileUploadMessage request);
    
    [System.ServiceModel.OperationContractAttribute(Action="urn:XLoc.Services/ITransferService/UploadGameFile", ReplyAction="urn:XLoc.Services/ITransferService/UploadGameFileResponse")]
    System.Threading.Tasks.Task<UploadGameFileResponse> UploadGameFileAsync(GameFileUploadMessage request);
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
[System.ServiceModel.MessageContractAttribute(WrapperName="GameFileUploadMessage", WrapperNamespace="urn:XLoc.Services", IsWrapped=true)]
public partial class GameFileUploadMessage
{
    
    [System.ServiceModel.MessageHeaderAttribute(Namespace="urn:XLoc.Services")]
    public string ApiKey;
    
    [System.ServiceModel.MessageHeaderAttribute(Namespace="urn:XLoc.Services")]
    public string AuthToken;
    
    [System.ServiceModel.MessageHeaderAttribute(Namespace="urn:XLoc.Services")]
    public XLoc.Contracts.GameFileUploadInfo FileMetaData;
    
    [System.ServiceModel.MessageHeaderAttribute(Namespace="urn:XLoc.Services")]
    public long Length;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:XLoc.Services", Order=0)]
    public System.IO.Stream FileByteStream;
    
    public GameFileUploadMessage()
    {
    }
    
    public GameFileUploadMessage(string ApiKey, string AuthToken, XLoc.Contracts.GameFileUploadInfo FileMetaData, long Length, System.IO.Stream FileByteStream)
    {
        this.ApiKey = ApiKey;
        this.AuthToken = AuthToken;
        this.FileMetaData = FileMetaData;
        this.Length = Length;
        this.FileByteStream = FileByteStream;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
[System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
public partial class UploadGameFileResponse
{
    
    public UploadGameFileResponse()
    {
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ITransferServiceChannel : ITransferService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class TransferServiceClient : System.ServiceModel.ClientBase<ITransferService>, ITransferService
{
    
    public TransferServiceClient()
    {
    }
    
    public TransferServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public TransferServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public TransferServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public TransferServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    UploadGameFileResponse ITransferService.UploadGameFile(GameFileUploadMessage request)
    {
        return base.Channel.UploadGameFile(request);
    }
    
    public void UploadGameFile(string ApiKey, string AuthToken, XLoc.Contracts.GameFileUploadInfo FileMetaData, long Length, System.IO.Stream FileByteStream)
    {
        GameFileUploadMessage inValue = new GameFileUploadMessage();
        inValue.ApiKey = ApiKey;
        inValue.AuthToken = AuthToken;
        inValue.FileMetaData = FileMetaData;
        inValue.Length = Length;
        inValue.FileByteStream = FileByteStream;
        ((ITransferService)(this)).UploadGameFile(inValue);
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    System.Threading.Tasks.Task<UploadGameFileResponse> ITransferService.UploadGameFileAsync(GameFileUploadMessage request)
    {
        return base.Channel.UploadGameFileAsync(request);
    }
    
    public System.Threading.Tasks.Task<UploadGameFileResponse> UploadGameFileAsync(string ApiKey, string AuthToken, XLoc.Contracts.GameFileUploadInfo FileMetaData, long Length, System.IO.Stream FileByteStream)
    {
        GameFileUploadMessage inValue = new GameFileUploadMessage();
        inValue.ApiKey = ApiKey;
        inValue.AuthToken = AuthToken;
        inValue.FileMetaData = FileMetaData;
        inValue.Length = Length;
        inValue.FileByteStream = FileByteStream;
        return ((ITransferService)(this)).UploadGameFileAsync(inValue);
    }
}
