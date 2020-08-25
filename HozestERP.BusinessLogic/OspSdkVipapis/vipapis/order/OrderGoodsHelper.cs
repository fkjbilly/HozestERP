using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class OrderGoodsHelper : BeanSerializer<OrderGoods>
	{
		
		public static OrderGoodsHelper OBJ = new OrderGoodsHelper();
		
		public static OrderGoodsHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderGoods structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("goods_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_name(value);
					}
					
					
					
					
					
					if ("size_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetSize_id(value);
					}
					
					
					
					
					
					if ("size_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_name(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("pri_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPri_url(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetPrice(value);
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
		
		
		public void Write(OrderGoods structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetGoods_name() != null) {
				
				oprot.WriteFieldBegin("goods_name");
				oprot.WriteString(structs.GetGoods_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("goods_name can not be null!");
			}
			
			
			if(structs.GetSize_id() != null) {
				
				oprot.WriteFieldBegin("size_id");
				oprot.WriteI32((int)structs.GetSize_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_id can not be null!");
			}
			
			
			if(structs.GetSize_name() != null) {
				
				oprot.WriteFieldBegin("size_name");
				oprot.WriteString(structs.GetSize_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_name can not be null!");
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("amount can not be null!");
			}
			
			
			if(structs.GetPri_url() != null) {
				
				oprot.WriteFieldBegin("pri_url");
				oprot.WriteString(structs.GetPri_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				oprot.WriteI32((int)structs.GetPrice()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("price can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderGoods bean){
			
			
		}
		
	}
	
}