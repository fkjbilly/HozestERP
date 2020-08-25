using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class OrderItemsModelHelper : TBeanSerializer<OrderItemsModel>
	{
		
		public static OrderItemsModelHelper OBJ = new OrderItemsModelHelper();
		
		public static OrderItemsModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderItemsModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetName(value);
					}
					
					
					
					
					
					if ("unit".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnit(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetPrice(value);
					}
					
					
					
					
					
					if ("number".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetNumber(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("model".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetModel(value);
					}
					
					
					
					
					
					if ("goodsSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodsSn(value);
					}
					
					
					
					
					
					if ("taxRate".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetTaxRate(value);
					}
					
					
					
					
					
					if ("goodsTaxClassifyCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodsTaxClassifyCode(value);
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
		
		
		public void Write(OrderItemsModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetName() != null) {
				
				oprot.WriteFieldBegin("name");
				oprot.WriteString(structs.GetName());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("name can not be null!");
			}
			
			
			if(structs.GetUnit() != null) {
				
				oprot.WriteFieldBegin("unit");
				oprot.WriteString(structs.GetUnit());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				oprot.WriteDouble((double)structs.GetPrice());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("price can not be null!");
			}
			
			
			if(structs.GetNumber() != null) {
				
				oprot.WriteFieldBegin("number");
				oprot.WriteI32((int)structs.GetNumber()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("number can not be null!");
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteDouble((double)structs.GetAmount());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("amount can not be null!");
			}
			
			
			if(structs.GetModel() != null) {
				
				oprot.WriteFieldBegin("model");
				oprot.WriteString(structs.GetModel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsSn() != null) {
				
				oprot.WriteFieldBegin("goodsSn");
				oprot.WriteString(structs.GetGoodsSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTaxRate() != null) {
				
				oprot.WriteFieldBegin("taxRate");
				oprot.WriteDouble((double)structs.GetTaxRate());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("taxRate can not be null!");
			}
			
			
			if(structs.GetGoodsTaxClassifyCode() != null) {
				
				oprot.WriteFieldBegin("goodsTaxClassifyCode");
				oprot.WriteString(structs.GetGoodsTaxClassifyCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderItemsModel bean){
			
			
		}
		
	}
	
}