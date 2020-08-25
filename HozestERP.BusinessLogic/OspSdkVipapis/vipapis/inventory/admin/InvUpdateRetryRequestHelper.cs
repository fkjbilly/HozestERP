using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.inventory.admin{
	
	
	
	public class InvUpdateRetryRequestHelper : TBeanSerializer<InvUpdateRetryRequest>
	{
		
		public static InvUpdateRetryRequestHelper OBJ = new InvUpdateRetryRequestHelper();
		
		public static InvUpdateRetryRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InvUpdateRetryRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransId(value);
					}
					
					
					
					
					
					if ("batchNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatchNo(value);
					}
					
					
					
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("cooperationNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
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
					
					
					
					
					
					if ("vendorQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorQuantity(value);
					}
					
					
					
					
					
					if ("cartQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetCartQuantity(value);
					}
					
					
					
					
					
					if ("unpaidQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetUnpaidQuantity(value);
					}
					
					
					
					
					
					if ("sellableQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetSellableQuantity(value);
					}
					
					
					
					
					
					if ("isPos".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetIsPos(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("retryTimes".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetRetryTimes(value);
					}
					
					
					
					
					
					if ("areaWarehouseId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAreaWarehouseId(value);
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
		
		
		public void Write(InvUpdateRetryRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransId() != null) {
				
				oprot.WriteFieldBegin("transId");
				oprot.WriteString(structs.GetTransId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transId can not be null!");
			}
			
			
			if(structs.GetBatchNo() != null) {
				
				oprot.WriteFieldBegin("batchNo");
				oprot.WriteString(structs.GetBatchNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batchNo can not be null!");
			}
			
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendorId can not be null!");
			}
			
			
			if(structs.GetCooperationNo() != null) {
				
				oprot.WriteFieldBegin("cooperationNo");
				oprot.WriteI32((int)structs.GetCooperationNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cooperationNo can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("barcode can not be null!");
			}
			
			
			if(structs.GetVendorQuantity() != null) {
				
				oprot.WriteFieldBegin("vendorQuantity");
				oprot.WriteI32((int)structs.GetVendorQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendorQuantity can not be null!");
			}
			
			
			if(structs.GetCartQuantity() != null) {
				
				oprot.WriteFieldBegin("cartQuantity");
				oprot.WriteI32((int)structs.GetCartQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cartQuantity can not be null!");
			}
			
			
			if(structs.GetUnpaidQuantity() != null) {
				
				oprot.WriteFieldBegin("unpaidQuantity");
				oprot.WriteI32((int)structs.GetUnpaidQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("unpaidQuantity can not be null!");
			}
			
			
			if(structs.GetSellableQuantity() != null) {
				
				oprot.WriteFieldBegin("sellableQuantity");
				oprot.WriteI32((int)structs.GetSellableQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sellableQuantity can not be null!");
			}
			
			
			if(structs.GetIsPos() != null) {
				
				oprot.WriteFieldBegin("isPos");
				oprot.WriteI32((int)structs.GetIsPos()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("isPos can not be null!");
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64((long)structs.GetCreateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("createTime can not be null!");
			}
			
			
			if(structs.GetRetryTimes() != null) {
				
				oprot.WriteFieldBegin("retryTimes");
				oprot.WriteI32((int)structs.GetRetryTimes()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("retryTimes can not be null!");
			}
			
			
			if(structs.GetAreaWarehouseId() != null) {
				
				oprot.WriteFieldBegin("areaWarehouseId");
				oprot.WriteString(structs.GetAreaWarehouseId());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(InvUpdateRetryRequest bean){
			
			
		}
		
	}
	
}