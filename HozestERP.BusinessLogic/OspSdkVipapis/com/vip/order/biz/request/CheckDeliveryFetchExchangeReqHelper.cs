using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class CheckDeliveryFetchExchangeReqHelper : TBeanSerializer<CheckDeliveryFetchExchangeReq>
	{
		
		public static CheckDeliveryFetchExchangeReqHelper OBJ = new CheckDeliveryFetchExchangeReqHelper();
		
		public static CheckDeliveryFetchExchangeReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CheckDeliveryFetchExchangeReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("areaId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetAreaId(value);
					}
					
					
					
					
					
					if ("addressLevel".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAddressLevel(value);
					}
					
					
					
					
					
					if ("merItemNoSet".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<long?> value;
						
						value = new List<long?>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								long elem0;
								elem0 = iprot.ReadI64(); 
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetMerItemNoSet(value);
					}
					
					
					
					
					
					if ("areaIdStr".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAreaIdStr(value);
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
		
		
		public void Write(CheckDeliveryFetchExchangeReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAreaId() != null) {
				
				oprot.WriteFieldBegin("areaId");
				oprot.WriteI64((long)structs.GetAreaId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddressLevel() != null) {
				
				oprot.WriteFieldBegin("addressLevel");
				oprot.WriteI32((int)structs.GetAddressLevel()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerItemNoSet() != null) {
				
				oprot.WriteFieldBegin("merItemNoSet");
				
				oprot.WriteSetBegin();
				foreach(long _item0 in structs.GetMerItemNoSet()){
					
					oprot.WriteI64((long)_item0); 
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAreaIdStr() != null) {
				
				oprot.WriteFieldBegin("areaIdStr");
				oprot.WriteString(structs.GetAreaIdStr());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CheckDeliveryFetchExchangeReq bean){
			
			
		}
		
	}
	
}