using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vms.store.service{
	
	
	
	public class StoreWarehouseRelUpdateParamHelper : TBeanSerializer<StoreWarehouseRelUpdateParam>
	{
		
		public static StoreWarehouseRelUpdateParamHelper OBJ = new StoreWarehouseRelUpdateParamHelper();
		
		public static StoreWarehouseRelUpdateParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(StoreWarehouseRelUpdateParam structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("storeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStoreName(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("priority".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetPriority(value);
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
		
		
		public void Write(StoreWarehouseRelUpdateParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteString(structs.GetVendor_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetStoreName() != null) {
				
				oprot.WriteFieldBegin("storeName");
				oprot.WriteString(structs.GetStoreName());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("storeName can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetPriority() != null) {
				
				oprot.WriteFieldBegin("priority");
				oprot.WriteI32((int)structs.GetPriority()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("priority can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(StoreWarehouseRelUpdateParam bean){
			
			
		}
		
	}
	
}