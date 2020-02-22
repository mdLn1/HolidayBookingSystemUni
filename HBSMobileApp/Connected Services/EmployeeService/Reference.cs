﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HBSMobileApp.EmployeeService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://holidaybookingsystem.org/", ConfigurationName="EmployeeService.EmployeeServiceSoap")]
    public interface EmployeeServiceSoap {
        
        // CODEGEN: Generating message contract since element name username from namespace http://holidaybookingsystem.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://holidaybookingsystem.org/EmployeeLogin", ReplyAction="*")]
        HBSMobileApp.EmployeeService.EmployeeLoginResponse EmployeeLogin(HBSMobileApp.EmployeeService.EmployeeLoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://holidaybookingsystem.org/EmployeeLogin", ReplyAction="*")]
        System.Threading.Tasks.Task<HBSMobileApp.EmployeeService.EmployeeLoginResponse> EmployeeLoginAsync(HBSMobileApp.EmployeeService.EmployeeLoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://holidaybookingsystem.org/SubmitRequest", ReplyAction="*")]
        bool SubmitRequest(System.DateTime startDate, System.DateTime endDate, int workingDays);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://holidaybookingsystem.org/SubmitRequest", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> SubmitRequestAsync(System.DateTime startDate, System.DateTime endDate, int workingDays);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class EmployeeLoginRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="EmployeeLogin", Namespace="http://holidaybookingsystem.org/", Order=0)]
        public HBSMobileApp.EmployeeService.EmployeeLoginRequestBody Body;
        
        public EmployeeLoginRequest() {
        }
        
        public EmployeeLoginRequest(HBSMobileApp.EmployeeService.EmployeeLoginRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://holidaybookingsystem.org/")]
    public partial class EmployeeLoginRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string username;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string password;
        
        public EmployeeLoginRequestBody() {
        }
        
        public EmployeeLoginRequestBody(string username, string password) {
            this.username = username;
            this.password = password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class EmployeeLoginResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="EmployeeLoginResponse", Namespace="http://holidaybookingsystem.org/", Order=0)]
        public HBSMobileApp.EmployeeService.EmployeeLoginResponseBody Body;
        
        public EmployeeLoginResponse() {
        }
        
        public EmployeeLoginResponse(HBSMobileApp.EmployeeService.EmployeeLoginResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://holidaybookingsystem.org/")]
    public partial class EmployeeLoginResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool EmployeeLoginResult;
        
        public EmployeeLoginResponseBody() {
        }
        
        public EmployeeLoginResponseBody(bool EmployeeLoginResult) {
            this.EmployeeLoginResult = EmployeeLoginResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface EmployeeServiceSoapChannel : HBSMobileApp.EmployeeService.EmployeeServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeServiceSoapClient : System.ServiceModel.ClientBase<HBSMobileApp.EmployeeService.EmployeeServiceSoap>, HBSMobileApp.EmployeeService.EmployeeServiceSoap {
        
        public EmployeeServiceSoapClient() {
        }
        
        public EmployeeServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HBSMobileApp.EmployeeService.EmployeeLoginResponse HBSMobileApp.EmployeeService.EmployeeServiceSoap.EmployeeLogin(HBSMobileApp.EmployeeService.EmployeeLoginRequest request) {
            return base.Channel.EmployeeLogin(request);
        }
        
        public bool EmployeeLogin(string username, string password) {
            HBSMobileApp.EmployeeService.EmployeeLoginRequest inValue = new HBSMobileApp.EmployeeService.EmployeeLoginRequest();
            inValue.Body = new HBSMobileApp.EmployeeService.EmployeeLoginRequestBody();
            inValue.Body.username = username;
            inValue.Body.password = password;
            HBSMobileApp.EmployeeService.EmployeeLoginResponse retVal = ((HBSMobileApp.EmployeeService.EmployeeServiceSoap)(this)).EmployeeLogin(inValue);
            return retVal.Body.EmployeeLoginResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<HBSMobileApp.EmployeeService.EmployeeLoginResponse> HBSMobileApp.EmployeeService.EmployeeServiceSoap.EmployeeLoginAsync(HBSMobileApp.EmployeeService.EmployeeLoginRequest request) {
            return base.Channel.EmployeeLoginAsync(request);
        }
        
        public System.Threading.Tasks.Task<HBSMobileApp.EmployeeService.EmployeeLoginResponse> EmployeeLoginAsync(string username, string password) {
            HBSMobileApp.EmployeeService.EmployeeLoginRequest inValue = new HBSMobileApp.EmployeeService.EmployeeLoginRequest();
            inValue.Body = new HBSMobileApp.EmployeeService.EmployeeLoginRequestBody();
            inValue.Body.username = username;
            inValue.Body.password = password;
            return ((HBSMobileApp.EmployeeService.EmployeeServiceSoap)(this)).EmployeeLoginAsync(inValue);
        }
        
        public bool SubmitRequest(System.DateTime startDate, System.DateTime endDate, int workingDays) {
            return base.Channel.SubmitRequest(startDate, endDate, workingDays);
        }
        
        public System.Threading.Tasks.Task<bool> SubmitRequestAsync(System.DateTime startDate, System.DateTime endDate, int workingDays) {
            return base.Channel.SubmitRequestAsync(startDate, endDate, workingDays);
        }
    }
}
