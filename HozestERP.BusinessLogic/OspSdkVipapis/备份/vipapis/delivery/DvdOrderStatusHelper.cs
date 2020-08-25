using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class DvdOrderStatusHelper : BeanSerializer<DvdOrderStatus>
	{
		
		public static DvdOrderStatusHelper OBJ = new DvdOrderStatusHelper();
		
		public static DvdOrderStatusHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DvdOrderStatus structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("old_order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOld_order_id(value);
					}
					
					
					
					
					
					if ("order_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.common.OrderStatus? value;
						
						value = vipapis.common.OrderStatusUtil.FindByName(iprot.ReadString());
						
						structs.SetOrder_status(value);
					}
					
					
					
					
					
					if ("warehouse_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse_name(value);
					}
					
					
					
					
					
					if ("ebs_warehouse_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEbs_warehouse_code(value);
					}
					
					
					
					
					
					if ("b2c_warehouse_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetB2c_warehouse_code(value);
					}
					
					
					
					
					
					if ("user_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetUser_type(value);
					}
					
					
					
					
					
					if ("user_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUser_name(value);
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
		
		
		public void Write(DvdOrderStatus structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOld_order_id() != null) {
				
				oprot.WriteFieldBegin("old_order_id");
				oprot.WriteString(structs.GetOld_order_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_status() != null) {
				
				oprot.WriteFieldBegin("order_status");
				oprot.WriteString(structs.GetOrder_status().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse_name() != null) {
				
				oprot.WriteFieldBegin("warehouse_name");
				oprot.WriteString(structs.GetWarehouse_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEbs_warehouse_code() != null) {
				
				oprot.WriteFieldBegin("ebs_warehouse_code");
				oprot.WriteString(structs.GetEbs_warehouse_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetB2c_warehouse_code() != null) {
				
				oprot.WriteFieldBegin("b2c_warehouse_code");
				oprot.WriteString(structs.GetB2c_warehouse_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUser_type() != null) {
				
				oprot.WriteFieldBegin("user_type");
				oprot.WriteI32((int)structs.GetUser_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUser_name() != null) {
				
				oprot.WriteFieldBegin("user_name");
				oprot.WriteString(structs.GetUser_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DvdOrderStatus bean){
			
			
		}
		
	}
	
}