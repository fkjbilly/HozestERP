using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.schedule{
	
	
	
	public class VendorScheduleHelper : TBeanSerializer<VendorSchedule>
	{
		
		public static VendorScheduleHelper OBJ = new VendorScheduleHelper();
		
		public static VendorScheduleHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorSchedule structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("cooperationNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCooperationNo(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("businessType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetBusinessType(value);
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
		
		
		public void Write(VendorSchedule structs, Protocol oprot){
			
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
			
			
			if(structs.GetCooperationNo() != null) {
				
				oprot.WriteFieldBegin("cooperationNo");
				oprot.WriteI64((long)structs.GetCooperationNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetBusinessType() != null) {
				
				oprot.WriteFieldBegin("businessType");
				oprot.WriteI32((int)structs.GetBusinessType()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("businessType can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VendorSchedule bean){
			
			
		}
		
	}
	
}