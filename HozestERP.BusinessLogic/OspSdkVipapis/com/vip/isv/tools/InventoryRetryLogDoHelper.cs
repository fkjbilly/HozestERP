using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class InventoryRetryLogDoHelper : TBeanSerializer<InventoryRetryLogDo>
	{
		
		public static InventoryRetryLogDoHelper OBJ = new InventoryRetryLogDoHelper();
		
		public static InventoryRetryLogDoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InventoryRetryLogDo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("cooperationNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCooperationNo(value);
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
					
					
					
					
					
					if ("vendorRetryQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorRetryQuantity(value);
					}
					
					
					
					
					
					if ("realQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetRealQuantity(value);
					}
					
					
					
					
					
					if ("cartHold".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCartHold(value);
					}
					
					
					
					
					
					if ("sellableQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSellableQuantity(value);
					}
					
					
					
					
					
					if ("retryTimes".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetRetryTimes(value);
					}
					
					
					
					
					
					if ("errorMsg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErrorMsg(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetCreateTime(value);
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
		
		
		public void Write(InventoryRetryLogDo structs, Protocol oprot){
			
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
			
			
			if(structs.GetCooperationNo() != null) {
				
				oprot.WriteFieldBegin("cooperationNo");
				oprot.WriteI32((int)structs.GetCooperationNo()); 
				
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
			
			
			if(structs.GetVendorRetryQuantity() != null) {
				
				oprot.WriteFieldBegin("vendorRetryQuantity");
				oprot.WriteI32((int)structs.GetVendorRetryQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRealQuantity() != null) {
				
				oprot.WriteFieldBegin("realQuantity");
				oprot.WriteI32((int)structs.GetRealQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCartHold() != null) {
				
				oprot.WriteFieldBegin("cartHold");
				oprot.WriteI32((int)structs.GetCartHold()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSellableQuantity() != null) {
				
				oprot.WriteFieldBegin("sellableQuantity");
				oprot.WriteI32((int)structs.GetSellableQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRetryTimes() != null) {
				
				oprot.WriteFieldBegin("retryTimes");
				oprot.WriteI32((int)structs.GetRetryTimes()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetErrorMsg() != null) {
				
				oprot.WriteFieldBegin("errorMsg");
				oprot.WriteString(structs.GetErrorMsg());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetCreateTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(InventoryRetryLogDo bean){
			
			
		}
		
	}
	
}