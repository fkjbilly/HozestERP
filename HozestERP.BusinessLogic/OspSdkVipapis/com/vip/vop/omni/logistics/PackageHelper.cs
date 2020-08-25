using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.omni.logistics{
	
	
	
	public class PackageHelper : TBeanSerializer<Package>
	{
		
		public static PackageHelper OBJ = new PackageHelper();
		
		public static PackageHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Package structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transport_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_no(value);
					}
					
					
					
					
					
					if ("carrier_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_name(value);
					}
					
					
					
					
					
					if ("traceInfos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.vop.omni.logistics.TraceInfo> value;
						
						value = new List<com.vip.vop.omni.logistics.TraceInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.vop.omni.logistics.TraceInfo elem1;
								
								elem1 = new com.vip.vop.omni.logistics.TraceInfo();
								com.vip.vop.omni.logistics.TraceInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetTraceInfos(value);
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
		
		
		public void Write(Package structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransport_no() != null) {
				
				oprot.WriteFieldBegin("transport_no");
				oprot.WriteString(structs.GetTransport_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrier_name() != null) {
				
				oprot.WriteFieldBegin("carrier_name");
				oprot.WriteString(structs.GetCarrier_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTraceInfos() != null) {
				
				oprot.WriteFieldBegin("traceInfos");
				
				oprot.WriteListBegin();
				foreach(com.vip.vop.omni.logistics.TraceInfo _item0 in structs.GetTraceInfos()){
					
					
					com.vip.vop.omni.logistics.TraceInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Package bean){
			
			
		}
		
	}
	
}