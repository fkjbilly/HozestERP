using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class DeliveryTraceHelper : TBeanSerializer<DeliveryTrace>
	{
		
		public static DeliveryTraceHelper OBJ = new DeliveryTraceHelper();
		
		public static DeliveryTraceHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DeliveryTrace structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("storageNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStorageNo(value);
					}
					
					
					
					
					
					if ("transportNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportNo(value);
					}
					
					
					
					
					
					if ("carrierName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrierName(value);
					}
					
					
					
					
					
					if ("traces".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.vop.vcloud.jit.TraceDetail> value;
						
						value = new List<com.vip.vop.vcloud.jit.TraceDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.vop.vcloud.jit.TraceDetail elem0;
								
								elem0 = new com.vip.vop.vcloud.jit.TraceDetail();
								com.vip.vop.vcloud.jit.TraceDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetTraces(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(DeliveryTrace structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetStorageNo() != null) {
				
				oprot.WriteFieldBegin("storageNo");
				oprot.WriteString(structs.GetStorageNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportNo() != null) {
				
				oprot.WriteFieldBegin("transportNo");
				oprot.WriteString(structs.GetTransportNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrierName() != null) {
				
				oprot.WriteFieldBegin("carrierName");
				oprot.WriteString(structs.GetCarrierName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTraces() != null) {
				
				oprot.WriteFieldBegin("traces");
				
				oprot.WriteListBegin();
				foreach(com.vip.vop.vcloud.jit.TraceDetail _item0 in structs.GetTraces()){
					
					
					com.vip.vop.vcloud.jit.TraceDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DeliveryTrace bean){
			
			
		}
		
	}
	
}