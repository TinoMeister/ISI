﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SOAP_DeviceWS
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://homeautomation.org/", ConfigurationName="SOAP_DeviceWS.DeviceWSSoap")]
    public interface DeviceWSSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://homeautomation.org/GetAllDevices", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SOAP_DeviceWS.ArrayOfXElement GetAllDevices();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://homeautomation.org/GetAllDevices", ReplyAction="*")]
        System.Threading.Tasks.Task<SOAP_DeviceWS.ArrayOfXElement> GetAllDevicesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://homeautomation.org/GetDeviceById", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SOAP_DeviceWS.ArrayOfXElement GetDeviceById(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://homeautomation.org/GetDeviceById", ReplyAction="*")]
        System.Threading.Tasks.Task<SOAP_DeviceWS.ArrayOfXElement> GetDeviceByIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://homeautomation.org/InsertDevice", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int InsertDevice(int id, string name, bool state, double value, int houseId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://homeautomation.org/InsertDevice", ReplyAction="*")]
        System.Threading.Tasks.Task<int> InsertDeviceAsync(int id, string name, bool state, double value, int houseId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://homeautomation.org/UpdateDevice", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int UpdateDevice(int id, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://homeautomation.org/UpdateDevice", ReplyAction="*")]
        System.Threading.Tasks.Task<int> UpdateDeviceAsync(int id, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://homeautomation.org/DeleteDevice", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int DeleteDevice(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://homeautomation.org/DeleteDevice", ReplyAction="*")]
        System.Threading.Tasks.Task<int> DeleteDeviceAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface DeviceWSSoapChannel : SOAP_DeviceWS.DeviceWSSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class DeviceWSSoapClient : System.ServiceModel.ClientBase<SOAP_DeviceWS.DeviceWSSoap>, SOAP_DeviceWS.DeviceWSSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public DeviceWSSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(DeviceWSSoapClient.GetBindingForEndpoint(endpointConfiguration), DeviceWSSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DeviceWSSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(DeviceWSSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DeviceWSSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(DeviceWSSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DeviceWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }

        public DeviceWSSoapClient()
        {
        }

        public SOAP_DeviceWS.ArrayOfXElement GetAllDevices()
        {
            return base.Channel.GetAllDevices();
        }
        
        public System.Threading.Tasks.Task<SOAP_DeviceWS.ArrayOfXElement> GetAllDevicesAsync()
        {
            return base.Channel.GetAllDevicesAsync();
        }
        
        public SOAP_DeviceWS.ArrayOfXElement GetDeviceById(int Id)
        {
            return base.Channel.GetDeviceById(Id);
        }
        
        public System.Threading.Tasks.Task<SOAP_DeviceWS.ArrayOfXElement> GetDeviceByIdAsync(int Id)
        {
            return base.Channel.GetDeviceByIdAsync(Id);
        }
        
        public int InsertDevice(int id, string name, bool state, double value, int houseId)
        {
            return base.Channel.InsertDevice(id, name, state, value, houseId);
        }
        
        public System.Threading.Tasks.Task<int> InsertDeviceAsync(int id, string name, bool state, double value, int houseId)
        {
            return base.Channel.InsertDeviceAsync(id, name, state, value, houseId);
        }
        
        public int UpdateDevice(int id, double value)
        {
            return base.Channel.UpdateDevice(id, value);
        }
        
        public System.Threading.Tasks.Task<int> UpdateDeviceAsync(int id, double value)
        {
            return base.Channel.UpdateDeviceAsync(id, value);
        }
        
        public int DeleteDevice(int id)
        {
            return base.Channel.DeleteDevice(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteDeviceAsync(int id)
        {
            return base.Channel.DeleteDeviceAsync(id);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.DeviceWSSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.DeviceWSSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.DeviceWSSoap))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:44366/Services/DeviceWS.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.DeviceWSSoap12))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:44366/Services/DeviceWS.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            DeviceWSSoap,
            
            DeviceWSSoap12,
        }
    }
    
    [System.Xml.Serialization.XmlSchemaProviderAttribute(null, IsAny=true)]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil-lib", "2.1.0.0")]
    public partial class ArrayOfXElement : object, System.Xml.Serialization.IXmlSerializable
    {
        
        private System.Collections.Generic.List<System.Xml.Linq.XElement> nodesList = new System.Collections.Generic.List<System.Xml.Linq.XElement>();
        
        public ArrayOfXElement()
        {
        }
        
        public virtual System.Collections.Generic.List<System.Xml.Linq.XElement> Nodes
        {
            get
            {
                return this.nodesList;
            }
        }
        
        public virtual System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new System.NotImplementedException();
        }
        
        public virtual void WriteXml(System.Xml.XmlWriter writer)
        {
            System.Collections.Generic.IEnumerator<System.Xml.Linq.XElement> e = nodesList.GetEnumerator();
            for (
            ; e.MoveNext(); 
            )
            {
                ((System.Xml.Serialization.IXmlSerializable)(e.Current)).WriteXml(writer);
            }
        }
        
        public virtual void ReadXml(System.Xml.XmlReader reader)
        {
            for (
            ; (reader.NodeType != System.Xml.XmlNodeType.EndElement); 
            )
            {
                if ((reader.NodeType == System.Xml.XmlNodeType.Element))
                {
                    System.Xml.Linq.XElement elem = new System.Xml.Linq.XElement("default");
                    ((System.Xml.Serialization.IXmlSerializable)(elem)).ReadXml(reader);
                    Nodes.Add(elem);
                }
                else
                {
                    reader.Skip();
                }
            }
        }
    }
}
