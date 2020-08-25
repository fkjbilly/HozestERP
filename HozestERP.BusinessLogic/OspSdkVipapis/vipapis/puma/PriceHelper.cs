using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.puma{
	
	
	
	public class PriceHelper : TBeanSerializer<Price>
	{
		
		public static PriceHelper OBJ = new PriceHelper();
		
		public static PriceHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Price structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vip_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVip_price(value);
					}
					
					
					
					
					
					if ("market_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMarket_price(value);
					}
					
					
					
					
					
					if ("discount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDiscount(value);
					}
					
					
					
					
					
					if ("effective_start_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetEffective_start_time(value);
					}
					
					
					
					
					
					if ("effective_end_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetEffective_end_time(value);
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
		
		
		public void Write(Price structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVip_price() != null) {
				
				oprot.WriteFieldBegin("vip_price");
				oprot.WriteString(structs.GetVip_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMarket_price() != null) {
				
				oprot.WriteFieldBegin("market_price");
				oprot.WriteString(structs.GetMarket_price());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDiscount() != null) {
				
				oprot.WriteFieldBegin("discount");
				oprot.WriteString(structs.GetDiscount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEffective_start_time() != null) {
				
				oprot.WriteFieldBegin("effective_start_time");
				oprot.WriteI64((long)structs.GetEffective_start_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEffective_end_time() != null) {
				
				oprot.WriteFieldBegin("effective_end_time");
				oprot.WriteI64((long)structs.GetEffective_end_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Price bean){
			
			
		}
		
	}
	
}