using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.omni.logistics{
	
	
	
	public class LogisticsTrackResponseHelper : TBeanSerializer<LogisticsTrackResponse>
	{
		
		public static LogisticsTrackResponseHelper OBJ = new LogisticsTrackResponseHelper();
		
		public static LogisticsTrackResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(LogisticsTrackResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.vop.omni.logistics.Order> value;
						
						value = new List<com.vip.vop.omni.logistics.Order>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.vop.omni.logistics.Order elem0;
								
								elem0 = new com.vip.vop.omni.logistics.Order();
								com.vip.vop.omni.logistics.OrderHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrders(value);
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
		
		
		public void Write(LogisticsTrackResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrders() != null) {
				
				oprot.WriteFieldBegin("orders");
				
				oprot.WriteListBegin();
				foreach(com.vip.vop.omni.logistics.Order _item0 in structs.GetOrders()){
					
					
					com.vip.vop.omni.logistics.OrderHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(LogisticsTrackResponse bean){
			
			
		}
		
	}
	
}