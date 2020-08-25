using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.dvd{
	
	
	
	public class AreaWarehouseHelper : TBeanSerializer<AreaWarehouse>
	{
		
		public static AreaWarehouseHelper OBJ = new AreaWarehouseHelper();
		
		public static AreaWarehouseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AreaWarehouse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("area_warehouse_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArea_warehouse_id(value);
					}
					
					
					
					
					
					if ("area_warehouse_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArea_warehouse_name(value);
					}
					
					
					
					
					
					if ("area_warehouse_address".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArea_warehouse_address(value);
					}
					
					
					
					
					
					if ("returned_goods_address".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturned_goods_address(value);
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
		
		
		public void Write(AreaWarehouse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetArea_warehouse_id() != null) {
				
				oprot.WriteFieldBegin("area_warehouse_id");
				oprot.WriteString(structs.GetArea_warehouse_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArea_warehouse_name() != null) {
				
				oprot.WriteFieldBegin("area_warehouse_name");
				oprot.WriteString(structs.GetArea_warehouse_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArea_warehouse_address() != null) {
				
				oprot.WriteFieldBegin("area_warehouse_address");
				oprot.WriteString(structs.GetArea_warehouse_address());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturned_goods_address() != null) {
				
				oprot.WriteFieldBegin("returned_goods_address");
				oprot.WriteString(structs.GetReturned_goods_address());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AreaWarehouse bean){
			
			
		}
		
	}
	
}