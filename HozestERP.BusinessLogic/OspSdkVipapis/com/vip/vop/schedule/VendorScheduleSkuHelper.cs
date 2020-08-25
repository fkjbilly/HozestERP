using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.schedule{
	
	
	
	public class VendorScheduleSkuHelper : TBeanSerializer<VendorScheduleSku>
	{
		
		public static VendorScheduleSkuHelper OBJ = new VendorScheduleSkuHelper();
		
		public static VendorScheduleSkuHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorScheduleSku structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("scheduleId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetScheduleId(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("vendorSkuId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetVendorSkuId(value);
					}
					
					
					
					
					
					if ("stockPushStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetStockPushStatus(value);
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
		
		
		public void Write(VendorScheduleSku structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI64((long)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendorId can not be null!");
			}
			
			
			if(structs.GetScheduleId() != null) {
				
				oprot.WriteFieldBegin("scheduleId");
				oprot.WriteI64((long)structs.GetScheduleId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("scheduleId can not be null!");
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("barcode can not be null!");
			}
			
			
			if(structs.GetVendorSkuId() != null) {
				
				oprot.WriteFieldBegin("vendorSkuId");
				oprot.WriteI64((long)structs.GetVendorSkuId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendorSkuId can not be null!");
			}
			
			
			if(structs.GetStockPushStatus() != null) {
				
				oprot.WriteFieldBegin("stockPushStatus");
				oprot.WriteI32((int)structs.GetStockPushStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("stockPushStatus can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VendorScheduleSku bean){
			
			
		}
		
	}
	
}