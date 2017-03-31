﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceSoap11.IServiceSoap11")]
    public interface IServiceSoap11 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSoap11/Init", ReplyAction="http://tempuri.org/IServiceSoap11/InitResponse")]
        void Init();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSoap11/LoadFileAndReturnFileSizeInBytes", ReplyAction="http://tempuri.org/IServiceSoap11/LoadFileAndReturnFileSizeInBytesResponse")]
        long LoadFileAndReturnFileSizeInBytes(System.IO.Stream file);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSoap11/GetFileBySize", ReplyAction="http://tempuri.org/IServiceSoap11/GetFileBySizeResponse")]
        System.IO.Stream GetFileBySize(int fileSize);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSoap11/GetFileSizes", ReplyAction="http://tempuri.org/IServiceSoap11/GetFileSizesResponse")]
        int[] GetFileSizes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSoap11/GetIntValue", ReplyAction="http://tempuri.org/IServiceSoap11/GetIntValueResponse")]
        int GetIntValue(int value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceSoap11Channel : WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.IServiceSoap11, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceSoap11Client : System.ServiceModel.ClientBase<WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.IServiceSoap11>, WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.IServiceSoap11 {
        
        public ServiceSoap11Client() {
        }
        
        public ServiceSoap11Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceSoap11Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoap11Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoap11Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Init() {
            base.Channel.Init();
        }
        
        public long LoadFileAndReturnFileSizeInBytes(System.IO.Stream file) {
            return base.Channel.LoadFileAndReturnFileSizeInBytes(file);
        }
        
        public System.IO.Stream GetFileBySize(int fileSize) {
            return base.Channel.GetFileBySize(fileSize);
        }
        
        public int[] GetFileSizes() {
            return base.Channel.GetFileSizes();
        }
        
        public int GetIntValue(int value) {
            return base.Channel.GetIntValue(value);
        }
    }
}