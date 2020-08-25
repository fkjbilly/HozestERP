using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class updateVendorWarehouseAndVIPWarehouseMapHelper : TBeanSerializer<updateVendorWarehouseAndVIPWarehouseMap>
	{
		
		public static updateVendorWarehouseAndVIPWarehouseMapHelper OBJ = new updateVendorWarehouseAndVIPWarehouseMapHelper();
		
		public static updateVendorWarehouseAndVIPWarehouseMapHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(updateVendorWarehouseAndVIPWarehouseMap structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_warehouse_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_warehouse_id(value);
					}
					
					
					
					
					
					if ("vip_warehouse_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVip_warehouse_code(value);
					}
					
					
					
					
					
					if ("priority".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
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
		
		
		public void Write(updateVendorWarehouseAndVIPWarehouseMap structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_warehouse_id() != null) {
				
				oprot.WriteFieldBegin("vendor_warehouse_id");
				oprot.WriteString(structs.GetVendor_warehouse_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_warehouse_id can not be null!");
			}
			
			
			if(structs.GetVip_warehouse_code() != null) {
				
				oprot.WriteFieldBegin("vip_warehouse_code");
				oprot.WriteString(structs.GetVip_warehouse_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vip_warehouse_code can not be null!");
			}
			
			
			if(structs.GetPriority() != null) {
				
				oprot.WriteFieldBegin("priority");
				oprot.WriteString(structs.GetPriority());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("priority can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(updateVendorWarehouseAndVIPWarehouseMap bean){
			
			
		}
		
	}
	
}