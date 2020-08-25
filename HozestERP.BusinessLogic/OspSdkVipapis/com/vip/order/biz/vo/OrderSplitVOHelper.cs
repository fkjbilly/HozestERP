using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.vo{
	
	
	
	public class OrderSplitVOHelper : TBeanSerializer<OrderSplitVO>
	{
		
		public static OrderSplitVOHelper OBJ = new OrderSplitVOHelper();
		
		public static OrderSplitVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderSplitVO structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("walletPaySn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWalletPaySn(value);
					}
					
					
					
					
					
					if ("pointPaySn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPointPaySn(value);
					}
					
					
					
					
					
					if ("favourablePaySn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFavourablePaySn(value);
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
		
		
		public void Write(OrderSplitVO structs, Protocol oprot){
			
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
			
			
			if(structs.GetWalletPaySn() != null) {
				
				oprot.WriteFieldBegin("walletPaySn");
				oprot.WriteString(structs.GetWalletPaySn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPointPaySn() != null) {
				
				oprot.WriteFieldBegin("pointPaySn");
				oprot.WriteString(structs.GetPointPaySn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFavourablePaySn() != null) {
				
				oprot.WriteFieldBegin("favourablePaySn");
				oprot.WriteString(structs.GetFavourablePaySn());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderSplitVO bean){
			
			
		}
		
	}
	
}