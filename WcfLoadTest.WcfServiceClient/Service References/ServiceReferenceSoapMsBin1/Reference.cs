﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfLoadTest.WcfServiceClient.ServiceReferenceSoapMsBin1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceSoapMsBin1.IServiceSoapMsBin1")]
    internal interface IServiceSoapMsBin1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSoapMsBin1/Init", ReplyAction="http://tempuri.org/IServiceSoapMsBin1/InitResponse")]
        void Init();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSoapMsBin1/LoadFileAndReturnFileSizeInBytes", ReplyAction="http://tempuri.org/IServiceSoapMsBin1/LoadFileAndReturnFileSizeInBytesResponse")]
        long LoadFileAndReturnFileSizeInBytes(System.IO.Stream file);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSoapMsBin1/GetFileBySize", ReplyAction="http://tempuri.org/IServiceSoapMsBin1/GetFileBySizeResponse")]
        System.IO.Stream GetFileBySize(int fileSize);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSoapMsBin1/GetFileSizes", ReplyAction="http://tempuri.org/IServiceSoapMsBin1/GetFileSizesResponse")]
        int[] GetFileSizes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceSoapMsBin1/GetIntValue", ReplyAction="http://tempuri.org/IServiceSoapMsBin1/GetIntValueResponse")]
        int GetIntValue(int value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface IServiceSoapMsBin1Channel : WcfLoadTest.WcfServiceClient.ServiceReferenceSoapMsBin1.IServiceSoapMsBin1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal partial class ServiceSoapMsBin1Client : System.ServiceModel.ClientBase<WcfLoadTest.WcfServiceClient.ServiceReferenceSoapMsBin1.IServiceSoapMsBin1>, WcfLoadTest.WcfServiceClient.ServiceReferenceSoapMsBin1.IServiceSoapMsBin1 {
        
        public ServiceSoapMsBin1Client() {
        }
        
        public ServiceSoapMsBin1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceSoapMsBin1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoapMsBin1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoapMsBin1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
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
