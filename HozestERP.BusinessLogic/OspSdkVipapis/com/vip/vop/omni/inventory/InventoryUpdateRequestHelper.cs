using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.omni.inventory{
	
	
	
	public class InventoryUpdateRequestHelper : TBeanSerializer<InventoryUpdateRequest>
	{
		
		public static InventoryUpdateRequestHelper OBJ = new InventoryUpdateRequestHelper();
		
		public static InventoryUpdateRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InventoryUpdateRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("batch_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatch_no(value);
					}
					
					
					
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("cooperation_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetCooperation_no(value);
					}
					
					
					
					
					
					if ("area_codes".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetArea_codes(value);
					}
					
					
					
					
					
					if ("store_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStore_sn(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetQuantity(value);
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
		
		
		public void Write(InventoryUpdateRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBatch_no() != null) {
				
				oprot.WriteFieldBegin("batch_no");
				oprot.WriteString(structs.GetBatch_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batch_no can not be null!");
			}
			
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetCooperation_no() != null) {
				
				oprot.WriteFieldBegin("cooperation_no");
				oprot.WriteI32((int)structs.GetCooperation_no()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cooperation_no can not be null!");
			}
			
			
			if(structs.GetArea_codes() != null) {
				
				oprot.WriteFieldBegin("area_codes");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetArea_codes()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStore_sn() != null) {
				
				oprot.WriteFieldBegin("store_sn");
				oprot.WriteString(structs.GetStore_sn());
				
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
			
			
			if(structs.GetQuantity() != null) {
				
				oprot.WriteFieldBegin("quantity");
				oprot.WriteI32((int)structs.GetQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("quantity can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(InventoryUpdateRequest bean){
			
			
		}
		
	}
	
}