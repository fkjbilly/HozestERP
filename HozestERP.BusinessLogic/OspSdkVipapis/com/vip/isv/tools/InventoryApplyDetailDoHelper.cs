using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class InventoryApplyDetailDoHelper : TBeanSerializer<InventoryApplyDetailDo>
	{
		
		public static InventoryApplyDetailDoHelper OBJ = new InventoryApplyDetailDoHelper();
		
		public static InventoryApplyDetailDoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InventoryApplyDetailDo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("batchNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatchNo(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetQuantity(value);
					}
					
					
					
					
					
					if ("cartQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCartQuantity(value);
					}
					
					
					
					
					
					if ("sellableQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSellableQuantity(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("message".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMessage(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("updateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetUpdateTime(value);
					}
					
					
					
					
					
					if ("isIncrement".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsIncrement(value);
					}
					
					
					
					
					
					if ("realQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetRealQuantity(value);
					}
					
					
					
					
					
					if ("cooperationNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCooperationNo(value);
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
		
		
		public void Write(InventoryApplyDetailDo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBatchNo() != null) {
				
				oprot.WriteFieldBegin("batchNo");
				oprot.WriteString(structs.GetBatchNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQuantity() != null) {
				
				oprot.WriteFieldBegin("quantity");
				oprot.WriteI32((int)structs.GetQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCartQuantity() != null) {
				
				oprot.WriteFieldBegin("cartQuantity");
				oprot.WriteI32((int)structs.GetCartQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSellableQuantity() != null) {
				
				oprot.WriteFieldBegin("sellableQuantity");
				oprot.WriteI32((int)structs.GetSellableQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteI32((int)structs.GetStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMessage() != null) {
				
				oprot.WriteFieldBegin("message");
				oprot.WriteString(structs.GetMessage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetCreateTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdateTime() != null) {
				
				oprot.WriteFieldBegin("updateTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetUpdateTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsIncrement() != null) {
				
				oprot.WriteFieldBegin("isIncrement");
				oprot.WriteI32((int)structs.GetIsIncrement()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRealQuantity() != null) {
				
				oprot.WriteFieldBegin("realQuantity");
				oprot.WriteI32((int)structs.GetRealQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCooperationNo() != null) {
				
				oprot.WriteFieldBegin("cooperationNo");
				oprot.WriteI32((int)structs.GetCooperationNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(InventoryApplyDetailDo bean){
			
			
		}
		
	}
	
}