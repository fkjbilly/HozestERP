using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class OrderTrackHelper : BeanSerializer<OrderTrack>
	{
		
		public static OrderTrackHelper OBJ = new OrderTrackHelper();
		
		public static OrderTrackHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderTrack structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("timeline".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.TransportInfo> value;
						
						value = new List<vipapis.order.TransportInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.TransportInfo elem0;
								
								elem0 = new vipapis.order.TransportInfo();
								vipapis.order.TransportInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetTimeline(value);
					}
					
					
					
					
					
					if ("is_cod".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetIs_cod(value);
					}
					
					
					
					
					
					if ("transport".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport(value);
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
		
		
		public void Write(OrderTrack structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTimeline() != null) {
				
				oprot.WriteFieldBegin("timeline");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.TransportInfo _item0 in structs.GetTimeline()){
					
					
					vipapis.order.TransportInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_cod() != null) {
				
				oprot.WriteFieldBegin("is_cod");
				oprot.WriteByte((byte)structs.GetIs_cod()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_cod can not be null!");
			}
			
			
			if(structs.GetTransport() != null) {
				
				oprot.WriteFieldBegin("transport");
				oprot.WriteString(structs.GetTransport());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderTrack bean){
			
			
		}
		
	}
	
}