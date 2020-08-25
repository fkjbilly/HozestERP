using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class GetVendorScheduleFreezeStockHelper : BeanSerializer<GetVendorScheduleFreezeStock>
	{
		
		public static GetVendorScheduleFreezeStockHelper OBJ = new GetVendorScheduleFreezeStockHelper();
		
		public static GetVendorScheduleFreezeStockHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetVendorScheduleFreezeStock structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("schedule_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_id(value);
					}
					
					
					
					
					
					if ("start_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStart_date(value);
					}
					
					
					
					
					
					if ("end_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnd_date(value);
					}
					
					
					
					
					
					if ("page".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPage(value);
					}
					
					
					
					
					
					if ("limit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLimit(value);
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
		
		
		public void Write(GetVendorScheduleFreezeStock structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_warehouse_id() != null) {
				
				oprot.WriteFieldBegin("vendor_warehouse_id");
				oprot.WriteString(structs.GetVendor_warehouse_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSchedule_id() != null) {
				
				oprot.WriteFieldBegin("schedule_id");
				oprot.WriteString(structs.GetSchedule_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStart_date() != null) {
				
				oprot.WriteFieldBegin("start_date");
				oprot.WriteString(structs.GetStart_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnd_date() != null) {
				
				oprot.WriteFieldBegin("end_date");
				oprot.WriteString(structs.GetEnd_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPage() != null) {
				
				oprot.WriteFieldBegin("page");
				oprot.WriteI32((int)structs.GetPage()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLimit() != null) {
				
				oprot.WriteFieldBegin("limit");
				oprot.WriteI32((int)structs.GetLimit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetVendorScheduleFreezeStock bean){
			
			
		}
		
	}
	
}