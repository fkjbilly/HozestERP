using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.normal{
	
	
	
	public class AvailableInventoryRequestHelper : TBeanSerializer<AvailableInventoryRequest>
	{
		
		public static AvailableInventoryRequestHelper OBJ = new AvailableInventoryRequestHelper();
		
		public static AvailableInventoryRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AvailableInventoryRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("batch_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetBatch_no(value);
					}
					
					
					
					
					
					if ("warehouse_supplier".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse_supplier(value);
					}
					
					
					
					
					
					if ("availableInventoryList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.normal.AvailableInventory> value;
						
						value = new List<vipapis.normal.AvailableInventory>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.normal.AvailableInventory elem1;
								
								elem1 = new vipapis.normal.AvailableInventory();
								vipapis.normal.AvailableInventoryHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetAvailableInventoryList(value);
					}
					
					
					
					
					
					if ("cooperation_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCooperation_no(value);
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
		
		
		public void Write(AvailableInventoryRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetBatch_no() != null) {
				
				oprot.WriteFieldBegin("batch_no");
				oprot.WriteI32((int)structs.GetBatch_no()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batch_no can not be null!");
			}
			
			
			if(structs.GetWarehouse_supplier() != null) {
				
				oprot.WriteFieldBegin("warehouse_supplier");
				oprot.WriteString(structs.GetWarehouse_supplier());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAvailableInventoryList() != null) {
				
				oprot.WriteFieldBegin("availableInventoryList");
				
				oprot.WriteListBegin();
				foreach(vipapis.normal.AvailableInventory _item0 in structs.GetAvailableInventoryList()){
					
					
					vipapis.normal.AvailableInventoryHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("availableInventoryList can not be null!");
			}
			
			
			if(structs.GetCooperation_no() != null) {
				
				oprot.WriteFieldBegin("cooperation_no");
				oprot.WriteI32((int)structs.GetCooperation_no()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AvailableInventoryRequest bean){
			
			
		}
		
	}
	
}