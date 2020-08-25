using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class UpdateWarehouseInventoryHelper : TBeanSerializer<UpdateWarehouseInventory>
	{
		
		public static UpdateWarehouseInventoryHelper OBJ = new UpdateWarehouseInventoryHelper();
		
		public static UpdateWarehouseInventoryHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UpdateWarehouseInventory structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("store_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStore_name(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("inventory_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetInventory_qty(value);
					}
					
					
					
					
					
					if ("inventory_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetInventory_type(value);
					}
					
					
					
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_id(value);
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
		
		
		public void Write(UpdateWarehouseInventory structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetStore_name() != null) {
				
				oprot.WriteFieldBegin("store_name");
				oprot.WriteString(structs.GetStore_name());
				
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
			
			
			if(structs.GetInventory_qty() != null) {
				
				oprot.WriteFieldBegin("inventory_qty");
				oprot.WriteI32((int)structs.GetInventory_qty()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("inventory_qty can not be null!");
			}
			
			
			if(structs.GetInventory_type() != null) {
				
				oprot.WriteFieldBegin("inventory_type");
				oprot.WriteI32((int)structs.GetInventory_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("inventory_type can not be null!");
			}
			
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_id can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UpdateWarehouseInventory bean){
			
			
		}
		
	}
	
}