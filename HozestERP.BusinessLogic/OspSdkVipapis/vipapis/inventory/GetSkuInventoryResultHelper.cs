using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.inventory{
	
	
	
	public class GetSkuInventoryResultHelper : TBeanSerializer<GetSkuInventoryResult>
	{
		
		public static GetSkuInventoryResultHelper OBJ = new GetSkuInventoryResultHelper();
		
		public static GetSkuInventoryResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetSkuInventoryResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("cooperation_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCooperation_no(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("leaving_stock".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetLeaving_stock(value);
					}
					
					
					
					
					
					if ("current_hold".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetCurrent_hold(value);
					}
					
					
					
					
					
					if ("circuit_break_value".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCircuit_break_value(value);
					}
					
					
					
					
					
					if ("area_warehouse_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArea_warehouse_id(value);
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
		
		
		public void Write(GetSkuInventoryResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCooperation_no() != null) {
				
				oprot.WriteFieldBegin("cooperation_no");
				oprot.WriteI32((int)structs.GetCooperation_no()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("barcode can not be null!");
			}
			
			
			if(structs.GetLeaving_stock() != null) {
				
				oprot.WriteFieldBegin("leaving_stock");
				oprot.WriteI32((int)structs.GetLeaving_stock()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("leaving_stock can not be null!");
			}
			
			
			if(structs.GetCurrent_hold() != null) {
				
				oprot.WriteFieldBegin("current_hold");
				oprot.WriteI32((int)structs.GetCurrent_hold()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("current_hold can not be null!");
			}
			
			
			if(structs.GetCircuit_break_value() != null) {
				
				oprot.WriteFieldBegin("circuit_break_value");
				oprot.WriteI32((int)structs.GetCircuit_break_value()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArea_warehouse_id() != null) {
				
				oprot.WriteFieldBegin("area_warehouse_id");
				oprot.WriteString(structs.GetArea_warehouse_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetSkuInventoryResult bean){
			
			
		}
		
	}
	
}