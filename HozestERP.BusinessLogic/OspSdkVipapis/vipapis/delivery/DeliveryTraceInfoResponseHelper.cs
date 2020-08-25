using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class DeliveryTraceInfoResponseHelper : TBeanSerializer<DeliveryTraceInfoResponse>
	{
		
		public static DeliveryTraceInfoResponseHelper OBJ = new DeliveryTraceInfoResponseHelper();
		
		public static DeliveryTraceInfoResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DeliveryTraceInfoResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("delivery_trace_infoes".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.DeliveryTraceInfo> value;
						
						value = new List<vipapis.delivery.DeliveryTraceInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.DeliveryTraceInfo elem0;
								
								elem0 = new vipapis.delivery.DeliveryTraceInfo();
								vipapis.delivery.DeliveryTraceInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDelivery_trace_infoes(value);
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
		
		
		public void Write(DeliveryTraceInfoResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDelivery_trace_infoes() != null) {
				
				oprot.WriteFieldBegin("delivery_trace_infoes");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.DeliveryTraceInfo _item0 in structs.GetDelivery_trace_infoes()){
					
					
					vipapis.delivery.DeliveryTraceInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DeliveryTraceInfoResponse bean){
			
			
		}
		
	}
	
}