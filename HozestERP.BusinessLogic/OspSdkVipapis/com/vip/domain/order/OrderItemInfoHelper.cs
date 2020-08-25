using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.order{
	
	
	
	public class OrderItemInfoHelper : TBeanSerializer<OrderItemInfo>
	{
		
		public static OrderItemInfoHelper OBJ = new OrderItemInfoHelper();
		
		public static OrderItemInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderItemInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("size_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_sn(value);
					}
					
					
					
					
					
					if ("name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetName(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetPrice(value);
					}
					
					
					
					
					
					if ("brand_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name(value);
					}
					
					
					
					
					
					if ("size".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize(value);
					}
					
					
					
					
					
					if ("fore_word".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFore_word(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_id(value);
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
		
		
		public void Write(OrderItemInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSize_sn() != null) {
				
				oprot.WriteFieldBegin("size_sn");
				oprot.WriteString(structs.GetSize_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_sn can not be null!");
			}
			
			
			if(structs.GetName() != null) {
				
				oprot.WriteFieldBegin("name");
				oprot.WriteString(structs.GetName());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("name can not be null!");
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("amount can not be null!");
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				oprot.WriteDouble((double)structs.GetPrice());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("price can not be null!");
			}
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				oprot.WriteString(structs.GetBrand_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize() != null) {
				
				oprot.WriteFieldBegin("size");
				oprot.WriteString(structs.GetSize());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFore_word() != null) {
				
				oprot.WriteFieldBegin("fore_word");
				oprot.WriteString(structs.GetFore_word());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteString(structs.GetBrand_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderItemInfo bean){
			
			
		}
		
	}
	
}